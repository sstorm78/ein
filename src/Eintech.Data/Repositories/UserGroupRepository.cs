using System.Threading.Tasks;

namespace Eintech.Data.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly IEintechDbContext _dbContext;

        public UserGroupRepository(IEintechDbContext eintechDbContext)
        {
            _dbContext = eintechDbContext;
        }

        public async Task<int> Create(Entities.UserGroup userGroup)
        {
            _dbContext.UserGroups.Add(userGroup);
            await _dbContext.SaveChangesAsync();
            return userGroup.Id;
        }
    }
}
