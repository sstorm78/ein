using Eintech.Models;

namespace Eintech.Services.Extensions
{
    public static class UserGroupEntityExtensions
    {
        public static Group ToGroupModel(this Data.Entities.UserGroup userGroup)
        {
            return new Group(userGroup.Group.Id, userGroup.Group.Name, userGroup.Group.DateAdded);
        }
    }
}
