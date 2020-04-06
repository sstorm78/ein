using System.Linq;

namespace Eintech.Website.Extensions
{
    public static class UserModelExtensions
    {
        public static UiModels.User ToUiModel(this Models.User user)
        {
            return new UiModels.User
                   {
                       Id = user.Id,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       Groups = user.Groups.Select(GroupModelExtensions.ToUiModel).ToList()
                   };
        }
    }
}
