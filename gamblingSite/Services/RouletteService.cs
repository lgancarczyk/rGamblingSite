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
        private static bool firstTime;
        


        public RouletteService(ILogger<RouletteService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            firstTime = true;
            _logger.LogInformation("Timed Background Service is working.");
        }


        //private ICrudRouletteRepository repository;
        //public RouletteService(ICrudRouletteRepository repository)
        //{
        //    this.repository = repository;
        //}

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(RouletteOperations, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void RouletteOperations(object state) 
        {
            if (firstTime == true)
            {
                AddNewRouletteRecord();
                firstTime = false;
            }
            else
            {
                CloseOldRouletteRecord();

                DrawColorForOldRouletteRecord();

                //SettlePointsFromOldRecord();

                AddNewRouletteRecord();
            }
        }

        private string GetRandomColour() 
        {   //36 max  simple colours black is even, red is odd
            Random rnd = new Random();
            int number = rnd.Next(0, 37);
            if (number == 0)
            {
                return "green";
            }
            else if (number%2 == 0)
            {
                return "black";
            }
            else
            {
                return "red";
            }
        }
        private int GetRouletteRecordLastId() 
        {
            int id;
            _logger.LogInformation("GetRouletteRecordLastId is working.");
            using (var scope = _scopeFactory.CreateScope())
            {
                var dBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                id = dBContext.RouletteModels.Max(p => p.SpinID);
            }
            return id;
        }

        private void CloseOldRouletteRecord()
        {

            _logger.LogInformation("CloseOldRouletteRecord is working.");
            using (var scope = _scopeFactory.CreateScope())
            {
                var dBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                var item = dBContext.RouletteModels.Find(GetRouletteRecordLastId());
                item.IsClosed = true;
                dBContext.SaveChanges();
            }
        }

        private void DrawColorForOldRouletteRecord()
        {
            _logger.LogInformation("DrawColorFromOldRouletteRecord is working.");
            using (var scope = _scopeFactory.CreateScope())
            {
                var dBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                var item = dBContext.RouletteModels.Find(GetRouletteRecordLastId());
                item.SpinDate = DateTime.Now;
                item.Colour = GetRandomColour();
                dBContext.SaveChanges();
            }
        }

        private void SettlePointsFromOldRecord()
        {
            throw new NotImplementedException();
        }

        public void AddNewRouletteRecord() 
        {

            _logger.LogInformation("Timed Background Service is working.");
            using (var scope = _scopeFactory.CreateScope())
            {
                var dBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                RouletteModel item = new RouletteModel();
                item.SpinDate = DateTime.Now.AddMinutes(1);
                item.Colour = null;
                dBContext.RouletteModels.Add(item);
                dBContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
