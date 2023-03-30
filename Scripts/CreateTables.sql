use eBoletim

--Criar a tabela Roles
create table Roles(
id int identity,
Role nvarchar(50),
primary key (Role)
)

--Criar a tabela Person
create table Person(
id int identity,
Name nvarchar(250) NOT NULL,
Surname nvarchar(250) NOT NULL,
Cpf nvarchar(11) NOT NULL,
Email nvarchar(250) NOT NULL,
Password nvarchar(250) NOT NULL,
RoleId int NOT NULL,
RegistrationDate smalldatetime NOT NULL
primary key(Cpf)
)

--Criar a tabela Subjects
create table Subjects(
id int identity,
SubjectName nvarchar(20)
primary key(SubjectName)
)

--Criar a tabela Classes
create table Classes(
id int identity,
SubjectId int,
TeacherId int,
Year int,
primary key (SubjectId,TeacherId,Year)
)

--Criar a tabela StudentClasses
create table StudentClasses(
id int identity,
StudentId int,
ClassId int
primary key (ClassId,StudentId)
)

--Criar a tabela Grades
create table Grades(
id int identity,
StudentId int,
ClassId int,
Grade decimal(4,2),
Quarter int,
check(Grade >=0 and Grade <=10),
check(Quarter >=1 and Quarter <=4),
primary key(StudentId,ClassId,Quarter)
)