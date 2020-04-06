using System.Threading.Tasks;

namespace Eintech.Data.Repositories
{
    public interface IUserGroupRepository
    {
        Task<int> Create(Entities.UserGroup userGroup);
    }
}