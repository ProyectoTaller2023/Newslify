using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Newslify
{
    public class NewsApiService_Test
    {
        private readonly HandlerNewsAPI _newsApiService;

        public NewsApiService_Test()
        {
            // instancio la clase concreta ya que quiero probar explicitamente la misma.
            _newsApiService = new HandlerNewsAPI();
        }

        [Fact]
        public async Task Should_Get_3_News()
        {
            //Arrage            
            var query = "Bitcoin";

            //Act
            var articles = await _newsApiService.getNews("1", 3, query);

            //Assert
            articles.ShouldNotBeNull();
            articles.Count.ShouldBeGreaterThan(1);
            articles.Count.ShouldBeEquivalentTo(3);
        }
    }
}