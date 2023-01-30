using System.ComponentModel.DataAnnotations;

namespace AplicacionPatronDiseno_AaronZumarraga.Models
{
    public class Bridge
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Apellido { get; set; }

        [Range(0.01, 9999.99)]
        public decimal Edad { get; set; }

    }
}
