# Trove-Mover
Trove Mover allow you to sort the thousands files created by dev tools from Trove

**Warning : The modified batch files will convert the entire blueprints ! **
* Go to : "C:\Program Files (x86)\Steam\steamapps\common\Trove\Games\Trove\Live"
* Copy batch files into this folder
* Launch devtool_extract_bdd.bat
* Create folder "qbexport"
* Run the modified "devtool_dungeon_blueprint_to_QB.bat" batch
* Wait, take a coffee, maybe 10 ...
* Now launch the main script, it will ask you the folder where is all .qb files (default : C:\Program Files (x86)\Steam\steamapps\common\Trove\Games\Trove\Live\qbexport)
* The script will :
  - Delete all "*_a.qb" files
  - Delete all "*_t.qb" files
  - Delete all "*_s.qb" files
  - Delete all "*.blueprint" files
  - Create folders and move files into them in function of their structure
* Done ! 
