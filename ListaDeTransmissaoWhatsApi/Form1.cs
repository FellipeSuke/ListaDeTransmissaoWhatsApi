using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ListaDeTransmissaoWhatsApi.Models;
using ListaDeTransmissaoWhatsApi.Properties;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable enable
namespace ListaDeTransmissaoWhatsApi
{
    public partial class Form1 : Form
    {
        public int idCredencial;
        public string Nome;
        public string NomeCompleto;
        public string Empresa;
        public string Status;
        public string keyName;
        public string keyValue;
        public string host;
        public string sessionId;
        public string privilegios;
        private DadosImagemAnexo imagemEmAnexo = new DadosImagemAnexo();
        private MySqlConnection connection;
        private const string server = "apisuke.ddns.net";
        private const int port = 3306;
        private const string database = "db";
        private const string username = "Suke";
        private const string password = "Unreal05";

        public Form1(int idCredencial)
        {
            this.InitializeComponent();
            this.idCredencial = idCredencial;
            this.Shown += (EventHandler)(async (sender, e) => await this.LoadDataAsync());
        }

        private void InitializeDB()
        {
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 5);
            interpolatedStringHandler.AppendLiteral("Server=");
            interpolatedStringHandler.AppendFormatted("apisuke.ddns.net");
            interpolatedStringHandler.AppendLiteral(";Port=");
            interpolatedStringHandler.AppendFormatted<int>(3306);
            interpolatedStringHandler.AppendLiteral(";Database=");
            interpolatedStringHandler.AppendFormatted("db");
            interpolatedStringHandler.AppendLiteral(";Uid=");
            interpolatedStringHandler.AppendFormatted("Suke");
            interpolatedStringHandler.AppendLiteral(";Pwd=");
            interpolatedStringHandler.AppendFormatted("Unreal05");
            interpolatedStringHandler.AppendLiteral(";");
            string stringAndClear = interpolatedStringHandler.ToStringAndClear();
            try
            {
                this.connection = new MySqlConnection(stringAndClear);
                this.connection.Open();
            }
            catch (MySqlException ex)
            {
                int num = (int)MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                Environment.Exit(1);
            }
        }

        private async
#nullable enable
        Task LoadDataAsync()
        {
            try
            {
                this.InitializeDB();
                string query = "SELECT * FROM Credenciais WHERE IdCredencial = @idCredencial";
                using (MySqlCommand command = new MySqlCommand(query, this.connection))
                {
                    command.Parameters.AddWithValue("@idCredencial", (object)this.idCredencial);
                    DbDataReader dbDataReader = await command.ExecuteReaderAsync();
                    MySqlDataReader reader = (MySqlDataReader)dbDataReader;
                    dbDataReader = (DbDataReader)null;
                    try
                    {
                        if (reader.Read())
                        {
                            this.Nome = reader["Nome"].ToString();
                            this.NomeCompleto = reader["NomeCompleto"].ToString();
                            this.Empresa = reader["Empresa"].ToString();
                            this.Status = reader["Status"].ToString();
                            this.keyName = reader["KeyName"].ToString();
                            this.keyValue = reader["KeyValue"].ToString();
                            this.host = reader["HostApi"].ToString();
                            this.sessionId = reader["SessionId"].ToString();
                            this.privilegios = reader["Privilegios"].ToString();
                            this.tbSessionId.Text = this.sessionId;
                            this.tbSessionId.Enabled = false;
                            this.labelNomeCompleto.Text = this.NomeCompleto + "  " + this.Empresa;
                            if (this.privilegios == "superUser")
                            {
                                this.cbAdministração.Visible = true;
                                this.cbAdministração.Enabled = true;
                            }
                            System.Windows.Forms.Application.DoEvents();
                            if (!string.IsNullOrEmpty(this.keyValue))
                            {
                                string str = await this.PingSystem();
                                await this.PreencherCheckListBoxComGruposAsync();
                            }
                        }
                        else
                        {
                            int num = (int)MessageBox.Show("Usuário não encontrado.");
                        }
                    }
                    finally
                    {
                        reader?.Dispose();
                    }
                    reader = (MySqlDataReader)null;
                }
                query = (string)null;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void PrintMessage(RestResponse response, string comando)
        {
            try
            {
                StartSession startSession = this.DesserializeResponse(response);
                if (startSession.Success)
                {
                    string str = this.Translate(startSession.Message);
                    this.labelResponse.Text = comando + Environment.NewLine + str;
                }
                else if (!startSession.Success)
                {
                    if (startSession.Message != null)
                        this.labelResponse.Text = "Falha" + Environment.NewLine + this.Translate(startSession.Message);
                    else
                        this.labelResponse.Text = "Falha" + Environment.NewLine + startSession.Message;
                }
                else
                    this.labelResponse.Text = "Sem Dados de Sucesso";
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string Translate(string englishMessage)
        {
            return new ResponseTranslator().Translate(englishMessage);
        }

        private async void cbIniciarsessao_Click(object sender, EventArgs e)
        {
            this.cbStats.Enabled = false;
            this.cbIniciarsessao.Enabled = false;
            this.cbEnviarMensagem.Enabled = false;
            this.Processando();
            RestResponse response = await this.RequestRestGetAsync("/session/start/");
            this.PrintMessage(response, "Sessão " + this.sessionId + " Conectado");
            this.tbSessionId.Enabled = false;
            await this.ShowQRCodeAsync(response);
            this.cbStats.Enabled = true;
            this.cbIniciarsessao.Enabled = true;
            this.cbEnviarMensagem.Enabled = true;
            response = (RestResponse)null;
        }

        private async void cbEncerraSessao_Click(object sender, EventArgs e)
        {
            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    this.Processando();
                    RestResponse response = await this.RequestRestGetAsync("/session/terminate/");
                    if (response != null)
                    {
                        this.PrintMessage(response, "Sessão " + this.sessionId + " Encerrada");
                        break;
                    }
                    ++attempts;
                    response = (RestResponse)null;
                }
                catch (Exception ex)
                {
                    this.labelResponse.Text = "Erro: " + ex.Message;
                    ++attempts;
                }
            }
            if (attempts != 3)
                return;
            this.labelResponse.Text = "Todas as tentativas falharam. Não foi possível encerrar a sessão.";
        }

        private async void cbStats_Click(object sender, EventArgs e)
        {
            try
            {
                this.Processando();
                RestResponse response = await this.RequestRestGetAsync("/session/status/");
                this.PrintMessage(response, "Sessão " + this.sessionId + " ");
                response = (RestResponse)null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task ShowQRCodeAsync(RestResponse cache)
        {
            if (cache == null)
                throw new ArgumentNullException(nameof(cache), "O parâmetro cache não pode ser nulo.");

            Processando();

            try
            {
                int timeoutSeconds = 180;
                int elapsedTime = 0;
                bool connected = false;

                while (!connected && elapsedTime < timeoutSeconds)
                {
                    RestResponse responseStatus = await RequestRestGetAsync("/session/status/");

                    if (responseStatus != null && !string.IsNullOrEmpty(responseStatus.Content))
                    {
                        StartSession status = DesserializeResponse(responseStatus);

                        if (status != null && status.State == "CONNECTED")
                        {
                            connected = true;
                            PrintMessage(responseStatus, $"Sessão {sessionId} {status.State}");
                            pbQrCode.Visible = false;
                            cbRefreshQrCode.Visible = false;
                        }

                        status = null;
                    }

                    if (!connected)
                    {
                        RestResponse response = await RequestRestGetAsync("/session/qr/", "/Image", "image/png");

                        if (response != null && response.ContentType == "image/png")
                        {
                            using (MemoryStream ms = new MemoryStream(response.RawBytes))
                            {
                                pbQrCode.Image = Image.FromStream(ms);
                                pbQrCode.Visible = true;
                                cbRefreshQrCode.Visible = true;
                            }
                        }

                        labelResponse.Text = $"Aguardando QR Code... {elapsedTime}Seg";
                        elapsedTime++;
                        await Task.Delay(1000);
                    }

                    responseStatus = null;
                }

                if (!connected)
                {
                    MessageBox.Show("Tempo esgotado. QR Code não recebido.");
                    labelResponse.Text = "Tempo esgotado. QR Code não recebido.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
                labelResponse.Text = ex.Message;
            }
        }


        private async Task<RestResponse> RequestRestGetAsync(
          string caminhoSession,
          string optional = "",
          string contentType = "application/json")
        {
            RestResponse async;
            try
            {
                RestClientOptions options = new RestClientOptions(this.host)
                {
                    MaxTimeout = 10000
                };
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest(caminhoSession + this.sessionId + optional)
                {
                    Timeout = 5000
                };
                request.AddHeader(this.keyName, this.keyValue);
                request.AddHeader("Content-Type", contentType);
                async = await client.ExecuteAsync(request, new CancellationToken());
            }
            catch (Exception ex)
            {
                throw;
            }
            return async;
        }

        private async Task<string> PostMessageWhatsapp(
          string ItensMarcados,
          string host,
          int indexLinha)
        {
            string str;
            try
            {
                DadosDoUsuario usuarioTarget = this.DadosDoEnvioUsuario(ItensMarcados);
                RestClientOptions options = new RestClientOptions(host)
                {
                    MaxTimeout = 30000
                };
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest("/client/sendMessage/" + this.sessionId, Method.Post)
                {
                    Timeout = 5000
                };
                request.AddHeader(this.keyName, this.keyValue);
                request.AddHeader("Content-Type", "application/json");
                string ReplaceDeVariaveisMsg = this.tbCampoMessage.Text.Replace("@PrimeiroNomeContato@", usuarioTarget.PrimeiroNome.ToString()).Replace("@NomeCompletoDoContato@", usuarioTarget.NomeCompleto.ToString()).Replace("@NumeroDoContato@", usuarioTarget.Numero.ToString());
                string textoSemQuebrasDeLinha = ReplaceDeVariaveisMsg.Replace("\n", "\\n").Replace("\r", "\\r");
                string body = "{\r\n        \n  \"chatId\": \"" + usuarioTarget.Numero + "\",\r\n        \n  \"contentType\": \"string\",\r\n        \n  \"content\": \"" + textoSemQuebrasDeLinha + "\"\r\n        \n}";
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request, new CancellationToken());
                try
                {
                    if (!this.listBox1.Items[indexLinha].ToString().Contains(usuarioTarget.PrimeiroNome))
                        this.AcrescentarStringEmLinhaEspecifica(this.listBox1, usuarioTarget.PrimeiroNome + " >> Msg: " + response.StatusDescription, indexLinha);
                    else
                        this.AcrescentarStringEmLinhaEspecifica(this.listBox1, " >> Msg: " + response.StatusDescription, indexLinha);
                }
                catch
                {
                    this.AcrescentarStringEmLinhaEspecifica(this.listBox1, usuarioTarget.PrimeiroNome + " >> Msg: " + response.StatusDescription, indexLinha);
                }
                str = response.ResponseStatus.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return str;
        }

        private async Task<string> PostMessageWhatsappMedia(
          string ItensMarcados,
          string base64Image,
          byte[] imageBytes,
          string imagePath,
          int indexLinha)
        {
            string str;
            try
            {
                DadosDoUsuario usuarioTarget = this.DadosDoEnvioUsuario(ItensMarcados);
                string extension = Path.GetExtension(imagePath)?.ToLower();
                string mimetype = this.GetMimeTypeFromExtension(extension);
                string ReplaceDeVariaveisMsg = this.tbCampoMessage.Text.Replace("@PrimeiroNomeContato@", usuarioTarget.PrimeiroNome.ToString()).Replace("@NomeCompletoDoContato@", usuarioTarget.NomeCompleto.ToString()).Replace("@NumeroDoContato@", usuarioTarget.Numero.ToString());
                var body = new
                {
                    chatId = usuarioTarget.Numero,
                    contentType = "MessageMedia",
                    content = new
                    {
                        mimetype = mimetype,
                        data = base64Image,
                        filename = Path.GetFileName(imagePath)
                    },
                    options = new { caption = ReplaceDeVariaveisMsg }
                };
                RestClientOptions options = new RestClientOptions(this.host)
                {
                    MaxTimeout = 30000
                };
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest("/client/sendMessage/" + this.sessionId, Method.Post)
                {
                    Timeout = 15000
                };
                request.AddHeader(this.keyName, this.keyValue);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(body);
                RestResponse response = await client.ExecuteAsync(request, new CancellationToken());
                this.AcrescentarStringEmLinhaEspecifica(this.listBox1, usuarioTarget.PrimeiroNome + " >> Media: " + response.StatusDescription, indexLinha);
                str = response.ResponseStatus.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return str;
        }

        private string GetMimeTypeFromExtension(string extension)
        {
            string str = extension;
            if (str != null)
            {
                switch (str.Length)
                {
                    case 4:
                        switch (str[2])
                        {
                            case 'a':
                                if (str == ".wav")
                                    return "audio/wav";
                                goto label_33;
                            case 'd':
                                if (str == ".pdf")
                                    return "application/pdf";
                                goto label_33;
                            case 'g':
                                if (str == ".ogg")
                                    return "audio/ogg";
                                goto label_33;
                            case 'i':
                                if (str == ".gif")
                                    break;
                                goto label_33;
                            case 'l':
                                if (str == ".xls")
                                    return "application/vnd.ms-excel";
                                goto label_33;
                            case 'm':
                                if (str == ".bmp")
                                    break;
                                goto label_33;
                            case 'n':
                                if (str == ".png")
                                    break;
                                goto label_33;
                            case 'o':
                                if (str == ".mov")
                                    return "video/quicktime";
                                goto label_33;
                            case 'p':
                                switch (str)
                                {
                                    case ".jpg":
                                        break;
                                    case ".ppt":
                                        return "application/vnd.ms-powerpoint";
                                    case ".mp3":
                                        return "audio/mpeg";
                                    case ".mp4":
                                        return "video/mp4";
                                    default:
                                        goto label_33;
                                }
                                break;
                            case 'v':
                                if (str == ".avi")
                                    return "video/x-msvideo";
                                goto label_33;
                            case 'x':
                                if (str == ".txt")
                                    return "text/plain";
                                goto label_33;
                            default:
                                goto label_33;
                        }
                        break;
                    case 5:
                        switch (str[1])
                        {
                            case 'd':
                                if (str == ".docx")
                                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                goto label_33;
                            case 'j':
                                if (str == ".jpeg")
                                    break;
                                goto label_33;
                            case 'p':
                                if (str == ".pptx")
                                    return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                goto label_33;
                            case 'x':
                                if (str == ".xlsx")
                                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                goto label_33;
                            default:
                                goto label_33;
                        }
                        break;
                    default:
                        goto label_33;
                }
                return "image/jpeg";
            }
        label_33:
            return "*/*";
        }

        private StartSession DesserializeResponse(RestResponse response)
        {
            try
            {
                return JsonConvert.DeserializeObject<StartSession>(response.Content);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Processando()
        {
            try
            {
                this.labelResponse.Text = "Processando...";
                this.pbQrCode.Visible = false;
                this.cbRefreshQrCode.Visible = false;
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void cbRefreshQrCode_Click(object sender, EventArgs e)
        {
            try
            {
                string cache = this.labelResponse.Text;
                this.Processando();
                RestResponse response = await this.RequestRestGetAsync("/session/qr/", "/Image", "image/png");
                MemoryStream ms = new MemoryStream(response.RawBytes);
                this.pbQrCode.Image = Image.FromStream((Stream)ms);
                this.labelResponse.Text = cache;
                this.pbQrCode.Visible = true;
                this.cbRefreshQrCode.Visible = true;
                cache = (string)null;
                response = (RestResponse)null;
                ms = (MemoryStream)null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Campo_Leave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
                if (!(textBox.Text != ""))
                    return;
                if (textBox.Text.Length != 13)
                {
                    int num = (int)MessageBox.Show("Número de celular inválido. Por favor, insira um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox.Focus();
                }
                else
                    this.sessionId = this.tbSessionId.Text;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Campo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
                string str = new string(textBox.Text.Where<char>((Func<char, bool>)(c => char.IsDigit(c))).ToArray<char>());
                if (str.Length > 0)
                {
                    if (str.Length > 2)
                        str = str.Insert(2, "-");
                    if (str.Length > 8)
                        str = str.Insert(8, "-");
                }
                textBox.Text = str;
                textBox.SelectionStart = textBox.Text.Length;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Valida_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                    return;
                e.Handled = true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void cbAddContato_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tbNomeContato.Text != "" && this.tbNumeroContato.Text != "")
                {
                    string contatoWhatsapp = await FormatarNumeroWhatsApp(tbNumeroContato.Text);
                    if (contatoWhatsapp != null)
                    {
                        this.clbContatos.Items.Add((object)(contatoWhatsapp + "; " + this.tbNomeContato.Text), true);
                        foreach (object item in (System.Windows.Forms.ListBox.ObjectCollection)this.clbContatos.Items)
                        {
                            this.tbNomeContato.Clear();
                            this.tbNumeroContato.Clear();
                            this.tbNumeroContato.Focus();
                        }
                    }
                    else
                    {
                        int num = (int)MessageBox.Show("Contato não localizado na rede WhatsaApp", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    contatoWhatsapp = (string)null;
                }
                else
                {
                    int num1 = (int)MessageBox.Show("Campos Obrigatórios não Preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<string?> FormatarNumeroWhatsApp(string telefone)
        {
            try
            {
                string numeroLimpo = Regex.Replace(telefone, "[^0-9]", "");

                // Verifica se o número já começa com "55"
                if (!numeroLimpo.StartsWith("55"))
                {
                    numeroLimpo = "55" + numeroLimpo;
                }

                RestClientOptions options = new RestClientOptions(this.host)
                {
                    MaxTimeout = 1000
                };
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest("/client/getNumberId/" + this.sessionId, Method.Post);
                request.AddHeader(this.keyName, this.keyValue);
                request.AddHeader("Content-Type", "application/json");
                string body = "{\r\n\n  \"number\": \"" + numeroLimpo + "\"\r\n\n}";
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request, new CancellationToken());
                WhatsNumeroId responseData = JsonConvert.DeserializeObject<WhatsNumeroId>(response.Content);
                return responseData != null && responseData.Result != null ? responseData.Result._Serialized : (string)null;
            }
            catch (Exception ex)
            {
                return (string)null;
            }
        }

        private async void cbEnviarMensagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.clbContatos.CheckedItems.Count == 0)
                {
                    int num1 = (int)MessageBox.Show("Por favor, selecione pelo menos um contato para enviar a mensagem.\nSe for um problema procure a Mariana");
                }
                else
                {
                    this.Processando();
                    this.labelProcessandoMsg.Visible = true;
                    string respostaPraLabel = "Sem Resposta";
                    this.listBox1.Items.Clear();
                    int numeroDeMensagens = 0;
                    if (this.imagemEmAnexo.Base64Image != null || this.tbCampoMessage.Text != "")
                    {
                        if (this.imagemEmAnexo.Base64Image != null)
                        {
                            int indexLinha = 0;
                            foreach (object item in this.clbContatos.CheckedItems)
                            {
                                DadosDoUsuario usuarioTarget = this.DadosDoEnvioUsuario(item.ToString());
                                respostaPraLabel = await this.PostMessageWhatsappMedia(item.ToString(), this.imagemEmAnexo.Base64Image, this.imagemEmAnexo.ImageBytes, this.imagemEmAnexo.ImagePath, indexLinha);
                                ++numeroDeMensagens;
                                ++indexLinha;
                                usuarioTarget = (DadosDoUsuario)null;
                            }
                        }
                        if (this.tbCampoMessage.Text != "" && this.imagemEmAnexo.Base64Image == null)
                        {
                            if (numeroDeMensagens != 0)
                                numeroDeMensagens = 0;
                            int indexLinha = 0;
                            foreach (object item in this.clbContatos.CheckedItems)
                            {
                                respostaPraLabel = await this.PostMessageWhatsapp(item.ToString(), this.host, indexLinha);
                                ++numeroDeMensagens;
                                ++indexLinha;
                            }
                        }
                        this.labelProcessandoMsg.Visible = false;
                        this.labelResponse.Text = this.Translate(respostaPraLabel);
                    }
                    else
                    {
                        int num2 = (int)MessageBox.Show("Não há mensagem a ser enviada.");
                    }
                    respostaPraLabel = (string)null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DadosDoUsuario DadosDoEnvioUsuario(string ItenMarcados)
        {
            try
            {
                DadosDoUsuario dadosDoUsuario = new DadosDoUsuario();
                string[] strArray1 = ItenMarcados.Split("; ");
                if (strArray1.Length == 2)
                {
                    dadosDoUsuario.Numero = strArray1[0];
                    dadosDoUsuario.NomeCompleto = strArray1[1];
                    string[] strArray2 = dadosDoUsuario.NomeCompleto.Split(' ');
                    dadosDoUsuario.PrimeiroNome = strArray2[0];
                }
                return dadosDoUsuario;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void cbConnectar_Click(object sender, EventArgs e)
        {
            try
            {
                this.LabelServidor.Text = "Conectando";
                this.LabelServidor.BackColor = System.Drawing.Color.FromArgb((int)byte.MaxValue, 240, 240, 240);
                string str = await this.PingSystem();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private async Task<string> PingSystem()
        {
            try
            {
                this.Processando();
                RestResponse responseStatus = await this.RequestRestGetAsync("/session/status/");
                this.PrintMessage(responseStatus, "Sessão " + this.sessionId + " ");
                RestClientOptions options = new RestClientOptions(this.host)
                {
                    MaxTimeout = 1000
                };
                RestClient client = new RestClient(options);
                RestRequest request = new RestRequest("/PING");
                RestResponse response = await client.ExecuteAsync(request, new CancellationToken());
                StartSession responseData = this.DesserializeResponse(response);
                if (responseData.Success)
                {
                    this.LabelServidor.Text = "Servidor: Conectado";
                    this.LabelServidor.BackColor = System.Drawing.Color.YellowGreen;
                    this.cbConnectar.Visible = false;
                    this.AtivaStatusPeloServidorApp(true);
                    System.Windows.Forms.Application.DoEvents();
                    return responseData.Message;
                }
                if (!responseData.Success)
                {
                    if (responseData.Error != null)
                    {
                        this.LabelServidor.Text = "Falha" + Environment.NewLine + responseData.Error;
                        this.LabelServidor.BackColor = System.Drawing.Color.IndianRed;
                        this.cbConnectar.Visible = true;
                        System.Windows.Forms.Application.DoEvents();
                        return responseData.Error;
                    }
                    this.LabelServidor.Text = "Falha" + Environment.NewLine + responseData.Message;
                    this.AtivaStatusPeloServidorApp(false);
                    System.Windows.Forms.Application.DoEvents();
                    return responseData.Message;
                }
                this.LabelServidor.Text = "Sem Dados de Sucesso";
                this.LabelServidor.BackColor = System.Drawing.Color.IndianRed;
                this.cbConnectar.Visible = true;
                this.AtivaStatusPeloServidorApp(false);
                System.Windows.Forms.Application.DoEvents();
                return "Sem Dados de Sucesso";
            }
            catch (Exception ex)
            {
                this.LabelServidor.Text = "Servidor OFFLINE";
                this.LabelServidor.BackColor = System.Drawing.Color.IndianRed;
                this.AtivaStatusPeloServidorApp(false);
                System.Windows.Forms.Application.DoEvents();
                return "Sem Dados de Sucesso";
            }
        }

        private void AtivaStatusPeloServidorApp(bool Ativa)
        {
            try
            {
                this.cbIniciarsessao.Enabled = Ativa;
                this.cbStats.Enabled = Ativa;
                this.cbEncerraSessao.Enabled = Ativa;
                this.tbNumeroContato.Enabled = Ativa;
                this.tbNomeContato.Enabled = Ativa;
                this.tbCampoMessage.Enabled = Ativa;
                this.cbAddContato.Enabled = Ativa;
                this.cbSelectAll.Enabled = Ativa;
                this.cbExcluir.Enabled = Ativa;
                this.cbEnviarMensagem.Enabled = Ativa;
                this.cbPrimeiroNome.Enabled = Ativa;
                this.cbNomeCompleto.Enabled = Ativa;
                this.cbAddImagem.Enabled = Ativa;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cbPrimeiroNome_Click(object sender, EventArgs e)
        {
            try
            {
                this.VariaveisDeTexto(" @PrimeiroNomeContato@ ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cbNomeCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                this.VariaveisDeTexto(" @NomeCompletoDoContato@ ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void VariaveisDeTexto(string variavelTexto)
        {
            try
            {
                int selectionStart = this.tbCampoMessage.SelectionStart;
                this.tbCampoMessage.Text = this.tbCampoMessage.Text.Insert(selectionStart, variavelTexto);
                this.tbCampoMessage.SelectionStart = selectionStart + variavelTexto.Length;
                this.tbCampoMessage.SelectionLength = 0;
                this.tbCampoMessage.Focus();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cbSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.clbContatos.GetItemChecked(0))
                {
                    for (int index = 0; index < this.clbContatos.Items.Count; ++index)
                        this.clbContatos.SetItemChecked(index, false);
                }
                else
                {
                    for (int index = 0; index < this.clbContatos.Items.Count; ++index)
                        this.clbContatos.SetItemChecked(index, true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cbExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int count = this.clbContatos.CheckedItems.Count;
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(56, 1);
                interpolatedStringHandler.AppendLiteral("Tem certeza que deseja excluir ");
                interpolatedStringHandler.AppendFormatted<int>(count);
                interpolatedStringHandler.AppendLiteral(" contatos selecionado(s)?");
                if (MessageBox.Show(interpolatedStringHandler.ToStringAndClear(), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                List<int> intList = new List<int>();
                foreach (int checkedIndex in this.clbContatos.CheckedIndices)
                    intList.Add(checkedIndex);
                for (int index = intList.Count - 1; index >= 0; --index)
                    this.clbContatos.Items.RemoveAt(intList[index]);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task SalvarGrupoAsync(string nomeGrupo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nomeGrupo))
                {
                    int num1 = (int)MessageBox.Show("Por favor, insira um nome de grupo válido.");
                }
                else
                {
                    this.InitializeDB();
                    string queryCheckGroup = "SELECT COUNT(*) FROM GruposContatos WHERE NomeGrupo = @NomeGrupo AND IdCredencial = @IdCredencial";
                    using (MySqlCommand command = new MySqlCommand(queryCheckGroup, this.connection))
                    {
                        command.Parameters.AddWithValue("@NomeGrupo", (object)nomeGrupo);
                        command.Parameters.AddWithValue("@IdCredencial", (object)this.idCredencial);
                        object obj = await command.ExecuteScalarAsync();
                        int count = Convert.ToInt32(obj);
                        obj = (object)null;
                        if (count > 0)
                        {
                            int num2 = (int)MessageBox.Show("Já existe um grupo com o mesmo nome para o usuário atual.\nAtualizando Grupo Atual", "Atualizando Grupo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    string queryInsertGroup = "INSERT INTO GruposContatos (NomeGrupo, IdCredencial) VALUES (@NomeGrupo, @IdCredencial)";
                    using (MySqlCommand command = new MySqlCommand(queryInsertGroup, this.connection))
                    {
                        command.Parameters.AddWithValue("@NomeGrupo", (object)nomeGrupo);
                        command.Parameters.AddWithValue("@IdCredencial", (object)this.idCredencial);
                        int num3 = await command.ExecuteNonQueryAsync();
                    }
                    queryCheckGroup = (string)null;
                    queryInsertGroup = (string)null;
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Ocorreu um erro ao salvar o grupo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private async void cbSalvarGrupo_Click(object sender, EventArgs e)
        {
            await this.SalvarGrupoAsync(this.tbNomeDoArquivoDeGrupo.Text);
            await this.SalvarItensCheckListBoxAsync(this.tbNomeDoArquivoDeGrupo.Text);
            this.PreencherCheckListBoxComGruposAsync();
            int num = (int)MessageBox.Show("Grupo salvo com sucesso!");
        }

        private async Task SalvarItensCheckListBoxAsync(string nomeGrupo)
        {
            try
            {
                this.InitializeDB();
                int idGrupoExistente = -1;
                string queryCheckGroup = "SELECT IdGrupo FROM GruposContatos WHERE NomeGrupo = @NomeGrupo AND IdCredencial = @IdCredencial";
                using (MySqlCommand command = new MySqlCommand(queryCheckGroup, this.connection))
                {
                    command.Parameters.AddWithValue("@NomeGrupo", (object)nomeGrupo);
                    command.Parameters.AddWithValue("@IdCredencial", (object)this.idCredencial);
                    object obj = await command.ExecuteScalarAsync();
                    idGrupoExistente = Convert.ToInt32(obj);
                    obj = (object)null;
                }
                if (idGrupoExistente != -1)
                {
                    string queryDeleteContatos = "DELETE FROM Contatos WHERE IdGrupo = @IdGrupo";
                    using (MySqlCommand command = new MySqlCommand(queryDeleteContatos, this.connection))
                    {
                        command.Parameters.AddWithValue("@IdGrupo", (object)idGrupoExistente);
                        int num = await command.ExecuteNonQueryAsync();
                    }
                    queryDeleteContatos = (string)null;
                }
                foreach (object item in this.clbContatos.CheckedItems)
                {
                    string contatoCriptografado = Criptografias.Criptografar(item.ToString());
                    string queryInsertContato = "INSERT INTO Contatos (NomeContato, IdGrupo) VALUES (@NomeContato, @IdGrupo)";
                    using (MySqlCommand command = new MySqlCommand(queryInsertContato, this.connection))
                    {
                        command.Parameters.AddWithValue("@NomeContato", (object)contatoCriptografado);
                        command.Parameters.AddWithValue("@IdGrupo", (object)idGrupoExistente);
                        int num = await command.ExecuteNonQueryAsync();
                    }
                    contatoCriptografado = (string)null;
                    queryInsertContato = (string)null;
                }
                queryCheckGroup = (string)null;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao salvar contatos: " + ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private async Task PreencherCheckListBoxComGruposAsync()
        {
            try
            {
                this.clbGrupoDeContado.Items.Clear();
                this.InitializeDB();
                string query = "SELECT NomeGrupo FROM GruposContatos WHERE IdCredencial = @IdCredencial";
                using (MySqlCommand command = new MySqlCommand(query, this.connection))
                {
                    command.Parameters.AddWithValue("@IdCredencial", (object)this.idCredencial);
                    DbDataReader dbDataReader = await command.ExecuteReaderAsync();
                    MySqlDataReader reader = (MySqlDataReader)dbDataReader;
                    dbDataReader = (DbDataReader)null;
                    try
                    {
                        while (reader.Read())
                        {
                            string nomeGrupo = reader.GetString("NomeGrupo");
                            this.clbGrupoDeContado.Items.Add((object)nomeGrupo);
                            nomeGrupo = (string)null;
                        }
                    }
                    finally
                    {
                        reader?.Dispose();
                    }
                    reader = (MySqlDataReader)null;
                }
                query = (string)null;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao preencher CheckListBox com grupos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private async void cbImportContatosDeGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                int verificaContatoDuplo = 0;

                foreach (string nomeGrupo in clbGrupoDeContado.CheckedItems)
                {
                    InitializeDB();

                    string query = @"SELECT NomeContato 
                             FROM Contatos 
                             INNER JOIN GruposContatos 
                             ON Contatos.IdGrupo = GruposContatos.IdGrupo 
                             WHERE GruposContatos.NomeGrupo = @NomeGrupo 
                             AND GruposContatos.IdCredencial = @IdCredencial";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NomeGrupo", nomeGrupo);
                        command.Parameters.AddWithValue("@IdCredencial", idCredencial);

                        using (DbDataReader dbDataReader = await command.ExecuteReaderAsync())
                        {
                            while (dbDataReader.Read())
                            {
                                string contatoCriptografado = dbDataReader.GetString("NomeContato");
                                string contatoDescriptografado = Criptografias.Descriptografar(contatoCriptografado);

                                if (!clbContatos.Items.Cast<string>().Any(item => item == contatoDescriptografado))
                                {
                                    clbContatos.Items.Add(contatoDescriptografado, true);
                                }
                                else
                                {
                                    verificaContatoDuplo++;
                                    clbContatos.Items.Add(contatoDescriptografado, false);
                                }
                            }
                        }
                    }
                }

                if (verificaContatoDuplo > 0)
                {
                    MessageBox.Show($"Há {verificaContatoDuplo} contatos já existentes adicionados sem marcação");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao importar contatos dos grupos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private async void cbExcluirGrupoSelect_Click(object sender, EventArgs e)
        {
            await this.ExcluirGruposSelecionadosAsync();
        }

        private async Task ExcluirGruposSelecionadosAsync()
        {
            try
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir o(s) Grupo(s) selecionado(s)?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;
                this.InitializeDB();
                foreach (string nomeGrupo in this.clbGrupoDeContado.CheckedItems)
                {
                    string queryGetGroupId = "SELECT IdGrupo FROM GruposContatos WHERE NomeGrupo = @NomeGrupo AND IdCredencial = @IdCredencial";
                    int idGrupo;
                    using (MySqlCommand command = new MySqlCommand(queryGetGroupId, this.connection))
                    {
                        command.Parameters.AddWithValue("@NomeGrupo", (object)nomeGrupo);
                        command.Parameters.AddWithValue("@IdCredencial", (object)this.idCredencial);
                        object obj = await command.ExecuteScalarAsync();
                        idGrupo = Convert.ToInt32(obj);
                        obj = (object)null;
                    }
                    string queryDeleteContatos = "DELETE FROM Contatos WHERE IdGrupo = @IdGrupo";
                    using (MySqlCommand command = new MySqlCommand(queryDeleteContatos, this.connection))
                    {
                        command.Parameters.AddWithValue("@IdGrupo", (object)idGrupo);
                        int num = await command.ExecuteNonQueryAsync();
                    }
                    string queryDeleteGrupo = "DELETE FROM GruposContatos WHERE IdGrupo = @IdGrupo";
                    using (MySqlCommand command = new MySqlCommand(queryDeleteGrupo, this.connection))
                    {
                        command.Parameters.AddWithValue("@IdGrupo", (object)idGrupo);
                        int num = await command.ExecuteNonQueryAsync();
                    }
                    int num1 = (int)MessageBox.Show("Grupo '" + nomeGrupo + "' e todos os contatos associados foram excluídos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    queryGetGroupId = (string)null;
                    queryDeleteContatos = (string)null;
                    queryDeleteGrupo = (string)null;
                }
                await this.PreencherCheckListBoxComGruposAsync();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao excluir grupos selecionados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cbAddImagem_Click(object sender, EventArgs e)
        {
            try
            {
                DadosImagemAnexo dadosImagemAnexo = this.AnexarImagemMedia();
                if (dadosImagemAnexo.Base64Image != null)
                {
                    string str = this.FormatFileSize(new FileInfo(dadosImagemAnexo.ImagePath).Length);
                    System.Windows.Forms.Label labelCampoMensagemUp = this.LabelCampoMensagemUp;
                    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
                    interpolatedStringHandler.AppendLiteral("Mensagem com Anexo:   >>>   ");
                    interpolatedStringHandler.AppendFormatted(dadosImagemAnexo.NameFile);
                    interpolatedStringHandler.AppendLiteral(" (");
                    interpolatedStringHandler.AppendFormatted(str);
                    interpolatedStringHandler.AppendLiteral(")");
                    string stringAndClear = interpolatedStringHandler.ToStringAndClear();
                    labelCampoMensagemUp.Text = stringAndClear;
                    this.pbAnexado.Visible = true;
                }
                else
                {
                    this.LabelCampoMensagemUp.Text = "Mensagem:";
                    this.pbAnexado.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DadosImagemAnexo AnexarImagemMedia()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.imagemEmAnexo.ImagePath = openFileDialog.FileName;
                        this.imagemEmAnexo.ImageBytes = File.ReadAllBytes(this.imagemEmAnexo.ImagePath);
                        this.imagemEmAnexo.Base64Image = Convert.ToBase64String(this.imagemEmAnexo.ImageBytes);
                        this.imagemEmAnexo.NameFile = openFileDialog.SafeFileName.ToString();
                    }
                }
                return this.imagemEmAnexo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string FormatFileSize(long fileSizeInBytes)
        {
            double num1 = (double)fileSizeInBytes;
            if (num1 >= 1024.0)
            {
                double num2 = num1 / 1024.0;
                if (num2 >= 1024.0)
                {
                    double num3 = num2 / 1024.0;
                    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
                    interpolatedStringHandler.AppendFormatted<double>(num3, "N1");
                    interpolatedStringHandler.AppendLiteral(" MB");
                    return interpolatedStringHandler.ToStringAndClear();
                }
                DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(3, 1);
                interpolatedStringHandler1.AppendFormatted<double>(num2, "N1");
                interpolatedStringHandler1.AppendLiteral(" KB");
                return interpolatedStringHandler1.ToStringAndClear();
            }
            DefaultInterpolatedStringHandler interpolatedStringHandler2 = new DefaultInterpolatedStringHandler(6, 1);
            interpolatedStringHandler2.AppendFormatted<double>(num1);
            interpolatedStringHandler2.AppendLiteral(" bytes");
            return interpolatedStringHandler2.ToStringAndClear();
        }

        private void ExcluirImagem()
        {
            try
            {
                if (this.imagemEmAnexo == null)
                    return;
                this.imagemEmAnexo.ImagePath = (string)null;
                this.imagemEmAnexo.ImageBytes = (byte[])null;
                this.imagemEmAnexo.Base64Image = (string)null;
                this.imagemEmAnexo.NameFile = (string)null;
                this.pbAnexado.Visible = false;
                this.LabelCampoMensagemUp.Text = "Mensagem:";
                this.pbQrCode.Visible = false;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Erro ao excluir imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void AcrescentarStringEmLinhaEspecifica(
          System.Windows.Forms.ListBox listBox1,
          string novaString,
          int indexLinha)
        {
            try
            {
                if (indexLinha >= 0 && indexLinha <= listBox1.Items.Count)
                {
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.BeginInvoke((Delegate)(() =>
                        {
                            this.labelProcessandoMsg.Visible = true;
                            if (indexLinha == this.listView.Items.Count || string.IsNullOrEmpty(this.listView.Items[indexLinha]?.ToString()))
                                this.listView.Items.Insert(indexLinha, novaString);
                            else
                                listBox1.Items[indexLinha] = (object)(listBox1.Items[indexLinha].ToString() + " " + novaString);
                        }));
                    }
                    else
                    {
                        this.labelProcessandoMsg.Visible = true;
                        if (indexLinha == listBox1.Items.Count || string.IsNullOrEmpty(listBox1.Items[indexLinha]?.ToString()))
                        {
                            listBox1.Items.Insert(indexLinha, (object)novaString);
                        }
                        else
                        {
                            string str = listBox1.Items[indexLinha].ToString() + " " + novaString;
                            listBox1.Items[indexLinha] = (object)str;
                        }
                    }
                }
                else
                {
                    int num = (int)MessageBox.Show("Índice de linha especificado é inválido.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void pbAnexado_MouseEnter(object sender, EventArgs e)
        {
            this.pbAnexado.Image = (Image)Resources.Excluir;
        }

        private void pbAnexado_MouseLeave(object sender, EventArgs e)
        {
            this.pbAnexado.Image = (Image)Resources.Anexo;
        }

        private void pbAnexado_Click(object sender, EventArgs e) => this.ExcluirImagem();

        private void labelResponse_TextChanged(object sender, EventArgs e)
        {
            if (this.labelResponse.Text.Contains("Aguardando") || this.labelResponse.Text.Contains("Processando"))
            {
                this.pbAguarde.Image = (Image)Resources.Aguarde;
                this.pbAguarde.Visible = true;
            }
            else
            {
                this.pbAguarde.Image = (Image)Resources.CodeCraft;
                this.pbAguarde.Visible = true;
            }
        }

        private void tbNomeContato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            this.cbAddContato_Click(sender, (EventArgs)e);
        }

        private async void cbImportarContatosDeArquivos_ClickAsync(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "Selecione um arquivo do Excel";
            string importResult = "Contatos Não Importados: ";
            Processando();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                    Sheet sheet = workbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                    WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
                    bool primeiraLinha = true; // Variável para controlar se é a primeira linha do arquivo

                    OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
                    while (reader.Read())
                    {
                        if (reader.ElementType == typeof(Row))
                        {
                            Row row = (Row)reader.LoadCurrentElement();
                            if (primeiraLinha)
                            {
                                primeiraLinha = false;
                                continue;
                            }
                            Cell? cell = row.GetFirstChild<Cell>();
                            Cell? cell2 = row.Elements<Cell>().ElementAtOrDefault(1);
                            Cell? cell3 = row.Elements<Cell>().ElementAtOrDefault(4);
                            Cell? cell6 = row.Elements<Cell>().ElementAtOrDefault(6);
                            Cell? cell7 = row.Elements<Cell>().ElementAtOrDefault(7);
                            Cell? cell8 = row.Elements<Cell>().ElementAtOrDefault(8);
                            Cell? cell9 = row.Elements<Cell>().ElementAtOrDefault(9);
                        

                            // Verifica se a célula não é nula e se contém um valor
                            if (cell != null && cell.CellValue != null)
                            {
                                string? value = cell.CellValue.InnerText;
                                string? value2 = cell2.CellValue.InnerText;
                                string? value3 = cell3.CellValue.InnerText;
                                //string? value6 = cell6.CellValue.InnerText;
                                //string? value7 = cell7.CellValue.InnerText;
                                //string? value8 = cell8.CellValue.InnerText;
                                //string? value9 = cell9.CellValue.InnerText;

                                // Extrai somente os números do valor da célula
                                string numericValue = new string(value.Where(char.IsDigit).ToArray());
                                string contatoNome;

                                try
                                {
                                    contatoNome = value2.Substring(0, value2.IndexOf("- ")) + value3;
                                }
                                catch
                                {

                                    contatoNome = value2;
                                }
                                

                                string contatoWhatsapp;
                                if (numericValue != null && Regex.IsMatch(numericValue, @"^\d+$") && numericValue != "")
                                {
                                    contatoWhatsapp = await FormatarNumeroWhatsApp(numericValue);
                                    if (contatoWhatsapp != null)
                                    {
                                        clbContatos.Items.Add((object)(contatoWhatsapp + "; " + contatoNome), true);
                                        clbContatos.TopIndex = clbContatos.Items.Count - 1;
                                        labelContCheckBox.Text = clbContatos.Items.Count.ToString();
                                        foreach (object item in (System.Windows.Forms.ListBox.ObjectCollection)this.clbContatos.Items)
                                        {
                                            this.tbNomeContato.Clear();
                                            this.tbNumeroContato.Clear();
                                            this.tbNumeroContato.Focus();
                                        }
                                        
                                    }
                                    else
                                    {
                                        importResult += $"\n{contatoNome} Sem Whatsapp";
                                    }
                                    
                                }
                                else
                                {
                                    importResult += $"\n{contatoNome} Sem Whatsapp";
                                }
                                contatoWhatsapp = (string)null;



                            }
                        }
                    }
                    labelResponse.Text = ("Concluido");
                    int num = (int)MessageBox.Show(importResult,"Importados" , MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

    }
}