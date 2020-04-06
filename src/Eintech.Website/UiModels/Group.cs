using System.ComponentModel.DataAnnotations;

namespace Eintech.Website.UiModels
{
    public class Group
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; }
    }
}
