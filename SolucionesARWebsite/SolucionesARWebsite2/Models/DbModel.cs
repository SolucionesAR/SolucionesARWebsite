using System.Data.Entity;

namespace SolucionesARWebsite2.Models
{
    public class DbModel : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<RelationshipType> RelationshipTypes { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<GlobalParameter> GlobalParameters { get; set; }

        public DbSet<IdentificationType> IdentificationType { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<Canton> Cantons { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<CommissionLog> CommissionsLogs { get; set; }

    }
}