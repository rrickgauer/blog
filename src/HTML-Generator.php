<?php

class HTML {

    /*************************************************************
    Generate the HTML for a blog entry on the home page.

    The entry parm contains the fields:
        - id
        - date
        - title
        - source_link
        - page_link
        - topic_id
        - topic_name

    Parms:
        entry - entry record from the database
    
    Returns a string: the html
    **************************************************************/
    public static function getHomeListItem($entry) {
        $id = $entry['id'];
        $title = $entry['title'];
        $topicID = $entry['topic_id'];
        $topicName = $entry['topic_name'];

        // format the dates
        $date = new DateTime($entry['date']);
        $dateDisplay = $date->format('F jS, Y');
        $dateSort = $date->format('Ymd');

        $html = '
        <li class="list-group-item entry" data-date="%s" data-topic-id="%s">
            <div class="title">
                <a href="entries.php?entryID=%s">%s</a>
                <span class="badge badge-secondary ml-2">%s</span>
            </div>
            <div class="date">%s</div>
        </li>';

        return sprintf($html, $dateSort, $topicID, $id, $title, $topicName, $dateDisplay);
    }

    public static function getHomeTopicOption($topic) {
        $html = '<option value="' . $topic['id'] . '">';
        $html .= $topic['name'];
        $html .= '</option>';

        return $html;
    }


}




?>