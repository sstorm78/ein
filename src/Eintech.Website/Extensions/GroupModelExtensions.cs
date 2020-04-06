using Eintech.Website.UiModels;

namespace Eintech.Website.Extensions
{
    public static class GroupModelExtensions
    {
        public static Group ToUiModel(this Models.Group group)
        {
            return new Group
                   {
                       Id = group.Id,
                       Name = group.Name
                   };
        }
    }
}
