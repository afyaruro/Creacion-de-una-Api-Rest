
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class PersonaAfiliacionContext: DbContext
    {
        public PersonaAfiliacionContext(DbContextOptions options) : base(options)
        {   

        }
        public DbSet<Persona> personas { get; set; }
    }
}