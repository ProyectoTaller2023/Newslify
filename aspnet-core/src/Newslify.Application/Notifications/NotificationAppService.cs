using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newslify.Alerts;

namespace Newslify.Notifications
{
    public class NotificationAppService : NewslifyAppService, INotificationAppService
    {
        private readonly IRepository<Notification, int> _repository;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;
        private readonly AlertManager _alertManager;

        public NotificationAppService(IRepository<Notification, int> repository, UserManager<Volo.Abp.Identity.IdentityUser> userManager, AlertManager alertManager)
        {
            _repository = repository;
            _userManager = userManager;
            _alertManager = alertManager;
        }

        [Authorize]
        public async Task<ICollection<NotificationDto>> getNotificationsAsync()
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var identityUser = await _userManager.FindByIdAsync(userGuid.ToString());

            if (identityUser == null)
            {
                throw new InvalidOperationException("El usuario no fue encontrado.");
            }

            var notifications = await _repository.GetListAsync(Notif => Notif.User.Id == identityUser.Id, includeDetails:true);

            return ObjectMapper.Map<ICollection<Notification>, ICollection<NotificationDto>>(notifications);
        }

        public async Task<NotificationDto> createNotificationAsync(int alertId, string title, string description)
        {
            var alert = await _alertManager.GetAlertAsync(alertId);
            Guid userId = alert.User.Id;
            Volo.Abp.Identity.IdentityUser? user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new InvalidOperationException("El usuario no fue encontrado.");
            }

            var newNotification = new Notification { Title = title, Description = description, User = user, AlertId = alertId, Active=true };

            var notification = await _repository.InsertAsync(newNotification);

            return ObjectMapper.Map<Notification, NotificationDto>(notification);
        }
    }
}
