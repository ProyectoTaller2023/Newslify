using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Shouldly;
using Volo.Abp.Users;
using Volo.Abp.Security.Claims;
using Volo.Abp.Domain.Repositories;
using Newslify.SavedNews;

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
        var user = await _identityRepository.GetAsync(_currentUser.Id.GetValueOrDefault());

        // Act
        var readingList = await _readingListManager.getReadingListToCreate(name, parentId, user);

        //Assert
        readingList.ShouldNotBeNull();
        readingList.Name.ShouldBe(name);
        readingList.User.ShouldBe(user);
    }

    [Fact]
    public async Task Should_Update_Name_Reading_List()
    {
        // Arrange
        var name = "Lista de lectura actualizada!";
         
        // Act
        var readingList = await _readingListManager.getReadingListToUpdate(1,name, null, null, null);

        //Assert
        readingList.ShouldNotBeNull();
        readingList.Name.ShouldBe(name);
    }

    [Fact]
    public async Task Should_Add_Keyword_Reading_List()
    {
        // Arrange
        string keyword = "Finanzas";

        // Act
        var readingList = await _readingListManager.getReadingListToUpdate(1, null, null, keyword, null);

        //Assert
        readingList.ShouldNotBeNull();
        readingList.Keywords.ShouldContain(k => k.KeyWord == keyword);
    }

    [Fact]
    public async Task Should_Add_News_Reading_List()
    {
        // Arrange
        SavedNew news = new()
        {
            Author = "Autor",
            Title = "Titulo",
            Description = "Descripcion",
            Url = "##UniqueUrl##",
            UrlToImage = "UrlToImage",
            PublishedAt = DateTime.Now,
            Content = "Content"
        };  

        // Act
        var readingList = await _readingListManager.getReadingListToUpdate(1, null, null, null, news);

        //Assert
        readingList.ShouldNotBeNull();
        readingList.SavedNews.ShouldContain(n => n.Url == news.Url);
    }
}