CREATE TABLE Persona(
	codigoPersona INT PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(80),
	genero VARCHAR(1),
	edad INT,
	identificacion VARCHAR(13),
	direccion VARCHAR(150),
	telefono VARCHAR(20)
);
GO
CREATE TABLE Cliente (
	codigoCliente INT PRIMARY KEY IDENTITY(1,1),
	clientid INT,
	clave VARCHAR(100),
	estado BIT,
	codigoPersona INT,
	FOREIGN KEY (codigoPersona) REFERENCES Persona(codigoPersona)
);
GO
CREATE TABLE Cuenta(
	codigoCuenta INT PRIMARY KEY IDENTITY(1,1),
	numeroCuenta VARCHAR(13),
	tipoCuenta VARCHAR(20),
	saldoInicial DECIMAL(18,2),
	estado bit
);
GO
CREATE TABLE Movimiento(
	codigoMovimiento INT PRIMARY KEY IDENTITY(1,1),
	fecha VARCHAR(20),
	tipoMovimiento VARCHAR(50),
	valor DECIMAL(18,2),
	saldo DECIMAL(18,2)
);
GO

INSERT INTO dbo.Persona(nombre ,genero ,edad ,identificacion ,direccion ,telefono)
VALUES  ( 'Jose Lema' ,'M' , 32 , '1255778920' ,'Otavalo sn y principal' ,'098254785');

INSERT INTO dbo.Persona(nombre ,genero ,edad ,identificacion ,direccion ,telefono)
VALUES  ( 'Mariana Montalvo' ,'F' , 35 , '1255332920' ,'Amazonas y NNUU' ,'097548965');

INSERT INTO dbo.Persona(nombre ,genero ,edad ,identificacion ,direccion ,telefono)
VALUES  ( 'Juan Osorio' ,'M' , 37 , '1252178920' ,'13 junio y Equinoccial' ,'098874587');

INSERT INTO dbo.Cuenta( numeroCuenta ,tipoCuenta ,saldoInicial ,estado)
VALUES  ( '478758' ,'Ahorro' ,2000 ,1);

INSERT INTO dbo.Cuenta( numeroCuenta ,tipoCuenta ,saldoInicial ,estado)
VALUES  ( '225487' ,'Corriente' ,100 ,1);

INSERT INTO dbo.Cuenta( numeroCuenta ,tipoCuenta ,saldoInicial ,estado)
VALUES  ( '495878' ,'Ahorro' ,0 ,1);

INSERT INTO dbo.Cuenta( numeroCuenta ,tipoCuenta ,saldoInicial ,estado)
VALUES  ( '496825' ,'Ahorro' ,540 ,1);