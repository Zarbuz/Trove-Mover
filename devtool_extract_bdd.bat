@echo off
if not exist "%~dp0\Trove.exe" (
  echo. Error: Couldn't find Trove.exe
  echo. Please but this .bat script inside your Trove folder and retry!
  echo.&pause&goto:eof
)

echo. This script will extract all client files to the extracted folder.
echo. All current contents of the extracted folder will be overwritten.
echo. Please make backups of your modifications before continuing!
set /p test=Do you want to continue? (y/n)
if not "%test%" == "y" exit

rmdir /Q /S extracted
call:extractFolder "%~dp0"

echo.
echo. Completed extraction of the clientfiles to:
echo. "%~dp0"\extracted
echo.&pause&goto:eof

:extractFolder
for /D %%f in ("%~1*") do (
  if not "%%~nf" == "extracted" (
    if exist "%~2%%~nf\index.tfi" (
      echo. extracting %~2%%~nf
      "%~dp0Trove.exe" -tool extractarchive %~2%%~nf extracted\%~2%%~nf
    )
    call:extractFolder "%~1%%~nf\", "%~2%%~nf\"
  )
)
goto:eof