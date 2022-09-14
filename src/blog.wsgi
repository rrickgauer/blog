python_home = '/var/www/blog/src/.venv'
import sys
import site

# Calculate path to site-packages directory.
python_version = '.'.join(map(str, sys.version_info[:2]))
site_packages = python_home + '/lib/python%s/site-packages' % python_version

# Add the site-packages directory.
site.addsitedir(site_packages)

from blog import app as application

