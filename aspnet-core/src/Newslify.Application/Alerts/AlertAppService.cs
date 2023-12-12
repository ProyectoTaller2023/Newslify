using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Domain.Repositories;

namespace Newslify.Alerts
{
    [Authorize]
    public class AlertAppService : NewslifyAppService, IAlertsAppService
    {
        private readonly IRepository<Alert, int> _repository;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;

        public AlertAppService(IRepository<Alert, int> repository, UserManager<Volo.Abp.Identity.IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

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
    }
}
