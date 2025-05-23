CREATE DATABASE ExamenU3
GO

USE ExamenU3
GO

CREATE TABLE Productos 
(
    Id_Prod INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
	Descripcion  VARCHAR(255)NOT NULL,
	Stock INT NOT NULL
);
GO

INSERT INTO Productos (Stock, Nombre, Precio, Descripcion) VALUES
(50, 'Laptop HP 15"', 12500.00, 'Laptop con procesador Intel Core i5, 8GB RAM, 512GB SSD'),
(30, 'Mouse inalámbrico Logitech', 350.00, 'Mouse óptico inalámbrico con conexión USB'),
(20, 'Monitor LG 24"', 3200.50, 'Monitor LED Full HD de 24 pulgadas'),
(100, 'Teclado mecánico Redragon', 800.00, 'Teclado mecánico con retroiluminación RGB'),
(15, 'Impresora Epson L3250', 4200.00, 'Multifuncional con sistema de tinta continua'),
(75, 'USB Kingston 64GB', 180.99, 'Memoria USB 3.0 con 64GB de almacenamiento'),
(10, 'Router TP-Link Archer C6', 950.00, 'Router de doble banda con 4 antenas'),
(60, 'Audífonos JBL Tune 500', 599.00, 'Audífonos con micrófono y sonido potente'),
(25, 'Webcam Logitech C920', 1850.00, 'Webcam Full HD 1080p para videollamadas'),
(40, 'Silla ergonómica', 2950.75, 'Silla de oficina ergonómica con soporte lumbar');

INSERT INTO Productos values (20,'Mouse con cable',12.50,'Mouse gamer')
