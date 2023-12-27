using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Newslify.APILogs
{
    public class APIStatAppService_Test : NewslifyApplicationTestBase
    {
        private readonly IAPIStatAppService _APIStatAppService;

        public APIStatAppService_Test()
        {
            _APIStatAppService = GetRequiredService<IAPIStatAppService>();
        }

        [Fact]
        public async Task Should_Get_APILogs_Amount()
        {
            //Act
            int amount = await _APIStatAppService.GetLogsAmount();

            //Assert
            amount.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_GetAverageAPIAccess()
        {
            //Act
            double average = await _APIStatAppService.GetAverageAPIAccess();

            //Assert
            average.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_GetTrendingTopic()
        {
            //Act
            TrendingTopicResponse trending = await _APIStatAppService.GetTrendingTopic();

            //Assert
            trending.max.ShouldBeGreaterThan(0);
            trending.maxValue.ShouldBe("test");
        }


        [Fact]
        public async Task Should_PercentageSuccess()
        {
            //Act
           double percentage = await _APIStatAppService.GetPercentageSuccessRequests();

            //Assert
            percentage.ShouldBeGreaterThan(0);
            percentage.ShouldBeLessThan(100); // Ya que hay un error introducido a proposito en el data seeder.
        }
    }
}
