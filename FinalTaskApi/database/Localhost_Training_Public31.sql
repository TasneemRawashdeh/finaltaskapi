 
 create or REPLACE package puyment as
 PROCEDURE GGGG(service_idd in int DEFAULT 1,useridd in int DEFAULT 6,quntity in float DEFAULT 10,datesales in date DEFAULT '11-Nov-2008');

 end puyment;
 
  create or REPLACE package body puyment as
PROCEDURE GGGG(service_idd in int DEFAULT 1,useridd in int DEFAULT 6,quntity in float DEFAULT 10,datesales in date DEFAULT '11-Nov-2008')
 IS 
 l_price service_task.price%type;
 l_user user_task.id%type;
BEGIN
SELECT price INTO l_price from service_task where Id = service_idd;
SELECT Id into  l_user from card_task where UserId = useridd;
INSERT INTO sales_task(userid,serviceid,totelPrice,datesales,visa_id) VALUES (useridd,service_idd,l_price*quntity,datesales, l_user);
COMMIT;
END GGGG;
 end puyment;
 
 
 
 
 

alter table sales_task
add visa_id int;


alter table sales_task
ADD foreign key(visa_id)references card_task(Id);