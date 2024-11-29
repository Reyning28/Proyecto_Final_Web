// Interfaz que define los métodos para el servicio de agentes
using Digesett.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Digesett.Services
{
    public interface IAgentService
    {
        // Método para autenticar a un agente basado en su cédula y contraseña
        Task<Agent> LoginAsync(string cedula, string password);

        // Método para obtener las multas asociadas a un agente
        Task<List<Fine>> GetAgentFinesAsync(string agentId);

        // Método para obtener una multa por su identificador
        Task<Fine> GetFineByIdAsync(string id);

        // Método para crear una nueva multa
        Task<Fine> CreateFineAsync(Fine fine);

        // Método para calcular la comisión mensual de un agente
        Task<decimal> GetMonthlyCommissionAsync(string agentId);

        // Método para subir una foto asociada a una multa
        Task<string> UploadPhotoAsync(IBrowserFile file);

        // Métodos para gestionar conceptos de multas
        Task<List<string>> GetConceptosAsync();
        Task AddConceptoAsync(string concepto);
        Task DeleteConceptoAsync(string concepto);
    }
}
