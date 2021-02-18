cd /d %~dp0
@echo off

inject.exe -d -k divahook.dll diva.exe --launch

echo.
echo Game processes have terminated
pause