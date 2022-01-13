/*
 * База данных «Учет сделок с недвижимостью»
 *
 * База данных должна включать как минимум таблицы КВАРТИРЫ, РИЭЛТОРЫ, СДЕЛКИ
 * (возможны и другие таблицы), содержащие следующую информацию:
 *     • Название улицы
 *     • Номер дома
 *     • Номер квартиры
 *     • Площадь квартиры
 *     • Количество комнат
 *     • Зафиксированная цена продажи квартиры
 *     • Фамилия владельца квартиры
 *     • Имя владельца квартиры
 *     • Отчество владельца квартиры
 *     • Серия-номер паспорта владельца квартиры
 *     • Дата оформления сделки купли-продажи
 *     • Фамилия риэлтора, оформившего сделку купли-продажи
 *     • Имя риэлтора, оформившего сделку купли-продажи
 *     • Отчество риэлтора, оформившего сделку купли-продажи
 *     • Процент вознаграждения, выплачиваемый риэлтору за факт 
 *       оформления сделки купли-продажи
 *
 */

-- при повторном запуске скрипта удаляем старые варианты таблиц, не разбирая пустые они или нет
-- таблицы удаляем в порядке, обратном порядку создания
drop table if exists Deals;
drop table if exists Realtors;
drop table if exists Offers;
drop table if exists Apartments;
drop table if exists Owners;
drop table if exists Persons;
drop table if exists Streets;


-- названия улиц
create table Streets (
	Id          int          not null primary key identity (1, 1),
	Street      nvarchar(30) not null    -- название улицы
);
go

-- Таблица персональных данных, одинаковых для владельцев квартир 
-- и риелторов - Persons
create table dbo.Persons (
	Id          int          not null primary key identity (1, 1),
	Surname     nvarchar(60) not null,    -- Фамилия персоны
	[Name]      nvarchar(50) not null,    -- Имя персоны
	Patronymic  nvarchar(60) not null     -- Отчество персоны
);
go

-- Таблица сведений о владельцах квартир ВЛАДЕЛЬЦЫ --> Owners
create table dbo.Owners (
	Id          int          not null primary key identity (1, 1),
	IdPerson    int          not null,    -- Внешний ключ, связь с персональными данными
	Passport    nvarchar(15) not null     -- Серия и номер паспорта
	
	-- ограничение уникальности значения столбца
	-- https://docs.microsoft.com/ru-ru/sql/relational-databases/tables/create-unique-constraints?view=sql-server-ver15
	constraint  CK_Owners_Passport unique(Passport)
	
	-- внешний ключ - связь 1:1 к таблице Persons
	constraint  FK_Owners_Persons foreign key (IdPerson) references dbo.Persons(Id)
);
go

-- Таблица сведений о квартирах КВАРТИРЫ -> Apartments
create table Apartments (
	Id          int          not null primary key identity (1, 1),
	IdStreet    int          not null,    -- улица
	Building    nvarchar(10) not null,    -- номер дома
	Flat        int          not null,    -- номер квартиры, 0 для частного сектора
	Area        int          not null,    -- площадь квартиры
	RoomNum     int          not null,    -- количество комнат

	-- ограничение на номер квартиры
	constraint CK_Apartments_Flat check (Flat >= 0),
	constraint CK_Apartments_Area check (Area >= 12),
	constraint CK_Apartments_Room check (RoomNum >= 1),

	-- внешний ключ - связь 1:M к таблице Streets
	constraint FK_Apartments_Streets foreign key (IdStreet) references dbo.Streets(Id)
);
go

-- Таблица сведений о предложениях квартир
create table Offers (
	Id          int  not null primary key identity (1, 1),
	IdApartment int  not null,    -- связь с таблицей квартир
	IdOwner     int  not null,    -- связь с таблицей владельцев
	Price       int  not null     -- предложенная цена квартиры

	-- ограничение на предложенную цену квартиры
	constraint CK_Offers_Price check (Price > 0),

	-- внешний ключ - связь 1:M к таблице Apartments
	constraint FK_Offers_Apartments foreign key (IdApartment) references dbo.Apartments(Id),

	-- внешний ключ - связь 1:M к таблице Owners 
	constraint FK_Offers_Owners foreign key (IdOwner) references dbo.Owners(Id)
);
go

-- Таблица сведений о риелторах РИЕЛТОРЫ --> Realtors
create table dbo.Realtors (
	Id           int    not null primary key identity (1, 1),
	IdPerson     int    not null,    -- Внешний ключ, связь с персональными данными
	[Percent]    float  not null,    -- Процент вознаграждения, выплачиваемый риэлтору за факт 
                                     -- оформления сделки купли-продажи
	
	-- ограничения полей таблицы
	constraint CK_Realtors_Percent check ([Percent] > 0),

	-- внешний ключ - связь 1:1 к таблице Persons
	constraint FK_Realtors_Persons foreign key (IdPerson) references dbo.Persons(Id)
);
go



-- Таблица сведений о сделках риелторов: СДЕЛКИ --> Deals  
create table dbo.Deals (
    Id              int  not null primary key identity (1, 1),
	DealDate        date not null,     -- дата заключения сделки
	IdOffer         int  not null,     -- квартира - субъект сделки
	IdRealtor       int  not null,     -- риелтор, заключивший сделку
	DealPrice       int  not null,     -- фактическая цена квартиры при закрытии сделки

	-- ограничения полей таблицы
	constraint CK_Deals_DealPrice  check (DealPrice > 0),

	-- внешний ключ - связь M:1 к таблице предложений квартир
	constraint FK_Deals_Offers foreign key (IdOffer) references dbo.Offers(Id),

	-- внешний ключ - связь M:1 к таблице риелторов
	constraint FK_Deals_Realtors foreign key (IdRealtor) references dbo.Realtors(Id)
);
go

-- Создание представлений

-- создание представления для владельцев квартир
drop view if exists ViewOwners;
go
create view ViewOwners as
select
    Owners.Id as OwnerId
    , Persons.Surname     as OwnerSurname
    , Persons.[Name]      as OwnerName
    , Persons.Patronymic  as OwnerPatronymic
    , Owners.Passport
from
    Owners join Persons on Owners.IdPerson = Persons.Id;
go

-- создание представления для риелторов
drop view if exists ViewRealtors;
go

create view ViewRealtors as
select
    Realtors.Id as RealtorId
    , Persons.Surname     as RealtorSurname
    , Persons.[Name]      as RealtorName
    , Persons.Patronymic  as RealtorPatronymic
    , Realtors.[Percent]
from
    Realtors join Persons on Realtors.IdPerson = Persons.Id;
go

-- создание представления для квартир
drop view if exists ViewApartments;
go

create view ViewApartments as
select
    Apartments.Id as ApartmentId
    , Streets.Street
    , Apartments.Building
    , Apartments.Flat
    , Apartments.Area
    , Apartments.RoomNum
from
    Apartments join Streets on Apartments.IdStreet = Streets.Id;
go


-- представление для предложений квартир
drop view if exists ViewOffers
go
create view ViewOffers
as
select
    Offers.Id as OfferId
    , ViewApartments.ApartmentId
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


-- создание представления для сделок
drop view if exists ViewDeals
go
create view ViewDeals as
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