using AutoMapper;
using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public ReportController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Report>> GetReports()
        {
            try
            {
                var reports = _repository.Reports.GetAllReports();
                return Ok(reports);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public ActionResult CreateReport()
        {
            try
            {
                Report report = new Report() 
                { 
                    Date = DateTime.Now,
                    Status = ReportStatus.Pending
                };
                _repository.Reports.CreateReport(report);
                _repository.Save();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
