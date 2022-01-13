using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Periodicals.Models;       // модели
using Periodicals.Interfaces;   // интерфейсы
using static Periodicals.Application.App;         // утилиты


/*
 * Задача 1.Разработайте консольное приложение для выполнения запросов к базе данных
 * из задания на 10.11.2021:
 * База данных «Учет подписки на периодические печатные издания»
 * ЗАПРОСЫ
 * 1	Хранимая процедура	Выбирает из таблицы ИЗДАНИЯ информацию о доступных 
 *      для подписки изданиях заданного типа, стоимость 1 экземпляра для которых 
 *      меньше заданной.
 *      Требуется модель для вывода данных – данные выборки помещать в коллекцию
 * 2	Хранимая процедура	Выбирает из таблиц информацию о подписчиках, проживающих
 *      на заданной параметром улице и номере дома, которые оформили подписку на 
 *      издание с заданным параметром наименованием
 *      Требуется модель для вывода данных – данные выборки помещать в коллекцию
 * 3	Хранимая процедура	Выбирает из таблицы ИЗДАНИЯ информацию об изданиях, для 
 *      которых значение в поле Цена 1 экземпляра находится в заданном диапазоне значений
 *      Требуется модель для вывода данных – данные выборки помещать в коллекцию
 * 4	Хранимая процедура	Выбирает из таблиц информацию о подписчиках, подписавшихся 
 *      на заданный параметром тип издания
 *      Требуется модель для вывода данных – данные выборки помещать в коллекцию
 * 5	Хранимая процедура	Выбирает из таблиц ИЗДАНИЯ и ДОСТАВКА информацию обо всех
 *      оформленных подписках, для которых срок подписки есть значение из некоторого 
 *      диапазона
 * 6	Хранимая процедура	Вычисляет для каждой оформленной подписки ее стоимость с
 *      доставкой и без НДС. Включает поля Индекс издания, Наименование издания, Цена 
 *      1 экземпляра, Дата начала подписки, Срок подписки, Стоимость подписки без НДС.
 *      Сортировка по полю Индекс издания
 *  	 	 
 * 7	Итоговый запрос  Хранимая процедура
 * 	    Выполняет группировку по полю Вид издания. Для каждого вида вычисляет
 * 	    максимальную и минимальную цену 1 экземпляра
 * 8	Итоговый запрос с левым соединением  Хранимая процедура	
 *      Выполняет группировку по полю Улица. Для всех улиц вычисляет количество 
 *      подписчиков, проживающих на данной улице (итоги по полю Код получателя)
 * 9   Итоговый запрос с левым соединением  Хранимая процедура	
 *      Для всех изданий выводит количество оформленных подписок
 *      
 * •	Предусмотрите команду меню для шифрования конфигурационного файла
 * •	Предусмотрите команду меню для расшифровывания конфигурационного файла
 * •	Используйте пул подключений при выполнении запросов.
*/

namespace Periodicals.Controllers
{
    // Класс Контроллер обработки по заданию 
    public class TaskController
    {
        // строка для подключения
        private string _connectionString;

        public string ConnectionString
        {
            get => _connectionString; 
            set => _connectionString = value; 
        }


        #region Конструторы

        // конструктор по умолчанию
        public TaskController() : this(default) { }

        // конструктор инициализирующий
        public TaskController(string connectionString)
        {
            // установка значений
            ConnectionString = connectionString;
        }

        #endregion

        #region Методы

        // вывод всех записей таблицы TypesOfEdition			(Виды изданий)
        public void ShowTypesOfEdition() =>
            TypeOfEdition.ShowTable(ExecuteProcedure<TypeOfEdition>("ShowTypesOfEdition"));


        // вывод всех записей таблицы Editions                  (Издания)
        public void ShowEditions() =>
            Edition.ShowTable(ExecuteProcedure<Edition>("ShowEditions"));


        // вывод всех записей таблицы Streets                   (Улицы)
        public void ShowStreets() =>
            Street.ShowTable(ExecuteProcedure<Street>("ShowStreets"));


        // вывод всех записей таблицы Subscribers               (Подписчики)
        public void ShowSubscribers() =>
            Subscriber.ShowTable(ExecuteProcedure<Subscriber>("ShowSubscribers"));


        // вывод всех записей таблицы Delivery                  (Доставка)
        public void ShowDelivery() =>
            Delivery.ShowTable(ExecuteProcedure<Delivery>("ShowDelivery"));


        // 1. Хранимая процедура
        public void ShowProc1(string selectType) =>
            Edition.ShowTable(ExecuteProcedure<Edition>("Proc1", ("@selectType", selectType)));


        // 2. Хранимая процедура
        public void ShowProc2(string selectStreet, string selectNumberHome, string selectTitle) =>
            Delivery.ShowTable(ExecuteProcedure<Delivery>("Proc2", ("@selectStreet", selectStreet), 
                                                                   ("@selectNumberHome", selectNumberHome), 
                                                                   ("@selectTitle", selectTitle)));


        // 3. Хранимая процедура
        public void ShowProc3(int loPrice, int hiPrice) =>
            Edition.ShowTable(ExecuteProcedure<Edition>("Proc3", ("@loPrice", loPrice), 
                                                                   ("@hiPrice", hiPrice)));


        // 4. Хранимая процедура
        public void ShowProc4(string selectType) =>
            Delivery.ShowTable(ExecuteProcedure<Delivery>("Proc4", ("@selectType", selectType)));


        // 5. Хранимая процедура
        public void ShowProc5(int loMonths, int hiMonth) =>
            Delivery.ShowTable(ExecuteProcedure<Delivery>("Proc5", ("@loMonths", @loMonths), 
                                                                   ("@hiMonth", @hiMonth)));


        // 6. Хранимая процедура
        public void ShowProc6()
        {
            // вывод шапки таблицы 
            Utils.ShowHeadProc6();

            // вывод элементов таблицы
            ExecuteAndShowProcedure("Proc6", Utils.ShowElemProc6);

            // вывод подвала таблицы
            Utils.ShowLineProc6();
        }



        // 7. Хранимая процедура      Итоговый запрос
        public void ShowProc7()
        {
            // вывод шапки таблицы 
            Utils.ShowHeadProc7();

            // вывод элементов таблицы
            ExecuteAndShowProcedure("Proc7", Utils.ShowElemProc7);

            // вывод подвала таблицы
            Utils.ShowLineProc7();
        }


        // 8. Хранимая процедура      Итоговый запрос с левым соединением
        public void ShowProc8() 
        {
            // вывод шапки таблицы 
            Utils.ShowHeadProc8();

            // вывод элементов таблицы
            ExecuteAndShowProcedure("Proc8", Utils.ShowElemProc8);

            // вывод подвала таблицы
            Utils.ShowLineProc8();
        }


        // 9. Хранимая процедура      Итоговый запрос с левым соединение
        public void ShowProc9()
        {
            // вывод шапки таблицы 
            Utils.ShowHeadProc9();

            // вывод элементов таблицы
            ExecuteAndShowProcedure("Proc9", Utils.ShowElemProc9);

            // вывод подвала таблицы
            Utils.ShowLineProc9();
        }


        // выполнение процедуры
        public List<IModelSqlData> ExecuteProcedure<T>(string proc, params (string nameParam, object valueParam)[] paramsProc)
            where T : IModelSqlData, new()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // открытие соединения
                connection.Open();

                // создание команды
                SqlCommand command = new SqlCommand(proc);

                // установка типа команды
                command.CommandType = CommandType.StoredProcedure;

                // добавление параметров
                Array.ForEach(paramsProc, p => command.Parameters.AddWithValue(p.nameParam, p.valueParam));

                // установка соединения
                command.Connection = connection;

                // выполнение запроса
                SqlDataReader reader = command.ExecuteReader();

                // список объектов из полученных данных
                List<IModelSqlData> list = new List<IModelSqlData>();

                // заполнение списка данными
                while (reader.Read())
                    list.Add(new T().SetValuesSqlDataReader(reader));

                return list;
            }
        }

        
        // выполнение процедуры с выводом результата
        public void ExecuteAndShowProcedure(string proc, Action<SqlDataReader> showElem, params (string nameParam, object valueParam)[] paramsProc)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // открытие соединения
                connection.Open();

                // создание команды
                SqlCommand command = new SqlCommand(proc);

                // установка типа команды
                command.CommandType = CommandType.StoredProcedure;

                // добавление параметров
                Array.ForEach(paramsProc, p => command.Parameters.AddWithValue(p.nameParam, p.valueParam));

                // установка соединения
                command.Connection = connection;

                // выполнение запроса
                SqlDataReader reader = command.ExecuteReader();

                // заполнение списка данными
                while (reader.Read())
                    showElem(reader);
            }
        }


        // шифрование/дешифрование секции connectionStrings в конфигурационном файле 
        public void ConfigProtected(bool value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = configuration.GetSection("connectionStrings") as ConnectionStringsSection;

            // если действие уже было выполнено
            if (value == section.SectionInformation.IsProtected)
                return;

            // если требуется зашифровать секцию
            if (value)
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

            // если требуется дешифровать секцию
            else
                section.SectionInformation.UnprotectSection();

            // сохранение изменений
            configuration.Save();   
        }

        #endregion
    }
}
