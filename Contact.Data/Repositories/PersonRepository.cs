using Contact.API.Repositories;
using Contact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ContactContext contactContext) : base(contactContext){}

        public void AddPerson(Person person) => Create(person);

        public void DeletePerson(Person person) => Delete(person);

        public IEnumerable<Person> GetPeople() => FindAll().ToList();

        public Person GetPersonByID(int id) => FindByCondition(p => p.Id == id).FirstOrDefault();

        public void UpdatePerson(Person person) => Update(person);
    }
}
