using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array = new int[3];

            array[0] = Convert.ToInt32(txtX.Text);
            array[1] = Convert.ToInt32(txtY.Text);
            array[2] = array[1] + array[0];

            txtZ.Text = array[2].ToString(); 



        }
    }
}
