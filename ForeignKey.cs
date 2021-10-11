/* Форма "Работа с внешним ключом".
*  Название: ForeignKey.
*  Язык: C#
*  Краткое описание:
*      Данная форма позволяет добавить или удалить внешний ключ.
*  Функции используемые в форме:
*      ForeignKey() - конструктор формы;
*      button1_Click() - выполнение действий по добавлению или удалению триггера;
*      button2_Click() - переход к форме обеспечения целостности данных;
*      ForeignKey_FormClosed() - завершение работы приложения;
*      comboBox1_SelectedIndexChanged() - блокировка введения лишних данных.
*  Переменные используемые в форме:
*      option - выбор действия;
*      conn - переменная для соединения с базой данных;
*      sqlFK - строковый SQL - запрос;
*      command - строковый SQL - запрос.
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
    public partial class ForeignKey : Form
    {
/*  ForeignKey() - конструктор формы. */
        public ForeignKey()
        {
            InitializeComponent();
        }

/*      button1_Click() - выполнение действий по добавлению или удалению триггера.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*       Локальные переменные:
*           option - выбор действия;
*           conn - переменная для соединения с базой данных;
*           sqlFK - строковый SQL - запрос;
*           command - строковый SQL - запрос.
*/
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte option = 2;
                string Message = "";
                if (comboBox1.Text == "Добавить")
                {
                    option = 1;
                    Message = "Вы создали внешний ключ!";
                };
                if (comboBox1.Text == "Удалить")
                {
                    option = 0;
                    Message = "Вы удалили внешний ключ!";
                };
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=master;Integrated Security=True");
                conn.Open();
                string sqlFK = "EXEC FK_CREATE_DELETE '" + textBox1.Text + "', '" + textBox5.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "'," + option; 
                SqlCommand command = new SqlCommand(sqlFK, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show(Message, "Успешно!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch
            {
                MessageBox.Show("Вы заполнили не все поля или ввели неверные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

/*       button2_Click() - переход к форме обеспечения целостности данных.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button2_Click(object sender, EventArgs e)
        {
            Form Integrity = new Integrity
            {
                Left = this.Left,
                Top = this.Top
            };
            Integrity.Show();
            this.Hide();
        }

/*      ForeignKey_FormClosed() - завершение работы приложения.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void ForeignKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

/*       comboBox1_SelectedIndexChanged() - блокировка введения лишних данных.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Удалить")
            {
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
            }
            else
            {
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
            }
        }
    }
}
