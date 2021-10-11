/* Форма "Работа с триггерами".
*  Название: Trigger.
*  Язык: C#
*  Краткое описание:
*      Данная форма позволяет добавить или удалить триггер.
*  Функции используемые в форме:
*      Trigger() - конструктор формы;
*      button1_Click() - выполнение действий по добавлению или удалению триггера;
*      button2_Click() - переход к форме обеспечения целостности данных;
*      Trigger_FormClosed() - завершение работы приложения;
*      comboBox1_SelectedIndexChanged() - блокировка введения лишних данных.
*  Переменные используемые в форме:
*      option - выбор действия;
*      conn - переменная для соединения с базой данных;
*      sqlTG - строковый SQL - запрос;
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
    public partial class Trigger : Form
    {
/*  Trigger() - конструктор формы. */
        public Trigger()
        {
            InitializeComponent();
        }

/*      Trigger_FormClosed() - завершение работы приложения.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void Trigger_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

/*      button1_Click() - выполнение действий по добавлению или удалению триггера.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*       Локальные переменные:
*           option - выбор действия;
*           conn - переменная для соединения с базой данных;
*           sqlTG - строковый SQL - запрос;
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
                    Message = "Вы создали триггер!";
                };
                if (comboBox1.Text == "Удалить")
                {
                    option = 0;
                    Message = "Вы удалили триггер!";
                };
                if (option == 1 && textBox1.Text!="")
                {
                    SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=clients;Integrated Security=True");
                    conn1.Open();
                    string sqlTG1 = "CREATE TRIGGER [INFORMATION_FILIAL_INSERT_UPDATE] ON[INFORMATION] FOR INSERT, UPDATE AS IF not exists(SELECT count(DISTINCT t1.[id_fillial]) FROM INSERTED t1 JOIN[OFFICES].dbo.FILLIAL t2 ON t1.[id_fillial]=t2.[id_fillial] INTERSECT SELECT count(DISTINCT t1.[id_fillial]) FROM INSERTED t1) throw 60000, 'Ошибка! Данного id не сущетсвует', 1";
                    SqlCommand command1 = new SqlCommand(sqlTG1, conn1);
                    command1.ExecuteNonQuery();
                    conn1.Close();
                    SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=offices;Integrated Security=True");
                    conn2.Open();
                    string sqlTG2 = "CREATE TRIGGER [FILIAL_INFORMATION_DELETE_UPDATE] ON[FILLIAL] FOR DELETE, UPDATE AS IF EXISTS(SELECT t1.[id_fillial] FROM DELETED t1 JOIN CLIENTS.dbo.INFORMATION t2 ON t2.[id_fillial] = t1.[id_fillial]) throw 60001, 'Ошибка! Данный id нельзя обновить или удалить, он используется в другой таблице', 1       ";
                    SqlCommand command2 = new SqlCommand(sqlTG2, conn2);
                    command2.ExecuteNonQuery();
                    conn2.Close();
                    MessageBox.Show(Message, "Успешно!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
                else {
                    SqlConnection conn1 = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=clients;Integrated Security=True");
                    conn1.Open();
                    string sqlTG1 = "DROP TRIGGER [INFORMATION_FILIAL_INSERT_UPDATE]";
                    SqlCommand command1 = new SqlCommand(sqlTG1, conn1);
                    command1.ExecuteNonQuery();
                    conn1.Close();
                    SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-SVQN580;Initial Catalog=offices;Integrated Security=True");
                    conn2.Open();
                    string sqlTG2 = "DROP TRIGGER [FILIAL_INFORMATION_DELETE_UPDATE]";
                    SqlCommand command2 = new SqlCommand(sqlTG2, conn2);
                    command2.ExecuteNonQuery();
                    conn2.Close();
                    MessageBox.Show(Message, "Успешно!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
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

 /*       comboBox1_SelectedIndexChanged() - блокировка введения лишних данных.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Удалить")
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
            }
            else {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
            }
        }
    }
}
