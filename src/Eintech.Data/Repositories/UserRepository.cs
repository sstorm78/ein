using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Eintech.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IEintechDbContext _dbContext;

        public UserRepository(IEintechDbContext eintechDbContext)
        {
            _dbContext = eintechDbContext;
        }

        public async Task<int> Create(Entities.User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<IEnumerable<Entities.User>> Search(string keyword)
        {
            return await _dbContext
                .Users
                .Include(i => i.UserGroups)
                .ThenInclude(g => g.Group)
                .Where(i => i.FirstName.Contains(keyword)
                            || i.LastName.Contains(keyword)
                            || i.UserGroups.Where(o => o.Group.Name.Contains(keyword)).Any())
                .ToArrayAsync();
        }
    }
}
