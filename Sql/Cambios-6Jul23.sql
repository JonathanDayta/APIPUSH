SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE Device
ALTER COLUMN TransFlag VARCHAR(150); 

ALTER TABLE Device add IdDeptoSucursal int;

CREATE TABLE AssignmentUser (
ID INT NOT NULL IDENTITY, 
DevSN VARCHAR(50), 
PIN VARCHAR(50),
HIGHDATE DATETIME,
PRIMARY KEY (ID), 
CONSTRAINT DEVSN_PIN_UNIQUE UNIQUE (DevSN, PIN));


---
--SP
ALTER PROCEDURE "dbo"."SP_INSERT_USER"
(
        @PIN VARCHAR(50), 
        @NOMBRE VARCHAR(100), 
        @SN VARCHAR(50),
        @PWD VARCHAR(5),
        @USRTYPE VARCHAR(2)
)
AS
BEGIN
        DECLARE @COUNT_DATA bigint;
        SET @COUNT_DATA = (SELECT COUNT(*) FROM UserInfo WHERE PIN = @PIN) 

        IF ((@PIN IS NOT NULL AND @PIN != '') AND (@NOMBRE IS NOT NULL AND @NOMBRE != '') AND (@SN IS NOT NULL AND @SN != ''))
        BEGIN               
                IF ((@PWD IS NOT NULL AND @PWD != '') AND (@USRTYPE IS NOT NULL AND @USRTYPE != ''))
                BEGIN
                        IF @COUNT_DATA = 0
                        BEGIN
                                INSERT INTO UserInfo (DevSN, PIN, UserName, Passwd, IDCard, Grp, TZ, Pri) VALUES ('1', @PIN, @NOMBRE, @PWD, '0', '1', '0001000100000000', @USRTYPE);
                        END   
                        INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA UPDATE USERINFO PIN='+@PIN+'	Name='+@NOMBRE+'	Pri='+@USRTYPE+'	Passwd='+@PWD+'	Card=0	Grp=1	TZ=0001000100000000', getDate());
                END
                ELSE IF ((@PWD IS NULL OR @PWD = '') AND (@USRTYPE IS NOT NULL AND @USRTYPE != ''))
                BEGIN
                        IF @COUNT_DATA = 0
                        BEGIN
                                INSERT INTO UserInfo (DevSN, PIN, UserName, Passwd, IDCard, Grp, TZ, Pri) VALUES ('1', @PIN, @NOMBRE, '', '0', '1', '0001000100000000', @USRTYPE);
                        END
                        INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA UPDATE USERINFO PIN='+@PIN+'	Name='+@NOMBRE+'	Pri='+@USRTYPE+'	Passwd=	Card=0	Grp=1	TZ=0001000100000000', getDate());
                END
                ELSE IF ((@PWD IS NOT NULL AND @PWD != '') AND (@USRTYPE IS NULL OR @USRTYPE = ''))
                BEGIN
                        IF @COUNT_DATA = 0
                        BEGIN
                                INSERT INTO UserInfo (DevSN, PIN, UserName, Passwd, IDCard, Grp, TZ, Pri) VALUES ('1', @PIN, @NOMBRE, @PWD, '0', '1', '0001000100000000', '0');
                        END
                        INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA UPDATE USERINFO PIN='+@PIN+'	Name='+@NOMBRE+'	Pri=0	Passwd='+@PWD+'	Card=0	Grp=1	TZ=0001000100000000', getDate());
                END
                ELSE
                BEGIN
                        IF @COUNT_DATA = 0
                        BEGIN
                                INSERT INTO UserInfo (DevSN, PIN, UserName, Passwd, IDCard, Grp, TZ, Pri) VALUES ('1', @PIN, @NOMBRE, '', '0', '1', '0001000100000000', '0');
                        END
                        INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA UPDATE USERINFO PIN='+@PIN+'	Name='+@NOMBRE+'	Pri=0	Passwd=	Card=0	Grp=1	TZ=0001000100000000', getDate());
                END        
        END
END; 
 


ALTER PROCEDURE "dbo"."SP_DELETE_USER"
(
        @SN VARCHAR(50) , 
        @PIN VARCHAR(50) 
)
AS
BEGIN
        IF ((@SN IS NOT NULL AND @SN != '') AND (@PIN IS NOT NULL AND @PIN != ''))
        BEGIN
                INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA DELETE FINGERTMP PIN='+@PIN, getDate());
                INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA DELETE FACE PIN='+@PIN, getDate());
                INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA DELETE BIODATA PIN='+@PIN, getDate());
                INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA DELETE BIODATA PIN='+@PIN, getDate());
                INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA DELETE USERPIC PIN='+@PIN, getDate());
                INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA DELETE BIOPHOTO PIN='+@PIN, getDate());  
                INSERT INTO DeviceCmds (DevSN, Content, CommitTime) VALUES (@SN, 'DATA DELETE USERINFO PIN='+@PIN, getDate());
        
                --borrado completo
                delete from TmpBioData where PIN in (@PIN); 
                delete from TmpFP where PIN in (@PIN) ;
                delete from TmpFace where PIN in (@PIN); 
                delete from TmpFvein where PIN in (@PIN); 
                delete from TmpUserPic where PIN in (@PIN); 
                delete from TmpBioPhoto where PIN in (@PIN); 
                delete from UserInfo where PIN in (@PIN); 
        END
END;
/* Procedure body */