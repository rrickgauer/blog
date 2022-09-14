
cd "/var/www/blog"
git pull

# Refresh python dependencies
./var/www/blog/src/.venv/bin/pip install -r /var/www/blog/src/requirements.txt --upgrade


cd "/var/www/blog/src/blog/static/css"
sass style.scss style.css
