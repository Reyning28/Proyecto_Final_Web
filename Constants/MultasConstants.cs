// Clase que contiene constantes relacionadas con las multas
namespace Digesett.Constants
{
    public static class FineConstants
    {
        // Lista de conceptos de multas posibles
        public static readonly List<string> Concepts = new()
        {
            "Exceso de velocidad",
            "Semáforo en rojo",
            "Estacionamiento prohibido",
            "Sin cinturón de seguridad",
            "Uso del celular mientras conduce",
            "Documentos vencidos",
            "Sin seguro obligatorio",
            "Conducir en estado de ebriedad"
        };

        // Diccionario que relaciona el estado de la multa con una clase CSS
        public static readonly Dictionary<string, string> StatusClasses = new()
        {
            ["Active"] = "badge-success",
            ["Paid"] = "badge-primary",
            ["Forgiven"] = "badge-secondary"
        };
    }
}