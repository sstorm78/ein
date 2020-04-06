using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eintech.Services
{
    public interface IUserService
    {
        Task<int> Create(Models.User user);

        Task<List<Models.User>> Search(string keywords);
    }
}