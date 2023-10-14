use[DbPuntoVenta]
go

create table Clientes(
Cedula varchar (25) not null primary key,
NombreCompleto varchar(100) not null,
Telefono varchar(25) not null,
LimiteCredito decimal(12,2) not null,
Email varchar(100) not null,
FechaNacimiento datetime not null,
FechaRegistro Datetime not null default getdate(),
Estado char not null default 'A')
go


create procedure [Sp_Cns_Clientes](
@Nombre varchar (100))
as 
select * from Clientes
where NombreCompleto like '%' + @Nombre + '%'
Order by NombreCompleto
go

create procedure [Sp_Ins_Clientes](
@Cedul varchar(25),
@FullN varchar (100),
@Telef varchar (25),
@LCredito decimal (12,2),
@Mail varchar (100),
@FechaN datetime
)
as 
Insert into Clientes (Cedula,NombreCompleto,Telefono,LimiteCredito,Email,FechaNacimiento)
values (@Cedul,@FullN,@Telef,@LCredito,@Mail,@FechaN)
go


create procedure [Sp_Del_Clientes](
@Cedula varchar(25))
as
delete from Clientes where Cedula = @Cedula
go

drop procedure [Sp_Upd_Clientes]
go

create procedure [Sp_Upd_Clientes](
@Cedula  varchar(25),
@FullN varchar(100),
@Telef varchar (25),
@LCredito decimal (12,2),
@Mail varchar (100),
@FechaN datetime)
as
update Clientes set
NombreCompleto = @FullN,
Cedula = @Cedula,
Telefono = @Telef,
LimiteCredito = @LCredito,
Email = @Mail,
FechaNacimiento = @FechaN
