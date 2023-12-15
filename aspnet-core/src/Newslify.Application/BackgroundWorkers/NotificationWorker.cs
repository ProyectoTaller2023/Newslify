using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newslify.Alerts;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace Newslify.BackgroundWorkers
{
    public class NotificationWorker : AsyncPeriodicBackgroundWorkerBase
    {
        public NotificationWorker(
                AbpAsyncTimer timer,
                IServiceScopeFactory serviceScopeFactory
            ) : base(
                timer,
                serviceScopeFactory)
        {
            Timer.Period = 60000; //1 minuto para las pruebas/demostracion de funcionamiento.
           // Timer.Period = 24 * 60 * 60 * 1000; //TODO: podria ejecutarse en la realidad cada 24hs por ej.
        }

        protected async override Task DoWorkAsync(
            PeriodicBackgroundWorkerContext workerContext)
        {
            Logger.LogInformation("Starting: Searching for alerts to notificate");

            //Resolve dependencies
            var alertAppService = workerContext
                .ServiceProvider
                .GetRequiredService<IAlertAppService>();

            //Do the work
            await alertAppService.NotifyNewResultsAsync();

            Logger.LogInformation("Completed: Notifications setted");
        }
    }

}
