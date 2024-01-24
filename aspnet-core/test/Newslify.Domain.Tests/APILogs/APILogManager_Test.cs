using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Xunit;
using Shouldly;
using Volo.Abp.Security.Claims;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Newslify.APILogs
{

    public class APILogManager_Test: NewslifyDomainTestBase
    {
        private readonly APILogManager _APILogManager;
       // private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly IdentityUserManager _identityUserManager;

        public APILogManager_Test()
        {
            _APILogManager = GetRequiredService<APILogManager>();
            _currentUser = GetRequiredService<ICurrentUser>();
            _identityUserManager = GetRequiredService<IdentityUserManager>();
        }

        [Fact]
        public async Task Should_Create_API_Log()
        {
            // Arrange
            var search = "bitcoin";
            var StartRequestTime = DateTime.Now;
            var EndRequestTime = DateTime.Now.AddMilliseconds(700);
            Volo.Abp.Identity.IdentityUser user = await _identityUserManager.GetByIdAsync(_currentUser.Id.GetValueOrDefault());
            var errorCode = 0;

            // Act
            var APILog = await _APILogManager.Create(search, StartRequestTime, EndRequestTime, user, errorCode);

            //Assert
            APILog.ShouldNotBeNull();
            APILog.Search.ShouldBe(search);
            APILog.UserId.ShouldBe(user.Id);
        }
    }
}
