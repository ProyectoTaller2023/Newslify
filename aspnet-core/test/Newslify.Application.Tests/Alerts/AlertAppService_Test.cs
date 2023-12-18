using Newslify.EntityFrameworkCore;
using Newslify.Notifications;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;
using Xunit;

namespace Newslify.Alerts
{
    public class AlertAppService_Test : NewslifyApplicationTestBase
    {
        private readonly IAlertAppService _alertAppService;
        private readonly IDbContextProvider<NewslifyDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AlertAppService_Test()
        {
            _alertAppService = GetRequiredService<IAlertAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<NewslifyDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Create_Alert()
        {
            //Arrange
            var topic = "programacion";

            //Act
            var newAlert = await _alertAppService.CreateAsync(topic);

            //Assert
            newAlert.ShouldNotBeNull();
            newAlert.Id.ShouldBePositive();
     
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.Alerts.FirstOrDefault(a => a.Id == newAlert.Id).ShouldNotBeNull();
                dbContext.Alerts.FirstOrDefault(a => a.Id == newAlert.Id)?.topic.ShouldBe(newAlert.topic);
            }
        }

        [Fact]
        public async Task Should_Notify_Active_Alerts()
        {
            //Arrange
            string pattern = "bitcoin";

            //Act
            ICollection<NotificationDto> notifications = await _alertAppService.NotifyNewResultsAsync();
            var notifToTest = notifications
            .Where(n => n.Title != null && n.Title.Contains(pattern, StringComparison.OrdinalIgnoreCase))
            .FirstOrDefault();

            //Assert
            notifications.Count().ShouldBeGreaterThan(0);
            notifications.ShouldContain(notification => notification.Title.Contains(pattern));
            notifications.ShouldContain(n => n.Title == notifToTest.Title);

            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                var notif = dbContext.Notifications.FirstOrDefault(n => n.Title == notifToTest.Title).ShouldNotBeNull();
                dbContext.Alerts.FirstOrDefault(a => a.Id == notif.AlertId)?.active.ShouldBeFalse();
            }

        }
    }
}