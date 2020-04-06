using System.Threading.Tasks;

namespace Eintech.Data.Repositories
{
    public interface IGroupRepository
    {
        Task<int> Create(Entities.Group group);
    }
}