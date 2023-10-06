using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Newslify.ReadingLists
{
    public class ReadingListAppService : NewslifyAppService, IReadingListsAppService 
    {
        private readonly IRepository<ReadingList, int> _repository;

        public ReadingListAppService(IRepository<ReadingList, int> repository)
        {
            _repository = repository;
        }


        public async Task<ICollection<ReadingListDto>> GetReadingListsAsync()
        {
            var readingLists = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<ReadingList>, ICollection<ReadingListDto>>(readingLists);
        }

        /* public async Task<ThemeDto> GetThemesAsync(int id)
         {
             var theme = await _repository.GetAsync(id);

             return ObjectMapper.Map<Theme, ThemeDto>(theme);
         }*/
    }
}