
import blog.repository.entries as entries_repo

def get_entries() -> list[dict]:
    entries = entries_repo.get_entries().data    
    return entries
