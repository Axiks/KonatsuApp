using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Konatsu.API.Entities
{
    public class UserEntity: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public DateTime BirthDay { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<HabitEntity> habits { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
