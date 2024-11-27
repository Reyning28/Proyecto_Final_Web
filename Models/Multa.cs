// Importación de bibliotecas necesarias
using System.ComponentModel.DataAnnotations;

namespace Digesett.Models
{
    // Clase que representa una multa
    public class Fine
    {
        // Identificador único para la multa, generado automáticamente
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Cédula del ciudadano, es obligatoria y debe tener máximo 13 caracteres
        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(13, ErrorMessage = "La cédula debe tener máximo 13 caracteres")]
        public string CitizenCedula { get; set; }

        // Nombre del ciudadano, es obligatorio
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string CitizenName { get; set; }

        // Latitud de la ubicación de la multa, es obligatoria
        [Required(ErrorMessage = "La Latitud es obligatoria")]
        public double Latitude { get; set; }

        // Longitud de la ubicación de la multa, es obligatoria
        [Required(ErrorMessage = "La Longitud es obligatoria")]
        public double Longitude { get; set; }

        // Concepto de la multa, es obligatorio
        [Required(ErrorMessage = "El concepto es obligatorio")]
        public string Concept { get; set; }

        // Descripción detallada de la multa, es obligatoria
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; set; }

        // Monto de la multa, es obligatorio y debe ser mayor que 0
        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0")]
        public decimal Amount { get; set; }

        // URL de la foto de la multa, se inicializa con una cadena vacía
        public string PhotoUrl { get; set; } = string.Empty;

        // Fecha de creación de la multa, se establece a la fecha y hora actuales por defecto
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Estado de la multa, por defecto se establece como "Activo"
        public string Status { get; set; } = "Active";

        // Identificador del agente que emitió la multa
        public string AgentId { get; set; }
    }
}