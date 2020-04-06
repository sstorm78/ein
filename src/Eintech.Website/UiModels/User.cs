using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eintech.Website.UiModels
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "First name length can't be more than 50.")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name length can't be more than 50.")]
        public string LastName { get; set; }

        [Required]
        public List<Group> Groups { get; set; }
    }
}
