using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            public DbSet<EscuelaModel> Escuelas { get; set; }
            public DbSet<ProfesoresModel> Profesores { get; set; }
            public DbSet<EstudianteModel> Estudiantes { get; set; }
            public DbSet<AlumnoEscuelaModel> AlumnoEscuelas { get; set; }
            public DbSet<ProfesorAlumnoModel> ProfesorAlumnos { get; set; }
    }
}
