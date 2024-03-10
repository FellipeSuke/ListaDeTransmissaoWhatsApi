namespace ListaDeTransmissaoWhatsApi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cbIniciarsessao = new Button();
            tbCampoMessage = new TextBox();
            cbEncerraSessao = new Button();
            tbSessionId = new TextBox();
            label1 = new Label();
            cbStats = new Button();
            pbQrCode = new PictureBox();
            labelResponse = new Label();
            cbRefreshQrCode = new Button();
            tbNumeroContato = new TextBox();
            labelContato = new Label();
            clbContatos = new CheckedListBox();
            cbAddContato = new Button();
            tbNomeContato = new TextBox();
            label2 = new Label();
            cbEnviarMensagem = new Button();
            LabelServidor = new Label();
            cbConnectar = new Button();
            cbPrimeiroNome = new Button();
            cbNomeCompleto = new Button();
            cbSelectAll = new Button();
            cbExcluir = new Button();
            clbGrupoDeContado = new CheckedListBox();
            cbSalvarGrupo = new Button();
            tbNomeDoArquivoDeGrupo = new TextBox();
            cbExcluirGrupoSelect = new Button();
            cbImportContatosDeGrupo = new Button();
            label3 = new Label();
            cbAddImagem = new Button();
            LabelCampoMensagemUp = new Label();
            listBox1 = new ListBox();
            labelProcessandoMsg = new Label();
            label4 = new Label();
            tbApiKey = new TextBox();
            pbAnexado = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbQrCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAnexado).BeginInit();
            SuspendLayout();
            // 
            // cbIniciarsessao
            // 
            cbIniciarsessao.Location = new Point(30, 42);
            cbIniciarsessao.Name = "cbIniciarsessao";
            cbIniciarsessao.Size = new Size(92, 23);
            cbIniciarsessao.TabIndex = 1;
            cbIniciarsessao.Text = "iniciarSessão";
            cbIniciarsessao.UseVisualStyleBackColor = true;
            cbIniciarsessao.Click += cbIniciarsessao_Click;
            // 
            // tbCampoMessage
            // 
            tbCampoMessage.AcceptsReturn = true;
            tbCampoMessage.AcceptsTab = true;
            tbCampoMessage.AllowDrop = true;
            tbCampoMessage.Location = new Point(30, 499);
            tbCampoMessage.Multiline = true;
            tbCampoMessage.Name = "tbCampoMessage";
            tbCampoMessage.ScrollBars = ScrollBars.Vertical;
            tbCampoMessage.Size = new Size(583, 144);
            tbCampoMessage.TabIndex = 16;
            // 
            // cbEncerraSessao
            // 
            cbEncerraSessao.Location = new Point(30, 99);
            cbEncerraSessao.Name = "cbEncerraSessao";
            cbEncerraSessao.Size = new Size(88, 27);
            cbEncerraSessao.TabIndex = 3;
            cbEncerraSessao.Text = "Stop Sessão";
            cbEncerraSessao.UseVisualStyleBackColor = true;
            cbEncerraSessao.Click += cbEncerraSessao_Click;
            // 
            // tbSessionId
            // 
            tbSessionId.BackColor = SystemColors.Info;
            tbSessionId.CharacterCasing = CharacterCasing.Lower;
            tbSessionId.Location = new Point(97, 9);
            tbSessionId.MaxLength = 14;
            tbSessionId.Name = "tbSessionId";
            tbSessionId.Size = new Size(88, 23);
            tbSessionId.TabIndex = 0;
            tbSessionId.TextChanged += Campo_TextChanged;
            tbSessionId.KeyPress += Valida_KeyPress;
            tbSessionId.Leave += Campo_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 12);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 4;
            label1.Text = "Nº Telefone:";
            // 
            // cbStats
            // 
            cbStats.Location = new Point(30, 70);
            cbStats.Name = "cbStats";
            cbStats.Size = new Size(92, 23);
            cbStats.TabIndex = 2;
            cbStats.Text = "Status";
            cbStats.UseVisualStyleBackColor = true;
            cbStats.Click += cbStats_Click;
            // 
            // pbQrCode
            // 
            pbQrCode.Location = new Point(144, 49);
            pbQrCode.Name = "pbQrCode";
            pbQrCode.Size = new Size(180, 180);
            pbQrCode.SizeMode = PictureBoxSizeMode.StretchImage;
            pbQrCode.TabIndex = 6;
            pbQrCode.TabStop = false;
            pbQrCode.Visible = false;
            // 
            // labelResponse
            // 
            labelResponse.AutoSize = true;
            labelResponse.BackColor = SystemColors.ActiveCaption;
            labelResponse.Location = new Point(484, 42);
            labelResponse.Name = "labelResponse";
            labelResponse.Size = new Size(12, 15);
            labelResponse.TabIndex = 7;
            labelResponse.Text = "_";
            // 
            // cbRefreshQrCode
            // 
            cbRefreshQrCode.Location = new Point(330, 49);
            cbRefreshQrCode.Name = "cbRefreshQrCode";
            cbRefreshQrCode.Size = new Size(88, 27);
            cbRefreshQrCode.TabIndex = 4;
            cbRefreshQrCode.Text = "Refresh";
            cbRefreshQrCode.UseVisualStyleBackColor = true;
            cbRefreshQrCode.Visible = false;
            cbRefreshQrCode.Click += cbRefreshQrCode_Click;
            // 
            // tbNumeroContato
            // 
            tbNumeroContato.Location = new Point(30, 215);
            tbNumeroContato.Name = "tbNumeroContato";
            tbNumeroContato.Size = new Size(92, 23);
            tbNumeroContato.TabIndex = 4;
            tbNumeroContato.TextChanged += Campo_TextChanged;
            tbNumeroContato.KeyPress += Valida_KeyPress;
            tbNumeroContato.Leave += Campo_Leave;
            // 
            // labelContato
            // 
            labelContato.AutoSize = true;
            labelContato.Location = new Point(30, 196);
            labelContato.Name = "labelContato";
            labelContato.Size = new Size(50, 15);
            labelContato.TabIndex = 32;
            labelContato.Text = "Contato";
            // 
            // clbContatos
            // 
            clbContatos.FormattingEnabled = true;
            clbContatos.Location = new Point(30, 284);
            clbContatos.Name = "clbContatos";
            clbContatos.Size = new Size(224, 148);
            clbContatos.TabIndex = 7;
            // 
            // cbAddContato
            // 
            cbAddContato.Location = new Point(30, 438);
            cbAddContato.Name = "cbAddContato";
            cbAddContato.Size = new Size(66, 23);
            cbAddContato.TabIndex = 6;
            cbAddContato.Text = "Adicionar";
            cbAddContato.UseVisualStyleBackColor = true;
            cbAddContato.Click += cbAddContato_Click;
            // 
            // tbNomeContato
            // 
            tbNomeContato.Location = new Point(30, 255);
            tbNomeContato.Name = "tbNomeContato";
            tbNomeContato.Size = new Size(224, 23);
            tbNomeContato.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 241);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 36;
            label2.Text = "Nome";
            // 
            // cbEnviarMensagem
            // 
            cbEnviarMensagem.Location = new Point(525, 649);
            cbEnviarMensagem.Name = "cbEnviarMensagem";
            cbEnviarMensagem.Size = new Size(88, 27);
            cbEnviarMensagem.TabIndex = 17;
            cbEnviarMensagem.Text = "Enviar Msg";
            cbEnviarMensagem.UseVisualStyleBackColor = true;
            cbEnviarMensagem.Click += cbEnviarMensagem_Click;
            // 
            // LabelServidor
            // 
            LabelServidor.AutoSize = true;
            LabelServidor.BackColor = SystemColors.Control;
            LabelServidor.Location = new Point(543, 16);
            LabelServidor.Name = "LabelServidor";
            LabelServidor.Size = new Size(169, 15);
            LabelServidor.TabIndex = 38;
            LabelServidor.Text = "Status Servidor:                           ";
            // 
            // cbConnectar
            // 
            cbConnectar.Location = new Point(445, 12);
            cbConnectar.Name = "cbConnectar";
            cbConnectar.RightToLeft = RightToLeft.Yes;
            cbConnectar.Size = new Size(92, 23);
            cbConnectar.TabIndex = 39;
            cbConnectar.Text = "Conectar";
            cbConnectar.UseVisualStyleBackColor = true;
            cbConnectar.Click += cbConnectar_Click;
            // 
            // cbPrimeiroNome
            // 
            cbPrimeiroNome.Location = new Point(637, 499);
            cbPrimeiroNome.Name = "cbPrimeiroNome";
            cbPrimeiroNome.Size = new Size(87, 40);
            cbPrimeiroNome.TabIndex = 18;
            cbPrimeiroNome.Text = "Primeiro Nome";
            cbPrimeiroNome.UseVisualStyleBackColor = true;
            cbPrimeiroNome.Click += cbPrimeiroNome_Click;
            // 
            // cbNomeCompleto
            // 
            cbNomeCompleto.Location = new Point(637, 545);
            cbNomeCompleto.Name = "cbNomeCompleto";
            cbNomeCompleto.Size = new Size(87, 40);
            cbNomeCompleto.TabIndex = 19;
            cbNomeCompleto.Text = "Nome Completo";
            cbNomeCompleto.UseVisualStyleBackColor = true;
            cbNomeCompleto.Click += cbNomeCompleto_Click;
            // 
            // cbSelectAll
            // 
            cbSelectAll.Location = new Point(102, 438);
            cbSelectAll.Name = "cbSelectAll";
            cbSelectAll.Size = new Size(46, 23);
            cbSelectAll.TabIndex = 8;
            cbSelectAll.Text = "Todos";
            cbSelectAll.UseVisualStyleBackColor = true;
            cbSelectAll.Click += cbSelectAll_Click;
            // 
            // cbExcluir
            // 
            cbExcluir.BackColor = Color.LightCoral;
            cbExcluir.Location = new Point(154, 438);
            cbExcluir.Name = "cbExcluir";
            cbExcluir.Size = new Size(53, 23);
            cbExcluir.TabIndex = 9;
            cbExcluir.Text = "Excluir";
            cbExcluir.UseVisualStyleBackColor = false;
            cbExcluir.Click += cbExcluir_Click;
            // 
            // clbGrupoDeContado
            // 
            clbGrupoDeContado.FormattingEnabled = true;
            clbGrupoDeContado.Location = new Point(615, 99);
            clbGrupoDeContado.Name = "clbGrupoDeContado";
            clbGrupoDeContado.ScrollAlwaysVisible = true;
            clbGrupoDeContado.Size = new Size(156, 184);
            clbGrupoDeContado.TabIndex = 14;
            // 
            // cbSalvarGrupo
            // 
            cbSalvarGrupo.Location = new Point(397, 430);
            cbSalvarGrupo.Name = "cbSalvarGrupo";
            cbSalvarGrupo.Size = new Size(99, 39);
            cbSalvarGrupo.TabIndex = 11;
            cbSalvarGrupo.Text = "Salvar Contaos em Grupo";
            cbSalvarGrupo.UseVisualStyleBackColor = true;
            cbSalvarGrupo.Click += cbSalvarGrupo_Click;
            // 
            // tbNomeDoArquivoDeGrupo
            // 
            tbNomeDoArquivoDeGrupo.Location = new Point(281, 439);
            tbNomeDoArquivoDeGrupo.Name = "tbNomeDoArquivoDeGrupo";
            tbNomeDoArquivoDeGrupo.Size = new Size(100, 23);
            tbNomeDoArquivoDeGrupo.TabIndex = 10;
            // 
            // cbExcluirGrupoSelect
            // 
            cbExcluirGrupoSelect.BackColor = Color.LightCoral;
            cbExcluirGrupoSelect.Location = new Point(637, 346);
            cbExcluirGrupoSelect.Name = "cbExcluirGrupoSelect";
            cbExcluirGrupoSelect.Size = new Size(106, 51);
            cbExcluirGrupoSelect.TabIndex = 15;
            cbExcluirGrupoSelect.Text = "Excluir Grupo";
            cbExcluirGrupoSelect.UseVisualStyleBackColor = false;
            cbExcluirGrupoSelect.Click += cbExcluirGrupoSelect_Click;
            // 
            // cbImportContatosDeGrupo
            // 
            cbImportContatosDeGrupo.Location = new Point(637, 289);
            cbImportContatosDeGrupo.Name = "cbImportContatosDeGrupo";
            cbImportContatosDeGrupo.Size = new Size(106, 51);
            cbImportContatosDeGrupo.TabIndex = 13;
            cbImportContatosDeGrupo.Text = "Adicionar Contatos";
            cbImportContatosDeGrupo.UseVisualStyleBackColor = true;
            cbImportContatosDeGrupo.Click += cbImportContatosDeGrupo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(676, 81);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 50;
            label3.Text = "Grupos Salvos";
            // 
            // cbAddImagem
            // 
            cbAddImagem.Location = new Point(637, 591);
            cbAddImagem.Name = "cbAddImagem";
            cbAddImagem.Size = new Size(87, 40);
            cbAddImagem.TabIndex = 51;
            cbAddImagem.Text = "Adicionar Imagem";
            cbAddImagem.UseVisualStyleBackColor = true;
            cbAddImagem.Click += cbAddImagem_Click;
            // 
            // LabelCampoMensagemUp
            // 
            LabelCampoMensagemUp.AutoSize = true;
            LabelCampoMensagemUp.Location = new Point(30, 481);
            LabelCampoMensagemUp.Name = "LabelCampoMensagemUp";
            LabelCampoMensagemUp.Size = new Size(66, 15);
            LabelCampoMensagemUp.TabIndex = 52;
            LabelCampoMensagemUp.Text = "Mensagem";
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Control;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(353, 99);
            listBox1.MultiColumn = true;
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(221, 285);
            listBox1.TabIndex = 53;
            // 
            // labelProcessandoMsg
            // 
            labelProcessandoMsg.AutoSize = true;
            labelProcessandoMsg.BackColor = Color.YellowGreen;
            labelProcessandoMsg.Location = new Point(410, 81);
            labelProcessandoMsg.Name = "labelProcessandoMsg";
            labelProcessandoMsg.Size = new Size(119, 15);
            labelProcessandoMsg.TabIndex = 54;
            labelProcessandoMsg.Text = "Enviando Mensagens";
            labelProcessandoMsg.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(215, 12);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 56;
            label4.Text = "Senha:";
            // 
            // tbApiKey
            // 
            tbApiKey.BackColor = SystemColors.Info;
            tbApiKey.Location = new Point(259, 8);
            tbApiKey.Name = "tbApiKey";
            tbApiKey.PasswordChar = '*';
            tbApiKey.Size = new Size(100, 23);
            tbApiKey.TabIndex = 57;
            tbApiKey.TextChanged += tbApiKey_TextChanged;
            // 
            // pbAnexado
            // 
            pbAnexado.Image = (Image)resources.GetObject("pbAnexado.Image");
            pbAnexado.Location = new Point(471, 646);
            pbAnexado.Name = "pbAnexado";
            pbAnexado.Size = new Size(48, 30);
            pbAnexado.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAnexado.TabIndex = 58;
            pbAnexado.TabStop = false;
            pbAnexado.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 697);
            Controls.Add(pbAnexado);
            Controls.Add(tbApiKey);
            Controls.Add(label4);
            Controls.Add(labelProcessandoMsg);
            Controls.Add(listBox1);
            Controls.Add(LabelCampoMensagemUp);
            Controls.Add(cbAddImagem);
            Controls.Add(label3);
            Controls.Add(cbImportContatosDeGrupo);
            Controls.Add(cbExcluirGrupoSelect);
            Controls.Add(tbNomeDoArquivoDeGrupo);
            Controls.Add(cbSalvarGrupo);
            Controls.Add(clbGrupoDeContado);
            Controls.Add(cbExcluir);
            Controls.Add(cbSelectAll);
            Controls.Add(cbNomeCompleto);
            Controls.Add(cbPrimeiroNome);
            Controls.Add(cbConnectar);
            Controls.Add(LabelServidor);
            Controls.Add(cbEnviarMensagem);
            Controls.Add(label2);
            Controls.Add(tbNomeContato);
            Controls.Add(cbAddContato);
            Controls.Add(clbContatos);
            Controls.Add(labelContato);
            Controls.Add(tbNumeroContato);
            Controls.Add(cbRefreshQrCode);
            Controls.Add(labelResponse);
            Controls.Add(pbQrCode);
            Controls.Add(cbStats);
            Controls.Add(label1);
            Controls.Add(tbSessionId);
            Controls.Add(cbEncerraSessao);
            Controls.Add(tbCampoMessage);
            Controls.Add(cbIniciarsessao);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Lista de Transmissão WhatsApp";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbQrCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAnexado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cbIniciarsessao;
        private TextBox tbCampoMessage;
        private Button cbEncerraSessao;
        private TextBox tbSessionId;
        private Label label1;
        private Button cbStats;
        private PictureBox pbQrCode;
        private Label labelResponse;
        private Button cbRefreshQrCode;
        private TextBox tbNumeroContato;
        private Label labelContato;
        private CheckedListBox clbContatos;
        private Button cbAddContato;
        private TextBox tbNomeContato;
        private Label label2;
        private Button cbEnviarMensagem;
        private Label LabelServidor;
        private Button cbConnectar;
        private Button cbPrimeiroNome;
        private Button cbNomeCompleto;
        private Button cbSelectAll;
        private Button cbExcluir;
        private CheckedListBox clbGrupoDeContado;
        private Button cbSalvarGrupo;
        private TextBox tbNomeDoArquivoDeGrupo;
        private Button cbExcluirGrupoSelect;
        private Button cbImportContatosDeGrupo;
        private Label label3;
        private Button cbAddImagem;
        private Label LabelCampoMensagemUp;
        private ListBox listBox1;
        private Label labelProcessandoMsg;
        private Label label4;
        private TextBox tbApiKey;
        private PictureBox pbAnexado;
    }
}