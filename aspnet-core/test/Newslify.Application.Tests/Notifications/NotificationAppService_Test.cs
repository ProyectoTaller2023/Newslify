using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Newslify.Notifications
{
    public class NotificationAppService_Test : NewslifyApplicationTestBase
    {
        private readonly INotificationAppService _notificationAppService;

        public NotificationAppService_Test()
        {
            _notificationAppService = GetRequiredService<INotificationAppService>();
        }

        [Fact]
        public async Task Should_Create_Alert()
        {
            //Arrange

            //Act
            var notifications = await _notificationAppService.getNotificationsAsync();

            //Assert
            notifications.ShouldNotBeEmpty();
            notifications.ShouldNotContain(notification => notification.Title == "wrong");
        }
    }
}
