using AutoMapper;
using Confluent.Kafka;
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
        public ActionResult CreateReport(string loc)
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

                var config = new ProducerConfig
                {
                    BootstrapServers = "broker:9092"
                };

                const string topic = "report";

                using (var producer = new ProducerBuilder<int, string>(
                    config.AsEnumerable()).Build())
                {

                    producer.Produce(topic, new Message<int, string> { Key = report.Id, Value = loc },
                        (deliveryReport) =>
                        {
                            if (deliveryReport.Error.Code != ErrorCode.NoError)
                            {
                                Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                            }
                            else
                            {
                                Console.WriteLine($"Produced event to topic {topic}: key = {report.Id,-10} value = {loc}");
                            }
                        });


                    producer.Flush(TimeSpan.FromSeconds(10));
                    return Ok(report);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
