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

#------------------------------------------------------
# Register the blueprints
#------------------------------------------------------
def _registerBlueprints(flask_app: flask.Flask):
    flask_app.register_blueprint(bp_routes, url_prefix='/')

#------------------------------------------------------
# # Configure the application
# #------------------------------------------------------
# def _setConfigurations(flask_app: flask.Flask, selected_config: ConfigBase):
#     flask_app.config.from_object(selected_config)
#     flask_app.json_encoder = selected_config.JSON_ENCODER

#     pymysql.credentials.USER     = selected_config.DB_USER
#     pymysql.credentials.PASSWORD = selected_config.DB_PASSWORD
#     pymysql.credentials.DATABASE = selected_config.DB_NAME
#     pymysql.credentials.HOST     = selected_config.DB_HOST


# Main logic
app = flask.Flask(__name__)
_registerBlueprints(app)
