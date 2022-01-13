drop view if exists ViewClients; 
drop view if exists ViewCars; 
drop view if exists ViewRentals; 
go

-- создание представления таблицы Clients (Клиенты)
create view ViewClients as 
	select
		Clients.Id
		, Clients.Surname
		, Clients.[Name]
		, Clients.Patronymic
		, Clients.Passport
	from
		Clients;
go


-- создание представления таблицы Cars (Машины)
create view ViewCars as 
	select
		Cars.Id
		, Brands.Brand
		, Colors.Color
		, Cars.Plate
		, Cars.YearManuf
		, Cars.InshurancePay
		, Cars.Rental
	from
		Cars inner join Brands on Cars.IdBrand = Brands.Id
			 inner join Colors on Cars.IdColor = Colors.Id;
go


-- создание представления таблицы Rentals (Факты_проката)
create view ViewRentals as 
	select
		Rentals.Id
		, Clients.Surname
		, Clients.[Name]
		, Clients.Patronymic
		, Clients.Passport
		, Brands.Brand
		, Colors.Color
		, Cars.Plate
		, Cars.YearManuf
		, Cars.InshurancePay
		, Cars.Rental
		, Rentals.DateStart
		, Rentals.Duration
	from
		Rentals inner join Clients on Rentals.IdClient = Clients.Id
			    inner join (Cars inner join Brands on Cars.IdBrand = Brands.Id
								 inner join Colors on Cars.IdColor = Colors.Id)
					on Rentals.IdCar = Cars.Id;
go



-- Для всех клиентов прокатной фирмы вычисляет количество фактов 
-- проката, суммарное количество дней проката, упорядочивание по 
-- убыванию суммарного количества дней проката

-- удаление представления
drop view if exists ViewClientsAmountRentals;
go

-- представление с клиентами и количеством фактов проката и количеством дней проката
-- alter view ViewClientsAmountRentals as
create view ViewClientsAmountRentals as
	select top (select count(*) from Clients)
		Clients.Id
		, Clients.Surname
		, Clients.[Name]
		, Clients.Patronymic
		, Clients.Passport
		, IsNull(Count(Rentals.Id), 0) as AmountRentals
		, IsNull(Sum(Rentals.Duration), 0) as AmountDuration
	from
		Clients left join Rentals on Clients.Id = Rentals.IdClient
	group by 
		Clients.Id, Clients.Surname, Clients.[Name], Clients.Patronymic, Clients.Passport
	order by 
		AmountDuration desc;
go
