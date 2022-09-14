"""
********************************************************************************************

This is the entry point for running an application.
    - Create a new flask application object
    - Register all the blue prints

********************************************************************************************
"""

from __future__ import annotations
import flask
from .routes import bp_routes
import pymysql
from . import config
from .utilities import get_config, CustomJSONEncoder

#------------------------------------------------------
# Register the blueprints
#------------------------------------------------------
def _register_blueprints(flask_app: flask.Flask):
    flask_app.register_blueprint(bp_routes, url_prefix='/')

# ------------------------------------------------------
# Configure the application
# ------------------------------------------------------
def _set_configurations(flask_app: flask.Flask, selected_config: config.ConfigBase):
    flask_app.config.from_object(selected_config)

    flask_app.json_encoder = CustomJSONEncoder
    
    pymysql.credentials.USER     = selected_config.DB_USER
    pymysql.credentials.PASSWORD = selected_config.DB_PASSWORD
    pymysql.credentials.DATABASE = selected_config.DB_NAME
    pymysql.credentials.HOST     = selected_config.DB_HOST


# Main logic
app = flask.Flask(__name__)
_register_blueprints(app)

current_config = get_config(app)
_set_configurations(app, current_config)


