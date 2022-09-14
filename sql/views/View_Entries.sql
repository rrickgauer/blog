CREATE VIEW View_Entries
AS
  SELECT e.id                                 AS id,
         DATE(e.date)                         AS date,
         DATE_FORMAT(e.date, '%M %D, %Y')     AS date_formatted,
         e.title                              AS title,
         e.link                               AS source_link,
         CONCAT('entries.php?entryID=', e.id) AS page_link,
         e.topic_id                           AS topic_id,
         t.name                               AS topic_name
  FROM   Entries e
         LEFT JOIN Topics t
                ON t.id = e.topic_id
  GROUP  BY e.id;