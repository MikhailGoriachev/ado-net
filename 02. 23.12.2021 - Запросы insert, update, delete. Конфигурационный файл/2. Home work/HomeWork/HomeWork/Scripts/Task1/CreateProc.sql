-- вывод всех записей таблицы Streets 

-- удаление процедуры 
drop proc if exists ShowStreets;
go

-- создание процедуры
create proc ShowStreets
as
	select
		*
	from
		Streets;
go


-- вывод всех записей таблицы Persons	

-- удаление процедуры
drop proc if exists ShowPersons;
go

-- создание процедуры
create proc ShowPersons
as
	select
		*
	from
		Persons;
go


-- вывод всех записей таблицы Immovables

-- удаление процедуры
drop proc if exists ShowImmovables;
go

-- создание процедуры
create proc ShowImmovables
as
	select
		*
	from
		ViewImmovables;
go


-- вывод всех записей таблицы Realtors

-- удаление процедуры
drop proc if exists ShowRealtors;
go

-- создание процедуры
create proc ShowRealtors
as
	select
		*
	from
		ViewRealtors;
go


-- вывод всех записей таблицы Owners

-- удаление процедуры
drop proc if exists ShowOwners;
go

-- создание процедуры
create proc ShowOwners
as
	select 
		*
	from
		ViewOwners;
go


-- вывод всех записей таблицы Transactions

-- удаление процедуры
drop proc if exists ShowTransactions;
go

-- создание процедуры
create proc ShowTransactions
as
	select
    	Id
    	, Street + ' ' + ltrim(str(HomeNumber)) + '/' + ltrim(str(ApartmentNumber))		as [Address] 
    	, Price
    	, RealtorLastName + ' ' + substring(RealtorFirstName, 1, 1) + '. ' + substring(RealtorPatronymic, 1, 1) + '.'	as Realtor
    	, RemunPercent		as RealtorPercent
    	, OwnerLastName + ' ' + substring(OwnerFirstName, 1, 1) + '. ' + substring(OwnerPatronymic, 1, 1) + '.'	as [Owner]
    	, Passport
    	, DateTrans
    from
    	ViewTransactions;
go

-- 1	Запрос с параметрами	
-- Выбирает из таблицы КВАРТИРЫ информацию о 3-комнатных квартирах, расположенных
-- на улице «Садовая». Значения задавать параметрами запроса

-- удаление процедуры
drop proc if exists Proc1;
go

-- создание процедуры
create proc Proc1
	@countRooms int,
	@street nvarchar(120)
as
	select
		*
	from
		ViewImmovables
	where
		Street = @street and AmountRooms = @countRooms;
go

-- 2	Запрос с параметрами	
-- Выбирает из таблицы РИЭЛТОРЫ информацию о риэлторах, фамилия которых начинается 
-- с буквы «И» и процент вознаграждения больше 10%. Значения задавать параметрами 
-- запроса

-- удаление запроса
drop proc if exists Proc2;
go

-- создание запроса
create proc Proc2
	@lastName nvarchar(60),
	@percent float
as
	select
		*
	from
		ViewRealtors
	where
		RealtorLastName in (select Persons.LastName from Persons where Persons.LastName like (@lastName + N'%'))
			and RemunPercent > @percent;
go


-- 3	Запрос с параметрами	
-- Выбирает из таблицы КВАРТИРЫ информацию об 1-комнатных квартирах, цена на которые 
-- находится в диапазоне от 900 000 руб. до 1000 000 руб. Значения задавать 
-- параметрами запроса
declare @countRooms int = 1, @priceLo int = 900000, @priceHi int = 1000000;

-- удаление процедуры
drop proc if exists Proc3;
go

-- создание процедуры
create proc Proc3
	@countRooms int,
	@priceLo int,
	@priceHi int
as
	select
		*
	from
		ViewImmovables
	where
		AmountRooms = @countRooms and Price between @priceLo and @priceHi;
go


-- 4	Запрос с параметрами	
-- Выбирает из таблицы КВАРТИРЫ информацию о квартирах с заданным числом комнат. 
-- Значения задавать параметрами запроса
declare @countRooms int = 2;

-- удаление процедуры
drop proc if exists Proc4;
go

-- создание процедуры
create proc Proc4
	@countRooms int
as
	select
		*
	from	
		ViewImmovables 
	where
		AmountRooms = @countRooms;
go


-- 5	Запрос с параметрами	
-- Выбирает из таблицы КВАРТИРЫ информацию обо всех 2-комнатных квартирах, площадь
-- которых есть значение из некоторого диапазона. Значения задавать параметрами запроса
declare @countRooms int = 2, @areaLo float = 40, @areaHi float = 55;

-- удаление процедуры
drop proc if exists Proc5;
go

-- создание процедуры
create proc Proc5
	@countRooms int,
	@areaLo float,
	@areaHi float
as
	select
		*
	from
		ViewImmovables 
	where	
		AmountRooms = @countRooms and Area between @areaLo and @areaHi;
go


-- 6	Запрос с вычисляемыми полями	
-- Вычисляет для каждой оформленной сделки размер комиссионного вознаграждения риэлтора.
-- Включает поля Фамилия риэлтора, Имя риэлтора, Отчество риэлтора, Дата сделки, Цена 
-- квартиры, Комиссионные. Сортировка по полю Дата сделки

-- удаление процедуры
drop proc if exists Proc6;
go

-- создание процедуры
create proc Proc6
as
	select
		Id
		, RealtorLastName
		, RealtorFirstName
		, RealtorPatronymic
		, DateTrans
		, Price
		, RemunPercent
		, Price * (RemunPercent / 100) as Commission
	from 
		ViewTransactions 
	order by
		ViewTransactions.DateTrans;
go
	

-- 7	Запрос на левое соединение	
-- Выбрать всех риэлторов, количество клиентов, оформивших с ним сделки и сумму сделок 
-- риэлтора. Упорядочить выборку по убыванию суммы сделок.

-- удаление процедуры
drop proc if exists Proc7;
go

-- создание процедуры
create proc Proc7
as
	select
		ViewRealtors.Id
		, ViewRealtors.RealtorLastName
		, ViewRealtors.RealtorFirstName
		, ViewRealtors.RealtorPatronymic
		, COUNT (Transactions.Id) as CountTransactions						-- количество сделок риэлтора (!!! СЧИТАЕТ КОЛИЧЕСТВО СДЕЛОК, А НЕ КОЛИЧЕСТВО КЛИЕНТОВ !!!)
		, ISNULL(SUM (Immovables.Price), 0) as SumTransactions				-- сумма сделок				
	from
		ViewRealtors left join (Transactions inner join Immovables on Transactions.IdImmovables = Immovables.Id) 
			on Transactions.IdRealtors = ViewRealtors.Id 
	group by
		ViewRealtors.Id, ViewRealtors.RealtorLastName, ViewRealtors.RealtorFirstName, ViewRealtors.RealtorPatronymic
	order by
		SumTransactions desc;		-- упорядочивание по убыванию суммы сделок
go	


-- 8	Запрос на левое соединение	
-- Для всех улиц вывести сумму сделок, упорядочить выборку по убыванию суммы сделки

-- удаление процедуры
drop proc if exists Proc8;
go

-- создание процедуры
create proc Proc8
as
	select
		Streets.Id
		, Streets.Street
		, COUNT(Immovables.Id) as CountTransactions					-- количество сделок
		, ISNULL(SUM(Immovables.Price), 0) as SumTransactions		-- сумма сделок
	from
		Streets left join (Immovables inner join Transactions on Immovables.Id = Transactions.IdImmovables)
			on Immovables.IdStreets = Streets.Id
	group by
		Streets.Street, Streets.Id
	order by
		SumTransactions desc;
go	


-- 9	Запрос на левое соединение	
-- Для всех улиц вывести сумму сделок за заданный период, упорядочить выборку по убыванию 
-- суммы сделки. Диапазон задавать параметрами запроса

declare @minDate date = '2021/01/01', @maxDate date = '2021/05/01' 

-- удаление процедуры
drop proc if exists Proc9;
go

-- созданеи процедуры
create proc Proc9
	@minDate date,
	@maxDate date
as
	select
		Streets.Id
		, Streets.Street
		, COUNT(results.IdStreets) as CountTransactions		-- количество сделок
		, ISNULL(SUM(results.Price), 0) as SumTransactions				-- сумма сделок
	from
		Streets left join (select Immovables.Price, Immovables.IdStreets, Transactions.Id, Transactions.DateTrans 
			from Immovables inner join Transactions on Immovables.Id = Transactions.IdImmovables
			where Transactions.DateTrans between @minDate and @maxDate) results
			on results.IdStreets = Streets.Id
	group by
		Streets.Id, Streets.Street
	order by
		SumTransactions desc;
go	
