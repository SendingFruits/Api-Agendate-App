﻿namespace Api_Agendate_App.Models
{
    public class ClienteDTO : UsuarioDTO
    {
        public string documento { get; set; }

        public byte[] foto { get; set; }
    }
}