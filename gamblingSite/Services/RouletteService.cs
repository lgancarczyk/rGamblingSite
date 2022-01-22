using gamblingSite.Models;
using Microsoft.Extensions.Hosting;
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
        private ICrudRouletteRepository repository;

        public RouletteService(ICrudRouletteRepository repository)
        {
            this.repository = repository;
        }

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
            RouletteModel item = new RouletteModel();
            item.SpinDate = DateTime.Now;
            item.Colour = "from Service";
            repository.Add(item);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            _timer.Dispose();
        }
    }
}
