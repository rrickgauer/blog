from __future__ import annotations
import db_manager
from prompts import Entry

#----------------------------------------------------------
# Retrieve a list of topics from the database
#----------------------------------------------------------
def getTopics(db: db_manager.DB) -> list[dict]:
    db_cursor = db.getCursor(True)

    sql = 'SELECT t.name, t.id FROM Topics t ORDER BY name ASC'
    db_cursor.execute(sql)
    records = db_cursor.fetchall()

    return records


#----------------------------------------------------------
# Insert the given entry into the database
#----------------------------------------------------------
def insertEntry(db: db_manager.DB, entry: Entry):
    cursor = db.getCursor(False)

    sql = 'INSERT INTO Entries (title, link, topic_id) VALUES (%s, %s, %s)'
    
    parms = (
        entry.title,
        entry.link,
        entry.topic_id
    )
    
    cursor.execute(sql, parms)
    db.commit()




