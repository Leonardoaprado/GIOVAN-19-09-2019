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
    public partial class Form1 : Form
    {
        //VARIÁVEIS NECESSÁRIAS PARA O LOGIN
        String usuário_digitado, usuário_banco, senha_digitada, senha_banco;

        //VARIÁVEL PARA TESTAR SE A TABELA Tb_Usuário ESTÁ VAZIA
        Int32 número_de_usuários_cadastrados_no_banco = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //BOTÃO ACCESS
        private void button1_Click(object sender, EventArgs e)
        {
            //LER O USUÁRIO E SENHA DIGITADOS NAS TEXTBOXES E SALVAR NAS VARIÁVEIS
            usuário_digitado = textBox1.Text;
            senha_digitada = textBox2.Text;

            //CRIAR form2 PARA ABRIR SE O USUÁRIO ACERTAR NOME E SENHA
            Form2 f_tela_principal = new Form2();

            //NÃO DEIXA AS TEXTBOXES VAZIAS POIS TRAVARIA O BANCO
            if (textBox1.Text != "" & textBox2.Text != "")
            {

                try //TESTA SE HÁ USUÁRIOS CADASTRADOS
                {
                    Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Tb_Usuário");
                    cmd.Connection = Cl_Banco.conn;
                    Cl_Banco.conn.Open();
                    OleDbDataReader aReader = cmd.ExecuteReader();
                    while (aReader.Read())
                    {
                        //CONTAR O NÚMERO DE USUÁRIOS CADASTRADOS, SE FOR ZERO ABAIXO CADASTRA UM NOVO
                        número_de_usuários_cadastrados_no_banco += 1;
                    }
                    Cl_Banco.conn.Close();
                    if(número_de_usuários_cadastrados_no_banco == 0)
                    {
                        MessageBox.Show("Não há usuários cadastrados, \n" +
                        "vamos cadastrar um ...\n" +
                        "Preencha os campos LOGIN e PASSWORD \n" +
                        "depois pressione o botão ACCESS.");

                        //INSERIR UM NOVO USUÁRIO
                        Cl_Banco.conn.Close(); //CASO O TRY NÃO CHEGUE ATÉ A LINHA Q FECHA O BANCO
                        Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
                        OleDbCommand cmd2 = new OleDbCommand("INSERT INTO Tb_Usuário(usuário_tc, senha_tc) " +
                            "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')");
                        cmd2.Connection = Cl_Banco.conn;

                        Cl_Banco.conn.Open();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Novo usuário cadastrado");
                        Cl_Banco.conn.Close();
                    }
                }
                catch //SE NÃO TEM USUÁRIOS CADASTRADOS, VEM PARA CÁ, PARA CADASTRAR...
                {}
                finally
                {
                    Cl_Banco.conn.ConnectionString = Cl_Banco.connect;
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Tb_Usuário WHERE " +
                        "usuário_tc = ('" + textBox1.Text + "')");
                    cmd.Connection = Cl_Banco.conn;
                    Cl_Banco.conn.Open();
                    OleDbDataReader aReader = cmd.ExecuteReader();
                    while (aReader.Read())
                    {
                        usuário_banco = aReader.GetString(0);
                        senha_banco = aReader.GetString(1);
                    }
                    Cl_Banco.conn.Close();

                    //TESTAR SE USUÁRIO E SENHA DIGITADOS SÃO IGAUIS AOS CADASTRADOS NO BANCO
                    if (usuário_digitado == usuário_banco & senha_digitada == senha_banco)
                        f_tela_principal.Show();
                    else
                        MessageBox.Show("Usuário e/ou senha incorretos :-(");
                }
            }
            else
                MessageBox.Show("Preencha TODOS os campos!\n" +
                    "Se for a primeira vez que o programa é executado,\n" +
                    "os usuário/senha digitados serão salvos no banco.");
        }

        //BOTÃO CANCELAR
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    //CLASSE COM AS VARIÁVEIS DO BANCO DE DADOS
    public class Cl_Banco
    {
        public static OleDbConnection conn = new OleDbConnection();
        public static String endereço_do_banco = @"C:\Users\leonardo.aprado\Documents\Giovan\AGOSTO\GIOVAN-19-09-2019\19092019\SISTEMA\teste.accdb";
        public static String connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + endereço_do_banco;

    }
}
