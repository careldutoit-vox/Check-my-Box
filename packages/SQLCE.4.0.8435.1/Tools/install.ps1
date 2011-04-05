<<<<<<< HEAD
param($installPath, $toolsPath, $package, $project)

. (Join-Path $toolsPath "GetSqlCEPostBuildCmd.ps1")

# Get the current Post Build Event cmd
$currentPostBuildCmd = $project.Properties.Item("PostBuildEvent").Value

# Append our post build command if it's not already there
if (!$currentPostBuildCmd.Contains($SqlCEPostBuildCmd)) {
    $project.Properties.Item("PostBuildEvent").Value += $SqlCEPostBuildCmd
}
=======
param($installPath, $toolsPath, $package, $project)

. (Join-Path $toolsPath "GetSqlCEPostBuildCmd.ps1")

# Get the current Post Build Event cmd
$currentPostBuildCmd = $project.Properties.Item("PostBuildEvent").Value

# Append our post build command if it's not already there
if (!$currentPostBuildCmd.Contains($SqlCEPostBuildCmd)) {
    $project.Properties.Item("PostBuildEvent").Value += $SqlCEPostBuildCmd
}
>>>>>>> 533e217c3f1d85b049f3a787e7029c40a8dbb016
