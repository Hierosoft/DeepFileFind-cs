@echo off
cd bin
SET CONFIGURATION_STRING=Release
IF NOT EXIST Windows%CONFIGURATION_STRING% echo "There is no build in bin/Windows%CONFIGURATION_STRING% yet. Open sln solution file in SharpDevelop 3.2, Build, Set configuration, %CONFIGURATION_STRING%, then Build, Build Solution"
IF NOT EXIST Windows%CONFIGURATION_STRING% GOTO END_ERROR
IF EXIST Windows%CONFIGURATION_STRING% cd Windows%CONFIGURATION_STRING%
DeepFileFind.exe 1>out.txt 2>err.txt
GOTO END_SILENT
:END_ERROR
pause
:END_SILENT