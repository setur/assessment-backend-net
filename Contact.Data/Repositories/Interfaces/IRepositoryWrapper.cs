using Contact.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IPersonRepository People { get; }
        void Save();
    }
}
