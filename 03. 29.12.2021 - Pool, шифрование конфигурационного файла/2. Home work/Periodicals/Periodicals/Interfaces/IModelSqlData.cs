using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Periodicals.Interfaces
{
    // Интерфейс для обеспечения наличия метода для заполнения полей модели из SqlReader
    public interface IModelSqlData
    {
        // установка значений полей из SqlDataReader
        IModelSqlData SetValuesSqlDataReader(SqlDataReader reader);

        // вывод записей таблицы
        void ShowElem();
    }
}
