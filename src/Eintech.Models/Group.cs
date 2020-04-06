using System;

namespace Eintech.Models
{
    public class Group
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime DateAdded { get; }
        
        public Group(int id, string name)
        {
            Id = id;
            Name = name;
            DateAdded = DateTime.UtcNow;
        }

        public Group(int id, string name, DateTime dateAdded)
        {
            Id = id;
            Name = name;
            DateAdded = dateAdded;
        }
    }
}
