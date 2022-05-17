"""
********************************************************************************************

Url Prefix: /search/tickers

********************************************************************************************
"""

import flask

# module blueprint
bp_routes = flask.Blueprint('routes', __name__)

#------------------------------------------------------
# Home page
# blog.ryanrickgauer.com
#------------------------------------------------------
@bp_routes.route('')
def home_page():
    return flask.render_template('home.html')