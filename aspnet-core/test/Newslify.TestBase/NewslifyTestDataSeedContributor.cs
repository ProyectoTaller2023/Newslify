using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Newslify.ReadingLists;
using Newslify.Alerts;
using Newslify.Notifications;
using Newslify.APILogs;

namespace Newslify;
public class NewslifyTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<ReadingList, int> _readingListRepository;
    private readonly IRepository<Alert, int> _alertRepository;
    private readonly IRepository<Notification, int> _notificationRepository;
    private readonly IdentityUserManager _identityUserManager;
    private readonly IRepository<APILog, int> _APILogRepository;


    public NewslifyTestDataSeedContributor(IRepository<ReadingList, int> readingListRepository, IdentityUserManager identityUserManager, IRepository<Alert,int> alertRepository, IRepository<Notification, int> notificationRepository, IRepository<APILog, int> APILogRepository)
    {
        _readingListRepository = readingListRepository;
        _identityUserManager = identityUserManager;
        _alertRepository = alertRepository;
        _notificationRepository = notificationRepository;
        _APILogRepository = APILogRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // Add users        
        IdentityUser identityUser1 = new IdentityUser(Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d"), "admin", "admin@abp.io");
        IdentityUser identityUser2 = new IdentityUser(Guid.Parse("2e701e62-0903-4dd3-950b-dc6cc92ccb7d"), "admin2", "admin2@abp.io");
        await _identityUserManager.CreateAsync(identityUser1, "1q2w3E*");
        await _identityUserManager.CreateAsync(identityUser2, "1q2w3F*");

        await _readingListRepository.InsertAsync(new ReadingList { Name = "Primer reading list", User = identityUser1 });
        await _readingListRepository.InsertAsync(new ReadingList { Name = "Segunda reading list", User = identityUser1 });
        var alert = await _alertRepository.InsertAsync(new Alert { topic = "test", User = identityUser1 }); 
        await _notificationRepository.InsertAsync(new Notification { Title = "Nuevas noticias de test", Description = "Hey, tienes nuevas noticias sobre test, no te las pierdas!", Alert=alert, AlertId=alert.Id, User = identityUser1, Active=true });
        var alert2 = await _alertRepository.InsertAsync(new Alert { topic = "test 2", User = identityUser2 });
        await _notificationRepository.InsertAsync(new Notification { Title = "wrong", Description = "Alerta para testear notificationService!", Alert = alert2, AlertId = alert2.Id, User = identityUser2, Active = true });

        var alert3 = await _alertRepository.InsertAsync(new Alert { topic = "bitcoin", User = identityUser1, active=true });

        await _APILogRepository.InsertAsync(new APILog { Search = "test", StartTime = DateTime.Now, EndTime = DateTime.Now.AddMilliseconds(1000), User = identityUser1, ErrorCode = 0 });
        await _APILogRepository.InsertAsync(new APILog { Search = "test", StartTime = DateTime.Now, EndTime = DateTime.Now.AddMilliseconds(1000), User = identityUser1, ErrorCode = 0 });
        await _APILogRepository.InsertAsync(new APILog { Search = "other", StartTime = DateTime.Now, EndTime = DateTime.Now.AddMilliseconds(1000), User = identityUser1, ErrorCode = 1 });

    }
}