#!/bin/bash


cd /var/www/blog/scripts/vps

printf "\n\n\n"
echo "------------------------------------------------"
echo 'Pulling down latest code from GitHub...'
echo "------------------------------------------------"
printf "\n\n\n"

./.pull-latest.sh


printf "\n\n\n"
echo "------------------------------------------------"
echo 'Refresh python dependencies'
echo "------------------------------------------------"
printf "\n\n\n"

./.install-python-dependencies.sh


printf "\n\n\n"
echo "------------------------------------------------"
echo 'Compiling css'
echo "------------------------------------------------"
printf "\n\n\n"

./.compile-css.sh


printf "\n\n\n"
echo "------------------------------------------------"
echo 'Starting up gui server...'
echo "------------------------------------------------"
printf "\n\n\n"

./.start-wsgi.sh
