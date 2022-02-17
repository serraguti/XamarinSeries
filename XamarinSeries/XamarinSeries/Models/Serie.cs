using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSeries.Models
{
    public class Serie
    {
        [JsonProperty("idSerie")]
        public int IdSerie { get; set; }
        [JsonProperty("nombreSerie")]
        public String NombreSerie { get; set; }
        [JsonProperty("imagen")]
        public String Imagen { get; set; }
        [JsonProperty("anyo")]
        public int Anyo { get; set; }
    }
}
