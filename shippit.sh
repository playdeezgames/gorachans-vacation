rm -rf ./pub-linux
rm -rf ./pub-windows
rm -rf ./pub-mac
dotnet publish ./src/GorachansVacation/GorachansVacation.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/GorachansVacation/GorachansVacation.vbproj -o ./pub-windows -c Release --sc -r win-x64
dotnet publish ./src/GorachansVacation/GorachansVacation.vbproj -o ./pub-mac -c Release --sc -r osx-x64
butler push pub-windows thegrumpygamedev/gorachans-vacation-iv:windows
butler push pub-linux thegrumpygamedev/gorachans-vacation-iv:linux
butler push pub-mac thegrumpygamedev/gorachans-vacation-iv:mac
git add -A
git commit -m "shipped it!"