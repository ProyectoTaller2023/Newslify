using Volo.Abp.Uow;
using Newslify.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Xunit;

namespace Newslify
{
    public class NewsAppService_Test : NewslifyApplicationTestBase
    {
        private readonly INewsAppService _newsAppService;
        private readonly IDbContextProvider<NewslifyDbContext> _dbContextProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public NewsAppService_Test()
        {
            _newsAppService = GetRequiredService<INewsAppService>();
            _dbContextProvider = GetRequiredService<IDbContextProvider<NewslifyDbContext>>();
            _unitOfWorkManager = GetRequiredService<IUnitOfWorkManager>();
        }

        [Fact]
        public async Task Should_Get_3_News()
        {
            //Arrange
            var query = "bitcoin";

            //Act
            var news = await _newsAppService.GetNewsAsync("1",3,query, null);

            //Assert
            news.ShouldNotBeNull();
            news.Count.ShouldBeGreaterThan(1);
            news.Count.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public async Task Should_Create_API_Log()
        {
            //Arrage            
            var query = "test creacion de api log";

            //Act
            await _newsAppService.GetNewsAsync("1", 3, query, null);

            //Assert
            using (var uow = _unitOfWorkManager.Begin())
            {
                var dbContext = await _dbContextProvider.GetDbContextAsync();
                dbContext.APILogs.FirstOrDefault(t => t.Search == query).ShouldNotBeNull();
            }
        }
    }
}