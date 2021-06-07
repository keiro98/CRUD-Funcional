create database Practica
go
use Practica

-- Tabla Productos es para el CRUD--
create table Productos
(
Id int identity(1,1) primary key,
Nombre nvarchar(100),
Descripcion nvarchar(100),
Marca nvarchar(100),
Precio float,
Stock int
)

-- Tabla usuario es para el login y el registro(aun no esta hecho)--
create table usuario(
nombre_completo nvarchar(50),
rutusuario nvarchar(50),
contraseña nvarchar(50)
)

--Insert en la tabla Productos--
insert into Productos values ('Gaseosa','3 litros','marcacola',7.5,24),
('Chocolate','Tableta 100 gramos','iberica',12.5,36),
('Leche','Deslactosada','supervaca',3,48),
('Mazomorra','Bolsa 1 kg','standar',2.0,24),
('Harina','bolsa 1 kg','Purotrigo',3.5,24),
('Nectar','1 litro','alljugos',4.5,20),
('Aceite','1 litro','cocinero',7.5,24)

--Insert en la tabla usuario--
insert into usuario values('Pedro Gonzalez Castro','12345678-9','elbaneado');


--Procedimientos almacenados--
/*create proc MostrarProductos
as
select * from Productos
go*/

/*create proc InsertarProductos
@nombre nvarchar(100),
@desc nvarchar(100),
@Marca nvarchar(100),
@precio float,
@stock int
as
insert into Productos values (@nombre,@desc,@Marca,@precio,@stock)
go*/


/*create proc EditarProductos
@nombre nvarchar(100),
@desc nvarchar(100),
@Marca nvarchar(100),
@precio float,
@stock int,
@id int
as
update Productos set Nombre =@nombre,Descripcion=@desc,Marca=@Marca,Precio=@precio,Stock=@stock
where Id=@id
go*/

/*create proc EliminarProducto
@idpro int 
as
delete from Productos where Id=@idpro
go*/

-- Lista de ejecutables de los proc. almacenados--
exec MostrarProductos
exec InsertarProductos 'jaja','dulce','marca',5,48
exec EditarProductos 'mandarina','dulce','los bosues',100,548,8
exec EliminarProducto 8