create database PE_PRN_24SumB1
go
use  PE_PRN_24SumB1
go
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(255),
    email VARCHAR(255),
    password VARCHAR(255)
);

go
CREATE TABLE Instructors (
    instructor_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255),
    bio TEXT
);
go

CREATE TABLE Courses (
    course_id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(255),
    description TEXT,
    instructor_id INT,
    FOREIGN KEY (instructor_id) REFERENCES Instructors(instructor_id)
);

go
CREATE TABLE Enrollments (
    user_id INT,
    course_id INT,
    enrolled_date DATE,
    PRIMARY KEY (user_id, course_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);
go
CREATE TABLE CourseCategories (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    category_name VARCHAR(255)
);
go
CREATE TABLE CourseCategoryAssignments (
    course_id INT,
    category_id INT,
    PRIMARY KEY (course_id, category_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id),
    FOREIGN KEY (category_id) REFERENCES CourseCategories(category_id)
);
go
CREATE TABLE Reviews (
    review_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    course_id INT,
    review_text TEXT,
    rating INT,
    review_date DATE,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);

go
INSERT INTO Users (username, email, password) VALUES 
('john_doe', 'john@example.com', CONVERT(VARCHAR(32), HASHBYTES('MD5', 'password1'), 2)),
('jane_smith', 'jane@example.com', CONVERT(VARCHAR(32), HASHBYTES('MD5', 'password2'), 2)),
('alice_jones', 'alice@example.com', CONVERT(VARCHAR(32), HASHBYTES('MD5', 'password3'), 2)),
('bob_brown', 'bob@example.com', CONVERT(VARCHAR(32), HASHBYTES('MD5', 'password4'), 2)),
('charlie_white', 'charlie@example.com', CONVERT(VARCHAR(32), HASHBYTES('MD5', 'password5'), 2)),
('david_clark', 'david@example.com', CONVERT(VARCHAR(32), HASHBYTES('MD5', 'password6'), 2)),
('emma_wilson', 'emma@example.com', CONVERT(VARCHAR(32), HASHBYTES('MD5', 'password7'), 2));
go
INSERT INTO Instructors (name, bio) VALUES 
('Dr. Smith', 'Expert in data science'),
('Prof. Johnson', 'Specialist in machine learning'),
('Dr. Lee', 'Experienced in web development'),
('Prof. Patel', 'Leader in artificial intelligence'),
('Dr. Garcia', 'Researcher in cybersecurity'),
('Prof. Kim', 'Teacher in cloud computing'),
('Dr. Davis', 'Professor of software engineering');
go
INSERT INTO Courses (title, description, instructor_id) VALUES 
('Data Science 101', 'Introduction to Data Science', 1),
('Machine Learning Basics', 'Fundamentals of Machine Learning', 2),
('Web Development', 'Learn to build websites', 3),
('AI and You', 'Understanding Artificial Intelligence', 4),
('Cybersecurity Fundamentals', 'Basics of Cybersecurity', 5),
('Cloud Computing', 'Introduction to Cloud Computing', 6),
('Software Engineering', 'Principles of Software Engineering', 7);
go
INSERT INTO CourseCategories (category_name) VALUES 
('Data Science'),
('Machine Learning'),
('Web Development'),
('Artificial Intelligence'),
('Cybersecurity'),
('Cloud Computing'),
('Software Engineering');
go
INSERT INTO Enrollments (user_id, course_id, enrolled_date) VALUES 
(1, 1, '2024-01-01'),
(2, 2, '2024-01-02'),
(3, 3, '2024-01-03'),
(4, 4, '2024-01-04'),
(5, 5, '2024-01-05'),
(6, 6, '2024-01-06'),
(7, 7, '2024-01-07'),
(1, 2, '2024-02-01'),
(2, 3, '2024-02-02'),
(3, 4, '2024-02-03'),
(4, 5, '2024-02-04'),
(5, 6, '2024-02-05'),
(6, 7, '2024-02-06'),
(7, 1, '2024-02-07');
go
INSERT INTO CourseCategoryAssignments (course_id, category_id) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 6),
(6, 7),
(7, 1);
go
INSERT INTO Reviews (user_id, course_id, review_text, rating, review_date) VALUES 
(1, 1, 'Great course!', 5, '2024-03-01'),
(2, 2, 'Very informative.', 4, '2024-03-02'),
(3, 3, 'Well structured.', 5, '2024-03-03'),
(4, 4, 'Excellent content.', 5, '2024-03-04'),
(5, 5, 'Very useful.', 4, '2024-03-05'),
(6, 6, 'Highly recommend.', 5, '2024-03-06'),
(7, 7, 'Good introduction.', 4, '2024-03-07'),
(1, 1, 'Great course!', 5, '2024-03-01'),
(2, 2, 'Very informative.', 4, '2024-03-02'),
(3, 3, 'Well structured.', 5, '2024-03-03'),
(4, 4, 'Excellent content.', 5, '2024-03-04'),
(5, 5, 'Very useful.', 4, '2024-03-05'),
(6, 6, 'Highly recommend.', 5, '2024-03-06'),
(7, 7, 'Good introduction.', 4, '2024-03-07'),
-- User 1 reviews Course 1 multiple times
(1, 1, 'Even better the second time!', 5, '2024-03-10'),
(1, 1, 'Third time and still learning.', 5, '2024-03-15'),
-- User 2 reviews Course 2 multiple times
(2, 2, 'Learned new things again.', 4, '2024-03-12'),
(2, 2, 'Good refresher.', 4, '2024-03-20'),
-- User 3 reviews Course 3 multiple times
(3, 3, 'Great insights.', 5, '2024-03-13'),
(3, 3, 'Useful information.', 5, '2024-03-22'),
-- User 4 reviews Course 4 multiple times
(4, 4, 'In-depth analysis.', 5, '2024-03-14'),
(4, 4, 'Very detailed.', 5, '2024-03-25'),
-- User 5 reviews Course 5 multiple times
(5, 5, 'Practical tips.', 4, '2024-03-16'),
(5, 5, 'Helpful examples.', 4, '2024-03-28'),
-- User 6 reviews Course 6 multiple times
(6, 6, 'Comprehensive coverage.', 5, '2024-03-18'),
(6, 6, 'Well explained.', 5, '2024-03-30'),
-- User 7 reviews Course 7 multiple times
(7, 7, 'Good basics.', 4, '2024-03-19'),
(7, 7, 'Nice introduction.', 4, '2024-04-01');

