﻿-- заполенение таблицы TypesOfEdition			(Виды изданий)
insert into TypesOfEdition
	(TypesOfEdition.[Type])
values
	(N'журнал'),
	(N'газета'),
	(N'альманах'),
	(N'каталог');

-- заполенение таблицы Streets					(Улицы)
insert into Streets
	(Street)
values
    (N'Петровского'),
    (N'Артёма'),
    (N'Горького'),
    (N'Садовая'),
    (N'Содовая'),
    (N'Крамарчука'),
    (N'Дерибасовская');

-- заполенение таблицы Editions					(Издания)
insert into Editions
	(IdTypesOfEdition, IndexEdition, Price, Title)
values
	(4, 75418, 650,		N'Новинки Avon'),
	(4,	87951, 480,		N'Новинки Oriflame'),
	(2,	87956, 250,		N'Аргументы и факты'),
	(2,	98516, 400,		N'Вечерняя Москва'),
	(2,	14657, 540,		N'Известия'),
	(1,	23165, 1500,	N'National Geographic'),
	(1,	19851, 2200,	N'Glamour'),
	(2,	98416, 120,		N'Земля моя кормилица'),
	(2,	95184, 520,		N'Земля и люди'),
	(3,	23154, 2200,	N'Образ жизни'),
	(3,	65484, 4200,	N'Литературный оверлок'),
	(3,	32134, 3200,	N'Мы все с планеты'),
	(2,	21654, 120,		N'Правда'),
	(2,	21891, 140,		N'Природа Европы'),
	(2,	87941, 120,		N'Правда'),
	(2,	89512, 120,		N'Правда'),
	(2,	95175, 520,		N'Земля и люди');

-- заполенение таблицы Subscribers				(Подписчики)
insert into Subscribers
	(LastName, FirstName, Patronymic, NumberPassport, IdStreets, NumberHome, NumberApartment)
values													-- номер паспорта по образцу украинских ID-карт
	(N'Орлов',      N'Марат',       N'Романович',       N'19700112-46514', 1, N'256',		N'87'),
    (N'Яровой',     N'Александр',   N'Александрович',   N'19800101-87951', 1, N'240',		N'52'),
    (N'Петровский', N'Илларион',    N'Львович',         N'19800101-32165', 2, N'256',		N'24'),
    (N'Щукин',      N'Клаус',       N'Леонидович',      N'19831209-87984', 3, N'38',		N'18'),
    (N'Воробьёв',   N'Савва',       N'Михайлович',      N'19861002-32154', 1, N'256',		N'4'),
    (N'Алчевский',  N'Жигер',       N'Андреевич',       N'19950818-98484', 1, N'256',		N'63'),
    (N'Яковенко',   N'Добрыня',     N'Романович',       N'19560315-17348', 1, N'184',		N'12'),
    (N'Щербаков',   N'Юлий',        N'Леонидович',      N'19861002-51842', 4, N'256',		N'18'),
    (N'Самойлов',   N'Ярослав',     N'Петрович',        N'19970315-87912', 2, N'13',		N'28'),
    (N'Романов',    N'Чарльз',      N'Сергеевич',       N'19561002-21354', 3, N'23',		N'7'),
    (N'Бородай',    N'Спартак',     N'Анатолиевич',     N'19861002-95417', 4, N'19',		N'78'),
    (N'Туров',      N'Болеслав',    N'Вадимович',       N'19861002-21568', 1, N'256',		N'25'),
    (N'Капустин',   N'Павел',       N'Викторович',      N'19861002-89741', 1, N'256',		N'17');

-- заполенение таблицы Delivery					(Доставка)
insert into Delivery
	(IdSubscribers, IdEditions, DateStartSubscribe, SubscribePeriodMonths)
values
	(1,		4,	'2020/12/10',	5),
	(2,		6,	'2020/12/10',	10),
	(3,		3,	'2020/12/10',	16),
	(4,		2,	'2020/12/10',	3),
	(5,		4,	'2020/12/10',	1),
	(6,		4,	'2020/12/10',	16),
	(7,		5,	'2020/12/10',	5),
	(8,		9,	'2020/12/10',	10),
	(9,		4,	'2020/12/10',	16),
	(10,	4,	'2020/12/10',	5);

-- удаление данных из таблиц
-- delete Delivery;
-- delete Subscribers;
-- delete Editions;
-- delete TypesOfEdition;
-- delete Streets;