@echo off
set DESTDIR=%~dp1
set TROVEDIR=%~dp0

setlocal EnableDelayedExpansion
FOR /R "%TROVEDIR%extracted\blueprints" %%f IN (*.blueprint) DO ( 
  set SRC="%%f"
  set DEST=%%~nf
  set DESTFN="%TROVEDIR%qbexport\!DEST!.qb"
  echo !DESTFN!
  CALL "%TROVEDIR%devtool.bat" copyblueprint -generatemaps 1 !SRC! !DESTFN!
)
pause
