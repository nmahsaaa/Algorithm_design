using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                int k = Convert.ToInt32(textBox2.Text);
                int q = Convert.ToInt32(textBox3.Text);
                if (n != k + q)
                {
                    MessageBox.Show("n!=k+q!!!");
                    return;
                }
                Form2 f = new Form2(n,k,q);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("you should enter number!!!");
            }
        }
    }
}
