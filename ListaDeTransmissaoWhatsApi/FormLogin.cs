using ListaDeTransmissaoWhatsApi.Properties;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ListaDeTransmissaoWhatsApi
{
    public partial class FormLogin : Form
    {
        private MySqlConnection connection;
        private const string Server = "apisuke.ddns.net";
        private const int Port = 3306;
        private const string Database = "db";
        private const string Username = "Suke";
        private const string Password = "Unreal05";

        public FormLogin()
        {
            InitializeComponent();
            // Registra o evento Shown para carregar os dados de login assincronamente quando o formulário é exibido
            Shown += (sender, e) => LoadDataAsyncLogin();
            // Inicializa a conexão com o banco de dados
            InitializeDB();
        }

        private void LoadDataAsyncLogin()
        {
            // Carrega os dados de login se a opção de lembrar está ativada
            if (Settings.Default.lembrarMe)
            {
                checkBoxLembrar.Checked = Settings.Default.lembrarMe;
                tbUsuario.Text = Settings.Default.login;
                tbPassword.Text = Settings.Default.password;
            }
        }

        private void InitializeDB()
        {
            // Inicializa a conexão com o banco de dados
            string connectionString = $"Server={Server};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
            try
            {
                connection = new MySqlConnection(connectionString);
                // Abre a conexão se não estiver aberta
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
            catch (MySqlException ex)
            {
                // Exibe uma mensagem de erro em caso de falha na conexão e encerra o programa
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}");
                Environment.Exit(1);
            }
        }

        private (bool isValid, int idCredencial) ValidateLogin(string username, string password)
        {
            bool isValid = false;
            int idCredencial = -1;
            // Prepara e executa a consulta para validar o login
            MySqlCommand command = new MySqlCommand("SELECT IdCredencial, Status FROM Credenciais WHERE Nome = @Username AND Senha = @Password", connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            try
            {
                // Executa a consulta e verifica o resultado
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Verifica se as credenciais são válidas e a conta está ativa
                        if (Convert.ToInt32(reader["Status"]) == 1)
                        {
                            isValid = true;
                            idCredencial = Convert.ToInt32(reader["IdCredencial"]);
                        }
                        else
                        {
                            // Exibe uma mensagem se a conta estiver desativada
                            MessageBox.Show("Sua conta está desativada. Por favor, entre em contato com o administrador.");
                        }
                    }
                    else
                    {
                        // Exibe uma mensagem se as credenciais forem inválidas
                        MessageBox.Show("Usuário ou senha inválidos.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Exibe uma mensagem de erro em caso de falha na validação do login
                MessageBox.Show($"Erro ao validar login: {ex.Message}");
            }
            // Retorna um par de valores indicando se o login é válido e o ID da credencial, se aplicável
            return (isValid, idCredencial);
        }

        private void cbLogin_Click(object sender, EventArgs e)
        {
            // Captura o nome de usuário e senha inseridos pelo usuário
            string username = tbUsuario.Text;
            string password = tbPassword.Text;
            // Valida o login com as credenciais fornecidas
            (bool isValid, int idCredencial) = ValidateLogin(username, password);
            if (isValid)
            {
                // Salva os detalhes do login se a opção de lembrar estiver marcada
                if (checkBoxLembrar.Checked)
                {
                    Settings.Default.login = username;
                    Settings.Default.password = password;
                }
                else
                {
                    Settings.Default.login = "";
                    Settings.Default.password = "";
                }
                Settings.Default.lembrarMe = checkBoxLembrar.Checked;
                Settings.Default.Save();
                // Oculta o formulário de login, exibe o formulário principal e fecha o formulário de login
                Hide();
                new Form1(idCredencial).ShowDialog();
                Close();
            }
            else
            {
                // Exibe uma mensagem se as credenciais forem inválidas
                MessageBox.Show("Credenciais inválidas. Por favor, tente novamente.");
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnClosed((EventArgs)e);
            connection.Close();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            cbLogin_Click(sender, (EventArgs)e);
        }
    }




}


