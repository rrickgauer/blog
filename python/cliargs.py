from __future__ import annotations
import argparse
from db_manager import DbCredentials

class CliArgs:

    #----------------------------------------------------------
    # Constructor
    #----------------------------------------------------------
    def __init__(self):
        self._parser = argparse.ArgumentParser(description="View a MySQL Database Schema on the command line.")

        self._host = None
        self._user = None
        self._password = None
        self._database = None

        self._addArguments()
        self._args = self._parser.parse_args()

    #--------------------------------------------------
    # Add all the arguments to the parser
    #--------------------------------------------------
    def _addArguments(self):
        self._parser.add_argument('--host', required=True)
        self._parser.add_argument('--user', required=True)
        self._parser.add_argument('--password', required=True)
        self._parser.add_argument('--database', required=True)


    #--------------------------------------------------
    # Transform the parsed cli args into a DbCredentials object 
    #--------------------------------------------------
    def getCredentials(self) -> DbCredentials:

        credentials = DbCredentials(
            host     = self._args.host,
            user     = self._args.user,
            password = self._args.password,
            database = self._args.database,
        )

        return credentials
