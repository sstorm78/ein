using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eintech.Data;
using Eintech.Data.Entities;
using Eintech.Services.Extensions;

namespace Eintech.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserGroupService _userGroupService;

        public UserService(IUserRepository userRepository, IUserGroupService userGroupService)
        {
            _userRepository = userRepository;
            _userGroupService = userGroupService;
        }

        public async Task<int> Create(Models.User user)
        {
            var userEntity = user.ToEntity();

            var newUserId = await _userRepository.Create(userEntity);

            foreach (var group in user.Groups)
            {
                var userGroup = new UserGroup
                                {
                                    GroupId = group.Id,
                                    UserId = newUserId,
                                    DateAdded = DateTime.UtcNow
                                };

                await _userGroupService.AssociateUserToGroup(userGroup);
            }

            return newUserId;
        }

        public async Task<List<Models.User>> Search(string keyword)
        {
            var result = await _userRepository.Search(keyword);

            return result.Select(UserEntityExtensions.ToModel).ToList();
        }

    }
}
