/*  Вспомогательный модуль, содержащий данные об авторизованном пользователе.
*  Название: DataHolder.
*  Язык: C#
*  Краткое описание:   
*      Данный модуль предназначен для хранения данных об авторизованном пользователе.
*  Глобальные переменные в модуле:
*           id - id пользователя;
*           admin - подтверждение прав администратора пользователя;
*           surname - фамилия пользователя.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DataHolder
    {
        public static int id;
        public static bool admin;
        public static string surname;
    }
}
