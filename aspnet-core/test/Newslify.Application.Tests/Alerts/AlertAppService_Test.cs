using Newslify.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;
using Xunit;

namespace Newslify.Alerts
{
    public class AlertAppService_Test : NewslifyApplicationTestBase
    {
        private readonly IAlertAppService _alertAppService;
        private readonly IDbContextProvider<NewslifyDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AlertAppService_Test()
        {
            _alertAppService = GetRequiredService<IAlertAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<NewslifyDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Create_Alert()
        {
            //Arrange
            var topic = "programacion";

            //Act
            var newAlert = await _alertAppService.CreateAsync(topic);

            //Assert
            newAlert.ShouldNotBeNull();
            newAlert.Id.ShouldBePositive();
     
            // se verifican los datos persistidos por el servicio
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.Alerts.FirstOrDefault(a => a.Id == newAlert.Id).ShouldNotBeNull();
                dbContext.Alerts.FirstOrDefault(a => a.Id == newAlert.Id)?.topic.ShouldBe(newAlert.topic);
            }
        }
    }
}