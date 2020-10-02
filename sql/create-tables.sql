DROP TABLE IF EXISTS 
    Entries;

CREATE TABLE Entries (
    id     INT UNSIGNED NOT NULL UNIQUE auto_increment,
    `date` DATETIME NOT NULL,
    title  VARCHAR(100) NOT NULL,
    link   VARCHAR(200) NOT NULL,
    PRIMARY KEY (id)
) engine=innodb; 


CREATE TABLE Users (
  id INT UNSIGNED NOT NULL UNIQUE AUTO_INCREMENT,
  email CHAR(200) NOT NULL UNIQUE,
  password VARCHAR(250) NOT NULL,
  PRIMARY KEY (id)
) engine = innodb;