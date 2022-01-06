from dataclasses import dataclass
import mysql.connector
from mysql.connector.cursor import MySQLCursor
import json

#----------------------------------------------------------
# This class is used when a function executes a database command.
# It is a way to standardize the return result of an sql operation.
#----------------------------------------------------------
@dataclass
class DbOperationResult:
    successful: bool = False
    data = None
    error: str = None

@dataclass
class DbCredentials:
    host    : str = None
    user    : str = None
    password: str = None
    database: str = None


class DB:

    #----------------------------------------------------------
    # Constructor
    #----------------------------------------------------------
    def __init__(self, credentials: DbCredentials):
        self.connection = mysql.connector.MySQLConnection()
        self.credentials = credentials
    
    #----------------------------------------------------------
    # Connect to the database
    #----------------------------------------------------------
    def connect(self):

        self.connection = mysql.connector.connect(
            user     = self.credentials.user,
            host     = self.credentials.host,
            database = self.credentials.database,
            password = self.credentials.password,
        )
    
    #----------------------------------------------------------
    # Close the database connection
    #----------------------------------------------------------
    def close(self):
        self.connection.close()

    #----------------------------------------------------------
    # Commit the current transaction
    #----------------------------------------------------------
    def commit(self):
        self.connection.commit()
        
    #----------------------------------------------------------
    # Get a cursor from the database connection.
    #----------------------------------------------------------
    def getCursor(self, as_dict: bool=True) -> MySQLCursor:
        cursor = None

        if as_dict:
            cursor = self.connection.cursor(dictionary=True)
        else:
            cursor = self.connection.cursor(prepared=True)
        
        return cursor



#------------------------------------------------------
# Execute a select statement for mulitple records
#
# Args:
#   credentials: The user credentials
#   sql_stmt: sql statement to execute
#   parms: sql parms to pass to the engine
#   fetch_all: if true, fetch all records, otherwise fetch one
#------------------------------------------------------
def select(credentials: DbCredentials, sql_stmt: str, parms: tuple=None, fetch_all: bool=True) -> DbOperationResult:
    db_result = DbOperationResult(successful=False)
    db = DB(credentials)

    try:
        db.connect()
        cursor = db.getCursor(True)
        cursor.execute(sql_stmt, parms)

        if fetch_all:
            db_result.data = cursor.fetchall()
        else:
            db_result.data = cursor.fetchone()

        db_result.successful = True

    except Exception as e:
        db_result.error = str(e)
        db_result.data = None
    finally:
        db.close()
    
    return db_result


#------------------------------------------------------
# Execute an insert, update, or delete sql command
#
# Args:
#   credentials: The user credentials
#   sql_stmt: sql statement to execute
#   parms: sql parms to pass to the engine
#
# Returns a DbOperationResult:
#   sets the data field to the row count
#------------------------------------------------------
def modify(credentials: DbCredentials, sql_stmt: str, parms: tuple=None) -> DbOperationResult:
    db_result = DbOperationResult(successful=False)
    db = DB(credentials)

    try:
        db.connect()
        cursor = db.getCursor(False)
        
        cursor.execute(sql_stmt, parms)
        db.commit()
        
        db_result.successful = True
        db_result.data = cursor.rowcount
    except Exception as e:

        
        print(json.dumps((e.msg, e.errno, e.sqlstate), indent=4))

        db_result.error = str(e)
    finally:
        db.close()
    
    return db_result