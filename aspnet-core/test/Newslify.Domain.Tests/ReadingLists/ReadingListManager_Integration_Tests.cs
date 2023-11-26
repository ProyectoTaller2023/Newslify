using Volo.Abp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Identity;
using Shouldly;
using Volo.Abp.Users;
using Volo.Abp.Security.Claims;
using Volo.Abp.Domain.Repositories;
using Newslify;

namespace Newslify.ReadingLists;

public class ReadingListManager_Integration_Tests : NewslifyDomainTestBase
{
    private readonly ReadingListManager _readingListManager;
    private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;
    private readonly ICurrentUser _currentUser;
    private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
    private readonly IRepository<Volo.Abp.Identity.IdentityUser, Guid> _identityRepository;

    public ReadingListManager_Integration_Tests()
    {
        _readingListManager = GetRequiredService<ReadingListManager>();
        _userManager = GetRequiredService<UserManager<Volo.Abp.Identity.IdentityUser>>();
        _currentUser = GetRequiredService<ICurrentUser>();
        _currentPrincipalAccessor = GetRequiredService<ICurrentPrincipalAccessor>();
        _identityRepository = GetRequiredService<IRepository<Volo.Abp.Identity.IdentityUser, Guid>>();
    }

    [Fact]
    public async Task Should_Create_Reading_List()
    {
        // Arrange
        var name = "Nueva lista de lectura!";
        int? parentId = null;
       // var userId = await _userManager.FindByIdAsync(_currentUser.Id.GetValueOrDefault().ToString());
        var user = await _identityRepository.GetAsync(_currentUser.Id.GetValueOrDefault());

        // Act
        var readingList = await _readingListManager.getReadingListToCreate(name, parentId, user);

        //Assert
        readingList.ShouldNotBeNull();
        readingList.Name.ShouldBe(name);
        readingList.User.ShouldBe(user);
    }
}