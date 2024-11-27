using Digesett.Models;
using Microsoft.EntityFrameworkCore;

namespace Digesett.Data
{
    // Clase que representa el contexto de base de datos para Digesett
    public class DigesettDbContext : DbContext
    {
        // Constructor que permite configurar las opciones del contexto de base de datos
        public DigesettDbContext(DbContextOptions<DigesettDbContext> options)
            : base(options)
        {
        }

        // Conjunto de datos que representa los agentes
        public DbSet<Agent> Agents { get; set; }

        // Conjunto de datos que representa las multas
        public DbSet<Fine> Fines { get; set; }

        // Método para configurar los modelos durante la creación del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para la entidad Agent
            modelBuilder.Entity<Agent>()
                .HasKey(a => a.Id);  // Define la clave primaria de la entidad

            modelBuilder.Entity<Agent>()
                .HasIndex(a => a.Cedula)  // Define un índice único para la cédula del agente
                .IsUnique();

            // Configuración para la entidad Fine
            modelBuilder.Entity<Fine>()
                .HasKey(f => f.Id);  // Define la clave primaria de la entidad

            // Relación entre la entidad Fine y Agent
            modelBuilder.Entity<Fine>()
                .HasOne<Agent>()  // Define que Fine tiene una relación con Agent
                .WithMany()  // Un agente puede tener muchas multas
                .HasForeignKey(f => f.AgentId)  // Clave foránea para la relación
                .OnDelete(DeleteBehavior.Restrict);  // Restricción de eliminación para evitar borrados en cascada

            // Datos de prueba para el agente
            modelBuilder.Entity<Agent>().HasData(
                new Agent
                {
                    Id = "1",
                    Cedula = "001-0000000-0",
                    Name = "Agente Demo",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456") // Contraseña hasheada para mayor seguridad
                }
            );
        }
    }
}
