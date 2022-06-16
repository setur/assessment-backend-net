using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(ContactContext contactContext) : base(contactContext) { }

        public void CreateReport(Report report) => Create(report);
        public IEnumerable<Report> GetAllReports() => FindAll().ToList();
        public Report GetReportById(int reportId) => FindByCondition(r => r.Id == reportId).FirstOrDefault();
        public void UpdateReport(Report report) => Update(report);
    }
}
