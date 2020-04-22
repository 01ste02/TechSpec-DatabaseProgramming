use School;

DROP TABLE IF EXISTS simplecomments;
DROP TABLE IF EXISTS commentors;
CREATE TABLE commentors (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    email varchar(30) NOT NULL
);

CREATE TABLE simplecomments (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    commentorid int(11) NOT NULL,
    comment text NOT NULL,
    reg_date timestamp,
    rating int(11) NOT NULL,
    FOREIGN KEY (commentorid) REFERENCES commentors(id)
);

INSERT INTO commentors (name, email)
SELECT DISTINCT name, email
FROM ratedcomments;

INSERT INTO simplecomments (commentorid, comment, reg_date, rating)
SELECT commentors.id, ratedcomments.comment, ratedcomments.reg_date, ratedcomments.rating FROM commentors, ratedcomments WHERE commentors.name = ratedcomments.name && commentors.email = ratedcomments.email;