/* Форма "Личный кабинет".
*  Название: LK.
*  Язык: C#
*  Краткое описание:
*      Данная форма является формой личного кабинета и предлагает пользователю выбрать вариант продолжения работы с программой.
*  Функции используемые в форме:
*      LK() - конструктор формы;
*      button1_Click() - переход к форме обеспечения целостности данных;
*      button3_Click() - переход к форме оптимизации бизнес-процессов;
*      button3_Click() - переход к форме регистрации нового пользователя;
*      button4_Click() - выход из личного кабинета;
*      LK_FormClosed() - завершение работы приложения.
*  Переменные используемые в форме:
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

namespace WindowsFormsApp2
{
    public partial class LK : Form
    {
/*  LK() - конструктор формы. */
        public LK()
        {
            InitializeComponent();
            label1.Text = DataHolder.surname;
            label3.Text = Convert.ToString(DataHolder.id);
            if (DataHolder.admin == true)
            {
                label2.Text = "Admin";
            }
            else
            {
                label2.Text = "User";
            }
        }

/*      button3_Click() - переход к форме регистрации нового пользователя.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*       Локальные переменные:
*           admin - подтверждение прав администратора пользователя.
*/
        private void button3_Click(object sender, EventArgs e)
        {
            if (DataHolder.admin == true)
            {
                Form Registration = new Registration
                {
                    Left = this.Left,
                    Top = this.Top
                };
                Registration.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Доступно только администраторам!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

/*      button4_Click() - выход из личного кабинета.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button4_Click(object sender, EventArgs e)
        {
            Form inLK = Application.OpenForms[0];
            inLK.StartPosition = FormStartPosition.Manual;
            inLK.Left = this.Left;
            inLK.Top = this.Top;
            inLK.Show();
            this.Hide();
        }

/*      button1_Click() - переход к форме обеспечения целостности данных.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button1_Click(object sender, EventArgs e)
        {
            Form Integrity = new Integrity
            {
                Left = this.Left,
                Top = this.Top
            };
            Integrity.Show();
            this.Hide();
        }

 /*      LK_FormClosed() - завершение работы приложения.
 *        Формальные параметры:
 *            sender - элемент управления, вызывающий эту функцию; 
 *            e - аргументы события.
 */
        private void LK_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

 /*      button2_Click() - переход к форме оптимизации бизнес-процессов.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button2_Click(object sender, EventArgs e)
        {
            Form Optimization = new Optimization
            {
                Left = this.Left,
                Top = this.Top
            };
            Optimization.Show();
            this.Hide();
        }
    }
}
