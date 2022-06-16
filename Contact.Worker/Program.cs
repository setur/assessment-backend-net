using Confluent.Kafka;
using Contact.Data;
using Contact.Data.Repositories;
using Contact.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using Contact.Data.Entities;
using Newtonsoft.Json;

namespace Contact.Worker
{
    class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<ContactContext>(options => options.UseNpgsql("Server=contactdb;Port=5432;Database=ContactDb;User Id=admin;Password=admin1234;"));
                    services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
                });

            return hostBuilder;
        }

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var repositoryWrapper = host.Services.GetService<IRepositoryWrapper>();

            List<ReportDetail> reports = new List<ReportDetail>();
            var config = new ConsumerConfig
            {
                BootstrapServers = "broker:9092",
                GroupId = "contact",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            const string topic = "report";

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            using (var consumer = new ConsumerBuilder<int, string>(
                config).Build())
            {
                consumer.Subscribe(topic);
                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(cts.Token);
                        int reportID = cr.Message.Key;
                        var loc = cr.Message.Value;
                        Report report = repositoryWrapper.Reports.GetReportById(reportID);
                        ReportDetail rd = new ReportDetail()
                        {
                            Location = loc,
                            PersonCount = repositoryWrapper.Infos.GetAllInfo().Where(i => i.Location == loc).Select(i => i.PersonId).Distinct().Count(),
                            TelephoneCount = repositoryWrapper.Infos.GetAllInfo().Where(i => i.Location == loc && !string.IsNullOrEmpty(i.Telephone)).Count()
                        };
                        string detail = JsonConvert.SerializeObject(rd);
                        report.Detail = detail;
                        repositoryWrapper.Reports.UpdateReport(report);
                        repositoryWrapper.Save();
                        Console.WriteLine($"Consumed event from topic {topic} with key {cr.Message.Key,-10} and value {cr.Message.Value}");
                    }
                }
                catch (OperationCanceledException)
                {
                }
                finally
                {
                    consumer.Close();
                }
            }
        }
    }
}
