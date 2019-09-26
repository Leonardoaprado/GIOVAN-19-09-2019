using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double ano(int num1, int num2)
        {

            int total;
            total = num1 - num2;
            return total;


        }

        private void btnApertar_Click(object sender, EventArgs e)
        {
           var Total2=(ano(Convert.ToInt32(txtAnoAtual.Text), Convert.ToInt32(txtAno.Text))).ToString();

            MessageBox.Show("Seu nome: " + txtNome.Text + ", Idade: " + Total2);
        }
    }
}
