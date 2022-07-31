---user table 

create table user_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
username varchar(255),
email varchar(255),
verficationcode  varchar(255),
country_id int,
FOREIGN KEY(country_id)references country_task(Id)
);


CREATE OR REPLACE PACKAGE user_task_Package AS
PROCEDURE GetAlluser;
Procedure Insertuser(fullname in varchar,emailuser in varchar ,verficationcodeuser in varchar,ccountry_id in int);
Procedure Updateuser(UId in int,fullname in varchar,emailuser in varchar ,verficationcodeuser in varchar,ccountry_id in int);
Procedure Deleteuser(UId in int);
PROCEDURE totaleachuser;
PROCEDURE CountCantryUser;

END user_task_Package;

CREATE OR REPLACE PACKAGE  Body user_task_Package AS
PROCEDURE GetAlluser
as
c_all sys_refcursor;
Begin
open c_all for
select * from user_task;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAlluser;

Procedure Insertuser(fullname in varchar,emailuser in varchar ,verficationcodeuser in varchar,ccountry_id in int)
IS
BEGIN
INSERT INTO user_task(username,email,verficationcode,country_id) 
VALUES (fullname ,emailuser ,verficationcodeuser,ccountry_id);
COMMIT;
END Insertuser;

PROCEDURE  Updateuser(UId in int,fullname in varchar,emailuser in varchar ,verficationcodeuser in varchar,ccountry_id in int)
IS
BEGIN
UPDATE user_task SET username=fullname,email=emailuser,verficationcode=verficationcodeuser,country_id=ccountry_id WHERE Id=UId;
COMMIT;
END Updateuser;


PROCEDURE Deleteuser(UId in int)
IS
BEGIN
DELETE From user_task WHERE Id=UId;
COMMIT;
END Deleteuser;

PROCEDURE totaleachuser
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
 username as "name",count(massage) as "massagees"
FROM user_task 
 inner JOIN massage_task  ON  massage_task.UserId = user_task.Id group by username;
 
DBMS_SQL.RETURN_RESULT(c_all);

END totaleachuser;
PROCEDURE CountCantryUser

AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
 COUNT(NameCountry) as "CountCantryUser"
FROM country_task 
 inner JOIN user_task   ON  user_task .country_id = country_task.Id;
 
DBMS_SQL.RETURN_RESULT(c_all);
end CountCantryUser;

END user_task_Package;


---end user table



CREATE OR REPLACE PACKAGE massage_task_Package AS
PROCEDURE GetAllmassage;
Procedure Insertmassage(UserIdd in int,massageuser in varchar,datemassagee in date);
Procedure Updatemassage(mId in int,UserIdd in int,massageuser in varchar,datemassagee in date);
Procedure Deletemassage(mId in int);
procedure SearchButweenDate(chackinn in date,chackoutt in date);
PROCEDURE FilterMassage(mm IN VARCHAR);

END massage_task_Package;

CREATE OR REPLACE PACKAGE Body massage_task_Package AS
PROCEDURE GetAllmassage
as
c_all sys_refcursor;
Begin
open c_all for
select * from massage_task;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllmassage;

Procedure Insertmassage(UserIdd in int,massageuser in varchar,datemassagee in date)
IS
BEGIN
INSERT INTO massage_task(UserId,massage,datemassage) 
VALUES(UserIdd,massageuser,TO_DATE(datemassagee,'yyyy-mm-dd'));
COMMIT;
end Insertmassage;

Procedure Updatemassage(mId in int,UserIdd in int,massageuser in varchar,datemassagee in date)
IS
BEGIN
UPDATE massage_task SET UserId = UserIdd,massage=massageuser,datemassage=datemassagee WHERE Id=mId;
COMMIT;
end Updatemassage;

Procedure Deletemassage(mId in int)
IS
BEGIN
DELETE From massage_task WHERE Id=mId;
COMMIT;
end Deletemassage;

procedure SearchButweenDate(chackinn in date,chackoutt in date)
as 
c_all SYS_REFCURSOR;
begin
open c_all for 
select massage as "Massage",datemassage as "DateMassage"
from massage_task 
 WHERE datemassage <= chackinn   and datemassage  >= chackoutt;
dbms_sql.return_result(c_all);
COMMIT;

end SearchButweenDate;

PROCEDURE FilterMassage(mm IN VARCHAR)
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
massage as "Massage"

FROM massage_task 
WHERE(mm IS NULL OR massage LIKE '%' || mm ||'%');

DBMS_SQL.RETURN_RESULT(c_all);
end FilterMassage;
end massage_task_Package;



--end table massage
