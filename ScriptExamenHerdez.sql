CREATE DATABASE DGaleanaHerdez
GO
USE DGaleanaHerdez


CREATE TABLE Sucursal(
IdSucursal INT IDENTITY (1,1) PRIMARY KEY,
Nombre VARCHAR (50),
Distancia INT
)


CREATE TABLE Producto(
IdProducto INT IDENTITY (1,1) PRIMARY KEY,
Nombre VARCHAR (50),
PrecioProducto FLOAT,
PrecioEnvio FLOAT,
IdSucursal INT FOREIGN KEY REFERENCES  Sucursal(IdSucursal)
)

INSERT [dbo].[Sucursal] ([Nombre], [Distancia]) VALUES ('Monterrey', 645)
INSERT [dbo].[Sucursal] ([Nombre], [Distancia]) VALUES ('Baja California', 984)
INSERT [dbo].[Sucursal] ([Nombre], [Distancia]) VALUES ('Chiapas', 826)

INSERT [dbo].[Producto] ([Nombre], [PrecioProducto], [PrecioEnvio], [IdSucursal]) VALUES ('Bocinas', 324, 0.45, 2)
INSERT [dbo].[Producto] ([Nombre], [PrecioProducto], [PrecioEnvio], [IdSucursal]) VALUES ('Monitor', 4300, 1.1, 1)
INSERT [dbo].[Producto] ([Nombre], [PrecioProducto], [PrecioEnvio], [IdSucursal]) VALUES ('Audifonos', 699, 0.88, 3)

GO

CREATE PROCEDURE GetById
@IdProducto INT,
@DistanciaSucursalSol INT
AS
SELECT
Producto.Nombre,
Producto.PrecioEnvio * (Sucursal.Distancia - @DistanciaSucursalSol) AS PrecioEnvio,
Sucursal.Distancia - @DistanciaSucursalSol AS DistanciaEstimada,
Producto.PrecioProducto - (Producto.PrecioProducto * 0.15) AS Precio,
Producto.PrecioProducto * 0.15 AS Iva,
Producto.PrecioProducto AS PrecioFinal
FROM Producto
INNER JOIN Sucursal
ON Sucursal.IdSucursal = Producto.IdSucursal
WHERE Producto.IdProducto = @IdProducto