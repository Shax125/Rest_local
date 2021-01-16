ALTER TABLE Customers_2021A_T4
ADD photo NVARCHAR(100)  NULL

ALTER TABLE Customers_2021A_T4
DROP COLUMN photo;

alter table Customers_2021A_T4
add idd int

update Customers_2021A_T4
set idd=id

alter table Customers_2021A_T4
drop column id1