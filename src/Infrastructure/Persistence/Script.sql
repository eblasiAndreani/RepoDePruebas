create database CrudTest

use CrudTest

create table CuadroFutbol
(
Id int primary key identity(1,1),
Nombre varchar(256),
);

create table Persona
(
Id int primary key identity(1,1),
Nombre varchar(256),
Dni int,
IdCuadro int,
constraint fk_Per_Cua foreign key (IdCuadro) references CuadroFutbol (Id)
);