// Interfaz que define los métodos para el servicio de agentes
using Digesett.Models;
using Microsoft.AspNetCore.Components.Forms;
using Digesett.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Digesett.Services
{
    public interface IAgentService
    {
        // Método para autenticar a un agente basado en su cédula y contraseña
        Task<Agent> LoginAsync(string cedula, string password);

        // Método para autenticar a un agente basado  nombre y contraseña
        Task<Agent> LoginAsyncSuperUser(string name, string password);

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
        Task<List<Fine>> GetFinesByAgentId(string agentId);

        Task UpdateFineStatus(string fineId, string newStatus);

        Task<List<Fine>> SearchFines(string agentId, string searchTerm);

        Task<List<Fine>> GetAgentFinesByMonthAndYearAsync(string agentId, int month, int year);

        // Métodos para gestión de agentes
        Task<Agent> CreateAgentAsync(Agent agent);
        Task<List<Agent>> GetAllAgentsAsync();
        Task DeleteAgentAsync(string agentId);
    }
}
