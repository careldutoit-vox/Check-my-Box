param($installPath, $toolsPath, $package, $project)

$requiredAssemblies = Get-ChildItem $toolsPath -Filter *.dll

# Add a reference to the required assemblies
$requiredAssemblies | ForEach-Object { Add-Type -Path $_.FullName }

function global:Render-Template {
    [CmdletBinding()]
    param(        
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$Template,

        $Model,

        [string]$ProjectName,

        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$OutputPath,
        
        [switch]$Force
    )
    Process {
        $project = Get-Project $ProjectName	
        
        if(![System.IO.Path]::IsPathRooted($Template)) {
            $templateProjectItem = Get-ProjectItem $Template -Project $ProjectName
            if(!$templateProjectItem) {
                throw "Template '$Template' does not exist"
            }
            else {
                $Template = $templateProjectItem.Properties.Item("FullPath").Value
            }
        }

        # Create a dynamic model
        $dynamicModel = New-Object ScaffoldingFramework.DynamicViewModel
        
        # Setup defaults
        $dynamicModel["Namespace"] = $project.Properties.Item("DefaultNamespace").Value

        # Get the framework moniker from the project properties
        $frameworkMoniker = $project.Properties.Item("TargetFrameworkMoniker").Value
        
        # Get the framework name and version
        $frameworkName = New-Object System.Runtime.Versioning.FrameworkName($frameworkMoniker)
        $dynamicModel["FrameworkVersion"] = $frameworkName.Version

        # Populate the model
        $Model.Keys | %{ $dynamicModel[$_] = $Model[$_] }

        # Create the host
        $pshost = New-Object ScaffoldingFramework.DynamicTextTemplatingEngineHost($dynamicModel)
        $pshost.TemplateFile = $Template

        if(!(Test-Path $Template)) {
            throw "Template '$Template' does not exist"
        }

        # Loop over all the references and add them to the host in case the t4 needs them
        foreach($reference in $project.Object.References) {
            # If an assembly reference is unresolved (e.g. if user deletes the referenced assembly)
            # the VS project will list the path as an empty string, so we will filter it out
            if ($reference.Path) {                
                $pshost.Assemblies.Add($reference.Path);
            }
        }

        $content = [System.IO.File]::ReadAllText($pshost.TemplateFile)

        $engine = New-Object Microsoft.VisualStudio.TextTemplating.Engine
        $output = $engine.ProcessTemplate($content, $pshost) 

        if($pshost.Errors.HasErrors) {
            $pshost.Errors | Sort-Object Line | Sort-Object Column
        }
        else {
            # Get the project item for the output path
            $directory = [System.IO.Path]::GetDirectoryName($OutputPath)
            $projectItem = Get-ProjectFolder $directory -Create -Project $ProjectName

            # Get a temp file to store the output of the t4
            $fileName = [System.IO.Path]::GetFileName($OutputPath)
            $tempFile = Join-Path $env:temp $fileName

            # Write the output file
            $output | Out-File $tempFile
            
            # If the item exists then delete it
            try {
                $fileItem = $projectItem.Item("$fileName")
                if($Force) { 
                    $fileItem.Delete()
                }
                else {                
                    Write-Warning "$fileName already exists! Skipping..."
                    return
                }
            }
            catch {
                # Doesn't exist
            }            

            # Add the file to the project
            $projectItem.AddFromFileCopy($tempFile) | Out-Null

            # Remove the temp file
            Remove-Item $tempFile -Force

            "Added file '$OutputPath'"
        }
    }
}



$global:mvcScaffoldToolsPath = $toolsPath
$global:mvcViewTemplatesPath = Join-Path $env:VS100COMNTOOLS "..\IDE\ItemTemplates\CSharp\Web\MVC 3\CodeTemplates\AddView\CSHTML"

function global:Scaffold-Controller {
    [CmdletBinding()]
    param(        
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$ModelType,
        
        [string]$Name,
        
        [string]$ProjectName,

        [parameter(Mandatory = $true)]
        [string]$ContextType,

        [string]$Repository,
        
        [switch]$Force = $false,
        
        [switch]$NoViews = $false
    )
    Process {
        $project = Get-Project $ProjectName	

        $codeTemplates = Get-MvcCodeTemplates -PathToSearch "CodeTemplates\AddController" -Project $ProjectName

        if ($Name -eq "") {
            $Name = $ModelType
        }

        if ($Repository -ne "") {
            $templateFile = $codeTemplates["ControllerWithRepository.t4"]
        } else {
            $templateFile = $codeTemplates["ControllerWithContext.t4"]
        }

        $ClassName = $Name + "Controller"
        $OutputFileExtension = ".cs"
        
        $OutputPath = Join-Path Controllers $OutputPath$ClassName$OutputFileExtension

        Render-Template -Template $templateFile -Model @{ ModelType = $ModelType; ControllerName = $Name; Repository = $Repository; ContextName = $ContextType } -ProjectName $ProjectName -OutputPath $OutputPath -Force:$Force 
        if (!$NoViews) {
            Scaffold-Views -ModelType $ModelType -Force:$Force 
        }
   }
}


function global:Scaffold-Repository {
    [CmdletBinding()]
    param(        
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$ModelType,

        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$ContextType,
        
        [string]$ProjectName,
        
        [switch]$Force
    )
    Process {
        $project = Get-Project $ProjectName	

        $codeTemplates = Get-MvcCodeTemplates -PathToSearch "CodeTemplates\AddModel" -Project $ProjectName

        $templateFile = $codeTemplates["Repository.t4"]

        $Name = $ModelType + "Repository"
        $OutputFileExtension = ".cs"
        
        $OutputPath = Join-Path Models $OutputPath$Name$OutputFileExtension

        Render-Template -Template $templateFile -Model @{ ModelType = $ModelType; ContextType = $ContextType } -ProjectName $ProjectName -OutputPath $OutputPath -Force:$Force 
    }
}


function global:Scaffold-View {
    [CmdletBinding()]
    param(        
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$TemplateName,

        [string]$Name,

        [string]$OutputPath,

        [string]$ModelType,
        
        [string]$Project,

        [string]$OutputFileExtension = ".cshtml",

        [string]$AreaName,

        [switch]$ContentPage,

        [switch]$Partial,

        [string]$MasterPageFile,

        [string]$Namespace,
        
        [switch]$Force
    )
    Process {
        if(!$Name) {
            # Default name to the template name
            $Name = $TemplateName
        }

        $vsProject = Get-Project $Project	

        $viewTemplates = Get-MvcCodeTemplates -PathToSearch "CodeTemplates\AddView\CSHTML" -Project $ProjectName

        # Create an mvc template host wit the properties
        $mvcHost = New-Object MvcToolsShim.MvcExtendedHost
        $mvcHost.TemplateFile = $viewTemplates["$TemplateName.t4"]
        $mvcHost.ViewName = $Name        
        $mvcHost.AreaName = $AreaName
        $mvcHost.IsContentPage = $ContentPage
        $mvcHost.IsPartialView = $Partial
        $mvcHost.MasterPageFile = $MasterPageFile
        $mvcHost.Namespace = $Namespace
        $mvcHost.OutputFileExtension = $OutputFileExtension
        $mvcHost.ViewDataTypeName = $ModelType
        $mvcHost.AssemblyPath = New-Object "System.Collections.Generic.List``1[System.String]"

        if(!$mvcHost.TemplateFile) {
            throw "Unable to find template '$TemplateName'"
        }
        
        # Add required assemblies to the path
        $requiredAssemblies = Get-ChildItem $global:mvcScaffoldToolsPath -Filter *.dll
        $requiredAssemblies | ForEach-Object { 
            $mvcHost.AssemblyPath.Add($_.FullName) 
        }
        
        $vsProject = Get-Project $Project
        
        if($ModelType) {
            # Get the types in the project
            $modelTypes = [Microsoft.VisualStudio.Helpers.VsHelper]::GetAvailableTypes($vsProject, $false)

            $type = $modelTypes[$ModelType]

            # We didn't find an exact match so try to do a partial match
            if(!$type) {
                if(!$ModelType.Contains(".")) {
                    $matchType = ".$ModelType"
                }
                else {
                    $matchType = $ModelType
                }

                # Try to find all keys that end with this type name
                $matchingKeys = @($modelTypes.Keys | Where-Object { $_.EndsWith($matchType, [StringComparison]"OrdinalIgnoreCase") })
                
                if($matchingKeys.Length -eq 0) {
                    throw "Unknown type '$ModelType'"
                }

                if($matchingKeys.Length -gt 1) {
                    throw "Ambiguous type name '$ModelType', try specifying the full type name"
                }

                $type = $modelTypes[$matchingKeys[0]]
            }
                        
            # Try to find the type for the type name
            $mvcHost.ViewDataType = $type
            $mvcHost.ViewDataTypeName = $type.get_FullName()

            # Add the assembly path to the list of paths in the t4 references
            $mvcHost.AssemblyPath.Add($mvcHost.ViewDataType.Assembly.Location)
        }

        # Loop over all the references and add them to the host in case the t4 needs them
        foreach($reference in $vsProject.Object.References) {
            # If an assembly reference is unresolved (e.g. if user deletes the referenced assembly)
            # the VS project will list the path as an empty string, so we will filter it out
            if ($reference.Path) {                
                $mvcHost.AssemblyPath.Add($reference.Path);
            }
        }

        if(!$mvcHost.Namespace) {
            # No namespace specified so use the default namespace
            $mvcHost.Namespace = $vsProject.Properties.Item("DefaultNamespace").Value
        }

        # Get the framework moniker from the project properties
        $frameworkMoniker = $vsProject.Properties.Item("TargetFrameworkMoniker").Value
        
        # Get the framework name and version
        $frameworkName = New-Object System.Runtime.Versioning.FrameworkName($frameworkMoniker)
        $mvcHost.FrameworkVersion = $frameworkName.Version

        # Process the template
        $output = [MvcToolsShim.MvcExtendedHost]::ProcessTemplate($mvcHost)
        
        if($mvcHost.Errors.HasErrors) {
            $mvcHost.Errors | Sort-Object Line | Sort-Object Column
        }
        else {            
            if($ModelType) {
                $OutputPath = Join-Path $ModelType $OutputPath
            }

            $OutputPath = Join-Path Views $OutputPath

            if($AreaName) {
                # If an area name was specified, then use it
                $OutputPath = Join-Path (Join-Path Areas $AreaName) $OutputPath
            }

            # Get the project item for the output path
            $projectItem = Get-ProjectFolder $OutputPath -Create -Project $Project

            # Get a temp file to store the output of the t4
            $tempFile = Join-Path $env:temp $Name
            $tempFile += $OutputFileExtension

            # Write the output file
            $output | Out-File $tempFile
            
            # If the item exists then delete it
            try {
                $fileItem = $projectItem.Item("$Name$OutputFileExtension")
                if($Force) { 
                    $fileItem.Delete()
                }
                else {                
                    Write-Warning "$Name$OutputFileExtension already exists! Skipping..."
                    return
                }

            }
            catch {
                # Doesn't exist
            }            

            # Add the file to the project
            $projectItem.AddFromFileCopy($tempFile) | Out-Null

            # Remove the temp file
            Remove-Item $tempFile -Force

            $outPath = Join-Path $OutputPath $Name
            Write-Host "Added file '$outPath$OutputFileExtension'"                        
        }
    }
}

function global:Scaffold-Views {
    [CmdletBinding()]
    param (
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$ModelType,

        [string]$OutputPath,

        [string]$Project,

        [string]$AreaName,
        
        [switch]$Force
    )
    Process {        
        # TODO: Handle in project override
        # Default template names
        $templateNames = @("Details", "Edit", "Create", "Delete")

        # List->Index is an edge case...        
        # Add a view for each of these templates
        $templateNames | ForEach-Object { Scaffold-View -ContentPage -TemplateName $_ -OutputPath $OutputPath -ModelType $ModelType -AreaName $AreaName -Project $Project -Force:$Force}
        Scaffold-View -ContentPage -TemplateName List -Name Index -OutputPath $OutputPath -ModelType $ModelType -AreaName $AreaName -Project $Project -Force:$Force
    }
}

function global:Get-MvcCodeTemplates {
    [CmdletBinding()]
    param (                
        [string]$Project,
        
        [string]$PathToSearch
    )

    $templates = @{}

    #Get-ChildItem $global:mvcViewTemplatesPath | ForEach-Object { $templates[$_.Name] = $_.FullName }

    $codeTemplateFolder = Get-ProjectFolder -Path $PathToSearch -Project $Project
    if($codeTemplateFolder) {
        $codeTemplateFolder | ForEach-Object { $templates[$_.Name] = $_.Properties.Item("FullPath").Value }
    }

    return $templates
}


#########################
#   Utility functions   #
#########################
function global:Get-ProjectItem {
    [CmdletBinding()]
    param(
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$Path,

        [string]$Project
    )

    $folderPath = [System.IO.Path]::GetDirectoryName($Path)

    if($folderPath -eq "") {
        return $null
    }

    $fileName = [System.IO.Path]::GetFileName($Path)

    $container = Get-ProjectFolder -Path $folderPath -Project $Project

    if(!$container) {
        return $null
    }

    try {
        return $container.Item($fileName)
    }
    catch {
        return $null
    }
}

function global:Get-ProjectFolder {
    [CmdletBinding()]
    param(
        [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
        [string]$Path,

        [switch]$Create,

        [string]$Project
    )
    Process {        
        $vsProject = Get-Project $Project

        $pathParts = $path.Split('\')
        $projectItems = $vsProject.ProjectItems
        
        foreach($folder in $pathParts) {
            if(!$folder -or $folder -eq "") {
                continue
            }

            try {
                $subFolder = $projectItems.Item($folder)
            }
            catch {
                if(!$Create) {
                    return $null
                }

                # Get the full path property
                $property = $projectItems.Parent.Properties.Item("FullPath")

                # Get the full path of this folder
                $fullPath = Join-Path ($property.Value) $folder

                # Create the folder on disk first
                mkdir $fullPath | Out-Null

                $subFolder = $projectItems.AddFromDirectory($fullPath)
            }

            $projectItems = $subFolder.ProjectItems
        }

        # We don't want powershell to implicitly convert projectitems to an array
        ,$projectItems
    }
}