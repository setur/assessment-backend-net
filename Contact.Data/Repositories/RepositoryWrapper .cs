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
        private IReportRepository _report;

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

        public IReportRepository Reports
        {
            get
            {
                if (_report == null)
                {
                    _report = new ReportRepository(_contactContext);
                }
                return _report;
            }
        }

        public void Save()
        {
            _contactContext.SaveChanges();
        }
    }
}
