-- вывод таблицы Brands (Модели_автомобилей)

-- удаление процедуры
drop proc if exists ShowBrands;
go

-- создание процедуры
create proc ShowBrands
as
	select
		Brands.Id
		, Brands.Brand
	from
		Brands;
go

exec ShowBrands;

-- вывод таблицы Colors (цвета)

-- удаление процедуры
drop proc if exists ShowColors;
go

-- созданиe процедуры
create proc ShowColors
as
	select
		Colors.Id
		, Colors.Color
	from
		Colors;
go	

exec ShowColors;

-- вывод предсталения таблицы Clients (Клиенты)

-- удаление процедуры
drop proc if exists ShowClients;
go

-- созданеи процедуры
create proc ShowClients
as
	select
		*
	from
		ViewClients;
go

exec ShowClients;

-- вывод предсталения таблицы Cars (Машины)

-- удаление процедуры
drop proc if exists ShowCars;
go

-- создание процедуры
create proc ShowCars
as
	select
		*
	from
		ViewCars;
go

exec ShowCars;

-- вывод предсталения таблицы Rentals (Факты_проката)

-- удаление процедуры
drop proc if exists ShowRentals;
go

-- создание процедуры
create proc ShowRentals
as
	select
		ViewRentals.Id
		, ViewRentals.Surname + ' ' + substring([Name], 1, 1) + '. ' + substring(Patronymic, 1, 1) + '.' as Client
		, Passport		
		, Brand			
		, Plate			
		, InshurancePay	
		, Rental		
		, Duration		
		, DateStart		
	from
		ViewRentals;
go

exec ShowRentals;


----------------------------------------------------------------------------------------------------

-- 1	Хранимая процедура
-- Выбирает информацию обо всех фактах проката автомобиля с заданным госномером

-- удаление процедуры
drop proc if exists Proc1;
go

-- создание процедуры
create proc Proc1
	@plate nvarchar(9)
as
	select
		ViewRentals.Id
		, ViewRentals.Surname + ' ' + substring([Name], 1, 1) + '. ' + substring(Patronymic, 1, 1) + '.' as Client
		, Passport		
		, Brand			
		, Plate			
		, InshurancePay	
		, Rental		
		, Duration		
		, DateStart		
	from
		ViewRentals
	where
		Plate = @plate;
go


-- 2	Хранимая процедура
-- Выбирает информацию обо всех фактах проката автомобиля с заданной моделью/брендом

-- удаление процедуры
drop proc if exists Proc2;
go

-- создание процедуры
create proc Proc2
	@brand nvarchar(30)
as
	select
		ViewRentals.Id
		, ViewRentals.Surname + ' ' + substring([Name], 1, 1) + '. ' + substring(Patronymic, 1, 1) + '.' as Client
		, Passport		
		, Brand			
		, Plate			
		, InshurancePay	
		, Rental		
		, Duration		
		, DateStart		
	from
		ViewRentals
	where	
		Brand = @brand;
go


-- 3	Хранимая процедура
-- Выбирает информацию об автомобиле с заданным госномером

-- удаление процедуры
drop proc if exists Proc3;
go

-- создание процедуры
create proc Proc3
	@plate nvarchar(9)
as
	select
		*
	from
		ViewCars
	where
		Plate = @plate;
go


-- 4	Хранимая процедура	
-- Выбирает информацию о клиентах по серии и номеру паспорта

-- удаление процедуры
drop proc if exists Proc4;
go

-- создание процедуры
create proc Proc4
	@passport nvarchar(15)
as
	select
		*
	from
		ViewClients
	where
		Passport = @passport;
go


-- 5	Хранимая процедура
-- Выбирает информацию обо всех зафиксированных фактах проката 
-- автомобилей в некоторый заданный интервал времени.

-- удаление процедуры
drop proc if exists Proc5;
go

-- создание процедуры
create proc Proc5
	@dateLo date,  
	@dateHi date
as
	select
		ViewRentals.Id
		, ViewRentals.Surname + ' ' + substring([Name], 1, 1) + '. ' + substring(Patronymic, 1, 1) + '.' as Client
		, Passport		
		, Brand			
		, Plate			
		, InshurancePay	
		, Rental		
		, Duration		
		, DateStart		
	from
		ViewRentals
	where
		DateStart between @dateLo and @dateHi;
go


-- 6	Хранимая процедура
-- Вычисляет для каждого факта проката стоимость проката.
-- Включает поля Дата проката, Госномер автомобиля, Модель 
-- автомобиля, Стоимость проката. Сортировка по полю Дата проката

-- удаление процедры
drop proc if exists Proc6;
go

-- создание процедуры
create proc Proc6
as
	select
		ViewRentals.DateStart
		, ViewRentals.Brand
		, ViewRentals.Plate
		, ViewRentals.Duration
		, ViewRentals.Rental
		, ViewRentals.Rental * ViewRentals.Duration as Price
	from
		ViewRentals
	order by
		ViewRentals.DateStart desc;
go

 	 	 
-- 7	Хранимая процедура
-- Для всех клиентов прокатной фирмы вычисляет количество фактов 
-- проката, суммарное количество дней проката, упорядочивание по 
-- убыванию суммарного количества дней проката

-- удаление процедуры
drop proc if exists Proc7;
go

-- создание процедуры
create proc Proc7
as
	select
		*
	from
		ViewClientsAmountRentals;
go


-- 8	Хранимая процедура
-- Выбирает информацию о фактах проката автомобилей по госномеру: количество 
-- фактов проката, сумма за прокаты, суммарная длительность прокатов

-- удаление процедуры
drop proc if exists Proc8;
go

-- создание процедуры
create proc Proc8
	@plate nvarchar(9)
as
	select
		SelectCar.Id
		, SelectCar.Brand
		, SelectCar.Plate
		, SelectCar.Rental
		, count(*) as Amount
		, sum(SelectCar.Rental * Rentals.Duration) as SumPrice
		, sum(Duration)	as SumDuration
	from
		(select * from ViewCars where Plate = @plate) as SelectCar 
			left join Rentals on Rentals.IdCar = SelectCar.Id
	group by
		SelectCar.Id, SelectCar.Brand, SelectCar.Plate, SelectCar.Rental;
go
