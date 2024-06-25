using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain.Models
{
    public class Categoria
    {
        [JsonProperty("idCategoria")]
        public Guid? IdCategoria { get; set; }

        [JsonProperty("nombre")]
        public string? Nombre { get; set; }
    }
}
