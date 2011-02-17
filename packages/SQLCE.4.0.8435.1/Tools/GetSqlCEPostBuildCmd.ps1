<<<<<<< HEAD
$solutionDir = [System.IO.Path]::GetDirectoryName($dte.Solution.FullName) + "\"
$path = $installPath.Replace($solutionDir, "`$(SolutionDir)")

$NativeAssembliesDir = Join-Path $path "NativeBinaries"
$x86 = $(Join-Path $NativeAssembliesDir "x86\*.dll")
$x64 = $(Join-Path $NativeAssembliesDir "amd64\*.dll")

$SqlCEPostBuildCmd = "
if not exist `"`$(TargetDir)x86`" md `"`$(TargetDir)x86`"
copy `"$x86`" `"`$(TargetDir)x86`"
if not exist `"`$(TargetDir)amd64`" md `"`$(TargetDir)amd64`"
=======
$solutionDir = [System.IO.Path]::GetDirectoryName($dte.Solution.FullName) + "\"
$path = $installPath.Replace($solutionDir, "`$(SolutionDir)")

$NativeAssembliesDir = Join-Path $path "NativeBinaries"
$x86 = $(Join-Path $NativeAssembliesDir "x86\*.dll")
$x64 = $(Join-Path $NativeAssembliesDir "amd64\*.dll")

$SqlCEPostBuildCmd = "
if not exist `"`$(TargetDir)x86`" md `"`$(TargetDir)x86`"
copy `"$x86`" `"`$(TargetDir)x86`"
if not exist `"`$(TargetDir)amd64`" md `"`$(TargetDir)amd64`"
>>>>>>> 533e217c3f1d85b049f3a787e7029c40a8dbb016
copy `"$x64`" `"`$(TargetDir)amd64"