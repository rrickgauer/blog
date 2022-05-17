"""
********************************************************************************************

Url Prefix: /search/tickers

********************************************************************************************
"""

import flask

from blog.services.entries import get_entries

# module blueprint
bp_routes = flask.Blueprint('routes', __name__)

#------------------------------------------------------
# Home page
# blog.ryanrickgauer.com
#------------------------------------------------------
@bp_routes.route('')
def home_page():
    data = dict(
        entries = get_entries(),
    )

    return flask.render_template('home.html', data=data)