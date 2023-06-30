create table employee_tbl(id int identity(1,1), name varchar(50),gender varchar(50),age int ,salary int, city varchar(50))

select * from employee_tbl

insert into employee_tbl values('divya','female',24,70000,'banglore')
insert into employee_tbl values('teju','female',20,60000,'chennai')
insert into employee_tbl values('kavya','female',17,10000,'hyderabad')
insert into employee_tbl values('sunny','male',26,60000,'chennai')
insert into employee_tbl values('ravi','male',25,20000,'hyderabad')

create procedure spGetEmployees
as
begin
  select * from employee_tbl
end

execute spGetEmployees


create procedure spAddEmployee
(
@name varchar(50),
@gender varchar(50),
@age int ,
@salary int,
@city varchar(50)
)
as
begin
 insert into employee_tbl(name,gender,age,salary,city) values (@name,@gender,@age,@salary,@city)
end

execute spAddEmployee 'test1','testing1',25,5000,'rrrhh';


create procedure spUpdateEmployee
(
@id int,
@name varchar(50),
@gender varchar(50),
@age int ,
@salary int,
@city varchar(50)
)
as
begin
   update employee_tbl set name=@name,gender=@gender,age=@age,salary=@salary,city=@city where id=@id;
end


execute spUpdateEmployee 2, 'navya','female',22,8878,'bhjhjh';


create procedure spDeleteEmployee
(
@id int
)
as
begin
 delete from employee_tbl where id=@id;
end

execute spDeleteEmployee 6