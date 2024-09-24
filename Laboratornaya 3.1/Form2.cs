using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BusinessLogic;

namespace Laboratornaya_3._1
{
    public partial class Form2 : Form
    {
        public Form1 form1 { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.ToString()) && !string.IsNullOrEmpty(textBox2.Text.ToString()) && !string.IsNullOrEmpty(textBox3.Text.ToString()))
            {
                string[] row = { textBox1.Text, textBox2.Text, textBox3.Text };
                var listItem = new ListViewItem(row);
                form1.listView1.Items.Add(listItem);
                form1.logic.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
