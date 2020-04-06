using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eintech.Data.Entities
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
