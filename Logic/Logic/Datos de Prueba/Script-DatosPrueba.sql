use AgendateApp

go

--Todas las claves de prueba son 123456

insert into Usuarios (
	NombreUsuario, Contrasenia, Correo, Nombre, Apellido, Celular, TipoUsuario,Activo
) values 
	('admin','0350MwGjTiI4C8O8o61/VA==','john@example.com','John','Doe','1234567890','customer',1),
    ('userX','0350MwGjTiI4C8O8o61/VA==','userX@example.com','User','Equiz','545654888','customer',1),
	('0use147rX','0350MwGjTiI4C8O8o61/VA==','userX@example.com','User','Equiz','099654888','customer',1),
	('a1dmin01','0350MwGjTiI4C8O8o61/VA==','john@example.com','John','Doe','094457890','customer',1),
	('0Rob55ert','0350MwGjTiI4C8O8o61/VA==','Robert@example.com','Robert','Dino','094467801','customer',1),
	('1car4ol','0350MwGjTiI4C8O8o61/VA==','carol@example.com','Carol','Gonzaléz','099567812','customer',1),
	('J4uaquin','0350MwGjTiI4C8O8o61/VA==','juaquin@example.com','Juaquin','Mendéz','091567890','customer',1),
	('Roberto01','0350MwGjTiI4C8O8o61/VA==','Roberto@example.com','Roberto','Dinero','1234567802','customer',1),
    ('carolina','0350MwGjTiI4C8O8o61/VA==','carolina@example.com','Carolina','González','094467813','customer',1),
    ('Juanitkio','0350MwGjTiI4C8O8o61/VA==','juanito@example.com','Juanito','Méndez','091567891','customer',1),
    ('userZ','0350MwGjTiI4C8O8o61/VA==','userZ@example.com','User','Zeta','098565489','customer',1),
    ('admifgn3','0350MwGjTiI4C8O8o61/VA==','Jhon@example.com','John','Jones','0924567892','customer',1),
    ('Roben4rta','0350MwGjTiI4C8O8o61/VA==','Roberta@example.com','Roberta','Dinamita','094567803','customer',1),
    ('car4los22','0350MwGjTiI4C8O8o61/VA==','carlos@example.com','Carlos','Gómez','099567814','customer',1),
    ('J1uan4ita','0350MwGjTiI4C8O8o61/VA==','juanita@example.com','Juanita','Méndez','097567892','customer',1),
    ('use4rA44','0350MwGjTiI4C8O8o61/VA==','userA@example.com','User','Aguilar','096654891','customer',1),
    ('a1dmin4','0350MwGjTiI4C8O8o61/VA==','admin4@example.com','John','Johnson','091567893','customer',1),
    ('Roberlto2','0350MwGjTiI4C8O8o61/VA==','Roberto2@example.com','Roberto','Dinosaurio','0994567804','customer',1),
    ('car4la','0350MwGjTiI4C8O8o61/VA==','carla@example.com','Carla','González','092567815','customer',1),
    ('Ju5anc0ho','0350MwGjTiI4C8O8o61/VA==','juancho@example.com','Juancho','Méndez','099567893','customer',1),
    ('use5rpB','0350MwGjTiI4C8O8o61/VA==','userB@example.com','User','Bellido','091654892','customer',1),
    ('admin5','0350MwGjTiI4C8O8o61/VA==','admin5@example.com','John','Doe','1234567894','customer',1),
    ('Roberta2','0350MwGjTiI4C8O8o61/VA==','Roberta2@example.com','Roberta','Dinamitada','096567805','customer',1),
    ('carl5os2','0350MwGjTiI4C8O8o61/VA==','carlos2@example.com','Carlos','Gómez','091567816','customer',1),
    ('Juan5ita23','0350MwGjTiI4C8O8o61/VA==','juanita2@example.com','Juanita','Méndez','092567894','customer',1),
    ('use5rC','0350MwGjTiI4C8O8o61/VA==','userC@example.com','User','Cabrera','0935654893','customer',1),
    ('admin6','0350MwGjTiI4C8O8o61/VA==','admin6@example.com','John','Smith','096567895','customer',1),
    ('Rop5berto3','0350MwGjTiI4C8O8o61/VA==','Roberto3@example.com','Ricardo','Peralta','095567806','customer',1),
    ('car5olpina2','0350MwGjTiI4C8O8o61/VA==','carolina2@example.com','Carolina','Goméz','098567817','customer',1),
    ('Juapnito2','0350MwGjTiI4C8O8o61/VA==','juanito2@example.com','Juanito','Méndez','099567895','customer',1),
    ('user5D','0350MwGjTiI4C8O8o61/VA==','userD@example.com','User','Delgado','097654894','customer',1),
    ('adpmin7','0350MwGjTiI4C8O8o61/VA==','admin7@example.com','John','Jones','094567896','customer',1),
    ('Robperta3','0350MwGjTiI4C8O8o61/VA==','Roberta3@example.com','Roberta','Dinamita','097567807','customer',1),
    ('car5los3','0350MwGjTiI4C8O8o61/VA==','carlos3@example.com','Carlos','Gómez','099567818','customer',1),
    ('Juanita3','0350MwGjTiI4C8O8o61/VA==','juanita3@example.com','Juanita','Méndez','091567896','customer',1),
    ('useprE21','0350MwGjTiI4C8O8o61/VA==','userE@example.com','User','Escobar','092654895','customer',1),
    ('sebas83','0350MwGjTiI4C8O8o61/VA==','admin8@example.com','Sebastian','Marset','096567897','customer',1),
    ('Michael45','0350MwGjTiI4C8O8o61/VA==','Michael4@example.com','Michael','Roman','098567808','customer',1),

    ('jose','0350MwGjTiI4C8O8o61/VA==','panaderia@example.com','Jose','Panadero','9876543210','company',1),
	('pelu1','0350MwGjTiI4C8O8o61/VA==','pelu1@example.com','Ana','Gonzales','54656543001','company',1),
	('abm','0350MwGjTiI4C8O8o61/VA==','abm@example.com','Jorge','Belloni','50002543001','company',1),
	('sofi','0350MwGjTiI4C8O8o61/VA==','sofipelu@example.com','Sofia','Rodriguez','098888011','company',1),
	('mauro','0350MwGjTiI4C8O8o61/VA==','mauro.taller@example.com','Mauro','Perez','092789789','company',1),
	('jopselo13','0350MwGjTiI4C8O8o61/VA==','panaderia@example.com','Jose','Panadero','099543210','company',1),
	('pelupo11o','0350MwGjTiI4C8O8o61/VA==','pelu1@example.com','Ana','Gonzales','099543001','company',1),
	('ab111mp33','0350MwGjTiI4C8O8o61/VA==','abm@example.com','Jorge','Belloni','0992543001','company',1),
	('sofpi2','0350MwGjTiI4C8O8o61/VA==','sofipelu@example.com','Sofia','Rodriguez','091888011','company',1),
	('papnaderia12','0350MwGjTiI4C8O8o61/VA==','panaderia1@example.com','Jose','Pastelero','097543211','company',1),
    ('pelpu22','0350MwGjTiI4C8O8o61/VA==','pelu2@example.com','Ana','González','093543002','company',1),
    ('a124pm23','0350MwGjTiI4C8O8o61/VA==','abm2@example.com','Jorge','Beltrano','0912543002','company',1),
    ('sofpi214','0350MwGjTiI4C8O8o61/VA==','sofi2@example.com','Sofia','Rodriguez','098888012','company',1),
    ('panadperi1a222','0350MwGjTiI4C8O8o61/VA==','panaderia2@example.com','Jose','Panadero','094543212','company',1),
    ('pelup333','0350MwGjTiI4C8O8o61/VA==','pelu3@example.com','Ana','González','098543003','company',1),
    ('abmp3k1','0350MwGjTiI4C8O8o61/VA==','abm3@example.com','Jorge','Belloni','093543003','company',1),
    ('sofpi310','0350MwGjTiI4C8O8o61/VA==','sofi3@example.com','Sofia','Rodriguez','098888013','company',1),
    ('panapderia31','0350MwGjTiI4C8O8o61/VA==','panaderia3@example.com','Jose','Panadero','091543213','company',1),
    ('p2elup4','0350MwGjTiI4C8O8o61/VA==','pelu4@example.com','Ana','González','094543004','company',1),
    ('abpm4','0350MwGjTiI4C8O8o61/VA==','abm4@example.com','Jorge','Belloni','097543004','company',1),
    ('sofipp4','0350MwGjTiI4C8O8o61/VA==','sofi4@example.com','Sofia','Rodriguez','098888014','company',1),
    ('panpaderia425','0350MwGjTiI4C8O8o61/VA==','panaderia45@example.com','Jose','Panadero','098765432','company',1),
    ('pelu4500','0350MwGjTiI4C8O8o61/VA==','pelu45@example.com','Ana','González','095465430','company',1),
    ('ab44mp45','0350MwGjTiI4C8O8o61/VA==','abm45@example.com','Jorge','Belloni','099543045','company',1),
    ('sof21211ip45','0350MwGjTiI4C8O8o61/VA==','sofi45@example.com','Sofia','Rodriguez','098888055','company',1),
	('mau21r1po','0350MwGjTiI4C8O8o61/VA==','mauro.taller@example.com','Mauro','Perez','092789789','company',1)
;

go

insert into Clientes(
	Id, Documento
) values 
	(1, '47659893'),
	(2, '35465878'),
	(3, '4765093'),
    (4, '1203478'),
    (5, '7012340'),
    (6, '5670012'),
    (7, '3450890'),
    (8, '4605878'),
    (9, '4678901'),
    (10, '8902345'),
    (11, '678901'),
    (12, '355701'),
    (13, '234589'),
    (14, '569012'),
    (15, '443457'),
    (16, '454780'),
    (17, '3457290'),
    (18, '670123'),
    (19, '890145'),
    (20, '343456'), 
    (21, '214567'),
    (22, '126891'),
    (23, '565012'),
    (24, '578123'),
    (25, '490145'),
    (26, '223456'),
    (27, '136789'),
    (28, '245890'),
    (29, '567010'),
    (30, '670121'),
    (31, '892340'),
    (32, '123470'),
    (33, '236789'),
    (34, '345690'),
    (35, '5678120'),
    (36, '6734523'),
    (37, '9876543'),
    (38, '8844667')
;

go

insert into Empresas (
	Id, RutDocumento, RazonSocial, Direccion, Rubro, Descripcion, Latitude, Longitude, NombrePropietario, Ciudad, Logo
) values
	(39, '100005001234', 'Panaderia y Rotiseria.', 'Vilardebo 4565','Gastronomia','Panaderia y Rotiseria donde podes realizar tu reserva de pedido y venir a retirar...', -34.84784073123643, -56.17782158777118,'Jose','Montevideo',''),
	(40, '100123451234', 'Peluqueria El Tato.', 'Av Gral Flores 3175','Estetica','Peluqueria donde encontraras...', -34.87687835086815, -56.18044914677739,'Ana','Montevideo',''),
	(41, '100123450000', 'ABM Tatú.', 'Rivadavia 1234','Estetica','Local de tatuajes, pedi tu reserva para venir a realizarte los mejores tatuajes...', -34.88075873144812, -56.17954256013036,'Jorge','Montevideo',''),
	(42, '100123451200', 'Peluqueria Sofia.', 'Guadalupe 123','Estetica','Cortes, brushing y mas, todo unisex....', -34.87917915703534, -56.16783572360873,'Sofia','Montevideo',''),
	(43, '100050001234', 'Taller Mauro.', 'Ofelia Machado Bonet 1548','Automotriz','Taller donde podes reservar con anticipacion una revision sin costo... \n Gomeria, chapa y Pintura', -34.846390668781666, -56.23299362137914,'Mauro','Montevideo',''),
    (44, '100987654321', 'MyMBarbería', 'Gualeguay 3355', 'Peluquería', 'Cortes unicos.', -34.867454968378674, -56.170369443929275, 'María', 'Montevideo',''),
    (45, '100876543210', 'salón Colonial', 'Dr.Juan Camisteguy 2921', 'Salon', 'Salón para todo evento .', -34.87338859431686, -56.16882303731943, 'Carlos', 'Montevideo',''),
    (46, '100654321098', 'Masajes al Alma', 'Charrúa', 'Masajes', 'Masajes de alta calidad.', -34.90556868296726, -56.16377949857722, 'Raquel ', 'Montevideo',''),
    (47, '100543210987', 'Rebel Peluquería', 'Juan María Peréz 2833', 'Peluquería', 'Peluquría de alto nivel ', -34.87654321098765, -56.20789012345678, 'Laura', 'Montevideo',''),
    (48, '100432109876', 'Painville Tatto', 'Francisco Araúcho 1374', 'Tatuajes', 'Estudiio de tatuajes profecionales con más de 10 años ', -34.90342693768367, -56.16147531691662, 'José', 'Montevideo',''),
    (49, '100321098765', 'Tatuajes 26', '26 de Marzo 1281', 'Tatuajes', 'Estudio de tatuajes con artistas especializados en diversos estilos.', -34.90849794284651, -56.1475394248725, 'Marcela', 'Montevideo',''),
    (50, '100210987654', 'Be yogi, be young', 'C.Jaime Cibils 2835', 'Yoga', 'Centro de yoga con clases para principiantes y avanzados.', -34.88504386504662, -56.153585507934544, 'Eduardo', 'Montevideo',''),
    (51, '100109876543', 'Peluquería el Tato bsrbershop', 'Dr. Manuel Landeira 3436', 'Barbería', 'Tu pelo, nuestro compromiso.', -34.892466400565326, -56.0924870246575, 'Tato', 'Montevideo',''),
    (52, '100098765432', 'Café Bohemia bar', 'Av.de las Americas 7852', 'Gastronomía', 'Café y bar con un ambiente bohemio y opciones de comida gourmet.',-34.86958770026516, -56.02679339169592, 'Gabriel', 'Montevideo',''),
    (53, '100907654329', 'Clinica Dental D', 'Miravlles 4437', 'Salud Bucal', 'Consultorio odontológico  con el respaldo de MSP ', -34.89031690224368, -56.12041598750196, 'Lucía', 'Montevideo',''),
    (54, '100816543219', 'Yoga Pilates Malvin', 'Mississipi 1526', 'Yoga', 'Centro de Yoga con  especializados en técnicas relajantes.', -34.79876543210987, -56.23122345675432, 'Javier', 'Montevideo',''),
    (55, '100725432109', 'Psicóloga Laura Capi', 'Av.Italia y Candelaria', 'Psicológa', 'Psicoológa egresada en udelar', -34.88701556462457, -56.11091385228516, 'Laura', 'Montevideo',''),
    (56, '100634321090', 'Golden Quiropráctica', 'San Jose 1073', 'Quiropráctico','La salud de tú cuerpo no puede esperar', -34.906173651060215, -56.19255412985705 ,'Jose','Montevideo',''),
    (57, '100543210981', 'Técnica en Pedicuría ', 'Chiringuanos 2702', 'Pedicura', 'Técnica en pedicuría profecional y Terapeuta', -34.878974612950714, -56.163826116898626, 'Valeria', 'Montevideo',''),
    (58, '100452109872', 'Uñas Carol', 'Carlos María Ramirez 3563', 'Uñas', 'Uñas esculpidas, Uñas Gel y todos los diseños que imaginas', -34.873905648773814, -56.248513111450904, 'Carol', 'Montevideo',''),
    (59, '100361098763', 'Old Barber', 'Av.Carlos María Ramírez 1547', 'BarberShop','Cortes modernos a tú medida', -34.873810530255, -56.247545980442716, 'Fernando', 'Montevideo',''),
    (60, '100270987654', 'Gomería La Maquina ', 'Carlos María Ramírez 1838', 'Gomería', 'Todos los repuestos y gomería ', -34.87437767877278, -56.25425033510361, 'Luis', 'Montevideo',''),
    (61, '100280987654', 'tatuajes SINALOA', 'Shakespiere 1610', 'Tatuajes', 'Tatauajes impreresionantes.', -34.82158305414252, -56.19590582687553, 'Luis', 'Montevideo',''),
    (62, '100290987654', 'Topdent Clínica Dental', 'Hilario Ascasubi 4260', 'Odontología', 'Nos ocupamos de tú sonrisa.', -34.86521222324026, -56.23241900986077, 'Marcos', 'Montevideo',''),
    (63, '100280987114', '', '', '', '', 0.00, 0.00, '', '', ''),
    (64, '100290987004', '', '', '', '', 0.00, 0.00, '', '', '')
;

go

insert into Servicios (
    Nombre, HoraInicio, HoraFin, DiasDefinidosSemana, DuracionTurno, TipoServicio , Costo, Descripcion, empresaId,Activo
) values
    ('Entregas a Domicilio', 9.0, 18.0, 'Lunes;Miercoles;Viernes', 30, 'Gastronomia', 300.00,'Realizamos pedidos', 39,1),
    ('Corte de Pelo', 9.0, 18.0, 'Lunes;Miercoles;Viernes', 1, 'Peluquería', 300.00,'Degradado y barba', 42,1),
    ('Masaje Relajante', 10.0, 20.0, 'Martes:Jueves;Sabado', 1, 'Centro de Masajes', 800.00,'Masajes ', 46,1),
    ('Café Gourmet', 8.0, 17.0, 'Lunes;Martes;Miercoles;Jueves;Viernes;Sabado;Domingo', 24, 'Cafetería', 500.00,'Date un gusto', 52,1),
    ('Clases de Yoga', 17.0, 18.0, 'Lunes;Miercoles', 1, 'Centro de Yoga', 250.00,'Yoga para el alma', 54,1),
    ('Sesion de Quiropráctica', 7.0, 15.0, 'Lunes;Martes;Miercoles;Jueves;Viernes;Sabado;Domingo', 1, 'Quiropráctica', 150.00,'Aliviamos tu cuerpo',56,1),
    ('Tatuaje Personalizado', 13.0, 19.0, 'Viernes', 30, 'Estudio de Tatuajes', 1500.00,'El tatuaje ideal ', 61,1),
    ('Consultas Dentales ', 9.0, 19.0, 'Lunes;Jueves', 30, 'Clinica dental', 500.00,'Tú sonrrisa Lista', 62,1)
;

go

insert into Reservas(
    ClienteId, ServicioId, FechaRealizada, FechaHoraTurno, Estado
) values
    (1,1, '2023-12-12 00:00:00', '2024-01-01 09:00:00', 'Realizada'),
    (1,1, '2024-04-02 00:00:00', '2024-01-01 09:30:00', 'Realizada'),
    (3,3, '2024-06-03 00:00:00', '2023-12-12 00:00:00', 'Cancelada'),
    (4,4, '2024-07-12 00:00:00', '2023-12-12 00:00:00', 'Pendiente'),
    (5,5, '2023-12-05 00:00:00', '2023-12-12 00:00:00', 'Realizada'),
    (6,6, '2024-03-09 00:00:00', '2023-12-12 00:00:00', 'Pendiente'),
    (7,8, '2024-08-01 00:00:00', '2023-12-12 00:00:00', 'Rechazada')
;

go

insert into Favoritos(
    ClienteId,ServicioId,recibirNotificaciones
) values
	(1,1,1),
	(1,2,1),
	(1,3,0),
	(1,4,1),
	(1,5,0),
	(1,6,1),
	(1,7,1),
	(1,8,1),
	(2,3,0),
	(2,4,0),
	(2,5,0),
	(2,5,0)
;

go

