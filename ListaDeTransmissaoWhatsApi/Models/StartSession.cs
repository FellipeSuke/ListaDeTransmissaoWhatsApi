﻿using MySqlX.XDevAPI.Common;

namespace ListaDeTransmissaoWhatsApi.Models
{
    internal class StartSession
    {
        public bool Success { get; set; }
        public string? State { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
    }


    internal class DadosDoUsuario
    {
        public string? Numero { get; set; }
        public string? NomeCompleto { get; set; }
        public string? PrimeiroNome { get; set; }
    }

    internal class DadosImagemAnexo
    {
        public string? ImagePath { get; set; }
        public byte[]? ImageBytes { get; set; }
        public string? Base64Image { get; set; }
        public string? NameFile { get; set; }
    }

    public class WhatsNumeroId
    {
        public bool? Success { get; set; }

        public Result? Result { get; set; }

        public string? Error { get; set; }
    }

    public class Result
    {
        public string? Server { get; set; }

        public string? User { get; set; }

        public string? _Serialized { get; set; }
    }
}
