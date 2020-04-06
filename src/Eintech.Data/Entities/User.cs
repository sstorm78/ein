using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eintech.Data.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateAdded { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
