@echo off
set root=%CD%
set clientOut="client\client\bin\x64\Release"
set installerOut="installer\Output"

FOR /F "tokens=* USEBACKQ" %%g IN (`git describe --tags --abbrev^=0`) do (SET version=%%g)

:: Build client

Powershell.exe -executionpolicy remotesigned -File updateversion.ps1 %version%
nuget restore "client"
msbuild "client\client.sln" /property:Configuration=Release /property:Platform=x64

cd %clientOut%
del LICENSE-InputHelper.txt
ren LICENSE.txt LICENSE-InputHelper.txt
copy %root%\..\LICENSE LICENSE.txt
tar -a -cf portable.zip screen-sbs.exe InputHelper.dll ScreenRecorderLib.dll LICENSE.txt LICENSE-InputHelper.txt
cd %root%


:: Build installer
iscc installer\installer.iss


:: Move artifacts to out dir
mkdir out
move %clientOut%\portable.zip out\screen-sbs_%version%.zip
move %installerOut%\setup.exe out\setup_screen-sbs_%version%.exe