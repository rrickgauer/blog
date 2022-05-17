

import pymysql.commands as sql_engine
from pymysql.structs import DbOperationResult

SQL_SELECT_ALL = 'SELECT * FROM View_Entries ORDER BY date DESC, title;'

def get_entries() -> DbOperationResult:
    return sql_engine.selectAll(SQL_SELECT_ALL)
