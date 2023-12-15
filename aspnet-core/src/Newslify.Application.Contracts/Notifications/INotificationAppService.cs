using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Newslify.Notifications
{
    public interface INotificationAppService : IApplicationService
    {
        Task<ICollection<NotificationDto>> getNotificationsAsync();

        // TODO: Este metodo tendria que ser un servicio de dominio y no de aplicacion.
        Task<NotificationDto> createNotificationAsync(int alertId, string title, string description);
    }
}
