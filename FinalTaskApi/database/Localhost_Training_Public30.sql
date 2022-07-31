
--start

create table API_DEPARTMENT
(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
Name VARCHAR(255)

);

ALTER TABLE API_DEPARTMENT
MODIFY  Id  GENERATED always as IDENTITY
(start with 500
increment by 1 
CYCLE
MINVALUE 500
MAXVALUE 1000);

CREATE OR REPLACE PACKAGE API_DEPARTMENT_Package AS
PROCEDURE GetAllDepartment;
Procedure InsertDepartment(depname in varchar);
Procedure UpdateDepartment(DId in int,depname in varchar);
Procedure DeleteDepartment(DId in int);

END API_DEPARTMENT_Package;


CREATE OR REPLACE PACKAGE  Body API_DEPARTMENT_Package AS

PROCEDURE GetAllDepartment
as
c_all sys_refcursor;
Begin
open c_all for
select * from API_DEPARTMENT;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllDepartment;

PROCEDURE InsertDepartment(depname in varchar)
IS
BEGIN
INSERT INTO API_DEPARTMENT(Name) 
VALUES(depname);
COMMIT;
END InsertDepartment;

PROCEDURE UpdateDepartment(DId in int,depname in varchar)
IS
BEGIN
UPDATE API_DEPARTMENT SET Name=depname WHERE Id=DId;
COMMIT;
END UpdateDepartment;


PROCEDURE DeleteDepartment(DId in int)
IS
BEGIN
DELETE From API_DEPARTMENT WHERE Id=DId;
COMMIT;
END DeleteDepartment;



END API_DEPARTMENT_Package;


--end



--start

create table API_EMPLOYEES
(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
Fname VARCHAR(255),
Lname VARCHAR(255),
depid int,
email VARCHAR(255),
salary float,
FOREIGN KEY(depid)references API_DEPARTMENT(Id) 
);


CREATE OR REPLACE PACKAGE API_EMPLOYEES_Package AS
PROCEDURE GetAllEMPLOYEES;
Procedure InsertEMPLOYEES(FirstName in varchar, LastName in varchar,iddep in int,emailemp in VARCHAR, salaryemp in float);
Procedure UpdateEMPLOYEES(EId in int,FirstName in varchar, LastName in varchar,iddep in int,emailemp in VARCHAR, salaryemp in float);
Procedure DeleteEMPLOYEES(EId in int);
PROCEDURE filtername(FirstName IN VARCHAR);
Procedure GetSumAvgCountsal;
Procedure Getendemailcom;
Procedure getcountempdep;
Procedure getcountemptask;
procedure emailexist(emailemp in VARCHAR);
END API_EMPLOYEES_Package;



CREATE OR REPLACE PACKAGE  Body API_EMPLOYEES_Package AS

PROCEDURE GetAllEMPLOYEES
as
c_all sys_refcursor;
Begin
open c_all for
select * from API_EMPLOYEES;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllEMPLOYEES;

PROCEDURE InsertEMPLOYEES(FirstName in varchar, LastName in varchar,iddep in int,emailemp in VARCHAR, salaryemp in float)
IS
BEGIN
INSERT INTO API_EMPLOYEES(Fname,Lname,depid,email,salary) 
VALUES(FirstName,LastName,iddep,emailemp,salaryemp);
COMMIT;
END InsertEMPLOYEES;

PROCEDURE UpdateEMPLOYEES(EId in int,FirstName in varchar, LastName in varchar,iddep in int,emailemp in VARCHAR, salaryemp in float)
IS
BEGIN
UPDATE API_EMPLOYEES SET Fname=FirstName,Lname=LastName,depid=iddep,email=emailemp,salary=salaryemp WHERE Id=EId;
COMMIT;
END UpdateEMPLOYEES;


PROCEDURE DeleteEMPLOYEES(EId in int)
IS
BEGIN
DELETE From API_EMPLOYEES WHERE Id=EId;
COMMIT;
END DeleteEMPLOYEES;

PROCEDURE filtername(FirstName IN VARCHAR)
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
Fname

FROM API_EMPLOYEES 
WHERE(FirstName IS NULL OR Fname LIKE '%' || FirstName ||
'%');

DBMS_SQL.RETURN_RESULT(c_all);
END filtername;



Procedure GetSumAvgCountsal
as
c_all sys_refcursor;
Begin
open c_all for
select COUNT(salary) as "CountSalary",SUM(salary) as"SumSalary" ,avg(salary)as"AvgSalary" from API_EMPLOYEES;
DBMS_SQL.RETURN_RESULT(c_all);
END GetSumAvgCountsal;

Procedure Getendemailcom

as
c_all sys_refcursor;
Begin
open c_all for
select Fname as "Firstname",Lname as"lastname"  from API_EMPLOYEES WHERE EMAIL lIKE '%.com';
DBMS_SQL.RETURN_RESULT(c_all);
END Getendemailcom;


Procedure getcountempdep
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
 Name as "depname",count(Fname) as "countEmpEachDep"
FROM API_EMPLOYEES 
 inner JOIN API_DEPARTMENT  ON  API_DEPARTMENT.Id = API_EMPLOYEES.depid group by Name;
 
DBMS_SQL.RETURN_RESULT(c_all);

END getcountempdep;

Procedure getcountemptask
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
nameTask as "Taskname" ,count(Fname) as "countEmpEachtask" 

FROM API_EMPLOYEES 
 inner JOIN API_EMPLOYEESTASK   ON  API_EMPLOYEES.Id = API_EMPLOYEESTASK.Empid 
 inner JOIN API_Task   ON  API_EMPLOYEESTASK.Taskid = API_Task.Id  group by nameTask;
DBMS_SQL.RETURN_RESULT(c_all);
commit;
END getcountemptask;

procedure emailexist(emailemp in VARCHAR)

as
c_all sys_refcursor;
Begin
open c_all for
select email as "emailemp" from API_EMPLOYEES where email = emailemp;
DBMS_SQL.RETURN_RESULT(c_all);
END emailexist;
END API_EMPLOYEES_Package;


--end



--START


create table API_Task
(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
nameTask VARCHAR(255)

);

CREATE OR REPLACE PACKAGE API_Task_Package AS
PROCEDURE GetAllTask;
Procedure InsertTask(TaskName in varchar);
Procedure UpdateTask(TId in int,TaskName in varchar);
Procedure DeleteTask(TId in int);
Procedure gettaskbyid (TId in int);

END API_Task_Package;


CREATE OR REPLACE PACKAGE  Body API_Task_Package AS

PROCEDURE GetAllTask
as
c_all sys_refcursor;
Begin
open c_all for
select * from API_Task;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllTask;

PROCEDURE InsertTask(TaskName in varchar)
IS
BEGIN
INSERT INTO API_Task(nameTask) 
VALUES(TaskName);
COMMIT;
END InsertTask;

PROCEDURE UpdateTask(TId in int,TaskName in varchar)
IS
BEGIN
UPDATE API_Task SET nameTask=TaskName WHERE Id=TId;
COMMIT;
END UpdateTask;


PROCEDURE DeleteTask(TId in int)
IS
BEGIN
DELETE From API_Task WHERE Id=TId;
COMMIT;
END DeleteTask;

Procedure gettaskbyid (TId in int)
as
c_all sys_refcursor;
Begin
open c_all for
select nameTask from API_Task WHERE Id=TId;
DBMS_SQL.RETURN_RESULT(c_all);
END gettaskbyid;
END API_Task_Package;



--END













--START

create table API_EMPLOYEESTASK
(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
Taskid int,
Empid int,
FOREIGN KEY(Taskid)references API_Task(Id),
FOREIGN KEY(Empid)references API_EMPLOYEES(Id)
);

CREATE OR REPLACE PACKAGE API_EMPLOYEESTASK_Package AS
PROCEDURE GetAllEMPLOYEESTASK;
Procedure InsertEMPLOYEESTASK(Taskidd in int,Empidd in int);
Procedure UpdateEMPLOYEESTASK(TEId in int,Taskidd in int,Empidd in int);
Procedure DeleteEMPLOYEESTASK(TEId in int);

END API_EMPLOYEESTASK_Package;


CREATE OR REPLACE PACKAGE  Body API_EMPLOYEESTASK_Package AS

PROCEDURE GetAllEMPLOYEESTASK
as
c_all sys_refcursor;
Begin
open c_all for
select * from API_EMPLOYEESTASK;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllEMPLOYEESTASK;

PROCEDURE InsertEMPLOYEESTASK(Taskidd in int,Empidd in int)
IS
BEGIN
INSERT INTO API_EMPLOYEESTASK( Taskid,Empid) 
VALUES(Taskidd,Empidd);
COMMIT;
END InsertEMPLOYEESTASK;

PROCEDURE UpdateEMPLOYEESTASK(TEId in int,Taskidd in int,Empidd in int)
IS
BEGIN
UPDATE API_EMPLOYEESTASK SET Taskid=Taskidd,Empid=Empidd WHERE Id=TEId;
COMMIT;
END UpdateEMPLOYEESTASK;


PROCEDURE DeleteEMPLOYEESTASK(TEId in int)
IS
BEGIN
DELETE From API_EMPLOYEESTASK WHERE Id=TEId;
COMMIT;
END DeleteEMPLOYEESTASK;



END API_EMPLOYEESTASK_Package;


--END



--START

create table API_CHACK
(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
empid int,
chackin date,
chackout date,
FOREIGN KEY(empid)references API_EMPLOYEES(Id)
);
CREATE OR REPLACE PACKAGE API_CHACK_Package AS
PROCEDURE GetAllCHACK;
Procedure InsertCHACK(idemp in int,chackinn in date,chackoutt in date);
Procedure UpdateCHACK(ckId in int,idemp in int,chackinn in date,chackoutt in date);
Procedure DeleteCHACK(ckId in int);

END API_CHACK_Package;


CREATE OR REPLACE PACKAGE  Body API_CHACK_Package  AS

PROCEDURE GetAllCHACK
as
c_all sys_refcursor;
Begin
open c_all for
select * from API_CHACK;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllCHACK;

PROCEDURE InsertCHACK(idemp in int,chackinn in date,chackoutt in date)
IS
BEGIN
INSERT INTO API_CHACK(empid,chackin,chackout) 
VALUES(idemp,TO_DATE(chackinn,'yyyy-mm-dd'),TO_DATE(chackoutt,'yyyy-mm-dd'));
COMMIT;
END InsertCHACK;

PROCEDURE UpdateCHACK(ckId in int,idemp in int,chackinn in date,chackoutt in date)
IS
BEGIN
UPDATE API_CHACK SET  empid=idemp, chackin=chackinn,chackout=chackoutt WHERE Id=ckId;
COMMIT;
END UpdateCHACK;


PROCEDURE DeleteCHACK(ckId in int)
IS
BEGIN
DELETE From API_CHACK WHERE Id=ckId;
COMMIT;
END DeleteCHACK;



END API_CHACK_Package;

--END





--start
CREATE OR REPLACE PACKAGE API_EMPLOYEESDEP_Package AS
PROCEDURE GetNameSalaryDep;
END API_EMPLOYEESDEP_Package;

CREATE OR REPLACE PACKAGE  Body API_EMPLOYEESDEP_Package AS
PROCEDURE GetNameSalaryDep
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
Fname as "fristname" ,
Lname as "lastname",
salary as "salary",
Name as "depname"
FROM API_EMPLOYEES 
 JOIN API_DEPARTMENT   ON  API_DEPARTMENT.Id = API_EMPLOYEES.depid  ;
DBMS_SQL.RETURN_RESULT(c_all);
END  GetNameSalaryDep;
END API_EMPLOYEESDEP_Package;
--end









--start


CREATE OR REPLACE PACKAGE API_EMPLOYEEStask_Package AS
PROCEDURE GetNametask;
END API_EMPLOYEEStask_Package;

CREATE OR REPLACE PACKAGE  Body API_EMPLOYEEStask_Package AS
PROCEDURE GetNametask
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
Fname as "fristname" ,
Lname as "lastname",
nameTask as "Taskname"


FROM API_EMPLOYEES 
 inner JOIN API_EMPLOYEESTASK   ON  API_EMPLOYEES.Id = API_EMPLOYEESTASK.Empid 
 inner JOIN API_Task   ON  API_EMPLOYEESTASK.Taskid = API_Task .Id;
DBMS_SQL.RETURN_RESULT(c_all);
commit;
END GetNametask;

END API_EMPLOYEEStask_Package;
