using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zoologico1_Modelos
{
    public class Especie
    {
        [Key] public int Id { get; set; }
        public string NombreEspecie { get; set; }

        // navegation
        [JsonIgnore]
        public List<Animal>? Animales { get; set; }
    }
}
