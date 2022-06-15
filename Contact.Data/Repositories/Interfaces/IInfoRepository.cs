using Contact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories.Interfaces
{
    public interface IInfoRepository
    {
        public IEnumerable<Info> GetAllInfo(int personId);
        public Info GetInfoById(int infoId);
        public void CreateInfo(Info info);
        public void UpdateInfo(Info info);
        public void DeleteInfo(Info ınfo);
    }
}
