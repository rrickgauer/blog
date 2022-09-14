#!/bin/bash

printf "\n\n\n"
echo "------------------------------------------------"
echo 'Pulling down latest code from GitHub...'
echo "------------------------------------------------"
printf "\n\n\n"

cd "/var/www/blog"
git pull



printf "\n\n\n"
echo "------------------------------------------------"
echo 'Refresh python dependencies'
echo "------------------------------------------------"
printf "\n\n\n"
/var/www/blog/src/.venv/bin/pip install -r /var/www/blog/src/requirements.txt --upgrade


printf "\n\n\n"
echo "------------------------------------------------"
echo 'Compiling css'
echo "------------------------------------------------"
printf "\n\n\n"

cd "/var/www/blog/src/blog/static/css"
sass style.scss style.css


IP_ADDRESS='104.225.208.163'

#---------------------------------------
# Start up the API
#---------------------------------------

printf "\n\n\n"
echo "------------------------------------------------"
echo 'Starting up gui server...'
echo "------------------------------------------------"
printf "\n\n\n"

cd /var/www/blog/src

mod_wsgi-express setup-server \
--user www-data  \
--group www-data  \
--server-name blog.ryanrickgauer.com  \
--port 5050   \
--access-log  \
--log-level info   \
--server-root /etc/blog.ryanrickgauer.com \
--host $IP_ADDRESS \
--setup-only \
blog.wsgi


# restart the apache server

printf "\n\n\n"
echo "------------------------------------------------"
echo 'Restarting the Apache service...'
echo "------------------------------------------------"
printf "\n\n\n"

/etc/blog.ryanrickgauer.com/apachectl restart