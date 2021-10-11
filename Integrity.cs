/* Форма "Целостность".
*  Название: Integrity.
*  Язык: C#
*  Краткое описание:
*      Данная форма предоставляет выбор способа обеспечения целостности данных.
*  Функции используемые в форме:
*      Integrity() - конструктор формы;
*      button1_Click() - переход к форме добавления или удаления триггера;
*      button2_Click() - переход к форме добавления или удаления внешнего ключа;
*      button3_Click() - переход к форме личного кабинета;
*      Integrity_FormClosed() - завершение работы приложения.
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
    public partial class Integrity : Form
    {
/*  Integrity() - конструктор формы. */
        public Integrity()
        {
            InitializeComponent();
        }

/*       button1_Click() - переход к форме добавления или удаления триггера.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button1_Click(object sender, EventArgs e)
        {
            Form Trigger = new Trigger
            {
                Left = this.Left,
                Top = this.Top
            };
            Trigger.Show();
            this.Hide();
        }

/*       button2_Click() - переход к форме добавления или удаления внешнего ключа.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button2_Click(object sender, EventArgs e)
        {
            Form ForeignKey = new ForeignKey
            {
                Left = this.Left,
                Top = this.Top
            };
            ForeignKey.Show();
            this.Hide();
        }

/*       button3_Click() - переход к форме личного кабинета.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void button3_Click(object sender, EventArgs e)
        {
            Form LK = Application.OpenForms[1];
            LK.StartPosition = FormStartPosition.Manual;
            LK.Left = this.Left;
            LK.Top = this.Top;
            LK.Show();
            this.Hide();
        }

/*      Integrity_FormClosed() - завершение работы приложения.
*        Формальные параметры:
*            sender - элемент управления, вызывающий эту функцию; 
*            e - аргументы события.
*/
        private void Integrity_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
