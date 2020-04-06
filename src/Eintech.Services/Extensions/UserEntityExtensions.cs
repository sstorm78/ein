using System.Linq;
using Eintech.Models;

namespace Eintech.Services.Extensions
{
    public static class UserEntityExtensions
    {
        public static User ToModel(this Data.Entities.User userEntity)
        {
            var groups = userEntity.UserGroups.Select(UserGroupEntityExtensions.ToGroupModel).ToList();
            
            return new User(userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.DateAdded, groups);
        }
    }
}
