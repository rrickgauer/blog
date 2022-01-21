# Proxying HTTP Requests with Apache 

This was a note I made for myself when I was deploying [wmiys.com](https://wmiys.com/login) to a VPS.

## Background

For mod_wsgi-express, you can only have 1 application listening on the same port. However, I needed both the api and the gui to both be listening on the same ports: 80 and 443. Additionally, I wanted them both to use HTTPS.

To resolve this, I needed to setup proxies using Apache.

Essentially, I needed apache to listen on ports 80/443 for each domain requests: **api.wmiys.com** and **wmiys.com**. Then, take those requests and rewrite the urls to use their ports that they are listening on with mod_wsgi.

How it works is basically Apache is listening for these urls at the top of the server. Once it receives one of those url requests, it takes it and appends the port to the url that mod_wsgi is listening for. Then, it sends the requests to mod_wsgi. *I think... This is probably completely wrong, but this is how I could make myself understand proxies.*

## Settings for mod_wsgi-express 

Since every mod_wsgi application needs its own port to listen on, I needed to define different port numbers for both the api and the front-end applications. I think of them like private/internal ports that only the server knows about. The outside world / incoming website requests only know about ports 80/443. 

I programmed the API to internally listen on port 81, and the gui to listen on 82. Now when a user goes to wmiys.com, Apache will secretly send that request to port 82.


## Apache Conf Files

Each application needed its own Apache configuration file and placed in `/etc/apache2/sites-available`:

### api.wmiys.com.conf

```apacheconf
<VirtualHost *:80>
    ServerName api.wmiys.com
    ProxyPass / http://api.wmiys.com:81/

    RewriteEngine On
    RewriteRule .* - [E=SERVER_PORT:%{SERVER_PORT},NE]

    RequestHeader set X-Forwarded-Port %{SERVER_PORT}e
</VirtualHost>

<VirtualHost *:443>
    ServerName api.wmiys.com

    SSLEngine On
    SSLCertificateFile /etc/letsencrypt/live/api.wmiys.com/fullchain.pem
    SSLCertificateKeyFile /etc/letsencrypt/live/api.wmiys.com/privkey.pem

    ProxyPass / http://api.wmiys.com:81/

    RequestHeader set X-Forwarded-Port 444
    RequestHeader set X-Forwarded-Scheme https
</VirtualHost>
```

### wmiys.com.conf

```apacheconf
<VirtualHost *:80>
    ServerName wmiys.com
    ProxyPass / http://wmiys.com:82/

    RewriteEngine On
    RewriteRule .* - [E=SERVER_PORT:%{SERVER_PORT},NE]

    RequestHeader set X-Forwarded-Port %{SERVER_PORT}e
</VirtualHost>

<VirtualHost *:443>
    ServerName wmiys.com

    SSLEngine On
    SSLCertificateFile /etc/letsencrypt/live/wmiys.com/fullchain.pem
    SSLCertificateKeyFile /etc/letsencrypt/live/wmiys.com/privkey.pem

    ProxyPass / http://wmiys.com:82/

    RequestHeader set X-Forwarded-Port 443
    RequestHeader set X-Forwarded-Scheme https
</VirtualHost>
```

## Further reading

http://blog.dscpl.com.au/2015/06/proxying-to-python-web-application.html
