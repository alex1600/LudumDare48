::set PP_DIR="./../../../../Build/Win"
set OUTPUT_DIR="E:/1 - Works/Unity/LudumDare48/Build/WebGL.zip"
set FULL_DIR="E:/1 - Works/Unity/LudumDare48/Build/WebGL"

cd "E:/1 - Works/Unity/LudumDare48/Build/"
del /f "WebGL.zip"

7z a -tzip %OUTPUT_DIR% %FULL_DIR%

set USER=alexandre2bi
set GAME=ludumdare48
::set CHANNEL=win
set CHANNEL="HTML5 / Playable in browser"
butler push %OUTPUT_DIR% %USER%/"%GAME%":%CHANNEL%
pause