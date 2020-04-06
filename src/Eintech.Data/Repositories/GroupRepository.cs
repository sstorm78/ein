using System.Threading.Tasks;

namespace Eintech.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IEintechDbContext _dbContext;

        public GroupRepository(IEintechDbContext eintechDbContext)
        {
            _dbContext = eintechDbContext;
        }
        
        public async Task<int> Create(Entities.Group group)
        {
            _dbContext.Groups.Add(group);
            await _dbContext.SaveChangesAsync();
            return group.Id;
        }
    }
}
