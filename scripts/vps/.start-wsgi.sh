IP_ADDRESS='104.225.208.163'

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


/etc/blog.ryanrickgauer.com/apachectl restart