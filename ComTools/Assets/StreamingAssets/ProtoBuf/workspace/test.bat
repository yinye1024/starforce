@echo off
chcp 65001

setlocal EnableDelayedExpansion

set proto_dir=.\protos
set gen_dir=.\gen

for %%i in (%proto_dir%\*.proto) do (
   
	protoc --csharp_out=%gen_dir% %%i
    rem 从这里往下都是注释，可忽略
    echo From %%i To %%~ni.cs Successfully!  
)

pause

