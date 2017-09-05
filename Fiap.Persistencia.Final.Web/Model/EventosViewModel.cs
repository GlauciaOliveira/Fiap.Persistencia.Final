using Fiap.Persistencia.Final.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Persistencia.Final.Web.Model
{
    public class EventosViewModel
    {
        public int IdEvento { get; set; }

        public string NomeEvento { get; set; }

        public DateTime DataEvento { get; set; }

        public string Localizacao { get; set; }

        public string Observacao { get; set; }

        public int IdVersao { get; set; }

        public ICollection<Versao>ListaVersoes { get; set; }
    }
}
