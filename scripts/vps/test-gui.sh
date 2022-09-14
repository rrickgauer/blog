#!/bin/bash

IP_ADDRESS='104.225.208.163'

echo 'Starting up front-end TESTING server...'

cd /var/www/blog/src

mod_wsgi-express start-server \
--user www-data  \
--group www-data  \
--server-name blog.ryanrickgauer.com  \
--port 5050   \
--access-log  \
--log-level info   \
--host $IP_ADDRESS \
--log-to-terminal \
blog.wsgi


