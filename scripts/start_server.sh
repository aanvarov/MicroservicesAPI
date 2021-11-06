cd /var/www/html/MicroservicesAPI/MicroservicesAPI_10888/bin/Release/net5.0/publish
pm2 start "dotnet MicroservicesAPI_10888.dll" --name tmro
