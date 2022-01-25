using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Meta.IntroApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Meta.IntroApp
{
    public class BackgroundServiceEmailProjectManager:IHostedService,IDisposable
    {
        private IServiceScopeFactory _scope;
        private ILogger<BackgroundServiceEmailProjectManager> _logger;
        private Timer _timer;

        public BackgroundServiceEmailProjectManager(ILogger<BackgroundServiceEmailProjectManager> logger,IServiceScopeFactory scope)
        {
            _logger = logger;
            _scope = scope;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using(var scope =_scope .CreateScope())
            {  
                
               var context =scope.ServiceProvider.GetRequiredService<MetaITechDbContext>();
               var x = context.Accounts.Where(x => x.FirstName== "ibrahim" ).ToList();
               foreach (var y in x)
               {
                   _timer=new Timer(o=>
                       {
                           _logger.LogInformation($"schedule start now:{y.Email}");
                       },
                       null,TimeSpan.Zero, TimeSpan.FromSeconds(20));  
               }
              
            }
             
            
           
          return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
          _logger.LogInformation("stop schedule now"); 
          return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}