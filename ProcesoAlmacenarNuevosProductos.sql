use [DbPuntoVenta]
go

create procedure [Sp_Ins_Productos](
@CodBarra varchar(40),
@Descrip varchar (100),
@PrecComp decimal (12,2),
@Imp decimal (12,2))
as 
Insert into Productos (CodigoBarras,Descripcion,PrecioCompra,Impuesto)
values (@CodBarra,@Descrip,@PrecComp,@Imp)
go

exec [Sp_Ins_Productos] 1112224, 'Salsa Lizano', 1350,13
go

select * from Productos
go

