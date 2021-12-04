@echo off
set root=%CD%
set clientOut="client\client\bin\x64\Release"
set installerOut="installer\Output"


:: Build client
nuget restore "client"
msbuild "client\client.sln" /property:Configuration=Release /property:Platform=x64

cd %clientOut%
del LICENSE-InputHelper.txt
ren LICENSE.txt LICENSE-InputHelper.txt
tar -a -cf portable.zip screen.exe InputHelper.dll ScreenRecorderLib.dll LICENSE-InputHelper.txt
cd %root%


:: Build installer
iscc installer\installer.iss


:: Move artifacts to out dir
mkdir out
move %clientOut%\portable.zip out\
move %installerOut%\setup.exe out\