using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SisHotel.Models
{
    public class Hotel
    {

        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int avaliacao { get; set; }
        public string TipoComodidade { get; set; }
        public int ativo { get; set; }

            public string Logradouro { get; set; }
            public int Numero { get; set; }
            public string Complemento { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
    }
}
