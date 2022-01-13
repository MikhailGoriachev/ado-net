-- База данных «Учет сделок с недвижимостью»

-- Вывод всех таблиц с рашифровкой полей связанных таблиц
select
    *
from
    Streets;
go


select
    *
from
    Persons;
go


-- таблица владельцев
select
    Owners.Id
    , Persons.Surname
    , Persons.[Name]
    , Persons.Patronymic
    , Owners.Passport
from
    Owners join Persons on Owners.IdPerson = Persons.Id;
go




-- таблица риелторов
select
    Realtors.Id 
    , Persons.Surname
    , Persons.[Name]
    , Persons.Patronymic
    , Realtors.[Percent]
from
    Realtors join Persons on Realtors.IdPerson = Persons.Id;
go



-- квартиры
select
    Apartments.Id
    , Streets.Street
    , Apartments.Building
    , Apartments.Flat
    , Apartments.Area
    , Apartments.RoomNum
from
    Apartments join Streets on Apartments.IdStreet = Streets.Id;
go




-- предложения квартир
select
    Offers.Id as OfferId
    , ViewApartments.Street
    , ViewApartments.Building
    , ViewApartments.Flat
    , ViewApartments.RoomNum
    , ViewApartments.Area
    , ViewOwners.OwnerSurname 
    , ViewOwners.OwnerName
    , ViewOwners.OwnerPatronymic
    , Offers.Price
from
    Offers join ViewApartments on Offers.IdApartment = ViewApartments.ApartmentId
           join ViewOwners on Offers.IdOwner = ViewOwners.OwnerId
go


-- сделки
select 
    Id as DealId
    , ViewOffers.OfferId
    , ViewOffers.ApartmentId
    , Deals.DealDate 
    , Deals.DealPrice
    , ViewOffers.Street
    , ViewOffers.Building
    , ViewOffers.Flat
    , ViewOffers.RoomNum
    , ViewOffers.Area
    , ViewOffers.OwnerSurname 
    , ViewOffers.OwnerName
    , ViewOffers.OwnerPatronymic
    , ViewOffers.Price
    , ViewRealtors.RealtorSurname
    , ViewRealtors.RealtorName
    , ViewRealtors.RealtorPatronymic
    , ViewRealtors.[Percent]
from
    Deals join ViewOffers on Deals.IdOffer = ViewOffers.OfferId
          join ViewRealtors on Deals.IdRealtor = ViewRealtors.RealtorId
go



-- Выполнение запросов по заданию

-- Запрос  1. Запрос с параметрами	
-- Выбирает информацию о 3-комнатных квартирах, расположенных на улице 
-- «Садовая». Значения задавать параметрами запроса
declare @roomNum int = 3, @street nvarchar(30) =  N'ул. Садовая';

select
    ApartmentId
    , Street
    , Building
    , Flat
    , Area
    , RoomNum
from
    ViewApartments
where
    RoomNum = @roomNum and Street = @street;
go





-- Запрос  2. Запрос с параметрами	
-- Выбирает информацию о риэлторах, фамилия которых начинается с буквы «И» и 
-- процент вознаграждения больше 10%. Значения задавать параметрами запроса
declare @surname nvarchar(60) =  N'И', @percent float = 10;

select
    RealtorId
    , RealtorSurname
    , RealtorName
    , RealtorPatronymic
    , [Percent]
from
    ViewRealtors
where
    RealtorSurname like (@surname + N'%') and [Percent] > @percent;
go


-- Запрос  3. Запрос с параметрами	
-- Выбирает информацию об 1-комнатных квартирах, цена на которые находится
-- в диапазоне от 900 000 руб. до 1000 000 руб. Значения задавать параметрами
-- запроса
declare @roomNum int = 1, @lo int =  900000, @hi int = 1000000;

select
    ApartmentId
    , Street
    , Building
    , Flat
    , Area
    , RoomNum
    , Price
from
    ViewOffers
where
    RoomNum = @roomNum and Price between @lo and @hi;
go


-- Запрос  4. Запрос с параметрами	
-- Выбирает информацию о квартирах с заданным числом комнат. Значения задавать 
-- параметрами запроса
declare @roomNum int = 1;

select
    ApartmentId
    , Street
    , Building
    , Flat
    , Area
    , RoomNum
    , Price
from
    ViewOffers
where
    RoomNum = @roomNum;
go


-- Запрос  5. Запрос с параметрами	
-- Выбирает информацию обо всех 2-комнатных квартирах, площадь которых есть 
-- значение из некоторого диапазона. Значения задавать параметрами запроса
declare @roomNum int = 2, @lo int = 80, @hi int = 120;

select
    ApartmentId
    , Street
    , Building
    , Flat
    , Area
    , RoomNum
    , Price
from
    ViewOffers
where
    RoomNum = @roomNum and Area between @lo and @hi;
go


-- Запрос  6. Запрос с вычисляемыми полями	
-- Вычисляет для каждой оформленной сделки размер комиссионного вознаграждения
-- риэлтора. Включает поля Фамилия риэлтора, Имя риэлтора, Отчество риэлтора, 
-- Дата сделки, Цена квартиры, Комиссионные. Сортировка по полю Дата сделки
select
    Persons.Surname
    , Persons.[Name]
    , Persons.Patronymic
    , Deals.DealDate
    , Deals.DealPrice
    , Realtors.[Percent]
    , Deals.DealPrice * Realtors.[Percent] / 100 as Fee
from
    ViewDeals;
go


-- Запрос  7. Запрос на левое соединение	
-- Выбрать всех риэлторов, количество клиентов, оформивших с ним сделки и сумму
-- сделок риэлтора. Упорядочить выборку по убыванию суммы сделок.
select
    -- данные риелтора - группа
    ViewRealtors.RealtorId
    , ViewRealtors.RealtorSurname
    , ViewRealtors.RealtorName
    , ViewRealtors.RealtorPatronymic
    -- агрегатные функции
    , Count(Deals.IdOffer) as ClientTotal -- упрощение Deals.IdOffer это клиент
    , Sum(Deals.DealPrice) as RealtorSum
from
    ViewRealtors 
        left join 
    Deals on ViewRealtors.RealtorId = Deals.IdRealtor
group by
    ViewRealtors.RealtorId, ViewRealtors.RealtorSurname, ViewRealtors.RealtorName, 
    ViewRealtors.RealtorPatronymic;
go


-- Запрос  8. Запрос на левое соединение	
-- Для всех улиц вывести сумму сделок, упорядочить выборку по убыванию суммы 
-- сделки
select
    Streets.Id
    , Streets.Street
    , Sum(ViewDeals.DealPrice) as SumDeals
from
    Streets left join ViewDeals  on Streets.Street = ViewDeals.Street
group by
    Streets.Id, Streets.Street;
go

-- Запрос  9. Запрос на левое соединение	
-- Для всех улиц вывести сумму сделок за заданный период, упорядочить выборку 
-- по убыванию суммы сделки. Диапазон задавать параметрами запроса 
declare @from date = '10-01-2021', @to date = '10-31-2021';
select
    Streets.Id
    , Streets.Street
    , COUNT(PeriodDeals.DealPrice) as Amount
    , SUM(PeriodDeals.DealPrice) as Total
from
    Streets left join 
        -- данные по сделкам за период извлекаем при помощи подзапроса, требуется назначить 
        -- псевдоним этому подзапросу
        (select ViewDeals.DealDate, ViewDeals.DealPrice, ViewDeals.Street from ViewDeals  
         where ViewDeals.DealDate between @from and @to) PeriodDeals
    on Streets.Street = PeriodDeals.Street
group by
    Streets.Id, Streets.Street
order by
    Total desc;
go 


-- ----------------------------------------------------------------
create proc ProcQuery01
   @roomNum int,
   @street nvarchar(30)
as
begin
    select
        ApartmentId
        , Street
        , Building
        , Flat
        , Area
        , RoomNum
    from
        ViewApartments
    where
        RoomNum = @roomNum and Street = @street;
end;
go

exec ProcQuery01 3,  N'ул. Садовая';
go


-- вставить риелтора, если нет персональных данных, то добавить их
-- вернуть ид добавленного риелтора
drop proc if exists InsertRealtor;
go

create proc InsertRealtor
     @surname    nvarchar(60),
     @name       nvarchar(50),
     @patronymic nvarchar(70),
     @percent    float
as
begin
    -- идентификатор персональных данных
    declare @id int;

    -- поиск персоны в таблице персональных данных
    select 
        @id = Id 
    from 
        Persons 
    where
        Surname = @surname and [Name] = @name and Patronymic = @patronymic;

    -- если данных нет, то добавить их
    if @id is null begin
        insert Persons
            (Surname, [Name], Patronymic)
        values
            (@surname, @name, @patronymic);
        set @id = @@IDENTITY;   -- последний добавленный идентификатор
    end;

    -- персональные данные найдены или добавлены, завершаем вставку
    -- добавляя данные данные риелтора
    insert Realtors
        (IdPerson, [Percent])
    values 
        (@id, @percent);

    return @@Identity; -- последний добавленный идентификатор
end;
go

-- проверка работы процедуры
declare @id int;
exec @id = InsertRealtor N'Шапиро', N'Федор', N'Федорович', 23
print N'Получен id: ' + convert(nvarchar, @id);
go

declare @id int;
exec @id = InsertRealtor N'Яковлева', N'Александра', N'Дмитриевна', 22
print N'Получен id: ' + convert(nvarchar, @id);
go