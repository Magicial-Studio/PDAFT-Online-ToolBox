if %Configuration%==Release (
:: Merge dlls
%ILMergeConsolePath% %TargetDir%PDAFT_Online_ToolBox.exe ^
/out:%TargetDir%PDAFT_Online_ToolBoxMerged.exe ^
%TargetDir%INIFileParser.dll

DEL /f %TargetDir%*.dll >NUL 2>&1
MOVE /Y %TargetDir%PDAFT_Online_ToolBoxMerged.exe %TargetDir%PDAFT_Online_ToolBox.exe >NUL
:: Delete useless files
DEL /f %TargetDir%*.config >NUL 2>&1
DEL /f %TargetDir%*.pdb >NUL 2>&1
DEL /f %TargetDir%*.xml >NUL 2>&1
)

