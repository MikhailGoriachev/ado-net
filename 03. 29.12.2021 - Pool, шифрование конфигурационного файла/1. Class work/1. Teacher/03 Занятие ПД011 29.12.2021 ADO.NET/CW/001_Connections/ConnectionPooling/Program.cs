using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// для работы с технологией ADO.NET
using System.Configuration;   // добавить сборку System.Configuration.dll
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

// для вызова стандартного окна сообщений MessageBox, сборка System.Windows.Forms
using System.Windows.Forms;
using ConnectionPooling.Models;

namespace ConnectionPooling
{
    class Program
    {
        // создание строки соединения с базой данных - чтение из app.config
        // индексируем свойство ConnectionStrings именем строки соединения
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["RealEstateConnection"].ConnectionString;

        static void Main(string[] args) {
            // количество выполняемых запросов
            int n = 1000;

            try {
                Stopwatch _timer = Stopwatch.StartNew();
                for (int i = 0; i < n; i++) {
                    Query01(2, "ул. Ореховая");
                }
                _timer.Stop();

                Console.WriteLine($"На выполнение {n} запросов затрачено {_timer.Elapsed}");
            } catch (Exception ex) {
                MessageBox.Show($"Исключение: {ex.Message}\nстрока: {ex.StackTrace}", 
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            } // try-box
        } // Main



        // Пример вызова хранимой процедуры
        // Выбирает информацию о 3-комнатных квартирах, расположенных на улице 
        // «Садовая». Значения задавать параметрами запроса
        private static void Query01(int roomNumber, string street) {
            // Console.WriteLine("\n\n\n\n\tЗапрос 01.\n" +
            //                   $"\tКвартиры с количеством комнат {roomNumber} на {street}\n");

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
                // if (reader.HasRows) {
                //     // выводим имена столбцов (это не обязательно)
                //     Console.WriteLine("\t" +
                //         $"│ {reader.GetName(0), 11} │ {reader.GetName(1),-15} " +
                //         $"│ {reader.GetName(2),-15} │ {reader.GetName(3), 4} " +
                //         $"│ {reader.GetName(4),  4} │ {reader.GetName(5), 7} │");
                // 
                //     while (reader.Read()) {
                //         Console.WriteLine("\t" +
                //             $"│ {reader.GetInt32(0), 11} " +
                //             $"│ {reader.GetString(1),-15} " +
                //             $"│ {reader.GetString(2),-15} " +
                //             $"│ {reader.GetInt32(3), 4} " +
                //             $"│ {reader.GetInt32(4), 4} " +
                //             $"│ {reader.GetInt32(5), 7} │");
                //     } // while
                // } // if
            } // using
        } // Query01




    } // class Program
}
