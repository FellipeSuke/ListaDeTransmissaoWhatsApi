using System.Collections.Generic;

#nullable enable
public class ResponseTranslator
{
    private Dictionary<string, string> translations;

    public ResponseTranslator()
    {
        this.translations = new Dictionary<string, string>()
    {
      {
        "Sessions terminated.",
        "Sessões encerradas."
      },
      {
        "Logged out successfully",
        "Sessão encerrada com sucesso."
      },
      {
        "Forbidden.",
        "Acesso proibido."
      },
      {
        "Invalid API key",
        "Chave de API inválida."
      },
      {
        "Unprocessable Entity.",
        "Entidade não processável."
      },
      {
        "Some server error",
        "Erro no servidor."
      },
      {
        "session_not_found",
        "sessão não localizada."
      },
      {
        "session_connected",
        "sessão conectada."
      },
      {
        "CONNECTED",
        "CONECTADO"
      },
      {
        "Completed",
        "Enviadas com sucesso"
      }
    };
    }

    public string Translate(string englishMessage)
    {
        return this.translations.ContainsKey(englishMessage) ? this.translations[englishMessage] : englishMessage;
    }
}