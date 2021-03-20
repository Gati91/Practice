USE [AdventureWorks2019]
GO

/****** Object:  View [Person].[vAdditionalContactInfo]    Script Date: 20-03-2021 18:22:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW Person.PersonInfo
AS 
	select p.BusinessEntityID, p.FirstName, p.MiddleName, p.LastName, pp.PhoneNumber as TelephoneNumber, pa.AddressLine1, pa.City, ps.StateProvinceCode, pa.PostalCode, ps.CountryRegionCode, pem.EmailAddress
	from Person.Person p inner join Person.PersonPhone pp on p.BusinessEntityID = pp.BusinessEntityID
	inner join Person.BusinessEntityAddress pba on p.BusinessEntityID = pba.BusinessEntityID
	inner join Person.Address pa on pba.AddressID = pa.AddressID
	inner join person.StateProvince ps on pa.StateProvinceID = ps.StateProvinceID
	inner join Person.EmailAddress pem on p.BusinessEntityID = pem.BusinessEntityID
GO