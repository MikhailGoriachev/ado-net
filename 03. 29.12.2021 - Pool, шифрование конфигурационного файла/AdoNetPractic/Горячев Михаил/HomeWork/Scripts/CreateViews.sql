-- удаление таблиц
drop view if exists ViewEditions;
drop view if exists ViewSubscribers;
drop view if exists ViewDelivery;
go

-- создание представления таблицы Editions				(Издания)
create view ViewEditions
as
	select
		Editions.Id					
		, Editions.IndexEdition				-- Индекс издания
		, TypesOfEdition.[Type]				-- Вид издания
		, Editions.Title					-- Название публикации
		, Editions.Price					-- Цена публикации
	from
		Editions inner join TypesOfEdition on Editions.IdTypesOfEdition = TypesOfEdition.Id;
go


-- создание представления для таблицы Subscribers				(Подписчики)
create view ViewSubscribers
as
	select
		Subscribers.Id					
		, Subscribers.LastName					-- Фамилия
		, Subscribers.FirstName					-- Имя
		, Subscribers.Patronymic				-- Отчество	
		, Subscribers.NumberPassport			-- Номер паспорта	
		, Streets.Street						-- Улица
		, Subscribers.NumberHome				-- Номер дома	
		, Subscribers.NumberApartment			-- Номер квартиры (0 - если нет квартиры)	
	from
		Subscribers inner join Streets on Subscribers.IdStreets = Streets.Id;
go


-- создание представления для таблицы Delivery				(Доставка)
create view ViewDelivery
as
	select
		Delivery.Id
		, ViewSubscribers.LastName				-- Фамилия подписчика
		, ViewSubscribers.FirstName				-- Имя подписчика
		, ViewSubscribers.Patronymic				-- Отчество	 подписчика
		, ViewSubscribers.NumberPassport			-- Номер паспорта подписчика
		, ViewSubscribers.Street					-- Улица
		, ViewSubscribers.NumberHome				-- Номер дома	
		, ViewSubscribers.NumberApartment			-- Номер квартиры (0 - если нет квартиры)	
		, ViewEditions.IndexEdition					-- Индекс издания
		, ViewEditions.[Type]						-- Вид издания
		, ViewEditions.Title						-- Название публикации
		, ViewEditions.Price						-- Цена публикации
		, Delivery.DateStartSubscribe						-- Дата начала подписки
		, Delivery.SubsctibePeriodMonths						-- Количество месяцев подписки
	from
		Delivery inner join ViewSubscribers on Delivery.IdSubscribers = ViewSubscribers.Id
				 inner join ViewEditions	on Delivery.IdEditions	  = ViewEditions.Id;
go