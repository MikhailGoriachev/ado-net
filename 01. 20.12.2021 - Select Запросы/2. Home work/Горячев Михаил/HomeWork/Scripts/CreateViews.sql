-- удаление представлений таблиц
drop view if exists ViewTransactions;		-- удаленеие таблицы Transactions	(Сделки)
drop view if exists ViewImmovables; 		-- удаленеие таблицы Immovables		(Недвижимость)
drop view if exists ViewRealtors; 			-- удаленеие таблицы Realtors		(Риэлторы)
drop view if exists ViewOwners; 			-- удаленеие таблицы Owners			(Владельцы)
go

-- создание представления таблицы Realtors (Риэлторы)
create view ViewRealtors
as
	select
		Realtors.Id
		, Persons.LastName		as	RealtorLastName 
		, Persons.FirstName		as	RealtorFirstName
		, Persons.Patronymic	as	RealtorPatronymic
		, Realtors.RemunPercent
	from
		Realtors inner join Persons on Realtors.IdPersons = Persons.Id;
go


-- создание представления таблицы Owners (Владельцы)
create view ViewOwners
as
	select
		Owners.Id
		, Persons.LastName		as	OwnerLastName 
		, Persons.FirstName		as	OwnerFirstName
		, Persons.Patronymic	as	OwnerPatronymic
		, Owners.Passport
	from
		Owners inner join Persons on Owners.IdPersons = Persons.Id;
go


-- создание представления таблицы Owners (Владельцы)
create view ViewImmovables
as
	select
		Immovables.Id
		, Streets.Street
		, Immovables.HomeNumber			
		, Immovables.ApartmentNumber		
		, Immovables.AmountRooms			
		, Immovables.Area				
		, Immovables.Price				
	from
		Immovables inner join Streets on Immovables.IdStreets = Streets.Id;
go


-- создание представления таблицы Owners (Владельцы)
create view ViewTransactions
as
	select
		Transactions.Id
		, ViewImmovables.Street
		, ViewImmovables.HomeNumber			
		, ViewImmovables.ApartmentNumber		
		, ViewImmovables.AmountRooms			
		, ViewImmovables.Area				
		, ViewImmovables.Price				
		, ViewRealtors.RealtorLastName 
		, ViewRealtors.RealtorFirstName
		, ViewRealtors.RealtorPatronymic
		, ViewRealtors.RemunPercent
		, ViewOwners.OwnerLastName 
		, ViewOwners.OwnerFirstName
		, ViewOwners.OwnerPatronymic
		, ViewOwners.Passport
		, Transactions.DateTrans
	from
		Transactions inner join ViewImmovables on Transactions.IdImmovables = ViewImmovables.Id
					 inner join ViewRealtors   on Transactions.IdRealtors	= ViewRealtors.Id
					 inner join ViewOwners	   on Transactions.IdOwners  	= ViewOwners.Id					 
go

