

import pymysql.commands as sql_engine
from pymysql.structs import DbOperationResult

SQL_SELECT_ALL = 'SELECT * FROM View_Entries ORDER BY date DESC, title;'
SQL_SELECT     = 'SELECT * FROM View_Entries e WHERE e.id = %s LIMIT 1;'

def get_entries() -> DbOperationResult:
    return sql_engine.selectAll(SQL_SELECT_ALL)


def get_entry(entry_id) -> DbOperationResult:
    parms = (entry_id,)
    return sql_engine.select(SQL_SELECT, parms)
