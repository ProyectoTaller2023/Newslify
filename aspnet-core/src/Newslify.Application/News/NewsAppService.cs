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

        private readonly INewsAPI _newsService;

        public NewsAppService(INewsAPI newsService)
        {
            _newsService = newsService;
        }

        public async Task<ICollection<NewsDto>> GetNewsAsync(string LanguageIntCode, int? amountNews, string? query, DateTime? dateFrom)
         {
            // Aca estaria el monitoreo de tiempo de respuesta de la API para independizar
            //TODO: Control de acceso tiempo a la API
           ICollection <ArticleDto> articles = await _newsService.getNews(LanguageIntCode.ToUpper(),amountNews, query, dateFrom);// metodo que se conecte a la API y traiga las noticias

           return ObjectMapper.Map<ICollection<ArticleDto>, ICollection<NewsDto>>(articles);
         }
    }
}


