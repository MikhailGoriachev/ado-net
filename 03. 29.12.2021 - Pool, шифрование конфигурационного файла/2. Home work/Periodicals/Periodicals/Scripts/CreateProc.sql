-- ХРАНИМЫЕ ПРОЦЕДУРЫ

-- вывод всех записей таблицы TypesOfEdition			(Виды изданий)

-- удаление процедуры 
drop proc ShowTypesOfEdition;
go

-- создание процедуры
create proc ShowTypesOfEdition
as
	select
		*
	from
		TypesOfEdition;
go


-- вывод всех записей таблицы Editions					(Издания)

-- удаление процедуры 
drop proc ShowEditions;
go

-- создание процедуры
create proc ShowEditions
as
	select
		*
	from
		ViewEditions;
go


-- вывод всех записей таблицы Streets					(Улицы)

-- удаление процедуры 
drop proc ShowStreets;
go

-- создание процедуры
create proc ShowStreets
as
	select
		*
	from
		Streets;
go


-- вывод всех записей таблицы Subscribers				(Подписчики)

-- удаление процедуры 
drop proc ShowSubscribers;
go

-- создание процедуры
create proc ShowSubscribers
as
	select
		*
	from
		ViewSubscribers;
go


-- вывод всех записей таблицы Delivery					(Доставка)

-- удаление процедуры 
drop proc ShowDelivery;
go

-- создание процедуры
create proc ShowDelivery
as
	select
		Id		
		, LastName + ' ' + Substring(FirstName, 1, 1) + '. ' + Substring(Patronymic, 1, 1) + '.' as FullName	-- фамилия и инициалы подписчика
		, NumberPassport 													-- номер паспорта подписчика
		, Street + ' ' + NumberHome + '/' + NumberApartment	as [Address]	-- адресс подписчика
		, IndexEdition														-- индекс издания
		, Title																-- название издания
		, Price																-- цена издания
		, DateStartSubscribe												-- дата начала подписки
		, SubscribePeriodMonths												-- количество месяцев подписки
	from
		ViewDelivery;
go


------------------------------------------------------------------------------------


-- 1	Запрос с параметром	
-- Выбирает из таблицы ИЗДАНИЯ информацию о доступных для 
-- подписки изданиях заданного типа, стоимость 1 экземпляра 
-- для которых меньше заданной.

-- удаление процедуры
drop proc if exists Proc1;
go

-- создание процедуры
create proc Proc1
	@selectType nvarchar(100)
as
	select
		*
	from
		ViewEditions
	where
		ViewEditions.TypeEdition = @selectType;
go


-- 2	Запрос с параметром	
-- Выбирает из таблиц информацию о подписчиках, проживающих
-- на заданной параметром улице и номере дома, которые 
-- оформили подписку на издание с заданным параметром
-- наименованием

-- удаление процедуры
drop proc if exists Proc2;
go

-- создание процедуры
create proc Proc2
	@selectStreet		nvarchar(120),
	@selectNumberHome	nvarchar(10),
	@selectTitle		nvarchar(100)
as
	select
		Id
		, LastName + ' ' + Substring(FirstName, 1, 1) + '. ' + Substring(Patronymic, 1, 1) + '.'	-- фамилия и инициалы подписчика
		, NumberPassport											-- номер паспорта подписчика
		, Street + ' ' + NumberHome + '/' + NumberApartment			-- адресс подписчика
		, IndexEdition												-- индекс издания
		, Title														-- название издания
		, Price														-- цена издания
		, DateStartSubscribe										-- дата начала подписки
		, SubscribePeriodMonths										-- количество месяцев подписки
	from
		ViewDelivery
	where
		Street = @selectStreet and NumberHome = @selectNumberHome and Title = @selectTitle;
go


-- 3	Запрос с параметром	
-- Выбирает из таблицы ИЗДАНИЯ информацию об изданиях, для
-- которых значение в поле Цена 1 экземпляра находится в 
-- заданном диапазоне значений
declare @loPrice int = 250, @hiPrice int = 2000;

-- удаление процедуры
drop proc if exists Proc3;
go

-- создание процедуры
create proc Proc3
	@loPrice int,
	@hiPrice int
as
	select
		Id
		, IndexEdition
		, TypeEdition
		, Title
		, Price
	from
		ViewEditions
	where
		Price between @loPrice and @hiPrice;
go


-- 4	Запрос с параметром	
-- Выбирает из таблиц информацию о подписчиках, подписавшихся
-- на заданный параметром тип издания
-- виды изданий:
-- газета
-- каталог
-- альманах
-- журнал

-- удаление процедуры
drop proc if exists Proc4;
go

-- создание процедуры
create proc Proc4
	@selectType nvarchar(100)
as
	select
		Id
		, LastName + ' ' + Substring(FirstName, 1, 1) + '. ' + Substring(Patronymic, 1, 1) + '.'	-- фамилия и инициалы подписчика
		, NumberPassport											-- номер паспорта подписчика
		, Street + ' ' + NumberHome + '/' + NumberApartment			-- адресс подписчика
		, IndexEdition												-- индекс издания
		, Title														-- название издания
		, Price														-- цена издания
		, DateStartSubscribe										-- дата начала подписки
		, SubscribePeriodMonths										-- количество месяцев подписки
	from
		ViewDelivery
	where
		TypeEdition like @selectType;
go


-- 5	Запрос с параметром	
-- Выбирает из таблиц ИЗДАНИЯ и ПОДПИСКА информацию обо всех 
-- оформленных подписках, для которых срок подписки есть 
-- значение из некоторого диапазона. 

-- удаление процедуры
drop proc if exists Proc5;
go

-- создание процедуры
create proc Proc5
	@loMonths	int,
	@hiMonth	int
as
	select
		Id
		, LastName + ' ' + Substring(FirstName, 1, 1) + '. ' + Substring(Patronymic, 1, 1) + '.'	-- фамилия и инициалы подписчика
		, NumberPassport											-- номер паспорта подписчика
		, Street + ' ' + NumberHome + '/' + NumberApartment			-- адресс подписчика
		, IndexEdition												-- индекс издания
		, Title														-- название издания
		, Price														-- цена издания
		, DateStartSubscribe										-- дата начала подписки
		, SubscribePeriodMonths										-- количество месяцев подписки
	from
		ViewDelivery
	where
		SubscribePeriodMonths between @loMonths and @hiMonth;
go


-- 6	Запрос с вычисляемыми полями
-- Вычисляет для каждой оформленной подписки ее стоимость с 
-- доставкой и без НДС. Включает поля Индекс издания, 
-- Наименование издания, Цена 1 экземпляра, Дата начала 
-- подписки, Срок подписки, Стоимость подписки без НДС. 
-- Сортировка по полю Индекс издания

-- удаление процедуры
drop proc if exists Proc6;
go

-- создание процедуры
create proc Proc6
as
	select
		Id
		, IndexEdition
		, Title
		, Price
		, DateStartSubscribe
		, SubscribePeriodMonths
		, Price * SubscribePeriodMonths as SubscriptionCost
	from 
		ViewDelivery;
go


-- 7	Итоговый запрос	
-- Выполняет группировку по полю Вид издания. Для каждого 
-- вида вычисляет максимальную и минимальную цену 1 экземпляра

-- удаление процедуры
drop proc if exists Proc7;
go

-- создание процедуры
create proc Proc7
as
	select
		Id
		, TypeEdition
		, COUNT(*) as [Count]
		, MIN(Price) as MinPrice
		, AVG(Price) as AvgPrice
		, MAX(Price) as MaxPrice
	from
		ViewEditions
	group by
		Id, TypeEdition;
go


-- 8	Итоговый запрос с левым соединением	
-- Выполняет группировку по полю Улица. Для всех улиц вычисляет 
-- количество подписчиков, проживающих на данной улице (итоги 
-- по полю Код получателя)

-- удаление процедуры
drop proc if exists Proc8;
go

-- создание процедуры
create proc Proc8
as
	select
		Streets.Id
		, Streets.Street
		, IsNull(Count(Subscribers.IdStreets), 0) as [Count]
	from
		Streets left join Subscribers on Subscribers.IdStreets = Streets.Id
	group by
		Streets.Id, Streets.Street
	order by
		[Count] desc;
go


-- 9	Итоговый запрос с левым соединением	
-- Для всех изданий выводит количество оформленных подписок

-- удаление процедуры
drop proc if exists Proc9;
go

-- создание процедуры
create proc Proc9
as
	select
		ViewEditions.Id
		, ViewEditions.Title
		, IsNull(Count(Delivery.IdEditions), 0) as [Count]
	from
		ViewEditions left join Delivery on Delivery.IdEditions = ViewEditions.Id
	group by
		ViewEditions.Id, ViewEditions.Title
	order by
		[Count] desc;
go