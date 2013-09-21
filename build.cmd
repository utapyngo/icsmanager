for /D %%d in (%SystemRoot%\Microsoft.NET\Framework64\v4*) do set "msbuild=%%d\MSBuild.exe"
if not exist %msbuild% for /D %%d in (%SystemRoot%\Microsoft.NET\Framework\v4*) do set "msbuild=%%d\MSBuild.exe"
if not exist %msbuild% set "msbuild=%SystemRoot%\Microsoft.NET\Framework64\v3.5\MSBuild.exe"
if not exist %msbuild% set "msbuild=%SystemRoot%\Microsoft.NET\Framework\v3.5\MSBuild.exe"

%msbuild% /p:Configuration=Release;DebugType=None;OutDir=..\
