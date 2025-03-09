using Microsoft.EntityFrameworkCore;

namespace PracticaJoel.AppMVCCodeFirst.Models
{
    public class EmpleadoAlumnoDbContext : DbContext
    {
        public EmpleadoAlumnoDbContext(DbContextOptions<EmpleadoAlumnoDbContext> options) : base(options) { }

        public DbSet<Empleado> empleados { get; set; }

        public DbSet<Alumno> alumnoes { get; set; }
    }
}
