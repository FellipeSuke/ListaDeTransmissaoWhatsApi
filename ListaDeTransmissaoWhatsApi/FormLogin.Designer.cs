namespace ListaDeTransmissaoWhatsApi
{
    partial class FormLogin
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
            cbLogin = new Button();
            checkBoxLembrar = new CheckBox();
            tbUsuario = new TextBox();
            tbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cbLogin
            // 
            cbLogin.Location = new Point(116, 219);
            cbLogin.Name = "cbLogin";
            cbLogin.Size = new Size(117, 40);
            cbLogin.TabIndex = 0;
            cbLogin.Text = "Entrar";
            cbLogin.UseVisualStyleBackColor = true;
            cbLogin.Click += cbLogin_Click;
            // 
            // checkBoxLembrar
            // 
            checkBoxLembrar.AutoSize = true;
            checkBoxLembrar.Location = new Point(22, 231);
            checkBoxLembrar.Name = "checkBoxLembrar";
            checkBoxLembrar.Size = new Size(88, 19);
            checkBoxLembrar.TabIndex = 1;
            checkBoxLembrar.Text = "Lembra-me";
            checkBoxLembrar.UseVisualStyleBackColor = true;
            // 
            // tbUsuario
            // 
            tbUsuario.Location = new Point(69, 145);
            tbUsuario.Name = "tbUsuario";
            tbUsuario.Size = new Size(172, 23);
            tbUsuario.TabIndex = 2;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(69, 174);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(172, 23);
            tbPassword.TabIndex = 3;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.KeyPress += tbPassword_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 153);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 4;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 182);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 5;
            label2.Text = "Senha:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CodeCraft;
            pictureBox1.Location = new Point(93, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(258, 9);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 7;
            label3.Text = "1.0.7";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 287);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(tbUsuario);
            Controls.Add(checkBoxLembrar);
            Controls.Add(cbLogin);
            Name = "FormLogin";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "FormLogin";
            FormClosed += FormLogin_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cbLogin;
        private CheckBox checkBoxLembrar;
        private TextBox tbUsuario;
        private TextBox tbPassword;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
    }
}