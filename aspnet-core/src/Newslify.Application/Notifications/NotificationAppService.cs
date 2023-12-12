using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Newslify.Notifications
{
    [Authorize]
    public class NotificationAppService : NewslifyAppService, INotificationAppService
    {
        private readonly IRepository<Notification, int> _repository;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;

        public NotificationAppService(IRepository<Notification, int> repository, UserManager<Volo.Abp.Identity.IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

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

        // TODO: para testear se crea metodo para publicar notificaciones (borrar luego, no deberia ser parte del servicio que se expone)
        public async Task<NotificationDto> createNotificationAsync(int alertId, string title, string description)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var identityUser = await _userManager.FindByIdAsync(userGuid.ToString());
            if (identityUser == null)
            {
                throw new InvalidOperationException("El usuario no fue encontrado.");
            }
            var newNotification = new Notification { Title = title, Description = description, User = identityUser, AlertId = alertId, Active=true };

            var notification = await _repository.InsertAsync(newNotification, autoSave: true);

            return ObjectMapper.Map<Notification, NotificationDto>(notification);
        }
    }
}
