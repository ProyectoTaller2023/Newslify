using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Newslify.Notifications
{
    public interface INotificationAppService : IApplicationService
    {
        Task<ICollection<NotificationDto>> getUserNotificationsAsync();

        Task<NotificationDto> createNotificationAsync(int alertId, string title, string description);
    }
}
