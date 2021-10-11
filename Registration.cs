/* Форма "Регистрация".
*  Название: Registration.
*  Язык: C#
*  Краткое описание:
*      Данная форма является формой создания нового пользователя.
*  Функции используемые в форме:
*      Registration() - конструктор формы;
*      button1_Click() - внесение данных о новом пользователе в базу данных;
*      button2_Click() - переход к форме личного кабинета;
*      Registration_FormClosed() - завершение работы приложения.
*  Переменные используемые в форме:
*      conn - переменная для соединения с базой данных;
*      admin - подтверждение прав администратора пользователя;
*      sqlRegistration - строковый SQL - запрос.
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
    public partial class Registration : Form
    {
/*  Registration() - конструктор формы. */
        public Registration()
        {
            InitializeComponent();
        }

/*      button2_Click() - переход к форме личного кабинета.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button2_Click(object sender, EventArgs e)
        {
            Form LK = Application.OpenForms[1];
            LK.StartPosition = FormStartPosition.Manual;
            LK.Left = this.Left;
            LK.Top = this.Top;
            LK.Show();
            this.Hide();
        }

/*      button1_Click() - внесение данных о новом пользователе в базу данных.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*       Локальные переменные:
*           conn - переменная для соединения с базой данных;
*           sqlRegistration - строковый SQL - запрос;
*           command - строковый SQL - запрос;
*           admin - подтверждение прав администратора пользователя.
*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                byte admin = 0;
                if (checkBox1.Checked)
                {
                    admin = 1;
                }
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=Workers;Integrated Security=True");
                    conn.Open();
                    string sqlRegistration = "INSERT INTO INFORMATION(Surname, Name, Lgn, Psw, Lvl) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + admin + ")";
                    SqlCommand command = new SqlCommand(sqlRegistration, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Регистрация прошла успешно", "Выполнено!");
                    Form LK = Application.OpenForms[1];
                    LK.StartPosition = FormStartPosition.Manual;
                    LK.Left = this.Left;
                    LK.Top = this.Top;
                    LK.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Введите корректные значения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

/*      Registration_FormClosed() - завершение работы приложения.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
