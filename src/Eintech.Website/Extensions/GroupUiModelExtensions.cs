namespace Eintech.Website.Extensions
{
    public static class GroupUiModelExtensions
    {
        public static Models.Group ToModel(this UiModels.Group group)
        {
            return new Models.Group(group.Id, group.Name);
        }
    }
}
