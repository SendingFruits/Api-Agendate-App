use AgendateApp

go

--Todas las claves de prueba son 123456

insert into Usuarios (
	NombreUsuario, Contrasenia, Correo, Nombre, Apellido, Celular, TipoUsuario,Activo
) values 
    -- Para Defensa
	('admin','0350MwGjTiI4C8O8o61/VA==','admin@agendate.app.com','AdminUser','Administrador','1234567890','customer',1),
    ('john','0350MwGjTiI4C8O8o61/VA==','johnsnow@gmail.com','John','Snow','545654888','customer',1),
	('ilena','0350MwGjTiI4C8O8o61/VA==','ibalciunas@bios.edu.uy ','Ilena','Balciunas','099654888','customer',1),
	('santi','0350MwGjTiI4C8O8o61/VA==','sandela91@gmail.com','Santiago','Delacroix ','094457890','customer',1),

	('esteban','0350MwGjTiI4C8O8o61/VA==','estebanpiccardo1989@gmail.com','Esteban','Piccardo','098790944','customer',1),
	('kevin','0350MwGjTiI4C8O8o61/VA==','kevinmiranda621@gmail.com','Kevin','Miranda','099567812','customer',1),
	('german','0350MwGjTiI4C8O8o61/VA==','germantexeira@gmail.com','German','Texeira','091567890','customer',1),

    -- Otros
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

    -- empresas
    ('jose','0350MwGjTiI4C8O8o61/VA==','panaderia@example.com','Jose','Panadero','9876543210','company',1),
	('pelu1','0350MwGjTiI4C8O8o61/VA==','pelu1@example.com','Ana','Gonzales','54656543001','company',1),
	('abm','0350MwGjTiI4C8O8o61/VA==','abm@example.com','Luciano','Gonzales','50002543001','company',1),
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
    ('jgolden','0350MwGjTiI4C8O8o61/VA==','josegolden@example.com','Jose','Golden','091543213','company',1),
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

insert into Clientes (
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
	(41, '100123450000', 'ABM Tatú.', 'Rivadavia 1234','Estetica','Local de tatuajes, pedi tu reserva para venir a realizarte los mejores tatuajes...', -34.88075873144812, -56.17954256013036,'Jorge','Montevideo',
        '/9j/4QBYRXhpZgAATU0AKgAAAAgABAEAAAQAAAABAAAA4QEBAAQAAAABAAAA4YdpAAQAAAABAAAAPgESAAQAAAABAAAAAAAAAAAAAZIIAAMAAAABAAAAAAAAAAD/4AAQSkZJRgABAQAAAQABAAD/4gIoSUNDX1BST0ZJTEUAAQEAAAIYAAAAAAIQAABtbnRyUkdCIFhZWiAAAAAAAAAAAAAAAABhY3NwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAA9tYAAQAAAADTLQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAlkZXNjAAAA8AAAAHRyWFlaAAABZAAAABRnWFlaAAABeAAAABRiWFlaAAABjAAAABRyVFJDAAABoAAAAChnVFJDAAABoAAAAChiVFJDAAABoAAAACh3dHB0AAAByAAAABRjcHJ0AAAB3AAAADxtbHVjAAAAAAAAAAEAAAAMZW5VUwAAAFgAAAAcAHMAUgBHAEIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFhZWiAAAAAAAABvogAAOPUAAAOQWFlaIAAAAAAAAGKZAAC3hQAAGNpYWVogAAAAAAAAJKAAAA+EAAC2z3BhcmEAAAAAAAQAAAACZmYAAPKnAAANWQAAE9AAAApbAAAAAAAAAABYWVogAAAAAAAA9tYAAQAAAADTLW1sdWMAAAAAAAAAAQAAAAxlblVTAAAAIAAAABwARwBvAG8AZwBsAGUAIABJAG4AYwAuACAAMgAwADEANv/bAEMAUDc8RjwyUEZBRlpVUF94yIJ4bm549a+5kcj////////////////////////////////////////////////////bAEMBVVpaeGl464KC6//////////////////////////////////////////////////////////////////////////AABEIAOEA4QMBIgACEQEDEQH/xAAZAAADAQEBAAAAAAAAAAAAAAAAAQIDBAX/xAAvEAACAgEEAQIEBQUBAQAAAAAAAQIRIQMSMUFRImETMnGBBEKRofAjUrHB4WLR/8QA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'),
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
    (56, '100634321090', 'Golden Quiropráctica', 'San Jose 1073', 'Quiropráctico','La salud de tú cuerpo no puede esperar', -34.906173651060215, -56.19255412985705 ,'Jose','Montevideo',
        '/9j/4QBYRXhpZgAATU0AKgAAAAgABAEAAAQAAAABAAAEsAEBAAQAAAABAAACdodpAAQAAAABAAAAPgESAAQAAAABAAAAAAAAAAAAAZIIAAMAAAABAAAAAAAAAAD/4AAQSkZJRgABAQAAAQABAAD/4gIoSUNDX1BST0ZJTEUAAQEAAAIYAAAAAAIQAABtbnRyUkdCIFhZWiAAAAAAAAAAAAAAAABhY3NwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQAA9tYAAQAAAADTLQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAlkZXNjAAAA8AAAAHRyWFlaAAABZAAAABRnWFlaAAABeAAAABRiWFlaAAABjAAAABRyVFJDAAABoAAAAChnVFJDAAABoAAAAChiVFJDAAABoAAAACh3dHB0AAAByAAAABRjcHJ0AAAB3AAAADxtbHVjAAAAAAAAAAEAAAAMZW5VUwAAAFgAAAAcAHMAUgBHAEIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFhZWiAAAAAAAABvogAAOPUAAAOQWFlaIAAAAAAAAGKZAAC3hQAAGNpYWVogAAAAAAAAJKAAAA+EAAC2z3BhcmEAAAAAAAQAAAACZmYAAPKnAAANWQAAE9AAAApbAAAAAAAAAABYWVogAAAAAAAA9tYAAQAAAADTLW1sdWMAAAAAAAAAAQAAAAxlblVTAAAAIAAAABwARwBvAG8AZwBsAGUAIABJAG4AYwAuACAAMgAwADEANv/bAEMAUDc8RjwyUEZBRlpVUF94yIJ4bm549a+5kcj////////////////////////////////////////////////////bAEMBVVpaeGl464KC6//////////////////////////////////////////////////////////////////////////AABEIAnYEsAMBIgACEQEDEQH/xAAZAAEBAQEBAQAAAAAAAAAAAAAAAQIDBAX/xAAwEAEBAAIBBAECBQIGAwEAAAAAAQIRIQMSMUFRMmEEEyJxgTORFCNCUnKhQ2KxU//EABYBAQEBAAAAAAAAAAAAAAAAAAABAv/EABcRAQEBAQAAAAAAAAAAAAAAAAABEUH/2gAMAwEAAhEDEQA/APaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA5fn471Jbd+m+pu4WS6tcej07L3ZcaEd3PLr443U5Op1J2XV3+zzBa9eGczm428WOVxu55ejDq3OcY/9hK6jHfrzjlP4WZ45eLBWgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEtkm7Ut51OaTHnd5oOXXytxnGps6EmWNt5u/a9bKSyZTcq9HKZbmM1II3ljvCz7PG9zx9XHt6lgVlccrjdxAZevDOZzc/stxmXmbeTHK43cuq9PT6sz4vFGpV7bPpy/ikz51lNVtLJZq8iqOfOHjdx/7jcss3PAKAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAzbd6nn/wCFup9/S4zU+4EmlAHn/EznGn4be78N9bO4SWa/lyw6ly6uO/HwJ16nD8RjuTKftXdMpMpZfYrxBlLjbL6BgPAA9PR6nfNXy6vDLcbLPMezDLuxlg1K0xZ23ux/mNgqSyzc8Kxf0Zb/ANN8/ZsAAAAAYzzmN1zbfUZ/Ns+rCyfIOo55Z6skndv7nfn/APn/ANg6DFzkzmN9tgDEztlsx3q68s/mZd2vy+f3B1HO9Szt/RzfW0vUynOWFkB1E3Nb3w5/mW/ThbPkHUYx6kyuuZfitgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAzl418gTm939mkUAAGOrjc8NTy4TD8u92fieJ8vS8nVxuOerbfiiV6ennM8dz+Y28vQtme/WuXpl3OAjl1+n3TunmPO9rj1elud2Pn3AsY/D6/M5+G/wARhNd0/lxxy7cpfh6s9ZdK/sJHkdvw+Wsrj8uK43tyl+BHtEUbSzc1WcLreN8xtjPizL44v7A2AAADl0ed53za6OUv5WVl+m3crV6uM8Xd+IInUvb1cLq3z4anU3dduU/eM52Tq4W8cXy3+Zh/un9wYzxmXV1f9q4ZXfbl9U/7P/PP+K9TG2bx+qeATpeMv+VJ/Xv/ABTo845X/wBln9e/8QTqXXU6dvjlcuph23mX7ROpN9TCX7nUxmMmWMm8QZ1e3p4X35dmM53YzLHzOYTq42c3V+KB1prHv94ujlcvzbJj9MvNdRQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABnzl+zTOPu/cGgAAS3U3QVjqYTOczx8Jh1ZnncZOPl0B48suLjjNT230epZZjeZW+r0e7LeOp8s44zpS5ZWW+tDLurh0urz25X9q7jTy9bDty3PFdOld9C79ba62Nyw4m6zZ+X+Hs9iPOAMvX0rvp437NuX4e76f7V1GxLNyz5UBnC7wm/PtpjDjLKffbYAAJUmMniSL4JlL4soFxl8yVOzH/bP7LbogGpvftU3N69m5vW/AGtGpveuU78f90/usss4uwNT4BJlLdSz+4LJJ4LjL5kqs9+P+6f3BVTad+P+6f3BoSXZbryCgm5fFBRNyeabnyCib15UAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABnH6Z+zTOH0z9gaAAef8Rnz2Tx7d7xHit3bb7Ert0NY45Z3x4b6fV78rNaefLLcmM8Rvp53HWOE3b5vyJr03mPHnj2Z2PazlNzxN/cWvL08O/LnxPL0YdSZ2yenDLqZauNknyxLZdzyI9zn1sbnhrH5Xp5zPHfv22NPH1Me3KYz011se24z7O16WNz7vbH4jG3tsmxnF/Dz9F/d2Zwx7cJGhoABif1b95G2P/L/AA2AADlJ+bbll9MvEW9LGziavzDo8Y9nvFsRy7relnMvM4rph9GP7Oc/Vj1Mp4vh06d3hj+wM3+vP+J0/wCp1P4Tz1/2xXp/1Op/AM9PDHKZWyX9VNTDq49vjLzE6eOV7tZa/VfS9KbyyuV3lOAWz8zOy39M/wC1vSws8HT/AE55Y3zvboDn07Zbhld68X5jPSwxyw3ZLWsf1dXLKeJNMdOZ3D9OUk/YFx/TnljPGtnSwxvTluM21jh2y87t81jp453pyzPX20DWM7OrccfFm9fB1d5WYT3zTo67blfq97Zwz/Vll25XfjU9A6dPLuw58zis5/o6kz9Xipjlrq3iyZfM9r1bvWE85AYfrzud8TiL0/6nU/eJ0rreF84rh/U6n8AnV3lZhPfNa6WXdhz5nFc8Mt5ZZ9uV341PS45a6t4smXz8g7ACgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADOP0z+zTM82fcGgAY6t108nkej8Rf0T93nGaO/SxmGPflw5dPHuzk9e3T8ReZj6COvTzmctkbcvw/9P+XUacOr0u7Lux199uf5Oe9aejqY92FjyzLKeLYM1175085jPpnl3eJ6ujbenN+hZXQAUAAABic9TL7SRtjDnuvzWwAAYywmV3uy/Mc+pjljJcsrljvl3SyWavgCSSanhj8qy/pyuM+G5JJqeFBjDCYTjm3zauOOssrvy0Azhj2y873dp2f5ndLr5jYDGeEy+1nixn8vK8XqXTqAmOMxmp4TDHsx1vbQCekwx7cZjvemgHO9PnLV13N4ztkk9KAxnj3Sc6su5THDWVyt3a2AxcN5zKXVn/aXp/Xz9ToAmM7ZJPSZ490nOrLuVoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZvGU+/DSZTc+4KJLubUHD8T9OP7uD0fiJ+ifu84zXf8NPqv8ADP4j65+zX4ezts9sde76n7cBx0/DX9NnxXZ5Ojl25z4vD1iwebPo3vurP2el5vxH1y/YKmPSsu8+MY69Lqd9sk1J4ebds1u6+HT8PddTXzBI9QA0AAM53txt9+mmL+rOT1jyC4zWMnw0AAAMYZXK5b9XR1MrhhuJ0vOf/I6/9P8AkQ6mWUuMx1u/KXLqYzdxln2OrZjnhb45L1cbNY7tviaBcs9Y42eLXRxyx7elhL/ujsKxjlbnlPhMs7cu3Cbs81mXWXVrXRmunPvyInfnjf148X3GrlZ1McfVW54y6tm2cv62H7UHRjp5XLDdbcule3o7vrYq/mT83sXqZXGSybntz7L+V3f6t9zrjZnjL6oi907d74Z6eVym7NS+HOY3v/L3+mcuwqgAAAAAAAAAAAAAAAAAAAAAAAAgKAAIAoAAAAAAAAAAgCgAAAAAAAAAAAAAAAAAAAAAAAAAAAAgKIAogCgACAKIAogCiAKAAAAAAAAAAAAAAAAAAAAIAoAAAM+MvtWks3NVJdXtvn19wTqzu6djyPa8nUx7M7PXoSs+ABkezC92Ev2eN6uh/SgsdHLrdPv1qzbo4/ifpx/cWuX5efdrtrt0scccrJzlPNcZ1M5Nd1dfw3+qiR3AGgEtkm74BM8u2ff0Y49s+/tMZ3Xuv8RoFAAABy3+XnbZvHLnc9JlfzdY4y6912Ac8/6nT/k6s/TMp5x5dAHPOfmdOXHz5ifnTXMsvxp1Ac+njf1ZZTnL0zLelxZbj6sdgHDPKdSaxxtvzpvqS7xyxm7PTogjnerLNYy3L40zceMen8812AY/L/8AfP8AunS/TlcPjmOgKxP69/4ugAAAgAKAAAAAAAAAAAACAogCoAAAAAAAAAAAAAAAAAAAAAAAAAKIAogCiAKIAogCiAKIAogAAAAAAAAAAACAoAAAAAAAAAAAAACoAoAAAAAAAAACAAAAAAACgAAAJZuKAzLzrLz/APWOvh3Y7nmOlks1WecfPM/7B5Bc5JldeEGB6eh/T/l5nq6E/wAqCxtz62PfJJZv4dHm69/zP2FrHZlLrtu3o6ONxxu/Nrlj1M8tYy/y9M4gRQYufOpzfgVq2SbrMlzu8uJ6hMd3eXN/+NAoigAAAAAAAAAAAAAAAAAAAAAAgqAAAogCoACoAogCiAAQAAAEAUQABAUEBRAFEAUQBRAFEAUQBQQFEAaEAUQBRAFEAUQBQABAFEAUQBRAFEAUQBRAFQSgqbTZsGhJVAAAAAAAEAUAAAFEUAAAAAAAAAAAAEoVAUAFEAaAAAAABBUBx/EY8TKfy4PZnj3Y2fLx2auqM0erpWdmM3PDzY43LKSPX24+5L/ARbdS2+nnyuHUndvtya6uE7bMJNzzpyw6dyyksuha69OYYc9266d1v043+eFkk8TSis9ty+rL+I1JJNSaAAAFBAURQAABAFEAUQBRAFEAUQBRAFEAAAAAAAAAAAAAAAAASKzeKoAeWfYKCAohsFEANlQl9AuxLxTYLsQBRAFEAUQBRAGkEBRAGhJQFENgqsqCiAKIAogCiAKIAogAIAogCiAKIAogCJsyZ2DcrW3KXl0gKIAogCiAKIAogCiAK0w0CgAAAAAAAAAgADN8qzURVZUGolpEyuhXQBQAAAARQEYz6WOd3fP2dEBnDp44eIdTOYY7aAeXHHPPLc3+704zU1vagYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIIC3mMyql45BUvMSVdgkqplN+ElBpEAUQASqgL5ibJSgbVnazwCiAKIoAICiANCAAgC7XbK7BoZUFEAUQBRDYKIAogCiAKIAqCAqsqCiAGxNmwXYmzYJWdtMXyBt0xvDltrDLnQOggCiAKIAogCiCKogCtxhqUGhBUAAAAAAAAEVASorKIoEBpzzrdcrd1KPSINKogCiAKIAogAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIIKAoAACKAAAggAJsA88IAngW8xnwC7TKe4EoJKu0ynuJKDWxAFQAF2gCXhZRIgptBRVQBRAAQ2DUEiggICqysBVQBRAFEAXZtAF2bQBRAFEAUQBdoAAigqAAIgNDIC1nJUoMm0oDtjd4q5YXVdhURpAQUQxABQE2gogDTWLC41UroIqoAAAAAAAAiKAmk0u0tRAibNgZXhicrlSThB3AaUAAAAAAAAAAAAEUAAAAAAAAAAAAAAAAAAAAAAAAAAAAEAQFQAAUAAVKIACAIACCAsShKCBYgLKmU9wNgSiWe4soAAAAKaQ5QEWpVFlXbmu0G9CY5eq1Yoyi1AahWcfLdBkEAWIA0JFBUAF2mwAAAABRAFQAAABNoCqyoKJs2AJtAVWQFtS1LUAqKgqx2xu44xvC6QdBAVUNptBUTaXKAtptjvNitbNs7Ablaxrm3j5VK6qkFZAAAAAAAAEtWs0EtRURDSoAUioDsAqgAAAAAAAAAAAIqKAAAAAAAAAAAAAAAAAAAAAAAAAAAioAAgAAAKAFBAqAIVAAQAABAA9IAAAG0s0CACgKgChI3JIKzMLWuyaUBi9Nm9OuoDj2X4WWzy6nAMWM2OrNx2DnPLfpLGpOFRhFvlAQAFjTMUFQANgAAAAAAAAAAgKgACbAVDaAqbQBdm02ACIChFgLGpCRqIoDFyFat0z3fDPmm0Vf3pwIBufBsAFRYCtRFgldZ4VJ4VpkAAAAABE20lgJsZvCdyDSEaEJF0bZtFLUAR2AVQAAAAAAAAAABBFQUUAAAAAAAAAAAAAAAAAAAAAAAAQAAQAEABQAABFEqKgIFQAEBUAAEAABAEAACeV0LoU0sizgNFBEVQABFAE2bBQAPJJo2bXUYzjDtZLHOzSoyABGkigIABsANm0UDZsANmxAXabAF2IAVAA2bQA2bEA2bQA2bEFXZsQRdt4ubrh4RWjbNumd2g1cmdKlukUQ2CrKi6QFABSJrlQVZUjUgjrj4VnHw00yAAAloCs7WAoIBYxli2lQc5l6a2xnNXadwjpLyrGNbAqaWRfAOgCqAAAAAAAAAAAAgUgKAAAAAAAAAAAAAAAAAAAAAAACCogAAAIAABEVQQSqqVNqlEEVAEABAABAVAAAQFI1IKml2ujSKmza6NAmza6NAmza6NIJs2ujSibTbWjSCbNro0CbNro0CbX6jQpWMsdM6de6XilwnpplzitdukBkAAAEUAAAEDQAqUEVDYAIACAIqAAAACgADUuoysltQPLWiTRsVLU3wt5TXCCaFBSVUWAkvysKQFEWA1FiLBHTHw0zPCtMqIArOVVzyvINRYzFgNCAFS1UqDnnXG12yjlcRFwy5ejHw82PFejC8A34ZtLUB2AVQAAAAAAAAAAAEpCkBQAAAAAAAAAAAAAAAAAAAAAAAEAABAAQAAIAqoipQRFSioJUuWvImKioqAIACAogCkFk54QWTd06JJqAqiCKogCiAKIAogCiAKgAAAAlBz6n2dOnP0zbnlN3TtPCxKWJYt9NaVHKxNOljNgMDViAyKAiKAgoCAAgAIAAioACAAACiAFZt3xBVnN06emJZjE7gatZuXoSoptdoQGotQ2AoCgAKqKCxYkankRr0b0qWNMrLtXOXTUoK5ZX9TpfDjlf1IN7alc9tSg1tWdrKo1Eq+kBmxm4t2s7RGMouF0uXhmfIO05NM43h0grYCgAAAAAAAAAAACECAoAAAAAAAAAAAAAAAAAAAIAAAAAAAgAAAQCotQVEVAEqpRWbWLfs1UQY3Zy1MpVZsUxpGZbOL4XexFNpsEUhHXDD3VVmY2tSab0mkEF0aBBdGkEF0aMEF0aMERrRoGRdGhUF0aBBdGgQNGgAAJJGowsqo3Vl2yl3jdwG0sJltVRixLG2bAY0aasQGRbEBBUBBUBCgCAAgqAIoCKAAM5X0iplkuKY475a1oUtjJU5lBrSstIJZ8Juy8KoEvypo0AsvyjUFD2qApAgityMTy7ScKlZ2bWxmiJYk4NpaDe+HDL6m7WL5BY1GYqI1tqOe2pVG7UNpldQGM8t3TUl0zhN3bpoGMqx3N5uW+RXTHJ2leeXl1wuwegBQAAAAAAAAAAABKFRBoBQAAAAAAAAAAAAAAABAAAAAABLU2DQzs2DQmzYKqTlQSoURUFQERUFSstVlBKla0lgrnWfHh0sZsBZdrIzjOeXow1jFZMMNc10TZtUURQAAAAAQFEAUQBUAAAAADSXhWbyioi6AQioDUq3lnaygxd41qZyrlNxxsuNB6Jdlccc9Osu1QZaSwGaljSUGUaQERpmgIoCIqAAavwALMb7NAyN6kS5SAxldMzHfNa1cub4W7RU5E0CrpLFl2b2gkal4Z0cwGtJpZyoMxpFABfQAALKm2bW8ZwC4+XaXhw8V2xu4sRbWLWrGLKIzWbWrtmwGbSVLGfCI6TyWsSrbwCy7ajGLcBuMdS+mt6jl5yUdenOHSs4Thq0Vx6lcd8unUvLnoRqOuHDlHXEV6gFAAAAAAAAAAAAEoVEVoSKqAAAAAAAAAAAAAAAIAAAAAUKDNRagAAAAN4+Ck8AIAiiKgIigrNGkBlK1WagzdpprRRWNLMrP2E0I7YZ9zpK8vM5jePU9VUsdxJdqqAAAoCCgIKAgoCCgAAAAJUWogIoKiKgAIDW0slQ2DnlhZzFxrpa55TV4BvHqS3VvLbz3GXmeWsepZxkDqiyyzhKqJYioCJWkBnQpQZbw6Vy5vEb6fTnnJ0BznRkrck8aU8g559P3i5/u7+HLqYzLwDlbbeDWr45bmMx8JUajO9pW9IisI1YmgSrE01BBFQVYtSKCKgIptNpaC7S23wnlqQCR0x8MNY8AVcMu2lQR33LGLWcctJmqFsS2OfJoRbYxWu1exBiNLMV0CNxhdguXhnGcteSQHXHiMZ5LbqOOV3VUvLK1IBbp0xvDnYY5aB9ABQAAAAAAAAAAABKi1EFipFUAAAAAAAAAAAAAAEVAAAAAAAZqLUAAAUJ5BtBKKICAACCoAioCCpRUrNaSoM27iNGgZZdEsFMM7jfs6zKXw4pzLuKmPTKrhjnv3y6zL1VZbEl2oAAAAAAAAAAAACVQGRrSaQRFBWajVSwGdhoAEAZs1dxOL58ts3FBOcbw6Y9TbnLZ5WedxR13Klid0vku9cUBExy3dXy122qjNXCXLL7Nzp/Lckk1AUEABLdAW+mKvlEWIzWrGRoSggyFh6BLASAC+kBTbNqbEb2lrFy0TeVUa2SN4YadLhLOPIjlFNaqooqKC7QAGvMZXERLIy3U7RCDN4JRFNwrIq3SAIu12wA1leGZFVVTSyEm29agOefEcd8unUvLnBH0wFUAAAAAAAAAAABKi1EVYoKgAAAAAAAAAAAAIAogAAAAAADNRagAAKuKLiCpVSoqAACAAACKgIKgoy1U0CC2M8oBTRoGRamhWbPhvHP1kzTWxHaZOku48syuN58OmOc9KjuM45y+2lQAAAAAAAAAAAABnKgmVZ3QZaS7TdipQWZfK8MIGN8JWWplNAhtqxmwRLyzzFAWZT2rFm3TpdK73leFDHp3Ku0xmMUVAAA0JcpATK6Y8+Vt3zURQCilrCoglFqCpUWgM2GuWrEAvDGV0Z5bc7ltUW5Ju30Y43K/Z2xwkEYx6e/LtjjIsi6VBqIoJlj3Rz1quplj3fuiuSp4NoqiKA1jjpJOXS+BGGa3pLFRyyrO28oxURdjMq7BU2nK6FNqyoLtdsmwdcaZ1z7k3tQs2mtNxm+RHvAVQAAAAAAAAAAAGaFEVoRVQAAAAAAAAAAABAAAAAAAAAAZqLUAAAajKb5BtDexFEAUAEAAEKCgACKgJtF0AAIIy1UoM63StegGNJ4bs9s6Bccv7umPU+XCxNqmPZM5WnjmbrOpYqO4xj1JWpQUAAAAAAACsZVrK8OdSrBCoy0qABo0F4BLEXYoTLTW5WNJ4EbsSYbawls3XSKiY4TFpFVFQADwly0xu0Grl8M7NoiqAKVNrWQPYCKlRb5TXIGl0RdAlcep1OdR06t41PLlMFSsc1vHp+61JpuQQk4akFVBQAVFAVAEzx7pueXPTsznj7iVWI0zPLSKq+kVUEUEc8o52O9jnYDnpHTSWIjG1kKsFO00u0tBmovldAQWAJtGtM65EfQAaUAAAABKCibUAABNqzUDaFIK0bQA2qKAqKqCKgAAAAAAAAAAAAAAAAMVFqAoiglCgLBYCoFRBQQVRAFQAEVAAAVKmwDRoLQRFvhEBLytIBfhNKUGLGLHXymgc9JzjeK3pLOFCZ/w6Y9SuOqbsB6p1JWpdvJLflrHqWexMerZtzw6ky8tqi7EAUEtAtZpUrLQioigADNrTGV0Bvldue2sZcrwotreHT95f2axxmP3rW1ZUTbNzijYx3/Y3aGN2yM3L4QTTFSqCsi+wAoAiLQEA2ipRPagsMstQjHV9URnzdrEaioNRFVFABQAAAUABUUGLNZDdm4wyrQiqAAiJYoDnYzlXXTNwBxtTbr+WzcUGOTldLBCRrRFFNJYsWxRjS6a0yg9oDQAAAAFAEFQARNoq7E2mwUTYDQgCqigKiqgioAAAAAAAAAAAAAAAADGSLkgAABBqARQBldAgiNIKgpcQQEFBNmwVDaAogAm9KAnlYKggICxlYlAWIAVmxoBjXOiz7NEoMaSx0TSjnLY6Y9W+2bGdBj045y+2pXlm3bpy3m+BMdmatrKKIqIoAAACM3Duu2lnhYlYmEjW/7Kx1PpaRrunyd8cZV3EXG7ncljG17kaxtpzmRepII6Dl+dj7blmU3jdg2JFVEFQBFQAAVKi1KglVKAqdX6YsTqeIqVjHmN6Yx4bVk0oAoKAAAAAqKAACxnKarSZeEENs7WIqqIqKAAACWMZR00zYDjlwxt3yx2z2A57reE2ZY6MctA6yDn3bdICyM3BtQdQFAAAAAAAoAzWWqyigAACCgqgrNyk9ueXX14B23rzTc+Xgz6mWV3akyvzQe69TGe0/Nw+Xi7mblaGPozPG+Kr50tniuk62c9hj2jyf4jNvpdbLLyGPQM9yXMMbGPzDvgY2MfmRZnNhjQCoAAAAxkhlUlBQAG4w1AaABKFSoqptAFlkLkgCXlndjSWIrO8ahljti3LD7wGzbMzl8LsGtm2f2TdBrZtjag1tLUFF9ntlQXZvlAC1WaqC7TaVAaS8EpdCrDTPhZQLOUW3lccd0RcMN37OvjiEmoAIqAgCKAAAAjF6nbxpvK6jz+ao6zqW+i3fliNxRi9Pfg/Lvy6Kgx+X91mDW02KdsYywlbtZtBi9OGH6L9luTGVVHrisdOfojYgipQEogKi1BRF9IgXwkW+EBYnU9EiZXdVKntqM3y0rKgoCooAAAACooAAKXwCDnGontUVUUUABAAFABNJVrGXIOXUyYktdbhur2aBnCO2Phz1prGg6AA6gKAAAAAAAAM1lqsooCWyeRVWRjvk5WW5eOIg1bIxn1JrUY6mU9VztulFzyl42xbNaZ3tPILbim56h2/K60gTXwaibT+VFqcn8puiLsmV+U3UB0/Myntfza5guu2OVvt0k+7yy68OmHU9VGpXbVZ7uWvTnlbbwivT0stx0celdR0mTUYsaE2qsgAOeU2na6aNAxpdNaNAzonDWjQE5UkEEqKmhUFEVBQEFQEsZuLYDhl0fePFZmPUnmPQA4W34Tfy9GmbhKDls21en8OeWOUBdm2dptR02bZ2mwb3wbZ2oLamzYBaJQFEWCnklPZJuoiybuo7449sTDDt59tAIqAIAIKiAAKAlvAMdXLU4c4W92W2ooSNyMzhrYDNy03tnLGWAx3ncz234WdPK+eFNLkm9uk6cn3bmEE1wmNy8R0x6PvJ2kL50qaQQ2jS7EWAlIUQKgoESqlBAAX05+3TL6XNUo3OWfTWPhWVAAVFAAAVABQAABQEGL5Et5WVFagQUABAAFABDSgJpdCgxcWdarqzYBFZjQOoCgAAAAAAADNFc+rl248IqZZc6hMPljp88+2+rl29O1FY/qdTU8R0zsk1Gehj24bvmufUz518gXnm+GM7tcsuGJVFkS6TLL4Y3aDVyTZIaBka0AkXcQEXcOGTQKgcUAAHTDqWO0ywyebgnAuvZj2+mu6fLx91+WpnoHrlN1wx6jpMkHWZNTly2sqmNm2bUNTG9m2QRrZtlrFRpARUFQAABFAQUBABUFEEFQE0ljQDll05XLLpWeOXp0mgeTmG3puEvmOeXRnqg57WVLhlikoNU2myeVG/KUAFnhFlRSuvSw91np4913fDuIgAIACAAIoggAo59TLjUbvy427oEjUSKooALFSKCaUSqY1FjMq70rLVuoY8csb3WgPdTSW8rKy1E8VuM2cHTu5+wLUq1KAqKAlVnLiAAsgF+iucdrP8uuUVlYYqmPlUaBQRQAAAAAVFAAAVC3UQYv1Uib5WIrUVIqgAIKigAAAAoACKKM6WKiDqAoAAAAAloKM7AWuPX5xda5dTnFFY6N/Sv4m/5Uc+ne3Kytde76ekV0xy/yeHnzu8tphnZh2paoZXhnfBldxICyb8+F3IzamxGu7aIbBdm0AXadyGgW1NgBtdoAqCgAAGwBd1vHq3FiNSCu+HUmTe3mk1dx3xu4itm0UDdN0AXudMfDi64+BK0IKioKCAAAAAAIoCAAACiKIIKgImmgGLGMunjfTqaB5culZzGeZ5j16S4y+geWZNSx2vSlY/JBmNYYd1XHpc812xkk4BZNThUUEFQEBAAAAEVAS3QMdS+nPbV5ppQhPKgKCiiooBRAKzcmmb5ExrFpzlalVky8kS3lYjTXpnC/qsa9MY/WDpUKAlurG3LqecXX0CM5emmM/qgK3jHOc12x+lUpfpri736a4qyE8qgKqAKIAogCiaXQGzZpdAmzZpdAMZ31GrxNuW/YK1GNtd8RWo1GJnL6XugNCTKVRBUUAAAFAAAAUAAdAAAAAAKzWqzQSNaSNAzfDGt410vhzl/VpFefOc/di22WV36s1y5Wb59iuULS7l2luwDxEXQiEamF1unAMo1U/cCKaFBNggbEANAoIKgBsUAAFlbjCyium1xvLHfITNFenHwrjj1La6wFAQG8fDDUqjYyoigKgAAAAAAAAAAACCgICoqAAgoCJpQEFARYAKAAioCIqAAAICKMZ301ldRz3tRIKACgCoooqKBWWmc5fMBUqTL00DGjbTFglal5ajlLy6SqRrbGN/Wu0wm8qitrEaEc+p9eLrfDnl9eLdBkynK6TL0C4x0nhnDHUbnhYzS+K4u18VxioqKkBRQE0oAAAAoIqKABALNzVYy6cdAHHtXt+y26qy7BJj9l0uwE0usoaOYB+o3fhZV2CdxuBqAuzbOr6XfyC7O6HFO0DuZuV+FuKaBO+/CfmNaqa35gPQAAAAABWa1WQWKkUB5+rNZbehy6k3NVFcr1NzWTndejOWcViimWmLOVtTYDpjjqbvlzx8t93IjWfOoxrkufKbBbpng2KGxABAAAAAAAQAUEAAVAF8tyM4x1xgq4x1xZkbiKoCA1izG+nFSlNtZTfLILFZUFEBFEFUAAAQAAUQVFAAQBQBAAAABBQAAFBFQRUqKiKgAIigJkDGd2ytRQVFAVFAVFFBQANAM5Yy/uzu4+XRNAm9xm8rcfhAYymm8buJlOGendXQjovT4toY+xW9m0AL9UatZ9xRBU1sx5z+0CuvoBpgv01xjtfprlAE9qQFRUgKAAAAqAKCApPAQBUUEym4xrTo529t58AqpqXmGwVUAVABdiaNgoAJr4XYAuxAAFB1AAAAAARUAVFASzc1S3TGXVk4QcerjriuGXDv1Mrl5nDhlyNMVGrGbKIsax8MLLqAl8ouXlKoGxAa2m19AIKgAAAigAICoAAALOUax8g1OHXFz0s3ajTtGozGogoKCe3bGajj7dsfEWJVZynw0NMuY1cWWWlENgomwFQAAAFQBRFAAAAAAAAAAAAAA2CobNqDKogIqCiFECLpZNQajOsXFzuOq7pZKLrgreWHO4zYKCKiqJsllBqGiGxGbcsbvzGpZlOF8s3DV3iDWjSY5b4vFaBlizbpU0K5W+qzZq7dcsNxzvwI1Lw1h5c8W8PIOmjQoMy76n7NMYebW9gXiVrp46xZ1uyOkVmigqJl9NcsXXP6K5Y+AVJ5CeQWieaoAAAAAAKgAoigKgCsXm2Vtzz4ylBJ+lvixMpubTG6oL4aSxPFBVRQEUBPCiAoeQBFABFB2AAAAAARUoCpFBjLmueMl3l5dM5e26+HHG66P3RU6nUcbVytt0lxFYqbay8MAACF8J5a1NM+wBe23wugJNlmjYCIoogqAgqAoQAAQAAFiNQGp4dMJwxjy6So1G4sZjSKu12yoiuvTvDlG+neViV0AaZEs2oDmldLJWbh8Ji6xs2XGpZUVdm2dVqY2guxe07aCKnICiKAAAAAAAAAIAogCiAKgCgigIWpsCtSGOPuqSJaANMoKAiWStIK53FNOujSYuuOksjtcZWLhTF1zls8Ny7Z7bCINLKkuzwC2Spuzyu18gTldMZY2c43+Ew6m7rLig6OeeLolgOWOFtb7Lj5bwnLVm1TXMrfZTs35MNYx8Fuvu32RZhJdmGrjjqNArICgx1OMK54+HTrfQ5Y+AUX0kBYAAAB7AAABUAFEUAAD2zn9LSZc4gY39LNmrtrHwXwB6PKYqCb00lIAACoKCCgAAAAOwAAAAACVUoEVFAcc8NbnquqZTcB5Jjzyt8Ln9bNRpzyY03YzYCIqCLLwdsNU0DU3C6vhJx7XYJpNNbSyXwDPIasAEAAAEVAFRRQAQU0jUBrGOkcpdNzKI06RYzK0iqrO12DUaxurGFlWI9AmN3IrTACAogAagAaRUAAATUUBntTVjYmLrA2moYayL2pqoumxNUBRAVRNmwUTZsFE2bAA5BNmzttamGjDWZutTHTQuM6AKgACCgIaUARUANCgxcds3DTqiLrj2n7utm2bgLrOlh22KGqxnhK0WoOctx4rpLamt10xmopUxx00CsgKCCgAACooMdX6HLHw7dT6K4Yg2ipAUAAAAAAAAAFEUAABL4UoJj4UgDM8qTyewEUACAAACoAAAAA7ggKIbBRAFQ2mwUTadwNJfCdxvgHDOc7Yy8O2U4cLtlpJNs3hvxHPJRnyuMWR26PS/Mu7xjBGMenll9Md8fw81+vy744zGaiqjhfw2Dnfws+XqKDx38NfVc8unnhdWbe/SXHYPn6vwmn0L058M/k4+dCvAa29v5GNT/DYg8ejT2f4bHTN/Cy3zwI8qWPVfwvHFL+F488ivLoei/hs/Vcsuj1J5xBgP4AGoysQajc0zK1EaajTK7RVVlQaEUHfpXeLTl0brLTq1GKqAqAKCGlAQNpsF2gAAAAgCooCACgAmp8JqKAnbDtjQYus9sO2NICdsXUAQ0CggqACoAAAAAAAAAAAAAAAKgCaUBntOxsF1iY6aUEQUAAAAABQRQBLN4158XpefKazoNekipAUVAAAAAAAFRQRUAURQEVICnoKCTyeyJfIKACe1KeYAAAAAAAADuggACCou0UEAETSiKml0bNgljlnjrLh12lm0V5r5Zk3eXXPEw6ffeQc9d2WsXuwx7cZGMOljjfDq0yAgFIlZm5QbDZsANmwBNmwUAAAENKAzcMb/AKY4Z/hccsrZdPSA+b1Onenlqsvo9TCZzVjx9ToXC8eBXOVvHd9L0sZ3/qj2zHGTiIuvJq68U5+K9nBqfCYa8e1lem4Y3zGMuhPV0Ya5KXDLHzE2iumF1nHd5ZdV6pdyVqJQBWTa7QAtTabABQAAAC0E2CgIUAVFAKIAoAAUBFAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABQEBQAAAAHHqcZuzn1Z4oMEVAaqKgAAAAAAAAAKCKigAAJVQBL5VPNBfQbAKk8qlBQ9AAAAAAAO1YtbZsRWe47mMuKjOrjfcdzntO41cdO4257NmmN7NsbUGtnlcelb5dZhIuJrnMMq3MPu2Lia559OWGGGq6VFNXQAgigIigJpQA0mlATS6DYGgATQpwBKAAABWM8dxtKDljjPcdIxPLaKKgCiKA55dKZeOHQB5csbjeXfpZd2DVks5YwxnTt58g6DPcdyo1bpne0WAoigohoFDwloFoigqAAKAAUEqgAACotQAAAAAAAAAUBAAAAAAAABUtAAAAAAAAAAAFAQUAAAAAAAAAY6k3i2mXMoOJCANIAAAAAAAAAAqAKgCgAIAFqTg808gQhCAqVQEgniqCobNoAndE7oDQxcr6i/qvpR6koA45+WdAxW4WOdgILIugUWTdd8OnMZ9wWJWwGmQAAAAAAAEAAAAAATQAoACWcABFAEvgw8ACpQBz9rsEVQAUAAARUslAVizVIAiqCgACloAnlZAAAAUAKQAKgAoACgCAAAAAAAAAAqAAAAAAACgAlAAAAABQAAAAAAAAAAAAAAARQAQAcrxakAGkAAAAAAABQAABAAVAAQAPSTwAE8k4ugQX2m+QBMqd36QUZlt9tTC3zQQanSjUwk9AC6igD//Z'),
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
    Nombre, HoraInicio, HoraFin, DiasDefinidosSemana, DuracionTurno, TipoServicio , Costo, Descripcion, empresaId, Activo
) values
    ('Entregas a Domicilio', 9.0, 18.0, 'Lunes;Miercoles;Viernes', 30, 'Gastronomia', 300.00,'Realizamos pedidos', 39,1),
    ('Corte de Pelo', 9.0, 18.0, 'Lunes;Miercoles;Viernes', 1, 'Peluquería', 300.00,'Degradado y barba', 42,1),
    ('Masaje Relajante', 10.0, 20.0, 'Martes:Jueves;Sabado', 1, 'Centro de Masajes', 800.00,'Masajes ', 46,1),
    ('Café Gourmet', 8.0, 17.0, 'Lunes;Martes;Miercoles;Jueves;Viernes;Sabado;Domingo', 24, 'Cafetería', 500.00,'Date un gusto', 52,1),
    ('Clases de Yoga', 17.0, 18.0, 'Lunes;Miercoles', 1, 'Centro de Yoga', 250.00,'Yoga para el alma', 54,1),
    ('Sesion de Quiropráctica', 7.0, 15.0, 'Lunes;Martes;Miercoles;Jueves;Viernes;Sabado;Domingo', 1, 'Quiropráctica', 150.00,'Aliviamos tu cuerpo',56,1),
    ('Tatuaje Personalizado', 13.0, 19.0, 'Viernes', 30, 'Estetica', 1500.00,'El tatuaje ideal ', 61,1),
    ('Consultas Dentales', 9.0, 19.0, 'Lunes;Jueves', 30, 'Clinica dental', 500.00,'Tú sonrrisa Lista', 62,1),
    ('Tatuajes', 9.0, 19.0, 'Martes:Jueves;Sabado', 1, 'Estetica', 2000.00,'Estamos con promociones del 50% hasta el mes de Junio', 41, 0)
;

go

insert into Reservas (
    ClienteId, ServicioId, FechaRealizada, FechaHoraTurno, Estado
) values
    -- admin
    (1, 2, '2023-12-20 00:00:00', '2024-02-01 09:00:00', 'Realizada'),
    (1, 3, '2024-01-02 00:00:00', '2024-04-02 09:30:00', 'Solicitada'),
    -- john
    (2, 1, '2024-02-02 10:00:00', '2024-02-01 09:00:00', 'Realizada'),
    (2, 2, '2024-02-02 11:00:00', '2024-02-01 10:30:00', 'Cancelada'),
    (2, 3, '2024-02-10 00:00:00', '2024-03-10 14:00:00', 'Solicitada'),
    (2, 4, '2024-02-03 00:00:00', '2024-03-11 15:30:00', 'Solicitada'),
    -- esteban
    (5, 2, '2024-03-03 00:00:00', '2024-02-01 09:00:00', 'Realizada'),
    (5, 3, '2024-03-03 00:00:00', '2024-02-01 09:30:00', 'Realizada'),
    (5, 3, '2024-02-04 00:00:00', '2024-02-11 11:00:00', 'Cancelada'),
    (5, 9, '2024-02-04 00:00:00', '2024-04-12 10:00:00', 'Solicitada'),
    -- kevin
    (6, 3, '2024-03-04 00:00:00', '2024-02-12 08:00:00', 'Realizada'),
    (6, 3, '2024-02-04 00:00:00', '2024-04-12 09:00:00', 'Solicitada'),
    (6, 9, '2024-02-04 00:00:00', '2024-04-12 10:00:00', 'Solicitada'),
    (6, 9, '2024-03-04 00:00:00', '2024-02-01 16:00:00', 'Realizada'),
    (6, 9, '2024-03-04 00:00:00', '2024-02-01 22:30:00', 'Cancelada'),
    -- german
    (7, 1, '2024-03-04 00:00:00', '2024-02-01 09:00:00', 'Realizada'),
    (7, 1, '2024-03-04 00:00:00', '2024-02-02 10:30:00', 'Realizada'),
    (7, 9, '2024-03-04 00:00:00', '2024-02-03 13:00:00', 'Realizada'),
    (7, 2, '2024-03-04 00:00:00', '2024-02-04 16:30:00', 'Realizada'),
    -- carolina
    (9, 1, '2024-03-05 00:00:00', '2024-02-01 09:00:00', 'Realizada'),
    (9, 9, '2024-03-05 00:00:00', '2024-02-02 09:30:00', 'Realizada'),
    (9, 3, '2024-03-05 00:00:00', '2024-02-12 16:00:00', 'Cancelada'),
    (9, 4, '2024-02-05 00:00:00', '2024-04-12 08:00:00', 'Solicitada'),
    (9, 5, '2024-03-05 00:00:00', '2024-02-12 11:30:00', 'Cancelada'),
    (9, 6, '2024-02-06 00:00:00', '2024-04-12 10:00:00', 'Solicitada'),
    (9, 8, '2024-03-06 00:00:00', '2024-02-12 15:00:00', 'Cancelada')
;

go

insert into Favoritos (ClienteId, ServicioId, recibirNotificaciones
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
	(2,5,0)
;

go

insert into Promociones (UltimoEnvio, CuerpoMensaje, AsuntoMensaje, Destinatarios, EmpresaId
) values 
    ('2024-04-02', 'Cuerpo del mensaje para promoción 1', 'Asunto de la promoción 1', 'kevinmiranda621@gmail.com', 56),
    ('2024-04-05', 'Cuerpo del mensaje para promoción 2', 'Asunto de la promoción 2', 'estebanpiccardo1989@gmail.com', 56),
    ('2024-05-11', 'Cuerpo del mensaje para promoción 3', 'Asunto de la promoción 3', 'germantexeira@gmail.com', 56),
    ('2024-05-12', 'Cuerpo del mensaje para promoción 4', 'Asunto de la promoción 4', 'kevinmiranda621@gmail.com', 41),
    ('2024-06-08', 'Cuerpo del mensaje para promoción 5', 'Asunto de la promoción 5', 'estebanpiccardo1989@gmail.com', 41),
    ('2024-06-10', 'Cuerpo del mensaje para promoción 6', 'Asunto de la promoción 6', 'germantexeira@gmail.com', 39),
    ('2024-06-11', 'Cuerpo del mensaje para promoción 7', 'Asunto de la promoción 7', 'kevinmiranda621@gmail.com', 39),
    ('2024-06-13', 'Cuerpo del mensaje para promoción 8', 'Asunto de la promoción 8', 'estebanpiccardo1989@gmail.com', 39)
;

go