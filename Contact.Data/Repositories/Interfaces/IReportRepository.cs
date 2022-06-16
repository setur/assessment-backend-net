using Contact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories.Interfaces
{
    public interface IReportRepository
    {
        public IEnumerable<Report> GetAllReports();
        public Report GetReportById(int reportId);
        public void CreateReport(Report report);
    }
}
