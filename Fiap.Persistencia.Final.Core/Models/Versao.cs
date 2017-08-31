using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fiap.Persistencia.Final.Core.Models
{
    public class Versao
    {

        [Key]
        public int IdVersao { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public string DataAtualizacao { get; set; }
    }
}
