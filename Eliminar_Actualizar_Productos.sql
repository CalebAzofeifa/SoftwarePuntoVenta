use [DbPuntoVenta]
go

create procedure [SP_Del_Productos](
@ID int)
as
delete from Productos where id = @ID
go

create procedure [SP_Upd_Productos](
@id  int,
@CodBar varchar(40),
@Descrip varchar (100),
@PreComp decimal (12,2),
@Imp decimal (12,2))
as
update Productos set
CodigoBarras = @CodBar,
Descripcion = @Descrip,
PrecioCompra = @PreComp,
Impuesto = @Imp
where ID = @id
