using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            if (VerificaSenha(txtUsuario.Text, txtSenha.Text) == true)
            {
                MessageBox.Show("login efetuado com sucesso.");
            }
            else
            {
                MessageBox.Show("Usuario/Senha inválidos. Tente Novamente!!", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
        }

        private bool VerificaSenha(string usuario, string senha)
        {
            if (usuario == "leonardo" && senha == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
