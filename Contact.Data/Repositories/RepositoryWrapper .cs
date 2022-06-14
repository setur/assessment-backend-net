using Contact.API.Repositories;
using Contact.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ContactContext _contactContext;
        private IPersonRepository _people;

        public RepositoryWrapper(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public IPersonRepository People
        {
            get
            {
                if (_people == null)
                {
                    _people = new PersonRepository(_contactContext);
                }
                return _people;
            }
        }

        public void Save()
        {
            _contactContext.SaveChanges();
        }
    }
}
