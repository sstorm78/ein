using System;
using Eintech.Data.Entities;

namespace Eintech.Services.Extensions
{
    public static class UserModelExtensions
    {
        public static User ToEntity(this Models.User user)
        {
            return new User
                   {
                       DateAdded = DateTime.UtcNow,
                       FirstName = user.FirstName,
                       LastName = user.LastName
                   };
        }
    }
}
