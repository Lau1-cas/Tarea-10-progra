/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [correlativo]
      ,[nombre]
      ,[parcial1]
      ,[parcial2]
      ,[parcial3]
  FROM [dbprogra].[dbo].[tb_alumnos]

  insert into [dbprogra].[dbo].[tb_alumnos] values (904,'Juan Perez',8,16,25)

  delete from tb_alumnos 

  update tb_alumnos set nombre = 'Maria Porras' where correlativo = 904