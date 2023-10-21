using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Newslify
{
    public class NewsAppService: NewslifyAppService, INewsAppService
    { 
           
        public NewsAppService()
        {
        }

        public async Task<string> GetNewsAsync(string LanguageIntCode, int amountNews)
         {
           var newsAPI = new HandlerNewsAPI();
           string newsInJSON = await newsAPI.getNews(LanguageIntCode.ToUpper(),amountNews);// metodo que se conecte a la API y traiga las noticias

           return newsInJSON;
         }
    }
}


