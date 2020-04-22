use School;

DROP TABLE IF EXISTS teachercourses;
DROP TABLE IF EXISTS coursestudents;
DROP TABLE IF EXISTS teachers;
DROP TABLE IF EXISTS courses;
DROP TABLE IF EXISTS students;

CREATE TABLE teachers (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    code varchar(10) NOT NULL,
    email varchar(40) NOT NULL,
    phone varchar(16) NOT NULL
);

CREATE TABLE courses (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    code varchar(10) NOT NULL,
    size int(11) NOT NULL,
    start timestamp NOT NULL DEFAULT '2000-01-01 00:00:00',
    end timestamp NOT NULL DEFAULT '2000-01-01 00:00:00'
);

CREATE TABLE students (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    name varchar(50) NOT NULL,
    class varchar(10) NOT NULL,
    email varchar(40) NOT NULL,
    phone varchar(16)
);

CREATE TABLE teachercourses (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    teacher_id int(11) NOT NULL,
    course_id int(11) NOT NULL,
    FOREIGN KEY (teacher_id) REFERENCES teachers(id),
    FOREIGN KEY (course_id) REFERENCES courses(id)
);

CREATE TABLE coursestudents (
	id int(11) AUTO_INCREMENT PRIMARY KEY,
    courses_id int(11) NOT NULL,
    students_id int(11) NOT NULL,
    FOREIGN KEY (courses_id) REFERENCES courses(id),
    FOREIGN KEY (students_id) REFERENCES students(id)
);

INSERT INTO teachers (name, code, email, phone) VALUES
('Dennis Berling', 'BGD', 'dennis.berling@lund.se', '046-359 73 76'),
('Haris Drapic', 'DCH', 'haris.drapic@lund.se', '046-359 73 76'),
('Magnus Lilja', 'LAM', 'magnus.lilja@lund.se', '046-359 73 75'),
('Per Nyström', 'NMP', 'per.nystrom@lund.se', '046-359 73 47 '),
('Maria Petersson', 'PTM', 'maria.petersson@lund.se', '046-359 73 43');

INSERT INTO courses (name, code, size, start, end) VALUES
('Teknikspecialisering', '90TEK00SI', 16, '2019-08-19 00:00:00', '2020-06-12 00:00:00'),
('Dator- och nätverksteknik', '90DAC0', 30, '2019-08-19 00:00:00', '2020-06-12 00:00:00'),
('Nätverksprogrammering', '90FAK0E', 14, '2019-08-19 00:00:00', '2020-01-12 00:00:00'),
('Matematik 5', '92MAT05', 14, '2020-01-13 00:00:00', '2020-06-12 00:00:00'),
('Engelska 7', '90ENG07CA', 28, '2019-08-19 00:00:00', '2020-06-12 00:00:00');

INSERT INTO students (name, class, email, phone) VALUES
('Oskar Stenberg', 'TE17B', 'oskar@stenit.eu', '076-5995191'),
('Neo Sandström', 'TE17B', 'elev1@skola.lund.se', '000-0000203'),
('Christopher Voss', 'TE17D', 'elev2@skola.lund.se', '000-0000304'),
('Alexander Svanberg', 'TE17B', 'elev3@skola.lund.se', '000-0000405'),
('Tair Stenlund', 'TE17B', 'elev4@skola.lund.se', '000-0000506'),
('Philip Nielsen', 'TE17B', 'elev5@skola.lund.se', '000-0000607'),
('David Nilsson', 'TE17B', 'elev6@skola.lund.se', '000-0000708'),
('Simon Anderberg', 'SA17A', 'elev7@skola.lund.se', '000-0000809'),
('Victoria Malm', 'SA18B', 'elev8@skola.lund.se', '000-0000900'),
('Alice Jensen', 'NA17C', 'elev9@skola.lund.se', '000-0000001');

INSERT INTO teachercourses (teacher_id, course_id) VALUES
(1, 1),
(1, 2),
(2, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

INSERT INTO coursestudents (courses_id, students_id) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(2, 9),
(2, 10),
(3, 1),
(3, 2),
(3, 3),
(3, 4),
(3, 5),
(3, 6),
(3, 7),
(3, 8),
(3, 9),
(3, 10),
(4, 2),
(4, 1),
(4, 6),
(4, 3),
(4, 10),
(5, 8),
(5, 7),
(5, 3),
(5, 2),
(5, 4);

/*SELECT * FROM teachers WHERE teachers.id in (SELECT teachercourses.teacher_id FROM teachercourses WHERE teachercourses.course_id = (SELECT id FROM courses WHERE courses.name = 'Teknikspecialisering'));*/
/*SELECT * FROM students WHERE students.id in (SELECT coursestudents.students_id FROM coursestudents WHERE coursestudents.courses_id = (SELECT id FROM courses WHERE courses.name = 'Matematik 5'));*/
/*SELECT * FROM courses WHERE courses.id in (SELECT coursestudents.courses_id FROM coursestudents WHERE coursestudents.students_id = (SELECT id FROM students WHERE students.name = 'Oskar Stenberg'));*/