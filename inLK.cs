/*  Дипломный проект по теме: "Разработка сервиса по обеспечению стабильной работы систем класса 'Корпоративные хранилища данных'".
 *  Название: WindowsFormApp2.
 *  Разработал: Колунтаев Евгений Владимирович, группа ТМП-81.
 *  Дата и номер версии: 31.05.2020 v1.0.
 *  Язык: C#.
 *  Краткое описание:   
 *      Данная программа является сервисом по обеспечению стабильной работы систем класса 'Корпоративные хранилища данных'. 
 *      С помощью данного сервиса производится обеспечение целостности данных в хранилище и оптимизация бизнес-процессов.
 *  Модули используемые в программе:
 *      DataHolder - модуль, содержащий данные об авторизованном пользователе.
 *  Формы используемые в программе:
 *      inLK - форма входа в личный кабинет;
 *      LK – форма личного кабинета;
 *      Registration - форма регистрации нового пользователя;
 *      Optimization – форма оптимизации бизнес-процессов;
 *      Integrity - форма обеспечения целостности данных;
 *      Trigger – форма создания или удаления триггера;
 *      ForeignKey – форма создания или удаления внешнего ключа.
 */

/* Форма "Вход в личный кабинет".
*  Название: inLK.
*  Язык: C#
*  Краткое описание:
*      Данная форма позволяет пользователю войти в личный кабинет.
*  Функции используемые в форме:
*      inLK() - конструктор формы;
*      button1_Click() - авторизация по логину и паролю.
*  Переменные используемые в форме:
*      conn - переменная для соединения с базой данных;
*      d2 - переменная, для чтения базы данных;
*      dr - переменная, хранящяя данные выполнения SQL - запроса;
*      sqlLK - строковый SQL - запрос;
*      command - строковый SQL - запрос;
*      id - id пользователя;
*      admin - подтверждение прав администратора пользователя;
*      surname - фамилия пользователя.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class inLK : Form
    {
/*  inLK() - конструктор формы. */
        public inLK()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

/*      button1_Click() - авторизация по логину и паролю.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*       Локальные переменные:
*           conn - переменная для соединения с базой данных;
*           d2 - переменная, для чтения базы данных;
*           dr - переменная, хранящяя данные выполнения SQL - запроса;
*           sqlLK - строковый SQL - запрос;
*           command - строковый SQL - запрос;
*           id - id пользователя;
*           admin - подтверждение прав администратора пользователя;
*           surname - фамилия пользователя.
*/
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=Workers;Integrated Security=True");
                conn.Open();
                string sqlLK = "select * from INFORMATION where Lgn='" + textBox1.Text + "' and Psw='" + textBox2.Text + "'";
                SqlCommand command = new SqlCommand(sqlLK, conn);
                SqlDataReader dr = command.ExecuteReader();
                int id = 0;
                string surname = "";
                bool admin = false;
                while (dr.Read())
                {
                    id = Convert.ToInt32(Convert.ToDecimal(dr.GetValue(0)));
                    admin = Convert.ToBoolean(dr.GetValue(5));
                    surname = Convert.ToString(dr.GetValue(1));
                }
                dr.Close();
                conn.Close();
                if (textBox1.Text == "" || textBox2.Text == "" || id==0)
                {
                    MessageBox.Show("Вы заполнили не все поля или ввели неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";
                }
                else
                {
                    DataHolder.id = id;
                    DataHolder.admin = admin;
                    DataHolder.surname = surname;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    Form LK = new LK
                    {
                        Left = this.Left,
                        Top = this.Top
                    };
                    LK.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Нет подключения к Базе Данных! Прверьте соединение!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }
    }
}
