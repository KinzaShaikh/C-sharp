using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartReader
{
    public partial class Replace : Form
    {
        string rWhat, rWith;
        public Replace()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxReplaceWhat.Text != "" && textBoxReplaceWith.Text != "")
            {
                rWhat = textBoxReplaceWhat.Text;
                rWith = textBoxReplaceWith.Text;
                Form1.replaceWhat = rWhat;
                Form1.replaceWith = rWith;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Write Text");
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBoxReplaceWhat_TextChanged(object sender, EventArgs e)
        {

        }
        public void DarkMode()
        {
            this.BackColor = Color.DarkSlateGray;
            this.label1.ForeColor = Color.White;
            this.label2.ForeColor = Color.White;
        }
        public void LightMode()
        {

            this.BackColor = Color.White;
            this.label1.ForeColor = Color.Black;
            this.label2.ForeColor = Color.Black;
        }
        private void Replace_Load(object sender, EventArgs e)
        {

        }

        public string ReturnReplaceWhat()
        {
            return rWhat;
        }
    }
}
