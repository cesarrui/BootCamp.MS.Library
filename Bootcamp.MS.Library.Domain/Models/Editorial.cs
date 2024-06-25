using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain.Models
{
    public class Editorial
    {
        [JsonProperty("idEditorial")]
        public Guid? IdEditorial { get; set; }

        [JsonProperty("nombre")]
        public string? Nombre { get; set; }
    }
}
