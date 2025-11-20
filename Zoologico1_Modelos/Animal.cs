using System.ComponentModel.DataAnnotations;

namespace Zoologico1_Modelos
{
    public class Animal
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }

        //fk
        public int EspecieId { get; set; }
        public int RazaId { get; set; }

        // navegacion
        public Especie? Especie { get; set; }
        public Raza? Raza { get; set; }

    }
}
