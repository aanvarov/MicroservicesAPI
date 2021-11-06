export NVM_DIR="$HOME/.nvm"
[ -s "$NVM_DIR/nvm.sh" ] && \. "$NVM_DIR/nvm.sh"
[ -s "$NVM_DIR/bash_completion" ] && \. "$NVM_DIR/bash_completion"
cd /var/www/html/MicroservicesAPI/MicroservicesAPI_10888/bin/Release/net5.0/publish
pm2 start "dotnet MicroservicesAPI_10888.dll" --name tmro