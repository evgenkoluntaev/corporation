/* Форма "Оптимизация".
*  Название: Optimization.
*  Язык: C#
*  Краткое описание:
*      Данная форма является формой оптимизации бизнес-процессов.
*  Функции используемые в форме:
*      Optimization() - конструктор формы;
*      button1_Click() - выведение данных по оптимизации процессов на экран;
*      button2_Click() - переход к форме личного кабинета;
*      Optimization_FormClosed() - завершение работы приложения.
*  Переменные используемые в форме:
*      admin - подтверждение прав администратора пользователя;
*      sqlOpt - строковый SQL - запрос;
*      command - строковый SQL - запрос
*      dt - переменная, для чтения базы данных;
*      dr - переменная, хранящяя данные выполнения SQL - запроса.
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
    public partial class Optimization : Form
    {
/*  Optimization() - конструктор формы. */
        public Optimization()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyyMMdd";
            dateTimePicker2.CustomFormat = "yyyyMMdd";
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

/*      Optimization_FormClosed() - завершение работы приложения.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void Optimization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

/*      button1_Click() - выведение данных по оптимизации процессов на экран.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*       Локальные переменные:
*           conn - переменная для соединения с базой данных;
*           dt - переменная, для чтения базы данных;
*           dr - переменная, хранящяя данные выполнения SQL - запроса;
*           sqlOpt - строковый SQL - запрос;
*           command - строковый SQL - запрос.
*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Дата начала процесса не может быть позже даты окончания или совпадать!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=Workflow;Integrated Security=True");
            conn.Open();
            string sqlOpt = "EXECUTE WORKFLOW_OPTIMIZATION '"+dateTimePicker1.Text+"', '"+dateTimePicker2.Text+"', '"+textBox1.Text+"'";
            SqlCommand command = new SqlCommand(sqlOpt, conn);
            SqlDataReader dr = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            bindingSource1.DataSource = dt;
            dataGridView1.DataSource = bindingSource1;
            conn.Close();
        }
    }
}
