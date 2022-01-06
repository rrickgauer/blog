from __future__ import annotations
from dataclasses import dataclass
import printing

@dataclass
class Entry:
    id: int=None
    title: str=None
    link: str=None
    topic_id: int=None

#----------------------------------------------------------
# Prompt the user for the required values for a new entry:
#   - title
#   - link
#   - topic id
#----------------------------------------------------------
def getNewEntry(topics: list[dict]) -> Entry:
    entry = Entry(
        title = input('Title: '),
        link = input('Link: '),
    )

    printing.listDict(topics)

    entry.topic_id = int(input('Topic ID: '))

    return entry
