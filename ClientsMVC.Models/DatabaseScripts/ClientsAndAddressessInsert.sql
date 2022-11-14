
--Please make sure to run update-database from the package manager console before running this script
set identity_insert dbo.Clients on;

insert dbo.Clients ([Id],[Name],[BirthDate])
select 27,N'Ime1','2001-01-09 00:00:00.0000000' UNION ALL
select 28,N'Ime2','2003-01-09 00:00:00.0000000' UNION ALL
select 29,N'Gabriela Arsovska','1999-01-01 00:00:00.0000000';

set identity_insert dbo.Clients off;

set identity_insert dbo.Addressess on;

insert dbo.Addressess ([Id],[Name],[Type],[ClientId])
select 49,N' Home addres',1,27 UNION ALL
select 50,N' Vikend addres',2,27 UNION ALL
select 51,N' Vikend addres',2,28 UNION ALL
select 52,N' Home addres',1,28 UNION ALL
select 53,N'dm',1,29 UNION ALL
select 54,N'France Preshern 227',2,29;

set identity_insert dbo.Addressess off;