using Microsoft.EntityFrameworkCore;
using FarmApi.Models;

namespace FarmApi.Models
{
    public class FarmContext : DbContext
    {
        public FarmContext(DbContextOptions<FarmContext> options) : base(options) { }
        public DbSet<Grower> Growers { get; set; }
        public DbSet<Field> Fields { get; set; }

        public class Grower
        {
            public Guid GrowerID { get; set; }
            public string GrowerName { get; set; }
            public List<Field> Fields { get; set; }
        }

        public class Field
        {
            public Guid FieldID { get; set; }
            public string FieldName { get; set; }
            public Guid GrowerID { get; set; } 
        }
      
    }
}
