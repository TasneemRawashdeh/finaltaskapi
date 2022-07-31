--------start database-------------------


--country table
create table country_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
NameCountry varchar(255)
);


CREATE OR REPLACE PACKAGE country_task_Package AS
PROCEDURE GetAllcountry;
Procedure Insertcountry(NameCountryy in varchar);
Procedure Updatecountry(conId in int,NameCountryy in varchar);
Procedure Deletecountry(conId in int);

END country_task_Package;

CREATE OR REPLACE PACKAGE  Body country_task_Package AS
PROCEDURE GetAllcountry
as
c_all sys_refcursor;
Begin
open c_all for
select * from country_task;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllcountry;


Procedure Insertcountry(NameCountryy in varchar)
IS
BEGIN
INSERT INTO country_task(NameCountry) 
VALUES (NameCountryy);
COMMIT;
END Insertcountry;

Procedure Updatecountry(conId in int,NameCountryy in varchar)
IS
BEGIN
UPDATE country_task SET NameCountry=NameCountryy WHERE Id=conId;
COMMIT;

end Updatecountry;
Procedure Deletecountry(conId in int)
IS
BEGIN
DELETE From country_task WHERE Id=conId;
COMMIT;

end Deletecountry;

end country_task_Package;






-- end country table

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
PROCEDURE visaeachuser;

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
PROCEDURE visaeachuser
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
 username as "name",count(CardType) as "numbercrduser"
FROM user_task 
 inner JOIN card_task  ON  card_task.UserId = user_task.Id group by username;
 
DBMS_SQL.RETURN_RESULT(c_all);


end visaeachuser;



END user_task_Package;


---end user table 


--login table

create table login_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
userid int,
username varchar(255),
password varchar(255),
FOREIGN KEY(userid)references user_task(Id)
);
create or replace package loginapi_package
as
procedure Auth (username1 in varchar,password1 in varchar);
end loginapi_package;
create or replace package body loginapi_package
as
procedure Auth (username1 in varchar,password1 in varchar)
as
c_all SYS_REFCURSOR;
BEGIN
OPEN c_all  FOR
Select * FROM login_task where username=username1 and password=password1; 
DBMS_SQL.RETURN_RESULT(c_all);
end Auth;
END loginapi_package;

--end login table


--card_task table
create table card_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
UserId int,
cardNo int,
caedEndDate date,
CardType varchar(255),
FOREIGN KEY(UserId)references user_task(Id)
);







--end card_task

--frind table

create table frind_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
UserId int,
frindId int,
FOREIGN KEY(UserId)references user_task(Id)
);

--end frind table

--table massage
create table massage_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
UserId int,
massage varchar2(500 byte),
datemassage date,
FOREIGN KEY(UserId)references user_task(Id)
);

CREATE OR REPLACE PACKAGE massage_task_Package AS
PROCEDURE GetAllmassage;
Procedure Insertmassage(UserIdd in int,massageuser in varchar,datemassagee in date);
Procedure Updatemassage(mId in int,UserIdd in int,massageuser in varchar,datemassagee in date);
Procedure Deletemassage(mId in int);
procedure SearchButweenDate(chackinn in date,chackoutt in date);

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
 WHERE massage_task.datemassage>=chackinn and massage_task.datemassage<=chackoutt;
dbms_sql.return_result(c_all);
COMMIT;

end SearchButweenDate;

end massage_task_Package;


--group table

create table group_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
namegroup varchar(255)
);

--end group table
--group_user table
create table groupuser_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
groupId int,
userid int,
blockuser CHAR(1),
FOREIGN KEY(userid)references user_task(Id),
FOREIGN KEY(groupId)references group_task(Id)
);
--end group_user table

--category table
create table category_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
namecategory varchar(255)
);

--end category table

--service table
create table service_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
serviceName varchar(255),
categoryId int ,
price float,
FOREIGN KEY(categoryId)references category_task(Id)


);

--end service table
--sales table

create table sales_task
(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
userid int,
serviceId int,
totelPrice float,
datesales date,
FOREIGN KEY(userid)references user_task(Id),
FOREIGN KEY(serviceId)references service_task(Id)
);


--end sales table

--post table

create table post_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
userid int,
post varchar2(500 byte),
FOREIGN KEY(userid)references user_task(Id)

);




CREATE OR REPLACE PACKAGE post_task_Package AS
PROCEDURE GetAllpost;
Procedure Insertpost(useriddd in int , postt in VARCHAR);
Procedure Updatepost(plId in int,useriddd in int , postt in VARCHAR);
Procedure Deletepost(plId in int);

END post_task_Package;

CREATE OR REPLACE PACKAGE  Body post_task_Package AS
PROCEDURE GetAllpost
as
c_all sys_refcursor;
Begin
open c_all for
select * from post_task;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllpost;


Procedure Insertpost(useriddd in int , postt in VARCHAR)
IS
BEGIN
INSERT INTO post_task(userid , post) 
VALUES (useriddd  , postt );
COMMIT;
END Insertpost;

Procedure Updatepost(plId in int,useriddd in int , postt in VARCHAR)
IS
BEGIN
UPDATE post_task SET userid=useriddd,post=postt WHERE Id=plId;
COMMIT;

end Updatepost;
Procedure Deletepost(plId in int)
IS
BEGIN
DELETE From post_task WHERE Id=plId;
COMMIT;

end Deletepost;

end post_task_Package;





--end post table







--postlike table
create table postlike_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
postid int,
userid int,
FOREIGN KEY(userid)references user_task(Id),
FOREIGN KEY(postid)references post_task(Id)


);

CREATE OR REPLACE PACKAGE postlike_task_Package AS
PROCEDURE GetAllpostlike;
Procedure Insertpostlike(postidd in int , useridd in int);
Procedure Updatepostlike(pkId in int,postidd in int , useridd in int);
Procedure Deletepostlike(pkId in int);
procedure likeeachpost;

END postlike_task_Package;

CREATE OR REPLACE PACKAGE  Body postlike_task_Package AS
PROCEDURE GetAllpostlike
as
c_all sys_refcursor;
Begin
open c_all for
select * from postlike_task;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllpostlike;


Procedure Insertpostlike(postidd in int , useridd in int)
IS
BEGIN
INSERT INTO postlike_task(postid,userid) 
VALUES (postidd,useridd);
COMMIT;
END Insertpostlike;

Procedure Updatepostlike(pkId in int,postidd in int , useridd in int)
IS
BEGIN
UPDATE postlike_task SET postid=postidd,userid=useridd WHERE Id=pkId;
COMMIT;

end Updatepostlike;
Procedure Deletepostlike(pkId in int)
IS
BEGIN
DELETE From postlike_task WHERE Id=pkId;
COMMIT;

end Deletepostlike;

PROCEDURE likeeachpost
AS
c_all sys_refcursor;
BEGIN
open c_all for
SELECT
 post as "post",count(userid) as "numberlike"
FROM post_task 
 inner JOIN postlike_task  ON  postlike_task.postid= post_task.Id group by post;
 
DBMS_SQL.RETURN_RESULT(c_all);


end likeeachpost;
end postlike_task_Package;


--end postlike table


--------end database-------------------