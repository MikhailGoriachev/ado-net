using System;

using System.Collections.Generic;
using System.Data.SqlClient;        // для ADO.NET

using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Введение в ADO.NET
// подключенный уровень
namespace BasicAdo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 20.12.2021 - введение в ADO.NET";
            Console.WindowWidth = 110;
            Console.WindowHeight = 32;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();

            try {
                // строка подключения к БД - взята из свойств базы данных
                // Обозреватель серверов -> Свойства -> Строка подключения

                string connectingString =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\1.Programming\7.ADO.NET\01. 20.12.2021 -\2.Home work\HomeWork\HomeWork\App_Data\Transactions.mdf"";Integrated Security=True";

                // запрос без параметров
                Query01(connectingString);
                Console.WriteLine();

                // пример запроса с параметром
                //Query02(connectingString);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } // try-catch
        } // Main


        // пример запроса select без параметров
        private static void Query01(string connectingString) {
            Console.WriteLine("\nЗапрос 1");

            // подключение к БД
            using (SqlConnection connection = new SqlConnection(connectingString)) {
                connection.Open();   // подключение к серверу, блокирующий вызов
                Console.WriteLine("Соединение открыто");

                // создание команды (запрос SQL), привязка к соединению
                SqlCommand cmd = new SqlCommand(
                @"select
	                        Id
		                    , DepartmentName
		                    , DepartmentType
		                    , Addition1
	                     from
	                        ViewDepartments"
                );

                // задать соединение с БД
                cmd.Connection = connection;

                // выполнение запроса, ссылка на  выбранные данные - reader
                SqlDataReader reader = cmd.ExecuteReader();

                // Если данные получены (есть строки в полученном ответе серврера)
                if (reader.HasRows) {
                    // выводим имена столбцов (это не обязательно)
                    Console.WriteLine(
                        $"| {reader.GetName(0)} | {reader.GetName(1), -15} | " +
                        $"{reader.GetName(2), -15} | {reader.GetName(3), -9} |");

                    while (reader.Read()) {
                        Console.WriteLine(
                            $"| {reader.GetInt32(0), 2} | " +
                            $"{reader.GetString(1), -15} | {reader.GetString(2), -15} | " +
                            $"{reader.GetDouble(3), 9:n2} |");
                    } // while
                } // if
            } // using
            Console.WriteLine("Соединение закрыто");
            Console.WriteLine();
        }

        // пример запроса select с параметрfvb
        private static void Query02(string connectingString) {
            Console.WriteLine("\nЗапрос 2");

            // подключение к БД
            using (SqlConnection connection = new SqlConnection(connectingString)) {
                connection.Open();   // подключение к серверу, блокирующий вызов
                Console.WriteLine("Соединение открыто");

                // создание команды (запрос SQL), привязка к соединению
                SqlCommand cmd = new SqlCommand(
                @"select
	                        Id
		                    , DepartmentName
		                    , DepartmentType
		                    , Addition1
	                    from
	                        ViewDepartments
                        where
	                        DepartmentType in (@dep1, @dep2) and Addition1 > @addition1"
                );

                // задать соединение с БД
                cmd.Connection = connection;
                
                // задать параметры запроса
                cmd.Parameters.AddWithValue("@dep1", "цех");
                cmd.Parameters.AddWithValue("@dep2", "отдел");
                cmd.Parameters.AddWithValue("@addition1", 10);

                // выполнение запроса, ссылка на  выбранные данные - reader
                SqlDataReader reader = cmd.ExecuteReader();

                // Если данные получены (есть строки в полученном ответе серврера)
                if (reader.HasRows) {
                    // выводим имена столбцов (это не обязательно)
                    Console.WriteLine(
                        $"| {reader.GetName(0)} | {reader.GetName(1), -15} | " +
                        $"{reader.GetName(2), -15} | {reader.GetName(3), -9} |");

                    while (reader.Read()) {
                        Console.WriteLine(
                            $"| {reader.GetInt32(0), 2} | " +
                            $"{reader.GetString(1), -15} | {reader.GetString(2), -15} | " +
                            $"{reader.GetDouble(3), 9:n2} |");
                    } // while
                } // if
            } // using
            Console.WriteLine("Соединение закрыто");
            Console.WriteLine();
        }
    } // class Program
}
