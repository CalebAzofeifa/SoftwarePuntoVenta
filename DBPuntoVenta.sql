

if exists(select name from dbo.sysdatabases where name = 'DbUHSearch')
drop database [DbPuntoVenta]
go

create database [DbPuntoVenta]
go

use [DbPuntoVenta]
go

if exists(select name from dbo.sysobjects where name = 'TblUsuarios')
drop table [TblUsuarios]
go

create table [TblUsuarios](
Email varchar(100) not null primary key,
NombreCompleto varchar(150) not null,
Password varchar(200) not null,
FechaRegistro datetime not null default getdate(),
Estado char not null default 'A')
go

insert into TblUsuarios(Email,NombreCompleto,Password)
values('admin@gmail.com','Administrador','admin')
go



insert into TblUsuarios(Email,NombreCompleto,Password)
values('Leo@gmail.com','Leonardo Chavez','123456')
go

insert into TblUsuarios(Email,NombreCompleto,Password)
values('Pedro@gmail.com','Pedro Sandoval Morales','Pedro2712')
go

select * from TblUsuarios
go

select Email,NombreCompleto,Password,FechaRegistro,Estado from TblUsuarios where Email = 'admin@gmail.com' and Password = 'admin'
go

if exists(select name from dbo.sysobjects where name = 'Sp_Cns_Usuarios')
drop procedure [Sp_Cns_Usuarios]
go

create procedure [Sp_Cns_Usuarios](
@Nombre varchar (150))
as 
select * from TblUsuarios
where NombreCompleto like '%' + @Nombre + '%'
Order by NombreCompleto
go

exec [Sp_Cns_Usuarios] 'a'
go