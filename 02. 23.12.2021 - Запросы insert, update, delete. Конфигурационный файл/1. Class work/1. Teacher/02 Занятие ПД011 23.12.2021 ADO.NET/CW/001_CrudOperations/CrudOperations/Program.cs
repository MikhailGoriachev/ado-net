using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// для работы с технологией ADO.NET
using System.Configuration;   // добавить сборку System.Configuration.dll
using System.Data;
using System.Data.SqlClient;

// для вызова стандартного окна сообщений MessageBox, сборка System.Windows.Forms
using System.Windows.Forms;


namespace CrudOperations
{
    class Program
    {
        // создание строки соединения с базой данных - чтение из app.config
        // индексируем свойство ConnectionStrings именем строки соединения
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["RealEstateConnection"].ConnectionString;

        static void Main(string[] args) {
            try {

                // агрегатные функции - не затрагивают структуру таблицы,
                // можно не закомментировать
                // В аббревиатуре CUDA это A, Aggregate
                // !! Использование ExecuteScalar() - для запросов, возвращающих 1 значение !!
                // AggregateDemo();

                // раскомментировать вызовы по одному, в таблице apartments
                // действует уникальный индекс - не д.б. повторяющихся записей
                // при вставке - т.е. повторный вызов без коррекции вставляемых
                // данных приводит к исключению
                // создание новой записи в таблце
                // Insert - но в аббревиатуре CUDA это C, Create
                // InsertDemo();

                // Возвращаемое из запроса значение
                // int id = InsertRealtor("Шапиро", "Федор", "Федорович", 20);
                // Console.WriteLine($"создана новая запись для риэлтора, id = {id}");

                // обновление/изменение существующей записи/записей
                // Update - в аббревиатуре CUDA это U, Update 
                // UpdateDemo();

                // удаление записи/записей
                // Delete - в аббревиатуре CUDA это D, Delete
                // DeleteDemo();


                // Пример вызова хранимой процедуры
                Query01(2, "ул. Ореховая");
                Query01(3, "ул. Садовая");

                // пример вызова хранимой процедуры с возвратом значения
                ProcInsertRealtor("Шапиро", "Федор", "Федорович", 21);
                ProcInsertRealtor("Романофф", "Наталья", "Павловна", 50);

            }
            catch (Exception ex) {
                MessageBox.Show($"Исключение: {ex.Message}\nстрока: {ex.StackTrace}", 
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            } // try-box
        }  // Main

       

        // операция insert - при помощи вызова ExecuteNonQuery()
        // ExecuteNonQuery() - выполняет T-SQL инструкцию, возвращает
        // количество обработанных в запросе записей
        private static void InsertDemo() {
            Console.WriteLine("\nДобавим квартиру: Василий Васильевич Домовик, терапевт");
            string query= @"
                INSERT INTO apartments 
                    (IdStreet, Building, Flat, Area, RoomNum) VALUES 
                    ((select id from Streets where street = N'ул. Садовая'), 12, 17, 350, 3)";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand insert = new SqlCommand(query, connection);

                // create, update, delete - ExecuteNonQuery()
                // возвращается количество записей, затронутых запросом
                int number = insert.ExecuteNonQuery();

                Console.WriteLine($"\nВ таблицу apartments добавлено квартир: {number}");
            } // using
        } // InsertDemo

        // операция update - при помощи вызова ExecuteNonQuery()
        private static void UpdateDemo() {
            Console.WriteLine("\nУвеличим процент всем риэлторам на 2");
            string query = @"update realtors set [percent] += 2;";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand insert = new SqlCommand(query, connection);

                int number = insert.ExecuteNonQuery();
                
                Console.WriteLine($"\nВ таблице realtors изменено записей: {number}");
            } // using
        } // UpdateDemo

        // операция delete - при помощи вызова ExecuteNonQuery()
        private static void DeleteDemo() {
            // простой запрос
            // Console.WriteLine("\nУдалить все сделки риэлотра с ид = 7");
            // string query = @"delete from dealings where idRealtor = 7;";

            // запрос с подзапросом
            string surname = "Ильюшин", name = "Сергей";
            Console.WriteLine($"\nУдалить все сделки риэлторов с фамилией {surname} и именем {name}");
           
            string query = @"
                delete from deals 
                where idRealtor in (
                    -- это подзапрос, т.е. запрос в запросе
                    -- всегда должен возвращать только одно значение !!!!!! 
                    select RealtorId from ViewRealtors where RealtorSurname = @surname and RealtorName = @name 
                );";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand delete = new SqlCommand(query, connection);
                delete.Parameters.AddWithValue("@name", name);
                delete.Parameters.AddWithValue("@surname", surname);
                
                int number = delete.ExecuteNonQuery();
                Console.WriteLine($"\nВ таблице deals удалено записей: {number}");
            } // using
        } // DeleteDemo

        // работа с агрегатными функциями  - при помощи вызова ExecuteScalar()
        private static void AggregateDemo() {
            // Коллекция запросов
            string[] queries = {
                // средний процент вознаграждения риэлторов
                @"select avg([percent]) from realtors;",
                // минимальная площадь квартиры
                @"select min(area) from apartments;",
                // максимальная стоимость квартиры 
                @"select max(price) from offers;"
            };

            string[] strings = {
                @"средний процент вознаграждения риэлторов",
                @"минимальная площадь квартиры",
                @"максимальная стоимость квартиры"
            };

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand cmd = new SqlCommand("", connection);

                int i = 0;
                foreach (var query in queries) {
                    cmd.CommandText = query;

                    // удобство хранения запросов в данном случае разбивается
                    // о неудобство вывода результатов разного типа :( :( :( 
                    switch (i) {
                        case 0:
                            double avg = (double) cmd.ExecuteScalar();
                            Console.WriteLine($"{strings[i]}: {avg:N2}");
                            break;
                        case 1:
                            int min = (int)cmd.ExecuteScalar();
                            Console.WriteLine($"{strings[i]}: {min}");
                            break;
                        case 2:
                            int max = (int)cmd.ExecuteScalar();
                            Console.WriteLine($"{strings[i]}: {max:N2}");
                            break;
                    } // if
                    i++;
                } // foreach
            } // using

        } // AggregateDemo


        // Пример запроса с параметрами и возвращаением значения - выходным является @id 
        private static int InsertRealtor(string surname, string name, string patronymic, int interest) {
            SqlParameter idParameter;  // для выходного параметра запроса

            Console.WriteLine($"\nДобавление риэлтора: {surname} {name} {patronymic} {interest}");
            string query = @"
                INSERT INTO realtors 
                    (IdPerson, [Percent]) VALUES 
                    ((select id from persons where surname = @surname and [name] = @name and patronymic =  @patronymic), 
                     @percent);
                    set @id = scope_identity();";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand insert = new SqlCommand(query, connection);
                
                // добавляем входные параметры
                insert.Parameters.AddWithValue("@surname", surname);
                insert.Parameters.AddWithValue("@name", name);
                insert.Parameters.AddWithValue("@patronymic", patronymic);
                insert.Parameters.AddWithValue("@percent", interest);

                // определение выходного параметра запроса - @id
                // (ид, полученный записью)
                idParameter = new SqlParameter {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                // добавить выходной парамемтр
                insert.Parameters.Add(idParameter);   

                int number = insert.ExecuteNonQuery();
                Console.WriteLine($"\nВ таблицу realtors добавлен риэлотр, добавлено записей: {number}");
            } // using

            // возвращаем значение, полученное в выходном параметре запроса
            return (int)idParameter.Value;
        } // InsertRealtor

        // Пример вызова хранимой процедуры
        // Выбирает информацию о 3-комнатных квартирах, расположенных на улице 
        // «Садовая». Значения задавать параметрами запроса
        private static void Query01(int roomNumber, string street) {
            Console.WriteLine("\n\n\n\n\tЗапрос 01.\n" +
                              $"\tКвартиры с количеством комнат {roomNumber} на {street}\n");

            // подключение к БД
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open(); // подключение к серверу, блокирующий вызов

                // создание команды (запрос SQL), привязка к соединению
                // SqlCommand cmd = new SqlCommand(@"exec ProcQuery01 @roomNum, @street");
                SqlCommand cmd = new SqlCommand(@"ProcQuery01");
                cmd.CommandType = CommandType.StoredProcedure;

                // задать соединение с БД
                cmd.Connection = connection;

                // задать параметры запроса
                cmd.Parameters.AddWithValue("@roomNum", roomNumber);
                cmd.Parameters.AddWithValue("@street", street);

                // выполнение запроса, ссылка на  выбранные данные - reader
                SqlDataReader reader = cmd.ExecuteReader();

                // Если данные получены (есть строки в полученном ответе сервера)
                if (reader.HasRows) {
                    // выводим имена столбцов (это не обязательно)
                    Console.WriteLine("\t" +
                          $"│ {reader.GetName(0), 11} │ {reader.GetName(1),-15} " +
                          $"│ {reader.GetName(2),-15} │ {reader.GetName(3), 4} " +
                          $"│ {reader.GetName(4),  4} │ {reader.GetName(5), 7} │");

                    while (reader.Read()) {
                        Console.WriteLine("\t" +
                              $"│ {reader.GetInt32(0), 11} " +
                              $"│ {reader.GetString(1),-15} " +
                              $"│ {reader.GetString(2),-15} " +
                              $"│ {reader.GetInt32(3), 4} " +
                              $"│ {reader.GetInt32(4), 4} " +
                              $"│ {reader.GetInt32(5), 7} │");
                    } // while
                } // if
            } // using
        } // Query01


        // пример вызова хранимой процедуры с возвратом значения
        private static void ProcInsertRealtor(string surname, string name, string patronymic, double percent) {
              Console.WriteLine("\n\n\n\n\tЗапрос 01.\n" +
                              $"\tДобавление риелтора {surname} {name} {patronymic} {percent}%\n");

            // подключение к БД
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open(); // подключение к серверу, блокирующий вызов

                // создание команды (запрос SQL), привязка к соединению
                SqlCommand cmd = new SqlCommand(@"InsertRealtor");
                cmd.CommandType = CommandType.StoredProcedure;

                // задать соединение с БД
                cmd.Connection = connection;

                // задать параметры запроса
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@patronymic", patronymic);
                cmd.Parameters.AddWithValue("@percent", percent);

                SqlParameter id = cmd.Parameters.Add(new SqlParameter());
                id.Direction = System.Data.ParameterDirection.ReturnValue; // после выполнения комманды parameter будет содержать возвращаемое значение хранимой процедуры 

                // выполнение запроса
                cmd.ExecuteNonQuery();
                Console.WriteLine($"\tРиелтор добавлен, ид = {id.Value}\n\n");
            } // using
        } // ProcInsertRealtor
    }
}
