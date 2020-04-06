using System;
using System.Collections.Generic;

namespace Eintech.Models
{
    public class User
    {
        public int Id { get; }
        public string FirstName { get; }

        public string LastName { get; }

        public DateTime DateAdded { get; }
        
        public List<Group> Groups { get; }
        
        public User(int id, string firstName, string lastName, DateTime dateAdded, List<Group> groups)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateAdded = dateAdded;
            Groups = groups;
        }

        public User(string firstName, string lastName, List<Group> groups)
        {
            FirstName = firstName;
            LastName = lastName;
            Groups = groups;
            DateAdded = DateTime.UtcNow;
        }
    }
}
