CREATE VIEW `View_Entries` AS
SELECT
    `e`.`id` AS `id`,
    cast(`e`.`date` AS date) AS `date`,
    date_format(`e`.`date`, '%M %D, %Y') AS `date_formatted`,
    `e`.`title` AS `title`,
    `e`.`link` AS `source_link`,
    `e`.`file_name` AS `file_name`,
    `e`.`topic_id` AS `topic_id`,
    `t`.`name` AS `topic_name`
FROM
    (
        `Entries` `e`
        LEFT JOIN `Topics` `t` ON((`t`.`id` = `e`.`topic_id`))
    )
GROUP BY
    `e`.`id`;