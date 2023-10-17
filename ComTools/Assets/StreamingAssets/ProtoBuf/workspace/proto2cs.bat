@echo off
chcp 65001
"./protogen/bin/protogen" -i:./protos/avatar.proto -o:./gen/avatar.cs
"./protogen/bin/protogen" -i:./protos/comm.proto -o:./gen/comm.cs
"./protogen/bin/protogen" -i:./protos/friend.proto -o:./gen/friend.cs
"./protogen/bin/protogen" -i:./protos/gm.proto -o:./gen/gm.cs
"./protogen/bin/protogen" -i:./protos/login.proto -o:./gen/login.cs
"./protogen/bin/protogen" -i:./protos/mail.proto -o:./gen/mail.cs
"./protogen/bin/protogen" -i:./protos/misc.proto -o:./gen/misc.cs
"./protogen/bin/protogen" -i:./protos/prop.proto -o:./gen/prop.cs
"./protogen/bin/protogen" -i:./protos/res.proto -o:./gen/res.cs
pause
