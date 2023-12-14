using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Newslify.Notifications;
using Volo.Abp.Domain.Repositories;

namespace Newslify.Alerts
{
    public class AlertAppService : NewslifyAppService, IAlertAppService
    {
        private readonly IRepository<Alert, int> _repository;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;
        private readonly INotificationAppService _notificationAppService;
        private readonly INewsAppService _newsAppService;

        public AlertAppService(IRepository<Alert, int> repository, UserManager<Volo.Abp.Identity.IdentityUser> userManager, INotificationAppService notificationAppService, INewsAppService newsAppService)
        {
            _repository = repository;
            _userManager = userManager;
            _notificationAppService = notificationAppService;
            _newsAppService = newsAppService;
        }

        [Authorize]
        public async Task<AlertDto> CreateAsync (string topic)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var identityUser = await _userManager.FindByIdAsync(userGuid.ToString());

            if (identityUser == null)
            {
                throw new InvalidOperationException("El usuario no fue encontrado.");
            }

            var alertDraft = new Alert(topic, identityUser);

            Alert createdAlert = await _repository.InsertAsync(alertDraft, autoSave: true);

            return ObjectMapper.Map<Alert, AlertDto>(createdAlert);
        }

        public async Task<ICollection<NotificationDto>> NotifyNewResultsAsync()
        // iterar sobre cada alerta del usuario y hacer una llamada al servicio de la API.
        // Si devuelve algun resultado, crear una notificacion para el usuario asociada a esa alerta y la inactiva
        // para evitar notificar dos veces sobre la misma alerta.
        // El background worker se ejecutara cada 24hs por ejemplo aunque para testear deberia ser menos.
        {
            List<NotificationDto> notifications = new List<NotificationDto>();
            var alerts = await _repository.GetListAsync(a => a.active);

            foreach (var alert in alerts)
            {
                var news = await _newsAppService.GetNewsAsync("2", 1, alert.topic, null);

                if (news.Count > 0)
                {
                    NotificationDto notification = await _notificationAppService.createNotificationAsync(alert.Id, $"Nuevas novedades en {alert.topic}", $"Hey, parece que hay nuevas noticias acerca de tu alerta para {alert.topic}, échales un vistazo!");
                    notifications.Add(notification);
                    alert.active = false;
                    await _repository.UpdateAsync(alert);
                }
            }

            return notifications;
        }
    }
}
