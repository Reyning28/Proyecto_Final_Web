// Servicio que gestiona las operaciones relacionadas con los agentes
using Digesett.Models;
using Digesett.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;







namespace Digesett.Services
{
    public class AgentService  : IAgentService
    {
        private readonly DigesettDbContext _context;
        private readonly ILogger<AgentService> _logger;
        private readonly IWebHostEnvironment _environment;

        // Constructor que inicializa el contexto de base de datos y el entorno del host web
        public AgentService(DigesettDbContext context, ILogger<AgentService> logger, IWebHostEnvironment environment)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

       public async Task<List<Fine>> GetFinesByAgentId(string agentId)
    {
        return await _context.Fines
            .Where(f => f.AgentId == agentId)
            .ToListAsync();
    }

    public async Task UpdateFineStatus(string fineId, string newStatus)
    {
        var fine = await _context.Fines.FirstOrDefaultAsync(f => f.Id == fineId);
        if (fine != null)
        {
            fine.Status = newStatus;
            _context.Fines.Update(fine);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Fine>> SearchFines(string agentId, string searchTerm)
    {
        return await _context.Fines
            .Where(f => f.AgentId == agentId && 
                        (f.CitizenName.Contains(searchTerm) || f.CitizenCedula.Contains(searchTerm)))
            .ToListAsync();
    }

        // Método para autenticar a un agente basado en su cédula y contraseña
        public async Task<Agent> LoginAsync(string cedula, string password)
        {
            var agent = await _context.Agents
                .FirstOrDefaultAsync(a => a.Cedula == cedula && a.IsActive);

            if (agent == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password, agent.Password))
                return null;

            return agent;
        }

        // Método para autenticar a un agente basado en su nombre y contraseña
        public async Task<Agent> LoginAsyncSuperUser(string name, string password)
        {
            var agent = await _context.Agents
                .FirstOrDefaultAsync(a => a.Name == name && a.IsActive);

            if (agent == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password, agent.Password))
                return null;

            return agent;
        }

        // Método para obtener las multas asociadas a un agente
        public async Task<List<Fine>> GetAgentFinesAsync(string agentId)
        {
            return await _context.Fines
                .Where(f => f.AgentId == agentId)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        // Método para crear una nueva multa
        public async Task<Fine> CreateFineAsync(Fine fine)
        {
            fine.Id = Guid.NewGuid().ToString();
            fine.CreatedAt = DateTime.UtcNow;
            fine.Status = "Active";

            _context.Fines.Add(fine);
            await _context.SaveChangesAsync();

            return fine;
        }

        // Método para calcular la comisión mensual de un agente
        public async Task<decimal> GetMonthlyCommissionAsync(string agentId)
        {
            var startOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            return await _context.Fines
                .Where(f => f.AgentId == agentId &&
                           f.CreatedAt >= startOfMonth &&
                           f.CreatedAt <= endOfMonth &&
                           f.Status != "Forgiven")
                .SumAsync(f => f.Amount * 0.10m);
        }

        // Método para obtener una multa por su identificador
        public async Task<Fine> GetFineByIdAsync(string id)
        {
            return await _context.Fines
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        // Método para subir una foto asociada a una multa
        public async Task<string> UploadPhotoAsync(IBrowserFile file)
        {
            if (file == null) return null;

            // Crear directorio si no existe
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generar nombre único para el archivo
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Guardar archivo
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream(maxAllowedSize: 10485760).CopyToAsync(stream); // 10MB max

            // Retornar ruta relativa
            return $"/uploads/{fileName}";
        }

        // Método para agregar un nuevo concepto de multa
        public async Task AddConceptoAsync(string concepto)
        {
            if (!_context.ConceptosMultas.Any(c => c.Concept == concepto))
            {
                var newConcepto = new ConceptoMulta { Concept = concepto };
                _context.ConceptosMultas.Add(newConcepto);
                await _context.SaveChangesAsync();
            }
        }

        // Método para obtener los conceptos de multas
        public async Task<List<string>> GetConceptosAsync()
        {
            return await _context.ConceptosMultas
                .Select(c => c.Concept)
                .Distinct()
                .ToListAsync();
        }

        // Método para eliminar un concepto de multa
        public async Task DeleteConceptoAsync(string concepto)
        {
            var conceptoToDelete = await _context.ConceptosMultas.FirstOrDefaultAsync(c => c.Concept == concepto);
            if (conceptoToDelete != null)
            {
                _context.ConceptosMultas.Remove(conceptoToDelete);
                await _context.SaveChangesAsync();
            }
        }

        // Obtener multas de un agente filtradas por mes y año
        public async Task<List<Fine>> GetAgentFinesByMonthAndYearAsync(string agentId, int month, int year)
        {
            try
            {
                _logger.LogInformation($"Buscando multas para el agente {agentId} en {month}/{year}");

                // Calcular el primer y último día del mes
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                // Obtener las multas que coincidan con el mes y año especificados
                var multas = await _context.Fines
                    .Where(f => f.AgentId == agentId &&
                               f.CreatedAt >= startDate &&
                               f.CreatedAt <= endDate)
                    .OrderByDescending(f => f.CreatedAt)
                    .ToListAsync();

                _logger.LogInformation($"Se encontraron {multas.Count} multas para el período especificado");
                return multas;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener multas del agente {agentId} para {month}/{year}");
                throw;
            }
        }

        // Método para crear un nuevo agente
        public async Task<Agent> CreateAgentAsync(Agent agent)
        {
            try
            {
                _logger.LogInformation($"Creando nuevo agente con cédula: {agent.Cedula}");

                // Verificar si ya existe un agente con la misma cédula
                var existingAgent = await _context.Agents
                    .FirstOrDefaultAsync(a => a.Cedula == agent.Cedula);

                if (existingAgent != null)
                {
                    throw new InvalidOperationException("Ya existe un agente con esta cédula");
                }

                // Hash de la contraseña antes de guardarla
                agent.Password = BCrypt.Net.BCrypt.HashPassword(agent.Password);

                // Asignar valores por defecto
                agent.Id = Guid.NewGuid().ToString();
                agent.CreatedAt = DateTime.UtcNow;
                agent.IsActive = true;

                // Agregar el agente a la base de datos
                await _context.Agents.AddAsync(agent);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Agente creado exitosamente con ID: {agent.Id}");
                return agent;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear agente");
                throw;
            }
        }

        // Método para obtener todos los agentes
        public async Task<List<Agent>> GetAllAgentsAsync()
        {
            try
            {
                return await _context.Agents
                    .OrderByDescending(a => a.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de agentes");
                throw;
            }
        }

        // Método para eliminar un agente
        public async Task DeleteAgentAsync(string agentId)
        {
            try
            {
                _logger.LogInformation($"Eliminando agente con ID: {agentId}");

                var agent = await _context.Agents.FindAsync(agentId);
                if (agent == null)
                {
                    throw new InvalidOperationException("Agente no encontrado");
                }

                // Verificar si el agente tiene multas asociadas
                var hasFines = await _context.Fines.AnyAsync(f => f.AgentId == agentId);
                if (hasFines)
                {
                    // En lugar de eliminar, marcar como inactivo
                    agent.IsActive = false;
                    _context.Agents.Update(agent);
                }
                else
                {
                    // Si no tiene multas, eliminar completamente
                    _context.Agents.Remove(agent);
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation($"Agente {(hasFines ? "desactivado" : "eliminado")} exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar agente {agentId}");
                throw;
            }
        }
    }
}