using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fiap.Persistencia.Final.Core.Models
{
    public class Eventos
    {
        [Key]
        public int IdEvento { get; set; }

        public string NomeEvento { get; set; }

        public DateTime DataEvento { get; set; }

        public string Localizacao { get; set; }

        public string Observacao { get; set; }

        public Versao Versao { get; set; }
    }
}
