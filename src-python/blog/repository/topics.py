import rymysql.commands as sql_engine
from rymysql.structs import DbOperationResult


SQL_SELECT_ALL = 'SELECT * FROM View_Used_Topics ORDER BY name;'

def get_used() -> DbOperationResult:
    return sql_engine.selectAll(SQL_SELECT_ALL)