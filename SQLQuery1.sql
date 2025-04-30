CREATE TABLE emp5 (emp5_no INT PRIMARY KEY, e_name varchar(50), job varchar(50), mgr_id INT, hire_date Date, salary INT, comm INT, dept5_no int);

CREATE TABLE dept5 (dept5_no INT PRIMARY KEY, d_name varchar(50), locations VARCHAR(50));

CREATE TABLE sal_grade5 (grade INT PRIMARY KEY, losal INT, hisal INT);

CREATE TABLE job_history5 (emp5_no INT PRIMARY KEY, job VARCHAR(50), starting_date DATE, ending_date DATE);


INSERT INTO emp5 VALUES (7839, 'King', 'President', null, '17-NOV-81', 5000, null, 10);
INSERT INTO emp5 VALUES (7698, 'blake', 'manager', 7839, '01-MAY-81', 2850, null, 30);
INSERT INTO emp5 VALUES (7782, 'clark', 'manager', 7839, '09-JUN-81', 2450, null, 10);
INSERT INTO emp5 VALUES (7566, 'Jones', 'manager', 7839, '02-APR-81', 2975, null, 20);
INSERT INTO emp5 VALUES (7654, 'Martin', 'manager', 7839, '28-SEP-81', 1250, 1400, 30);

INSERT INTO dept5 VALUES (10, 'Accounting', 'New York');
INSERT INTO dept5 VALUES (20, 'Research', 'Dallas');
INSERT INTO dept5 VALUES (30, 'Sales', 'Chicago');
INSERT INTO dept5 VALUES (40, 'Operations', 'Boston');

INSERT INTO sal_grade5 VALUES (1, 700, 1200);
INSERT INTO sal_grade5 VALUES (2, 1201, 1400);
INSERT INTO sal_grade5 VALUES (1, 1401, 2000);
INSERT INTO sal_grade5 VALUES (1, 2001, 3000);
INSERT INTO sal_grade5 VALUES (1, 3001, 9999);


INSERT INTO job_history5 VALUES (7698, 'Accounting', '04-MAR-80', '30-APR-81');
INSERT INTO job_history5 VALUES (7654, 'Receptionist', '13-JAN-80', '09-SEP-80');
INSERT INTO job_history5 VALUES (7654, 'Salesman', '10-SEP-80', '20-SEP-81');
INSERT INTO job_history5 VALUES (7788, 'Programmer', '13-FEB-80', '03-DEC-82');
INSERT INTO job_history5 VALUES (7876, 'Typist', '12-APR-80', '13-NOV-81');
