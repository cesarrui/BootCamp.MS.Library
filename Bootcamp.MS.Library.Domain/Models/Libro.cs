using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain.Models
{
    public class Libro
    {
        [JsonProperty("idLibro")]  
        public Guid? IdLibro { get; set; }

        [JsonProperty("nombre")]
        public string? Nombre { get; set; }

        [JsonProperty("idCategoria")]
        public Guid? IdCategoria { get; set; }

        public string? nombreCategoria { get; set; }

        [JsonProperty("idAutor")]
        public Guid? IdAutor { get; set; }

        public string? nombreAutor { get; set; }

        [JsonProperty("idEditorial")]
        public Guid? IdEditorial { get; set; }

        public string? nombreEditorial { get; set; }

    }
}
