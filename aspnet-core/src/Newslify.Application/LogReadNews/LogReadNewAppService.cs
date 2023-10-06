using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Newslify.LogReadNews
{
    public class LogReadNewAppService : NewslifyAppService, ILogReadNewAppService
    {
        private readonly IRepository<LogReadNew, int> _repository;

        public LogReadNewAppService(IRepository<LogReadNew, int> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<LogReadNewDto>> GetLogReadNewsAsync()
        {
            var logReadNews = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<LogReadNew>, ICollection<LogReadNewDto>>(logReadNews);
        }

        /* public async Task<ThemeDto> GetThemesAsync(int id)
         {
             var theme = await _repository.GetAsync(id);

             return ObjectMapper.Map<Theme, ThemeDto>(theme);
         }*/
    }
}