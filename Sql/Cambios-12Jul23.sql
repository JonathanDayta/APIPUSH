SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE CatOperationCode (
ID INT NOT NULL IDENTITY, 
code INT NOT NULL,
descEng VARCHAR(150), 
descSpa VARCHAR(150)
PRIMARY KEY (ID), 
CONSTRAINT CatOperationCode_UNIQUE UNIQUE (ID, code));


INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (0,'Startup','Inicio');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (1,'Shutdown','Cierre');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (2,'Authentication fails','Autenticación fallida');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (3,'Alarm','Alarma');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (4,'Access menu','Acceso al menu');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (5,'Change settings','Cambio de configuración');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (6,'Enroll fingerprint','Registro de huella dactilar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (7,'Enroll password','Registro de contraseña');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (8,'Enroll HID card','Registro de tarjeta HID');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (9,'Delete user','Eliminacion de usuario');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (10,'Delete fingerprint','Eliminacion de huella dactilar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (11,'Delete password','Eliminacion de contraseña');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (12,'Delete RF card','Eliminacion de tarjeta RF');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (13,'Clear data','Eliminacion de datos');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (14,'Create MF card','Creacion de tarjeta MF');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (15,'Enroll MF card','Registro de tarjeta MF');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (16,'Register MF card','Registrar tarjeta MF');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (17,'Delete MF card registration','Eliminacion de regsitro de tarjeta MF');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (18,'Clear MF card content','Borrar contenido de tarjera MF');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (19,'Move enrolled data into the card','Mover datos del registro a la tarjeta');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (20,'Copy data in the card to the machine','Copiar datos de la tarjeta a la maquina');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (21,'Set time','Configuracion de tiempo');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (22,'Delivery configuration','Configuración de la entrega');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (23,'Delete entry and exit records','Borrar registros de entrada y salida');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (24,'Clear administrator privilege','Eliminar privilegios de administrador');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (25,'Modify access group settings','Modificar la configuración de los grupos de acceso');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (26,'Modify user access settings','Modificar la configuración de acceso de los usuarios');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (27,'Modify access time period','Modificar el plazo de acceso');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (28,'Modify unlocking combination settings','Modificar la configuración de la combinación de desbloqueo');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (29,'Unlock','Desbloquear');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (30,'Enroll a new user','Inscribir a un nuevo usuario');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (31,'Change fingerprint attribute','');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (32,'Duress alarm','Alarma de coacción');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (33,'Doorbell call','Llamada al timbre');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (34,'Anti-passback','Anti-retorno');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (35,'Delete attendance photo','Borrar foto de asistencia');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (36,'Modify other user information','Modificar otra información del usuario');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (37,'Holidays','Vacaciones');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (38,'Restore data','Restaurar datos');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (39,'Backup data','Copia de seguridad');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (40,'U-disk upload','Carga del disco U');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (41,'U-disk download','Descarga de disco U');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (42,'U-disk attendance record encryption','Cifrado de registros de asistencia en disco U');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (43,'Delete records after successful download','Eliminar registros tras una descarga correcta');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (53,'Exit button','Boton de salida');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (54,'Door sensor','Sensor de puerta');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (55,'Alarm','Alarma');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (56,'Recovery parameters','Parámetros de recuperación');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (68,'Register user photo','Registrar foto de usuario');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (69,'Edit user photo','Editar foto de usuario');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (70,'Modify user name','Modificar nombre e usuario');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (71,'Modify user permissions','Modificar permisos de usuario');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (76,'Modify network settings IP','Modificar la configuracion de red - IP');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (77,'Modify network settings mask','Modificar la configuracion de red - mascara');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (78,'Modify network settings gateway','Modificar la configuracion de red - gateway');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (79,'Modify network settings DNS','Modificar la configuracion de red - DNS');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (80,'Modify connection settings password','Modificar la contraseña de configuración de la conexión');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (81,'Modify connection settings device ID','Modificar la configuración de la conexión ID del dispositivo');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (82,'Modify cloud server address','Modificar la dirección del servidor en nube');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (83,'Modify cloud server port','Modificar el puerto del servidor en nube');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (87,'Modify access control record settings','Modificar la configuración del registro de control de acceso');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (88,'Modify face parameter icon','Icono de modificación de parámetros faciales');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (89,'Modify fingerprint parameter icon','Icono de modificación de los parámetros de la huella dactilar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (90,'Modify finger vein parameter icon','Icono de modificación de los parámetros de las venas dactilares');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (91,'Modify palmprint parameter icon','Modificar el icono de los parámetros de la huella palmar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (92,'U-disk upgrade icon','Actualizar icono de Disco U');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (100,'Modify RF card information','Modificar la información de la tarjeta RF');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (101,'Enroll face','Registrar cara');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (102,'Modify personnel permissions','Modificar los permisos del personal');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (103,'Delete personnel permissions','Eliminar los permisos del personal');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (104,'Add personnel permissions','Agregar los permisos del personal');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (105,'Delete access control records','Borrar registros de control de acceso');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (106,'Delete face','Borrar rostro');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (107,'Delete personnel photo','Eliminar foto del personal');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (108,'Modify parameters','Modificar parámetros');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (109,'Select WIFISSID','Seleccione WIFISSID');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (110,'proxy enable','Proxy habilitado');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (111,'proxyip modification','Modificacion de la ip del proxy');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (112,'Proxy port modification','Modificacion del puesto del proxy');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (113,'Change personnel password','Cambiar la contraseña del personal');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (114,'Modify face information','Modificar la información de la cara');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (115,'Change operators password','Cambiar la contraseña del operador');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (116,'Restore access control settings','Restablecer la configuración del control de acceso');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (117,'The operator password is entered incorrectly','La contraseña del operador se ha introducido incorrectamente');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (118,'operator password lock','Bloqueo de la contraseña del operador');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (120,'Modify the data length of the Legic card','Modificar la longitud de los datos de la tarjeta Legic');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (121,'Register finger vein','Registrar vena dactilar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (122,'Modify finger vein','Modificar vena dactilar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (123,'Delete finger vein','Eliminar vena dactilar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (124,'Register palmprint','Registrar huella palmar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (125,'Modify palmprint','Modificar huella palmar');
INSERT INTO CatOperationCode(code,descEng,descSpa) VALUES (126,'Delete palmprint','Eliminar huella palmar');