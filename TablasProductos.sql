use [DbPuntoVenta]
go

if exists (select name from dbo.sysobjects where name = 'Productos')
drop table [Productos]
go

create table [Productos](
ID int not null primary key identity,
CodigoBarras varchar(40) not null,
Descripcion varchar(100) not null,
PrecioCompra decimal(12,2) not null,
Impuesto decimal (12,2) not null,
FechaRegistro datetime not null default getdate(),
Estado char not null default 'A')
go

insert into Productos(CodigoBarras,Descripcion,PrecioCompra,Impuesto)
values('1112221','Arroz Almendros',1550.00,13)
go
insert into Productos(CodigoBarras,Descripcion,PrecioCompra,Impuesto)
values('1112222','Frijoles Indiana',950.00,13)
go
insert into Productos(CodigoBarras,Descripcion,PrecioCompra,Impuesto)
values('1112223','Atún Azul Sardimar',1950.00,13)
go

select * from Productos
go



if exists(select name from dbo.sysobjects where name = 'Sp_Cns_Productos')
drop procedure [Sp_Cns_Productos]
go

create procedure [Sp_Cns_Productos](
@Descrip varchar (100))
as 
select * from Productos
where Descripcion like '%' + @Descrip + '%'
Order by Descripcion
go

exec [Sp_Cns_Productos] 'a'
go
