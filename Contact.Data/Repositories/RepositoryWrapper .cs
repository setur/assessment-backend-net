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
        private IInfoRepository _infos;

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

        public IInfoRepository Infos
        {
            get
            {
                if (_infos == null)
                {
                    _infos = new InfoRepository(_contactContext);
                }
                return _infos;
            }
        }

        public void Save()
        {
            _contactContext.SaveChanges();
        }
    }
}
