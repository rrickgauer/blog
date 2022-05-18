import flask
from blog.services.entries import get_entries
from blog.services.topics import get_used_topics

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
        topics = get_used_topics(),
    )

    return flask.render_template('home.html', data=data)