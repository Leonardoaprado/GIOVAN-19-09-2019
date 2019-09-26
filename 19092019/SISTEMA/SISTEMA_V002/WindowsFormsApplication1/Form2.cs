using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {   

        public Form2()
        {
            InitializeComponent();
        }

        //EVENTO LOAD DO FORM PRINCIPAL
        private void Form2_Load(object sender, EventArgs e)
        {
            //ESCONDE OS BOTÕES ALTERAR NOME, ALTERAR TEL E VOLTAR
            button5.Hide();
            button6.Hide();
            button7.Hide();
        }

        //CADASTRAR
        private void button1_Click(object sender, EventArgs e)
        {
            Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
            OleDbCommand cmd = new OleDbCommand("INSERT INTO Tb_Funcionário(nome_tc,tel_tc) " +
                "VALUES ('" + textBox1.Text + "','" + textBox4.Text + "')");
            cmd.Connection = Cl_Banco.conn;

            Cl_Banco.conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado cadastrado");
            Cl_Banco.conn.Close();
        }

        //EXCLUIR
        private void button2_Click(object sender, EventArgs e)
        {
            Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
            OleDbCommand cmd = new OleDbCommand("DELETE FROM Tb_Funcionário WHERE nome_tc = ('" + textBox1.Text + "')");
            cmd.Connection = Cl_Banco.conn;

            Cl_Banco.conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado apagado");
            Cl_Banco.conn.Close();
        }

        //ALTERAR
        private void button3_Click(object sender, EventArgs e)
        {
            //MOSTRA OS BOTÕES ALTERAR NOME, ALTERAR TEL E VOLTAR
            button5.Show();
            button6.Show();
            button7.Show();

            //ESCONDE A LABEL, A TEXTBOX TEL E OS OUTROS BOTÕES
            textBox4.Hide();
            label3.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();

            Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Tb_Funcionário " +
                "ORDER BY nome_tc ASC");
            cmd.Connection = Cl_Banco.conn;
            Cl_Banco.conn.Open();
            OleDbDataReader aReader = cmd.ExecuteReader();
            textBox3.Text = "Os valores retornados da tabela são : ";
            while (aReader.Read())
            {
                textBox3.Text += Environment.NewLine + aReader.GetString(0) + 
                    "   " + aReader.GetString(1);
            }
            Cl_Banco.conn.Close();
        }

        //CONSULTAR
        private void button4_Click(object sender, EventArgs e)
        {
            Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Tb_Funcionário WHERE nome_tc " +
                "LIKE ('" + textBox1.Text + "%') ORDER BY nome_tc ASC");
            cmd.Connection = Cl_Banco.conn;
            Cl_Banco.conn.Open();
            OleDbDataReader aReader = cmd.ExecuteReader();
            textBox3.Text = "Os valores retornados da tabela são : ";
            while (aReader.Read())
            {
                textBox3.Text += Environment.NewLine + (aReader.GetString(0) + " " + aReader.GetString(1));
            }
            Cl_Banco.conn.Close();
        }

        //ALTERAR NOME
        private void button5_Click(object sender, EventArgs e)
        {
            Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
            OleDbCommand cmd = new OleDbCommand("UPDATE Tb_Funcionário SET nome_tc = ('" + textBox2.Text + "') WHERE " +
                "nome_tc = ('" + textBox1.Text + "')");
            cmd.Connection = Cl_Banco.conn;

            Cl_Banco.conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado atualizado");
            Cl_Banco.conn.Close();
        }

        //ALTERAR TEL
        private void button6_Click(object sender, EventArgs e)
        {
            Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
            OleDbCommand cmd = new OleDbCommand("UPDATE Tb_Funcionário SET tel_tc = ('" + textBox5.Text + "') WHERE " +
                "nome_tc = ('" + textBox1.Text + "')");
            cmd.Connection = Cl_Banco.conn;

            Cl_Banco.conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado atualizado");
            Cl_Banco.conn.Close();
        }

        //VOLTAR
        private void button7_Click(object sender, EventArgs e)
        {
            //MOSTRA OS BOTÕES ALTERAR NOME, ALTERAR TEL E VOLTAR
            button5.Hide();
            button6.Hide();
            button7.Hide();

            //ESCONDE A LABEL, A TEXTBOX TEL E OS OUTROS BOTÕES
            textBox4.Show();
            label3.Show();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();

            //LIMPAR A CAIXA DE TEXTO DO SELECT
            textBox3.Text = "";
        }
    }
}
