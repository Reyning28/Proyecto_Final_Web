// Servicio que gestiona las operaciones relacionadas con los agentes
using Digesett.Models;
using Digesett.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

namespace Digesett.Services
{
    public class AgentService : IAgentService
    {
        private readonly DigesettDbContext _context;
        private readonly IWebHostEnvironment _environment;

        // Constructor que inicializa el contexto de base de datos y el entorno del host web
        public AgentService(DigesettDbContext context, IWebHostEnvironment environment)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
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
    }
}