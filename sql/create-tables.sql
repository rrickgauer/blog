DROP TABLE IF EXISTS 
    Entries;

CREATE TABLE Entries (
    id     INT UNSIGNED NOT NULL UNIQUE auto_increment,
    `date` DATETIME NOT NULL,
    title  VARCHAR(100) NOT NULL,
    link   VARCHAR(200) NOT NULL,
    PRIMARY KEY (id)
) engine=innodb; 