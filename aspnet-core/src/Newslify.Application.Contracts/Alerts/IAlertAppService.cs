using Newslify.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Newslify.Alerts
{
    public interface IAlertAppService : IApplicationService
    {
        Task<AlertDto> CreateAsync(string topic);
        Task<ICollection<NotificationDto>> NotifyNewResultsAsync();
    }
}
