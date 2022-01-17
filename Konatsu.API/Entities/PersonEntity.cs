using System;

namespace Konatsu.API
{
    public class PersonEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
