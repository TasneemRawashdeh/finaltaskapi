--card_task table
create table card_task(
Id int GENERATED always as IDENTITY (start with 1 increment by 1) primary key,
UserId int,
cardNo int,
caedEndDate date,
CardType varchar(255),
FOREIGN KEY(UserId)references user_task(Id)
);

CREATE OR REPLACE PACKAGE  API_Card_Package as
PROCEDURE GetAllcard;
Procedure Insertcard(UserIdd in int,cardNoo in int ,caedEndDatee in date,CardTypee in varchar);
Procedure Updatecard(caId in int,UserIdd in int,cardNoo in int ,caedEndDatee in date,CardTypee in varchar);
Procedure Deletecard(caId in int);
end API_Card_Package;

CREATE OR REPLACE PACKAGE  Body API_Card_Package  AS

PROCEDURE GetAllcard
as
c_all sys_refcursor;
Begin
open c_all for
select * from card_task;
DBMS_SQL.RETURN_RESULT(c_all);
END GetAllcard;

Procedure Insertcard(UserIdd in int,cardNoo in int ,caedEndDatee in date,CardTypee in varchar)
IS
BEGIN
INSERT INTO card_task(UserId,cardNo,caedEndDate,CardType) 
VALUES(UserIdd,cardNoo,TO_DATE(caedEndDatee,'yyyy-mm-dd'),CardTypee);
COMMIT;
END Insertcard;

PROCEDURE Updatecard(caId in int,UserIdd in int,cardNoo in int ,caedEndDatee in date,CardTypee in varchar)
IS
BEGIN
UPDATE card_task SET UserId= UserIdd ,cardNo=cardNoo ,caedEndDate=caedEndDatee ,CardType=CardTypee  WHERE Id=caId;
COMMIT;
END Updatecard;

Procedure Deletecard(caId in int)
IS
BEGIN
DELETE From card_task WHERE Id=caId;
COMMIT;
end Deletecard;
end API_Card_Package;







--end card_task