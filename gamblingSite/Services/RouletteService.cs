using gamblingSite.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace gamblingSite.Services
{
    public class RouletteService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private ICrudRouletteRepository repository;


        public RouletteService(ILogger<RouletteService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }


        //private ICrudRouletteRepository repository;
        //public RouletteService(ICrudRouletteRepository repository)
        //{
        //    this.repository = repository;
        //}

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            _timer = new Timer(AddNewRouletteRecord, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void AddNewRouletteRecord(object state) 
        {
            //RouletteModel item = new RouletteModel();
            //item.SpinDate = DateTime.Now;
            //item.Colour = "from Service";
            //repository.Add(item);
            _logger.LogInformation("Timed Background Service is working.");
            using (var scope = _scopeFactory.CreateScope()) 
            {

                var dBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                RouletteModel item = new RouletteModel();
                item.SpinDate = DateTime.Now;
                item.Colour = "Red";
                dBContext.RouletteModels.Add(item);
                dBContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            _timer.Dispose();
        }
    }
}
