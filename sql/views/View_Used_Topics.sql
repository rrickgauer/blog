CREATE view View_Used_Topics
AS
  SELECT t.id                       AS id,
         t.name                     AS name,
         (SELECT COUNT(*)
          FROM   Entries e
          WHERE  e.topic_id = t.id) AS count
  FROM   Topics t
  WHERE  t.id IN (SELECT topic_id FROM Entries); 
