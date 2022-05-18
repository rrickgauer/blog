

import blog.repository.topics as topics_repo

def get_used_topics() -> list[dict]:
    topics = topics_repo.get_used().data
    return topics
    

