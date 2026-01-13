#!/bin/bash

printf "\n\n\n"
echo "------------------------------------------------"
echo 'Restoring SQLite database changes'
echo "------------------------------------------------"
printf "\n\n\n"

cd /var/www/blog
git restore src/gui/Blog/Blog.Resources/sql/data.db

cd /var/www/blog/scripts/vps

printf "\n\n\n"
echo "------------------------------------------------"
echo 'Pulling down latest code from GitHub...'
echo "------------------------------------------------"
printf "\n\n\n"

git pull


printf "\n\n\n"
echo "------------------------------------------------"
echo 'Building dotnet Project'
echo "------------------------------------------------"
printf "\n\n\n"


cd /var/www/blog/src/gui/Blog
dotnet publish Blog.Gui -r linux-x64 --self-contained false -c Release



printf "\n\n\n"
echo "------------------------------------------------"
echo 'Compiling css'
echo "------------------------------------------------"
printf "\n\n\n"

cd /var/www/blog/src/gui/Blog/Blog.Gui/wwwroot/css
sass --quiet --no-source-map custom/style.scss dist/style.css


printf "\n\n\n"
echo "------------------------------------------------"
echo 'Starting up gui server...'
echo "------------------------------------------------"
printf "\n\n\n"


cd /var/www/blog/src/gui/Blog/Blog.Resources
chown -R www-data:www-data sql

cd /etc/systemd/system
systemctl daemon-reload
systemctl reload-or-restart blog.gui.service
service apache2 restart
