import flask
from blog.services.entries import get_entries
from blog.services.entries import get_entry
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


#------------------------------------------------------
# Entry page
# blog.ryanrickgauer.com/entries/:entry_id
#------------------------------------------------------
@bp_routes.route('entries/<int:entry_id>')
def entry_page(entry_id: int):
    
    entry = get_entry(entry_id)

    return flask.jsonify(entry)
    
    return str(entry_id)