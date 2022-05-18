

import blog.repository.topics as topics_repo

def get_used_topics() -> list[dict]:
    return topics_repo.get_used().data
    

