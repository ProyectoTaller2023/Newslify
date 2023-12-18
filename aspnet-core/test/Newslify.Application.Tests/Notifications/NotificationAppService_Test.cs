using Newslify.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Xunit;
using Volo.Abp.Uow;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace Newslify.Notifications
{
    public class NotificationAppService_Test : NewslifyApplicationTestBase
    {
        private readonly INotificationAppService _notificationAppService;
        private readonly IDbContextProvider<NewslifyDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public NotificationAppService_Test()
        {
            _notificationAppService = GetRequiredService<INotificationAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<NewslifyDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Get_User_Notifications()
        {
            //Arrange

            //Act
            var notifications = await _notificationAppService.getUserNotificationsAsync();

            //Assert
            notifications.ShouldNotBeEmpty();
            notifications.ShouldNotContain(notification => notification.Title == "wrong");
        }

        [Fact]
        public async Task Should_Create_Notification()
        {
            //Arrange
            string notificationTitle = "test notification";

            //Act
            var notification = await _notificationAppService.createNotificationAsync(1, notificationTitle, "test notification description");

            //Assert
            notification.ShouldNotBeNull();
            notification.Title.ShouldBe(notificationTitle);

            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.Notifications.FirstOrDefault(N => N.Title == notificationTitle).ShouldNotBeNull();
            }
        }
    } 
}
