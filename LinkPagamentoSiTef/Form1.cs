using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using FirebirdSql.Data.FirebirdClient;

                /*
                `7MMF'      `7MM"""YMM    .g8""8q.   `7MMF'   `7MF'`7MM"""YMM    .g8"""bgd  `7MMF'`7MMF'      `7MM"""Yb.     .g8""8q.   
                  MM          MM    `7  .dP'    `YM.   `MA     ,V    MM    `7  .dP'     `M    MM    MM          MM    `Yb. .dP'    `YM. 
                  MM          MM   d    dM'      `MM    VM:   ,V     MM   d    dM'       `    MM    MM          MM     `Mb dM'      `MM 
                  MM          MMmmMM    MM        MM     MM.  M'     MMmmMM    MM             MM    MM          MM      MM MM        MM 
                  MM      ,   MM   Y  , MM.      ,MP     `MM A'      MM   Y  , MM.    `7MMF'  MM    MM      ,   MM     ,MP MM.      ,MP 
                  MM     ,M   MM     ,M `Mb.    ,dP'      :MM;       MM     ,M `Mb.     MM    MM    MM     ,M   MM    ,dP' `Mb.    ,dP' 
                .JMMmmmmMMM .JMMmmmmMMM   `"bmmd"'         VF      .JMMmmmmMMM   `"bmmmdPY  .JMML..JMMmmmmMMM .JMMmmmdP'     `"bmmd"'    
                                               ___   _        _                             
                                             / __| (_)  ___ | |_   ___   _ __    __ _   ___
                                             \__ \ | | (_-< |  _| / -_) | '  \  / _` | (_-<
                                             |___/ |_| /__/  \__| \___| |_|_|_| \__,_| /__/*/

                //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                //                                 L E O V E G I L D O  S I S T E M A S 
                //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                //Gerador de link de pagamentos com gestão dos links gerados. Integrado ao e-SiTef da Software Express
                //Desenvolvido em: 13/07/2020
                //Desenvolvedor: Leovegildo Neto
                //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

namespace LinkPagamentoSiTef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //VARIÁVEIS BLOBAIS
        String url, nit, nsuSitef;
        

        public class Root
        {
            public int responseCode { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string nsuesitef { get; set; }
            public string nit { get; set; }

        }

        public class Payment
        {
            public string authorizer_code { get; set; }
            public string authorizer_message { get; set; }
            public string status { get; set; }
            public string nit { get; set; }
            public string order_id { get; set; }
            public string customer_receipt { get; set; }
            public string merchant_receipt { get; set; }
            public string authorizer_id { get; set; }
            public string acquirer_id { get; set; }
            public string acquirer_name { get; set; }
            public string authorizer_date { get; set; }
            public string authorization_number { get; set; }
            public string esitef_usn { get; set; }
            public string sitef_usn { get; set; }
            public string host_usn { get; set; }
            public string amount { get; set; }
            public string payment_type { get; set; }
            public string issuer { get; set; }
            public string authorizer_merchant_id { get; set; }
            public string terminal_id { get; set; }
            public string payment_date { get; set; }

        }

        public class RootPayment
        {
            public string code { get; set; }
            public string message { get; set; }
            public Payment payment { get; set; }

        }

        public void AtualizaGrid()
        {
            FbConnection fbConn = new FbConnection("DataSource=localhost; Database=C:\\linksitef\\dat\\DBLINKSITEF.gdb; User=SYSDBA; Password=masterkey");
            FbCommand cmd = new FbCommand();
            cmd.Connection = fbConn;
            fbConn.Open();
            cmd.CommandText = "select " +
                                "t_datahora as DATA, t_link_valor as VALOR, t_link_nsu_sitef as NSU_SITEF, T_PAGAMENTO_STATUS as STATUS, T_PAGAMENTO_AUT_MENSAGEM as MENSAGEM " +
                                "from " +
                                "t_linksitef " +
                                "order by 3 desc";
            FbDataAdapter da = new FbDataAdapter(cmd);
            DataTable links = new DataTable();
            da.Fill(links);
            dataGridView1.DataSource = links;
            dataGridView1.AutoResizeColumn(3);
            dataGridView1.AutoResizeColumn(4);

        }

        private void txtLink_SelectAll()
        {
            if (!String.IsNullOrEmpty(txtLink.Text))
            {
                txtLink.SelectionStart = 0;
                txtLink.SelectionLength = txtLink.Text.Length;
            }
        } 


        private void btnGerarLink_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "")
            { MessageBox.Show("Informe o valor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                //Corrige: "Erro ao criar canal seguro para SSL/TLS."
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = true;

                double valor = Convert.ToDouble(txtValor.Text);
                double valorDouble = valor * 100;
                int valorLink = Convert.ToInt32(valor);

                try
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        merchant_id = "lebiscuit",
                        amount = txtValor.Text
                    });




                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://esitef-homologacao.softwareexpress.com.br/e-sitef-hml/init/json.se?request={\"merchant_id\":\"lebiscuit\",\"amount\":" + valorDouble + "}");
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {

                        string jsonEnvio = "{\"request\":" + json + "}";

                    }


                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        System.IO.StreamWriter escrever5 = new System.IO.StreamWriter("LogJsonRetorno.txt", true);
                        escrever5.WriteLine("*******************************************************");
                        escrever5.WriteLine(result);
                        escrever5.Close();
                        Root dados = JsonConvert.DeserializeObject<Root>(result);
                        nit = dados.nit;
                        url = dados.url;
                        nsuSitef = dados.nsuesitef;
                        txtLink.Text = dados.url;
                    }
                    FbConnection fbConn = new FbConnection("DataSource=localhost; Database=C:\\linksitef\\dat\\DBLINKSITEF.gdb; User=SYSDBA; Password=masterkey");
                    FbCommand cmd = new FbCommand();
                    cmd.Connection = fbConn;
                    fbConn.Open();
                    cmd.Connection = fbConn;
                    FbCommand escrever = new FbCommand();
                    FbTransaction transacao = fbConn.BeginTransaction();
                    escrever.Connection = fbConn;
                    escrever.CommandType = CommandType.Text;
                    escrever.Transaction = transacao;
                    escrever.CommandText = "insert into t_linksitef (t_datahora, t_link_valor, t_link_url, t_link_nit, t_link_nsu_sitef, T_PAGAMENTO_STATUS)" +
                                           "values (@DATA, @VALOR, @URL, @NIT, @NSU_SITEF, @STATUS)";
                    escrever.Parameters.AddWithValue("@DATA", DateTime.Today);
                    escrever.Parameters.AddWithValue("@VALOR", valorDouble);
                    escrever.Parameters.AddWithValue("@URL", url);
                    escrever.Parameters.AddWithValue("@NIT", nit);
                    escrever.Parameters.AddWithValue("@NSU_SITEF", nsuSitef);
                    escrever.Parameters.AddWithValue("@STATUS", "NOVO");
                    escrever.ExecuteNonQuery();
                    transacao.Commit();
                    fbConn.Close();
                    txtValor.Text = "";
                    AtualizaGrid();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                timer1.Interval = 10000;
                timer1.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            FormCloseButtonDisabler.DisableCloseButton(this.Handle.ToInt32());
            AtualizaGrid();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente Números e Vírgula", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente uma Vírgula", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnAtualizarStatus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "NOVO" || dataGridView1.CurrentRow.Cells[3].Value.ToString() == "AGUARDANDO USUARIO")
            {

                string nitLido = "";
                string status = "";
                FbConnection fbConn = new FbConnection("DataSource=localhost; Database=C:\\linksitef\\dat\\DBLINKSITEF.gdb; User=SYSDBA; Password=masterkey");
                FbCommand cmd = new FbCommand();
                cmd.Connection = fbConn;
                fbConn.Open();
                cmd.CommandText = "select t_link_nit " +
                                    "from t_linksitef " +
                                    "where t_link_nsu_sitef = @NSUSITEF";
                cmd.Parameters.AddWithValue("@NSUSITEF", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                FbDataReader ler = cmd.ExecuteReader();
                while (ler.Read())
                {
                    nitLido = ler.GetValue(0).ToString();
                }
                fbConn.Close();

                //Corrige: "Erro ao criar canal seguro para SSL/TLS."
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = true;

                Uri uri = new Uri(@"https://esitef-homologacao.softwareexpress.com.br/e-sitef/api/v1/transactions/" + nitLido);
                WebRequest webRequest = WebRequest.Create(uri);
                webRequest.Method = "GET";
                webRequest.Headers.Add("merchant_id", "lebiscuit");
                webRequest.Headers.Add("merchant_key", "8B9F033F05F30C9EED141FE4080FEA3E2D3DC0A5BFA6C780299A19DBC4D496DB");
                WebResponse response = webRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                String responseData = streamReader.ReadToEnd();
                System.IO.StreamWriter escrever5 = new System.IO.StreamWriter("LogJsonRetorno.txt", true);
                escrever5.WriteLine("*******************************************************");
                escrever5.WriteLine(responseData);
                escrever5.Close();
                RootPayment dadosPagamento = JsonConvert.DeserializeObject<RootPayment>(responseData);
                //MessageBox.Show(dadosPagamento.payment.status);
                if (dadosPagamento.payment.status == "NOV") { status = "NOVO"; }
                if (dadosPagamento.payment.status == "AGU") { status = "AGUARDANDO USUARIO"; }
                if (dadosPagamento.payment.status == "CON") { status = "CONFIRMADO"; }
                if (dadosPagamento.payment.status == "EXP") { status = "EXPIRADO"; }
                if (dadosPagamento.payment.status == "NEG") { status = "NEGADO"; }
                if (dadosPagamento.payment.status == "CAN") { status = "CANCELADO PELO USUARIO"; }

                fbConn.Open();
                cmd.Connection = fbConn;
                FbCommand escrever = new FbCommand();
                FbTransaction transacao = fbConn.BeginTransaction();
                escrever.Connection = fbConn;
                escrever.CommandType = CommandType.Text;
                escrever.Transaction = transacao;
                escrever.CommandText = "update t_linksitef " +
                                        "set t_pagamento_status = @STATUS, " +
                                        "t_pagamento_aut_mensagem = @AUTMENSAGEM, " +
                                        "t_pagamento_nsu_host = @NSUHOST, " +
                                        "t_pagamento_aut_cod = @AUTCOD, " +
                                        "t_pagamento_rede_id = @IDREDE, " +
                                        "t_pagamento_aut_id = @IDAUTH, " +
                                        "t_pagamento_rede_nome = @NOMEREDE, " +
                                        "t_pagamento_comprovante_loja = @COMPLOJA, " +
                                        "t_pagamento_comprovante_cliente = @COMPCLI " +
                                        "where " +
                                        "t_link_nsu_sitef = @NSU_SITEF";
                escrever.Parameters.AddWithValue("@STATUS", status);
                escrever.Parameters.AddWithValue("@AUTMENSAGEM", dadosPagamento.payment.authorizer_message);
                escrever.Parameters.AddWithValue("@NSUHOST", dadosPagamento.payment.host_usn);
                escrever.Parameters.AddWithValue("@AUTCOD", dadosPagamento.payment.authorizer_code);
                escrever.Parameters.AddWithValue("@IDREDE", dadosPagamento.payment.acquirer_id);
                escrever.Parameters.AddWithValue("@IDAUTH", dadosPagamento.payment.authorizer_id);
                escrever.Parameters.AddWithValue("@NOMEREDE", dadosPagamento.payment.acquirer_name);
                escrever.Parameters.AddWithValue("@COMPLOJA", dadosPagamento.payment.merchant_receipt);
                escrever.Parameters.AddWithValue("@COMPCLI", dadosPagamento.payment.customer_receipt);
                escrever.Parameters.AddWithValue("@NSU_SITEF", dadosPagamento.payment.esitef_usn);
                escrever.ExecuteNonQuery();
                transacao.Commit();
                fbConn.Close();
                AtualizaGrid();
            }
            else
            {
                MessageBox.Show("Atualização de status não permitida.\nTransação já finalizada.", "Não permitido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecuperarLink_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "EXPIRADO")
            { MessageBox.Show("Link de pagamento expirado!\nNão será possível exibir a URL.", "Link Expirado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "CONFIRMADO")
            { MessageBox.Show("O pagamento deste link já foi processado.\nNão será possível exibir a URL.", "Transação OK", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "NEGADO")
            { MessageBox.Show("O pagamento deste link foi negado, por favor gere outro link.\nNão será possível exibir a URL.", "Transação Negada", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "CANCELADO PELO USUARIO")
            { MessageBox.Show("O pagamento deste link foi cancelado pelo usuário, por favor gere outro link.\nNão será possível exibir a URL.", "Transação Negada", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            else
            {
                string url = "";
                FbConnection fbConn = new FbConnection("DataSource=localhost; Database=C:\\linksitef\\dat\\DBLINKSITEF.gdb; User=SYSDBA; Password=masterkey");
                FbCommand cmd = new FbCommand();
                cmd.Connection = fbConn;
                fbConn.Open();
                cmd.CommandText = "select t_link_url " +
                                    "from t_linksitef " +
                                    "where t_link_nsu_sitef = @NSUSITEF";
                cmd.Parameters.AddWithValue("@NSUSITEF", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                FbDataReader ler = cmd.ExecuteReader();
                while (ler.Read())
                {
                    url = ler.GetValue(0).ToString();
                }
                fbConn.Close();
                txtLink.Text = url;
                txtLink_SelectAll();
                timer1.Interval = 10000;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtLink.Text = "";
            timer1.Stop();
        }

        private void btnExibirComprovante_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "EXPIRADO")
            { MessageBox.Show("Link de pagamento expirado!\nSem comprovante para exibir.", "Link Expirado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "NOVO")
            { MessageBox.Show("Pagamento não confirmado!\nSem comprovante para exibir.", "Link Expirado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "AGUARDANDO USUARIO")
            { MessageBox.Show("Pagamento não confirmado!\nSem comprovante para exibir.", "Link Expirado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "NEGADO")
            { MessageBox.Show("O pagamento deste link foi negado, por favor gere outro link.\nSem comprovante para exibir.", "Transação Negada", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "CANCELADO PELO USUARIO")
            { MessageBox.Show("O pagamento deste link foi cancelado pelo usuário, por favor gere outro link.\nSem comprovante para exibir.", "Transação Negada", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            else
            {
                string comprovanteFundido = "", comprovanteLoja = "", comprovanteCliente = "";
                FbConnection fbConn = new FbConnection("DataSource=localhost; Database=C:\\linksitef\\dat\\DBLINKSITEF.gdb; User=SYSDBA; Password=masterkey");
                FbCommand cmd = new FbCommand();
                cmd.Connection = fbConn;
                fbConn.Open();
                cmd.CommandText = "select T_PAGAMENTO_COMPROVANTE_LOJA, T_PAGAMENTO_COMPROVANTE_CLIENTE " +
                                    "from t_linksitef " +
                                    "where t_link_nsu_sitef = @NSUSITEF";
                cmd.Parameters.AddWithValue("@NSUSITEF", dataGridView1.CurrentRow.Cells[2].Value.ToString());
                FbDataReader ler = cmd.ExecuteReader();
                while (ler.Read())
                {
                    comprovanteLoja = ler.GetValue(0).ToString();
                    comprovanteCliente = ler.GetValue(1).ToString();
                }
                fbConn.Close();

                comprovanteFundido = comprovanteLoja + "\n" + comprovanteCliente;

                FormComprovante formComprovante = new FormComprovante(comprovanteFundido);
                formComprovante.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

