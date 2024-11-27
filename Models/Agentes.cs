namespace Digesett.Models
{
    // Clase que representa un agente
    public class Agent
    {
        // Identificador único para el agente, generado automáticamente
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Cédula del agente
        public string Cedula { get; set; } = string.Empty;

        // Nombre del agente
        public string Name { get; set; } = string.Empty;

        // Contraseña del agente (se recomienda almacenar de forma segura, como un hash)
        public string Password { get; set; } = string.Empty;

        // Fecha de creación del agente, se establece a la fecha y hora actuales por defecto
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Estado del agente, indica si está activo o no
        public bool IsActive { get; set; } = true;
    }
}