using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laboratornaya_3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < logic.GetListStudents().Count; i++)
            {
                var listItem = new ListViewItem(logic.GetListStudents()[i]);
                listView1.Items.Add(listItem);
            }
        }

        public Logic logic = new Logic();

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.form1 = this;
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                logic.RemoveStudent(listView1.FocusedItem.Index);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            foreach (var s in logic.DistributionStudents())
            {
                chart1.Series[0].Points.AddXY(s.Key, s.Value);
            }
        }
    }
}
