using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eintech.Data
{
    public interface IUserRepository
    {
        Task<int> Create(Entities.User user);
        Task<IEnumerable<Entities.User>> Search(string keyword);
    }
}