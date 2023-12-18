using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Newslify
{
    public class NewsAppService_Test : NewslifyApplicationTestBase
    {
        private readonly INewsAppService _newsAppService;

        public NewsAppService_Test()
        {
            _newsAppService = GetRequiredService<INewsAppService>();
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
    }
}