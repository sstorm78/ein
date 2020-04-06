using System.Threading.Tasks;

namespace Eintech.Services
{
    public interface IUserGroupService
    {
        Task AssociateUserToGroup(Data.Entities.UserGroup userGroup);
    }
}