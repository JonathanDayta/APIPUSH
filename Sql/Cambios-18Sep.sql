SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE CatTypeUserInformation (
ID INT NOT NULL IDENTITY, 
code INT NOT NULL,
descEng VARCHAR(150), 
descSpa VARCHAR(150)
PRIMARY KEY (ID), 
CONSTRAINT CatTypeUserInformation_UNIQUE UNIQUE (ID, code));

insert CatTypeUserInformation(code, descEng, descSpa) values(0, 'Normal user', 'Usuario normal');
insert CatTypeUserInformation(code, descEng, descSpa) values(2, 'Registrar', 'Registrador');
insert CatTypeUserInformation(code, descEng, descSpa) values(6, 'Administrator', 'Administrador');
insert CatTypeUserInformation(code, descEng, descSpa) values(10, 'User-defined', 'Definido por el usuario');
insert CatTypeUserInformation(code, descEng, descSpa) values(14, 'Super administrator', 'Super administrador');


alter table TmpFace add DischargeDate datetime;
alter table TmpFP add DischargeDate datetime;
alter table TmpBioData add DischargeDate datetime;
alter table TmpBioPhoto add DischargeDate datetime;