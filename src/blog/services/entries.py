
import blog.repository.entries as entries_repo
import requests


def get_entries() -> list[dict]:
    entries = entries_repo.get_entries().data    
    return entries


def get_entry(entry_id):
    entry = entries_repo.get_entry(entry_id).data

    md_file_link = entry.get('source_link', None)
    api_request = requests.get(md_file_link)
    if not api_request.ok:
        raise Exception(api_request.text)

    entry['content'] = api_request.text

    return entry