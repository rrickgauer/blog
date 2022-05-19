
import requests
import markdown
from jinja2.utils import markupsafe 
from mdx_gfm import GithubFlavoredMarkdownExtension
import blog.repository.entries as entries_repo

def get_entries() -> list[dict]:
    entries = entries_repo.get_entries().data
    return entries


def get_entry(entry_id):
    # get the entry data
    entry = entries_repo.get_entry(entry_id).data

    # fetch the content
    md_file_link = entry.get('source_link', None)
    raw_content = _fetch_raw_content(md_file_link)

    # translate the GitHub Flavored markdown content into html
    rendered_content = markdown.markdown(raw_content, extensions=[GithubFlavoredMarkdownExtension()])
    entry['content'] = markupsafe.Markup(rendered_content)

    return entry


def _fetch_raw_content(source_link) -> str:
    api_request = requests.get(source_link)
    
    if not api_request.ok:
        raise Exception(api_request.text) 

    return str(api_request.text)