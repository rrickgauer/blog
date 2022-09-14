CREATE TABLE `Entries` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `title` varchar(100) NOT NULL,
  `link` varchar(200) NOT NULL,
  `file_name` varchar(150) DEFAULT NULL,
  `topic_id` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`),
  KEY `topic_id` (`topic_id`),
  CONSTRAINT `Entries_ibfk_1` FOREIGN KEY (`topic_id`) REFERENCES `Topics` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
