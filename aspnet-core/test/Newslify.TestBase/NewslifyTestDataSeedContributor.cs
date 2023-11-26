using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Newslify.ReadingLists;

namespace Newslify;
public class NewslifyTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<ReadingList, int> _readingListRepository;
    private readonly IdentityUserManager _identityUserManager;


    public NewslifyTestDataSeedContributor(IRepository<ReadingList, int> readingListRepository, IdentityUserManager identityUserManager)
    {
        _readingListRepository = readingListRepository;
        _identityUserManager = identityUserManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // Add users        
        IdentityUser identityUser1 = new IdentityUser(Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d"), "admin", "admin@abp.io");
        await _identityUserManager.CreateAsync(identityUser1, "1q2w3E*");
        // await _identityUserManager.AddToRoleAsync(identityUser1, "Admin");

        await _readingListRepository.InsertAsync(new ReadingList { Name = "Primer tema", User = identityUser1 });
        await _readingListRepository.InsertAsync(new ReadingList { Name = "Segundo tema", User = identityUser1 });
    }
}