using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Entities
{

    public class Report
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public ReportStatus Status { get; set; }
    }

    public enum ReportStatus
    {
        Pending = 0,
        Ready = 1,
    }

    public class ReportDetail
    {
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int TelephoneCount { get; set; }
    }
}
