use [DbPuntoVenta]
go

create procedure [Sp_Ins_Usuarios](
@Email varchar(100),
@FullName varchar (100),
@PassW varchar (100))
as 
Insert into TblUsuarios (Email,NombreCompleto,Password)
values (@Email,@FullName,@PassW)
go


select * from TblUsuarios
go