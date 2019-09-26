using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private double soma(int num1, int num2)
        {

            int total;
            total = num1 + num2;
            return total;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var soma2= (soma(Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text))).ToString();
            MessageBox.Show("O resultado da soma de: " + txtX.Text +  " + " +  txtY.Text + " é: " + soma2);

        }
    }
}
