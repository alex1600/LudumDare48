set PP_DIR="./../../../../LudumDare48_clone\"

@echo off
setlocal EnableExtensions

title Builder

set "App[1]=Win64"
set "App[2]=WebGL"

set "Message="
:Menu
cls
echo.%Message%
echo.
echo. Builder Menu
echo.
set "x=0"
:MenuLoop

set /a "x+=1"
if defined App[%x%] (
    call echo   %x%. %%App[%x%]%%
    goto MenuLoop
)
echo.

:Prompt
set "Input="
set /p "Input=Select what to build:"

:: Validate Input [Remove Special Characters]
if not defined Input goto Prompt
set "Input=%Input:"=%"
set "Input=%Input:^=%"
set "Input=%Input:<=%"
set "Input=%Input:>=%"
set "Input=%Input:&=%"
set "Input=%Input:|=%"
set "Input=%Input:(=%"
set "Input=%Input:)=%"

:: Equals are not allowed in variable names
set "Input=%Input:^==%"
call :Validate %Input%

call :Process %Input%
goto End

:Validate
set "Next=%2"
if not defined App[%1] (
    set "Message=Invalid Input: %1"
    goto Menu
)
if defined Next shift & goto Validate
goto :eof


:Process
set "Next=%2"
call set "App=%%App[%1]%%"


if %App% EQU Win64 unity.exe -quit -batchmode -projectPath %PP_DIR% -executeMethod Builder.BuildWin -logfile "editor.log"

if %App% EQU WebGL unity.exe -quit -batchmode -projectPath %PP_DIR% -executeMethod Builder.BuildWebGL -logfile "editor.log"

:: Prevent the command from being processed twice if listed twice.
set "App[%1]="
if defined Next shift & goto Process
goto :eof

:End
endlocal
echo. Done
pause >nul