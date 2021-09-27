# TASK-BE
TASK BE ASP NET CORE WEB API

Aplikasi membutuhkan 2 store prosedure sebagai berikut:

1. SP_Login

CREATE PROCEDURE [dbo].[SP_Login]
	@Name varchar(50)
AS
BEGIN
	SELECT P.Name AS 'Name', P.Password AS 'Password' FROM TB_M_Pegawai AS P
	WHERE P.Name=@Name
END
RETURN 0

2. SP_ListPegawai

CREATE PROCEDURE [dbo].[SP_ListPegawai]
AS
	SELECT P.Id as 'Id', P.Name AS 'Name',P.Unit_Id as 'Unit_Id',
	U.Name as 'Unit_Name', U.Code as 'Unit_Code', U.Created_At as 'Unit_created_at',
	U.Created_By as 'Unit_created_by',U.IsActive as 'isactive',
	P.Created_At as 'created_at',P.Created_By as 'created_by',
	P.IsActive AS 'isactive' FROM TB_M_Pegawai AS P inner join TB_M_Unit as U on P.Unit_Id = U.Id
RETURN 0

