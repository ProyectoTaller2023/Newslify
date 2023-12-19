using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Newslify
{
    public class NewsApiService_Test
    {
        private readonly HandlerNewsAPI _newsApiService;

        public NewsApiService_Test()
        {
            _newsApiService = new HandlerNewsAPI();
        }

        [Fact]
        public async Task Should_Get_3_News()
        {
            //Arrage            
            var query = "bitcoin";

            //Act
            var articles = await _newsApiService.getNews("1", 3, query, null);

            //Assert
            articles.ShouldNotBeNull();
            articles.Count.ShouldBeGreaterThan(1);
            articles.Count.ShouldBeEquivalentTo(3);
        }
    }
}