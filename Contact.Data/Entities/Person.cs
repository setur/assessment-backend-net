using System.Collections.Generic;

namespace Contact.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<Info> Info { get; set; }

    }
}
