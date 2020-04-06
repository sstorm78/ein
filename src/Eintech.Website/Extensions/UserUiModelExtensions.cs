using System.Linq;

namespace Eintech.Website.Extensions
{
    public static class UserUiModelExtensions
    {
        public static Models.User ToModel(this UiModels.User user)
        {
            return new Models.User(user.FirstName, user.LastName, user.Groups.Select(GroupUiModelExtensions.ToModel).ToList());
        }
    }
}
