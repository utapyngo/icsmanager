@echo off

for /D %%d in (%SystemRoot%\Microsoft.NET\Framework\v4*) do set "msbuild=%%d\MSBuild.exe"
if not exist "%msbuild%" (
	echo .NET Framework v4.0 is required to build this program
	pause
	goto :EOF
)

@echo on
%msbuild% /p:Configuration=Release;DebugType=None;OutDir=..\
