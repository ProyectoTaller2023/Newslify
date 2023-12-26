using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Newslify.APILogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Newslify
{
    [Authorize]
    public class NewsAppService: NewslifyAppService, INewsAppService
    {

        private readonly INewsAPI _newsService;
        private readonly APILogManager _APILogsManager;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;

        public NewsAppService(INewsAPI newsService, APILogManager APILogsManager, UserManager<Volo.Abp.Identity.IdentityUser> userManager)
        {
            _newsService = newsService;
            _APILogsManager = APILogsManager;
            _userManager = userManager;
        }

        public async Task<ICollection<NewsDto>> GetNewsAsync(string LanguageIntCode, int? amountNews, string? query, DateTime? dateFrom)
        {
            // Aca estaria el monitoreo de tiempo de respuesta de la API para independizar
            //TODO: Control de acceso tiempo a la API
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var User = await _userManager.FindByIdAsync(userGuid.ToString());
            DateTime startRequest = DateTime.Now;
            try
            {
                ICollection<ArticleDto> articles = await _newsService.getNews(LanguageIntCode.ToUpper(), amountNews, query, dateFrom);// metodo que se conecte a la API y traiga las noticias
                DateTime endRequest = DateTime.Now;
                await _APILogsManager.Create(query, startRequest, endRequest, User);
                return ObjectMapper.Map<ICollection<ArticleDto>, ICollection<NewsDto>>(articles);
            }
            catch (Exception ex) 
            { 
                return new List<NewsDto>();
            }
         }
    }
}


