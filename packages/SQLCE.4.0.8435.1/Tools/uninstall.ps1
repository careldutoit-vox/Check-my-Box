<<<<<<< HEAD
param($installPath, $toolsPath, $package, $project)

. (Join-Path $toolsPath "GetSqlCEPostBuildCmd.ps1")

# Get the current Post Build Event cmd
$currentPostBuildCmd = $project.Properties.Item("PostBuildEvent").Value

# Remove our post build command from it (if it's there)
$project.Properties.Item("PostBuildEvent").Value = $currentPostBuildCmd.Replace($SqlCEPostBuildCmd, "")
=======
param($installPath, $toolsPath, $package, $project)

. (Join-Path $toolsPath "GetSqlCEPostBuildCmd.ps1")

# Get the current Post Build Event cmd
$currentPostBuildCmd = $project.Properties.Item("PostBuildEvent").Value

# Remove our post build command from it (if it's there)
$project.Properties.Item("PostBuildEvent").Value = $currentPostBuildCmd.Replace($SqlCEPostBuildCmd, "")
>>>>>>> 533e217c3f1d85b049f3a787e7029c40a8dbb016
