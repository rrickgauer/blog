from datetime import datetime
import flask
from blog import config

def get_config(flask_app: flask.Flask) -> config.ConfigBase:
    """Get the appropriate configuration based on the given Flask application enviornment."""

    if flask_app.debug:
        return config.ConfigDev
    else:
        return config.ConfigProduction



def format_pretty_date(date_val: datetime) -> str:
    formatted_date = date_val.strftime('%B %d %Y')
    return formatted_date

