<?php

class HTML {

    public static function getHomeListItem($entry) {
        $id = $entry['id'];
        $title = $entry['title'];
        $date = $entry['date_formatted'];
        $dateSort = $entry['date_sort'];
        $topicID = $entry['topic_id'];
        $topicName = $entry['topic_name'];

        $html = "<li class=\"list-group-item entry\" data-date=\"$dateSort\">";
        $html .= "<div  class=\"title\">";
        $html .= "<a href=\"entries.php?entryID=$id\">$title</a>";
        $html .= "<span class=\"badge badge-secondary ml-2\">$topicName</span>";
        $html .= "</div>";
        $html .= "<div class=\"date\">$date</div>";
        $html .= '</li>';

        return $html;
    }


}




?>