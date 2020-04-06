using Eintech.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Eintech.Data
{
    public interface IEintechDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<UserGroup> UserGroups { get; set; }
        void SetEntryState(object entity, EntityState state);

        Task<int> SaveChangesAsync();

    }
}