use AgendateApp

insert into Usuarios (
	NombreUsuario,
	Contrasenia,
	Correo,
	Nombre,
	Apellido,
	Celular,
	TipoUsuario
) values 
	('admin','12345','john@example.com','John','Doe','1234567890','customer'),
	('jose','12345','panaderia@example.com','Jose','Panadero','9876543210','company'),
	('pelu1','12345','pelu1@example.com','Ana','Gonzales','54656543001','company'),
	('abm','12345','abm@example.com','Jorge','Belloni','50002543001','company'),
	('sofi','12345','sofipelu@example.com','Sofia','Rodriguez','098888011','company'),
	('userX','12345','userX@example.com','User','Equiz','545654888','customer'),
	('mauro','12345','mauro.taller@example.com','Mauro','Perez','092789789','company')
;
insert into Clientes(
	Id,
	Documento
) values 
	(1, '47659893'),
	(6, '35465878')
;
insert into Empresas (
	Id,
	RutDocumento,
	RazonSocial,
	Direccion,
	Rubro,
	Descripcion,
	Latitude,
	Longitude,
	NombrePropietario,
	Ciudad
) values
	(2,
	'10000500123456789',
	'Panaderia y Rotiseria.', 
	'Vilardebo 4565',
	'Gastronomia',
	'Panaderia y Rotiseria donde podes realizar tu reserva de pedido y venir a retirar...',
	-34.84784073123643,
	-56.17782158777118,
	'Jose',
	'Montevideo'),
	(3,
	'10012345123456789',
	'Peluqueria El Tato.', 
	'Av Gral Flores 3175',
	'Estetica',
	'Peluqueria donde encontraras...',
	-34.87687835086815,
	-56.18044914677739,
	'Ana',
	'Montevideo'),
	(4,
	'10012345000000089',
	'ABM Tatú.', 
	'Rivadavia 1234',
	'Estetica',
	'Local de tatuajes, pedi tu reserva para venir a realizarte los mejores tatuajes...',
	-34.88075873144812,
	-56.17954256013036,
	'Jorge',
	'Montevideo'),
	(5,
	'10012345123411789',
	'Peluqueria Sofia.', 
	'Guadalupe 123',
	'Estetica',
	'Cortes, brushing y mas, todo unisex....',
	-34.87917915703534,
	-56.16783572360873,
	'Sofia',
	'Montevideo'),
	(7,
	'10005000123456700',
	'Taller Mauro.', 
	'Ofelia Machado Bonet 1548',
	'Automotriz',
	'Taller donde podes reservar con anticipacion una revision sin costo... \n Gomeria, chapa y Pintura',
	-34.846390668781666,
	-56.23299362137914,
	'Mauro',
	'Montevideo')
;

/*

select * from Clientes
select * from Empresas
select * from Usuarios

-- SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Clientes';
-- DBCC CHECKIDENT ('Empresas', RESEED, 0); -- resetear autoincremental de tabla

*/

--insert into Usuarios (NombreUsuario,Nombre,Apellido,Contrasenia,Celular,Correo,TipoUsuario)
--Values ('kmiranda','Kevin','Miranda','AF1B3D065B57A902B0EFBE3866B479B49503D1376C858B61FD332228AF280392','098760127','kmiranda@gmail.com','Empresa')
----usu kmiranda
----pass kmiranda1234

--insert into Usuarios (NombreUsuario,Nombre,Apellido,Contrasenia,Celular,Correo,TipoUsuario)
--Values ('kmiranda2','Kevin2','Miranda2','978CC7F527BC78F70B3598A34ED50D4FBA8570E71F827582D545A4DD6D989C15','098760128','kmiranda2@gmail.com','Empresa')
----usu kmiranda2
----pass kmiranda234
--insert into Usuarios (NombreUsuario,Nombre,Apellido,Contrasenia,Celular,Correo,TipoUsuario)
--Values ('kmiranda3','Kevin','Miranda','BDF6FC2FB138CFECFA624284E4A57573344E271D05A685102A4AA2D88D84B14A','098760129','kmiranda2@gmail.com','Empresa')
----usu kmiranda2
----pass kmiranda34

--insert into Empresas (Id,RutDocumento,RazonSocial,NombrePropietario,Rubro,Direccion,Ciudad,Descripcion,Latitude,Longitude)
--Values (1,'123456789012','Una Empresa', 'Kevin Miranda', 'Peluqueria','18 de Julio - 11','Montevideo','Una Pelu Piola',-34.84784073123643,-56.17782158777118)

--insert into Empresas (Id,RutDocumento,RazonSocial,NombrePropietario,Rubro,Direccion, Ciudad,Descripcion,Latitude,Longitude)
--Values (2,'123456789013','Una Empresa 2', 'Kevin Miranda 2', 'Peluqueria2','18 de Julio 2 - 12','Montevideo','Una Pelu Piola 2',-34.863847713411204,-56.15342052653432)

--insert into Empresas (Id,RutDocumento,RazonSocial,NombrePropietario,Rubro,Direccion ,Ciudad,Descripcion,Latitude,Longitude)
--Values (3,'123456789014','Una Empresa 3', 'Kevin Miranda 3', 'Peluqueria3','18 de Julio 3 - 13','Montevideo','Una Pelu Piola 2',-34.855488761673755,-56.13270649686456)