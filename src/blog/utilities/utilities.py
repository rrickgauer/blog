import flask
from blog import config

def get_config(flask_app: flask.Flask) -> config.ConfigBase:
    """Get the appropriate configuration based on the given Flask application enviornment."""

    if flask_app.env == "development":
        return config.ConfigDev
    else:
        return config.ConfigProduction



