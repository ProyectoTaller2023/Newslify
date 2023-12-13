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

        // TODO: Se crea este metodo para testing, luego esto se eliminara ya que las notificaciones
        // se deberan crear cuando el worker que revisa las alertas encuentra nuevas noticias.
        Task<NotificationDto> createNotificationAsync(int alertId, string title, string description);
    }
}
