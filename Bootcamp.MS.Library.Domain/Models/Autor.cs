using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain.Models
{
    public class Autor
    {
        [JsonProperty("idAutor")]
        public Guid? IdAutor { get; set; }

        [JsonProperty("nombre")]
        public string? Nombre { get; set; }
    }
}
