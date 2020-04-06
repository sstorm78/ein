using System;
using System.Threading.Tasks;
using Eintech.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eintech.Data
{
    public class EintechDbContext : DbContext, IEintechDbContext
    {
        private readonly string _connectionString;

        public EintechDbContext(Models.IConfig config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));

            this._connectionString = config.DbConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        public virtual void SetEntryState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        public virtual Task<int> SaveChangesAsync() => base.SaveChangesAsync();

    }
}
