using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.Net;

namespace LinkPagamentoSiTef
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        string nomedoDominio;
        bool isValid;
        string nome, departamento;

        private void button1_Click(object sender, EventArgs e)
        {
            //if(txtUsuario.Text == "admin" && txtSenha.Text == "L3biscuit@1")
            //{
            //    Form1 principal = new Form1();
            //    principal.Show();
            //    this.Hide();
                
            //}
            //else
            //{
            //    MessageBox.Show("Usuário e/ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            if (txtUsuario.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("Um ou mais campos obrigatórios não foram informados\n\n*Usuário\n*Senha", "Falha no Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtUsuario.Text == "")
            {
                MessageBox.Show("Um ou mais campos obrigatórios não foram informados\n\n *Usuário", "Falha no Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Um ou mais campos obrigatórios não foram informados\n\n *Senha", "Falha no Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                DirectoryEntry lebiscuit = new DirectoryEntry("LDAP://" + nomedoDominio);
                DirectorySearcher busca = new DirectorySearcher(lebiscuit, "(&(objectClass=user)(objectCategory=person))");
                //busca.PropertiesToLoad.Add("department");
                busca.PropertiesToLoad.Add("cn");
                busca.PropertiesToLoad.Add("sAMAccountName");
                busca.PropertiesToLoad.Add("mail");
                busca.Sort.PropertyName = "sAMAccountName";
                busca.Filter = "(&(objectCategory=user)(objectClass=person)(samaccountname=" + txtUsuario.Text + "))"; ;
                foreach (SearchResult oRes in busca.FindAll())
                {
                    nome = oRes.Properties["cn"][0].ToString();
                }


                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, nomedoDominio))
                {
                    try
                    {
                        isValid = pc.ValidateCredentials(txtUsuario.Text, txtSenha.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (isValid == true)
                    {
                        timer1.Interval = 500;
                        timer1.Start();
                        //groupBox1.Visible = false;
                        //label3.Visible = false;
                        //label4.Visible = false;
                        //lblBemVindoNome.Text = "Bem-Vindo " + nome.Substring(0,30);
                        //lblBemVindoNome.Visible = true;
                    }
                    if (isValid == false)
                    {
                        MessageBox.Show("Não foi possível acessar o sistema.\nVerifique suas credenciais e tente novamente",
                            "Credenciais inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSenha.Text = "";
                    }

                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            timer1.Stop();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyData == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            nomedoDominio = ConfigINI.LerINI(@"configuracoes.ini", "[NomeDoDominio]");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
