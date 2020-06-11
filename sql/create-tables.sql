DROP TABLE IF EXISTS 
    Entries;

CREATE TABLE Entries (
    id int unsigned not null unique auto_increment,
    `date` datetime not null,
    title varchar(100) not null,
    content text,
    primary key (id)
) ENGINE=InnoDB;