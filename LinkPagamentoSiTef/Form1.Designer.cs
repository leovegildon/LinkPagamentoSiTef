namespace LinkPagamentoSiTef
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGerarLink = new System.Windows.Forms.Button();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskValor = new System.Windows.Forms.MaskedTextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExibirComprovante = new System.Windows.Forms.Button();
            this.btnRecuperarLink = new System.Windows.Forms.Button();
            this.btnAtualizarStatus = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerarLink
            // 
            this.btnGerarLink.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnGerarLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarLink.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGerarLink.Location = new System.Drawing.Point(7, 69);
            this.btnGerarLink.Name = "btnGerarLink";
            this.btnGerarLink.Size = new System.Drawing.Size(618, 44);
            this.btnGerarLink.TabIndex = 0;
            this.btnGerarLink.Text = "Gerar Link";
            this.btnGerarLink.UseVisualStyleBackColor = false;
            this.btnGerarLink.Click += new System.EventHandler(this.btnGerarLink_Click);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(7, 144);
            this.txtLink.Multiline = true;
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(618, 47);
            this.txtLink.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(237, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor:";
            // 
            // maskValor
            // 
            this.maskValor.Location = new System.Drawing.Point(529, 9);
            this.maskValor.Mask = "9999,00";
            this.maskValor.Name = "maskValor";
            this.maskValor.Size = new System.Drawing.Size(34, 20);
            this.maskValor.TabIndex = 3;
            this.maskValor.Visible = false;
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(299, 19);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(93, 29);
            this.txtValor.TabIndex = 4;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(7, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(618, 287);
            this.dataGridView1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExibirComprovante);
            this.groupBox1.Controls.Add(this.btnRecuperarLink);
            this.groupBox1.Controls.Add(this.btnAtualizarStatus);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.maskValor);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtLink);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGerarLink);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 536);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gerar novo Link";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnExibirComprovante
            // 
            this.btnExibirComprovante.BackColor = System.Drawing.Color.Teal;
            this.btnExibirComprovante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExibirComprovante.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExibirComprovante.Location = new System.Drawing.Point(229, 207);
            this.btnExibirComprovante.Name = "btnExibirComprovante";
            this.btnExibirComprovante.Size = new System.Drawing.Size(126, 30);
            this.btnExibirComprovante.TabIndex = 8;
            this.btnExibirComprovante.Text = "Exibir Comprovante";
            this.btnExibirComprovante.UseVisualStyleBackColor = false;
            this.btnExibirComprovante.Click += new System.EventHandler(this.btnExibirComprovante_Click);
            // 
            // btnRecuperarLink
            // 
            this.btnRecuperarLink.BackColor = System.Drawing.Color.Teal;
            this.btnRecuperarLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperarLink.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRecuperarLink.Location = new System.Drawing.Point(359, 207);
            this.btnRecuperarLink.Name = "btnRecuperarLink";
            this.btnRecuperarLink.Size = new System.Drawing.Size(127, 30);
            this.btnRecuperarLink.TabIndex = 8;
            this.btnRecuperarLink.Text = "Exibir Link";
            this.btnRecuperarLink.UseVisualStyleBackColor = false;
            this.btnRecuperarLink.Click += new System.EventHandler(this.btnRecuperarLink_Click);
            // 
            // btnAtualizarStatus
            // 
            this.btnAtualizarStatus.BackColor = System.Drawing.Color.Azure;
            this.btnAtualizarStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtualizarStatus.Location = new System.Drawing.Point(492, 207);
            this.btnAtualizarStatus.Name = "btnAtualizarStatus";
            this.btnAtualizarStatus.Size = new System.Drawing.Size(133, 30);
            this.btnAtualizarStatus.TabIndex = 7;
            this.btnAtualizarStatus.Text = "Atualizar Status";
            this.btnAtualizarStatus.UseVisualStyleBackColor = false;
            this.btnAtualizarStatus.Click += new System.EventHandler(this.btnAtualizarStatus_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Crimson;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFechar.Location = new System.Drawing.Point(551, 554);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(96, 33);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(662, 599);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Link de Pagamento";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGerarLink;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAtualizarStatus;
        private System.Windows.Forms.Button btnExibirComprovante;
        private System.Windows.Forms.Button btnRecuperarLink;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnFechar;
    }
}

