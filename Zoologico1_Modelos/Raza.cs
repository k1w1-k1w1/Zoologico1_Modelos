using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zoologico1_Modelos
{
    public class Raza
    {
        [Key] public int Id { get; set; }
        public string NombreRaza { get; set; }

        // navegacion
        [JsonIgnore]
        public List<Animal>? Animales { get; set; }

    }
}
