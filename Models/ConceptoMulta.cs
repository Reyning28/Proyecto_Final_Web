using System.ComponentModel.DataAnnotations;

namespace Digesett.Models
{
    public class ConceptoMulta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El concepto es obligatorio")]
        public string Concept { get; set; }
    }
}
