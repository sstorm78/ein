using System.Threading.Tasks;
using Eintech.Data.Repositories;

namespace Eintech.Services
{
    public class UserGroupService : IUserGroupService
    {
        public readonly IUserGroupRepository _userGroupRepository;

        public UserGroupService(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        public Task AssociateUserToGroup(Data.Entities.UserGroup userGroup)
        {
            return _userGroupRepository.Create(userGroup);
        }
    }
}
