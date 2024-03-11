using ListaDeTransmissaoWhatsApi.Properties;
using System.ComponentModel;

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
            labelNomeCompleto = new Label();
            pbAnexado = new PictureBox();
            pbAguarde = new PictureBox();
            cbAdministração = new Button();
            cbImportarContatosDeArquivos = new Button();
            labelContCheckBox = new Label();
            ((ISupportInitialize)pbQrCode).BeginInit();
            ((ISupportInitialize)pbAnexado).BeginInit();
            ((ISupportInitialize)pbAguarde).BeginInit();
            SuspendLayout();
            // 
            // cbIniciarsessao
            // 
            cbIniciarsessao.Location = new Point(30, 42);
            cbIniciarsessao.Name = "cbIniciarsessao";
            cbIniciarsessao.Size = new Size(92, 23);
            cbIniciarsessao.TabIndex = 1;
            cbIniciarsessao.Text = "Iniciar Sessão";
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
            tbCampoMessage.Size = new Size(620, 132);
            tbCampoMessage.TabIndex = 16;
            // 
            // cbEncerraSessao
            // 
            cbEncerraSessao.Location = new Point(30, 99);
            cbEncerraSessao.Name = "cbEncerraSessao";
            cbEncerraSessao.Size = new Size(92, 41);
            cbEncerraSessao.TabIndex = 3;
            cbEncerraSessao.Text = "Encerrar Sessão";
            cbEncerraSessao.UseVisualStyleBackColor = true;
            cbEncerraSessao.Click += cbEncerraSessao_Click;
            // 
            // tbSessionId
            // 
            tbSessionId.BackColor = SystemColors.Info;
            tbSessionId.CharacterCasing = CharacterCasing.Lower;
            tbSessionId.Enabled = false;
            tbSessionId.Location = new Point(97, 9);
            tbSessionId.MaxLength = 14;
            tbSessionId.Name = "tbSessionId";
            tbSessionId.Size = new Size(88, 23);
            tbSessionId.TabIndex = 0;
            tbSessionId.TextAlign = HorizontalAlignment.Center;
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
            pbQrCode.Location = new Point(128, 42);
            pbQrCode.Name = "pbQrCode";
            pbQrCode.Size = new Size(196, 196);
            pbQrCode.SizeMode = PictureBoxSizeMode.Zoom;
            pbQrCode.TabIndex = 6;
            pbQrCode.TabStop = false;
            pbQrCode.Visible = false;
            // 
            // labelResponse
            // 
            labelResponse.AutoSize = true;
            labelResponse.BackColor = SystemColors.Control;
            labelResponse.Location = new Point(481, 32);
            labelResponse.Name = "labelResponse";
            labelResponse.Size = new Size(12, 15);
            labelResponse.TabIndex = 7;
            labelResponse.Text = "_";
            labelResponse.TextChanged += labelResponse_TextChanged;
            // 
            // cbRefreshQrCode
            // 
            cbRefreshQrCode.Location = new Point(30, 143);
            cbRefreshQrCode.Name = "cbRefreshQrCode";
            cbRefreshQrCode.Size = new Size(92, 44);
            cbRefreshQrCode.TabIndex = 4;
            cbRefreshQrCode.Text = "Recarregar Qr Code";
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
            clbContatos.Size = new Size(294, 148);
            clbContatos.TabIndex = 7;
            // 
            // cbAddContato
            // 
            cbAddContato.Location = new Point(30, 438);
            cbAddContato.Name = "cbAddContato";
            cbAddContato.Size = new Size(75, 23);
            cbAddContato.TabIndex = 6;
            cbAddContato.Text = "Adicionar";
            cbAddContato.UseVisualStyleBackColor = true;
            cbAddContato.Click += cbAddContato_Click;
            // 
            // tbNomeContato
            // 
            tbNomeContato.Location = new Point(30, 255);
            tbNomeContato.Name = "tbNomeContato";
            tbNomeContato.Size = new Size(294, 23);
            tbNomeContato.TabIndex = 5;
            tbNomeContato.KeyPress += tbNomeContato_KeyPress;
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
            cbEnviarMensagem.Location = new Point(562, 637);
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
            LabelServidor.Location = new Point(481, 8);
            LabelServidor.Name = "LabelServidor";
            LabelServidor.Size = new Size(169, 15);
            LabelServidor.TabIndex = 38;
            LabelServidor.Text = "Status Servidor:                           ";
            // 
            // cbConnectar
            // 
            cbConnectar.Location = new Point(377, 9);
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
            cbPrimeiroNome.Location = new Point(684, 499);
            cbPrimeiroNome.Name = "cbPrimeiroNome";
            cbPrimeiroNome.Size = new Size(87, 40);
            cbPrimeiroNome.TabIndex = 18;
            cbPrimeiroNome.Text = "Primeiro Nome";
            cbPrimeiroNome.UseVisualStyleBackColor = true;
            cbPrimeiroNome.Click += cbPrimeiroNome_Click;
            // 
            // cbNomeCompleto
            // 
            cbNomeCompleto.Location = new Point(684, 545);
            cbNomeCompleto.Name = "cbNomeCompleto";
            cbNomeCompleto.Size = new Size(87, 40);
            cbNomeCompleto.TabIndex = 19;
            cbNomeCompleto.Text = "Nome Completo";
            cbNomeCompleto.UseVisualStyleBackColor = true;
            cbNomeCompleto.Click += cbNomeCompleto_Click;
            // 
            // cbSelectAll
            // 
            cbSelectAll.Location = new Point(111, 438);
            cbSelectAll.Name = "cbSelectAll";
            cbSelectAll.Size = new Size(51, 23);
            cbSelectAll.TabIndex = 8;
            cbSelectAll.Text = "Todos";
            cbSelectAll.UseVisualStyleBackColor = true;
            cbSelectAll.Click += cbSelectAll_Click;
            // 
            // cbExcluir
            // 
            cbExcluir.BackColor = Color.LightCoral;
            cbExcluir.Location = new Point(168, 438);
            cbExcluir.Name = "cbExcluir";
            cbExcluir.Size = new Size(50, 23);
            cbExcluir.TabIndex = 9;
            cbExcluir.Text = "Excluir";
            cbExcluir.UseVisualStyleBackColor = false;
            cbExcluir.Click += cbExcluir_Click;
            // 
            // clbGrupoDeContado
            // 
            clbGrupoDeContado.FormattingEnabled = true;
            clbGrupoDeContado.Location = new Point(629, 182);
            clbGrupoDeContado.Name = "clbGrupoDeContado";
            clbGrupoDeContado.ScrollAlwaysVisible = true;
            clbGrupoDeContado.Size = new Size(156, 184);
            clbGrupoDeContado.TabIndex = 14;
            // 
            // cbSalvarGrupo
            // 
            cbSalvarGrupo.Location = new Point(330, 438);
            cbSalvarGrupo.Name = "cbSalvarGrupo";
            cbSalvarGrupo.Size = new Size(99, 39);
            cbSalvarGrupo.TabIndex = 11;
            cbSalvarGrupo.Text = "Salvar Contaos em Grupo";
            cbSalvarGrupo.UseVisualStyleBackColor = true;
            cbSalvarGrupo.Click += cbSalvarGrupo_Click;
            // 
            // tbNomeDoArquivoDeGrupo
            // 
            tbNomeDoArquivoDeGrupo.Location = new Point(224, 438);
            tbNomeDoArquivoDeGrupo.Name = "tbNomeDoArquivoDeGrupo";
            tbNomeDoArquivoDeGrupo.Size = new Size(100, 23);
            tbNomeDoArquivoDeGrupo.TabIndex = 10;
            // 
            // cbExcluirGrupoSelect
            // 
            cbExcluirGrupoSelect.BackColor = Color.LightCoral;
            cbExcluirGrupoSelect.Location = new Point(718, 381);
            cbExcluirGrupoSelect.Name = "cbExcluirGrupoSelect";
            cbExcluirGrupoSelect.Size = new Size(67, 51);
            cbExcluirGrupoSelect.TabIndex = 15;
            cbExcluirGrupoSelect.Text = "Excluir Grupo";
            cbExcluirGrupoSelect.UseVisualStyleBackColor = false;
            cbExcluirGrupoSelect.Click += cbExcluirGrupoSelect_Click;
            // 
            // cbImportContatosDeGrupo
            // 
            cbImportContatosDeGrupo.Location = new Point(629, 381);
            cbImportContatosDeGrupo.Name = "cbImportContatosDeGrupo";
            cbImportContatosDeGrupo.Size = new Size(79, 51);
            cbImportContatosDeGrupo.TabIndex = 13;
            cbImportContatosDeGrupo.Text = "Adicionar Contatos";
            cbImportContatosDeGrupo.UseVisualStyleBackColor = true;
            cbImportContatosDeGrupo.Click += cbImportContatosDeGrupo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(690, 164);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 50;
            label3.Text = "Grupos Salvos";
            // 
            // cbAddImagem
            // 
            cbAddImagem.Location = new Point(684, 591);
            cbAddImagem.Name = "cbAddImagem";
            cbAddImagem.Size = new Size(87, 40);
            cbAddImagem.TabIndex = 51;
            cbAddImagem.Text = "Adicionar Anexo";
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
            listBox1.Size = new Size(221, 315);
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
            // labelNomeCompleto
            // 
            labelNomeCompleto.AutoSize = true;
            labelNomeCompleto.Location = new Point(191, 12);
            labelNomeCompleto.Name = "labelNomeCompleto";
            labelNomeCompleto.Size = new Size(0, 15);
            labelNomeCompleto.TabIndex = 56;
            // 
            // pbAnexado
            // 
            pbAnexado.Image = Resources.Anexo;
            pbAnexado.Location = new Point(508, 634);
            pbAnexado.Name = "pbAnexado";
            pbAnexado.Size = new Size(48, 30);
            pbAnexado.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAnexado.TabIndex = 58;
            pbAnexado.TabStop = false;
            pbAnexado.Visible = false;
            pbAnexado.Click += pbAnexado_Click;
            pbAnexado.MouseEnter += pbAnexado_MouseEnter;
            pbAnexado.MouseLeave += pbAnexado_MouseLeave;
            // 
            // pbAguarde
            // 
            pbAguarde.Image = Resources.CodeCraft;
            pbAguarde.Location = new Point(651, 42);
            pbAguarde.Name = "pbAguarde";
            pbAguarde.Size = new Size(95, 91);
            pbAguarde.SizeMode = PictureBoxSizeMode.Zoom;
            pbAguarde.TabIndex = 59;
            pbAguarde.TabStop = false;
            // 
            // cbAdministração
            // 
            cbAdministração.BackColor = SystemColors.GradientInactiveCaption;
            cbAdministração.Enabled = false;
            cbAdministração.Location = new Point(679, 9);
            cbAdministração.Name = "cbAdministração";
            cbAdministração.Size = new Size(92, 23);
            cbAdministração.TabIndex = 60;
            cbAdministração.Text = "Contas";
            cbAdministração.UseVisualStyleBackColor = false;
            cbAdministração.Visible = false;
            // 
            // cbImportarContatosDeArquivos
            // 
            cbImportarContatosDeArquivos.Location = new Point(457, 438);
            cbImportarContatosDeArquivos.Name = "cbImportarContatosDeArquivos";
            cbImportarContatosDeArquivos.Size = new Size(99, 39);
            cbImportarContatosDeArquivos.TabIndex = 61;
            cbImportarContatosDeArquivos.Text = "Importar Contatos de Arquivo";
            cbImportarContatosDeArquivos.UseVisualStyleBackColor = true;
            cbImportarContatosDeArquivos.Click += cbImportarContatosDeArquivos_ClickAsync;
            // 
            // labelContCheckBox
            // 
            labelContCheckBox.AutoSize = true;
            labelContCheckBox.Location = new Point(224, 465);
            labelContCheckBox.Name = "labelContCheckBox";
            labelContCheckBox.Size = new Size(12, 15);
            labelContCheckBox.TabIndex = 62;
            labelContCheckBox.Text = "_";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 672);
            Controls.Add(labelContCheckBox);
            Controls.Add(cbImportarContatosDeArquivos);
            Controls.Add(cbAdministração);
            Controls.Add(pbAguarde);
            Controls.Add(pbAnexado);
            Controls.Add(labelNomeCompleto);
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
            Name = "Form1";
            Text = "Lista De Transmissão";
            FormClosing += Form1_FormClosing;
            ((ISupportInitialize)pbQrCode).EndInit();
            ((ISupportInitialize)pbAnexado).EndInit();
            ((ISupportInitialize)pbAguarde).EndInit();
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
        private Label labelNomeCompleto;
        private PictureBox pbAnexado;
        private PictureBox pbAguarde;
        private ListView listView;
        private Button cbAdministração;
        private Button cbImportarContatosDeArquivos;
        private Label labelContCheckBox;
    }
}