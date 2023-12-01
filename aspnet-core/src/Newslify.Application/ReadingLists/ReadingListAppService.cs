using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Newslify.Keywords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Newslify.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Users;
using System.Security.Principal;
using Newslify;
using Newslify.SavedNews;

namespace Newslify.ReadingLists
{
    [Authorize]
    public class ReadingListAppService : NewslifyAppService, IReadingListAppService 
    {
        private readonly IRepository<ReadingList, int> _repository;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;
        private readonly ReadingListManager _readinglistManager;

        public ReadingListAppService(IRepository<ReadingList, int> repository, UserManager<Volo.Abp.Identity.IdentityUser> userManager, ReadingListManager readinglistManager
          )
        {
            _repository = repository;
            _userManager = userManager;
            _readinglistManager = readinglistManager;
        }

        public async Task<ICollection<ReadingListDto>> GetReadingListsAsync()
        {
            var readingLists = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<ReadingList>, ICollection<ReadingListDto>>(readingLists);

        }

        public async Task<ReadingListDto> GetReadingListAsync(int id)
        {
            var queryable = await _repository.WithDetailsAsync(x => x.ReadingLists);

            var query = queryable.Where(x => x.Id == id);

            var readingList = await AsyncExecuter.FirstOrDefaultAsync(query);

            return ObjectMapper.Map<ReadingList, ReadingListDto>(readingList);

        }

        public async Task<ReadingListDto> PostReadingListAsync(CreateReadingListDto input)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var identityUser = await _userManager.FindByIdAsync(userGuid.ToString());
            var readinglist = await _readinglistManager.getReadingListToCreate(input.Name, input.ParentId, identityUser);
           
            readinglist = await _repository.InsertAsync(readinglist, autoSave: true);
          
            return ObjectMapper.Map<ReadingList, ReadingListDto>(readinglist);
        }

        public async Task<ReadingListDto> PutReadingListAsync(UpdateReadingListDto input)
        {
            SavedNew news = null;

            if (input.News is not null)
            {
                news = ObjectMapper.Map<NewsDto, SavedNew>(input.News);
            }

            var readinglistModified = await _readinglistManager.getReadingListToUpdate(input.Id, input.Name, input.ParentId, input.Keyword, news);
          
            var readinglistUpdated = await _repository.UpdateAsync(readinglistModified, autoSave: true);
          
            return ObjectMapper.Map<ReadingList, ReadingListDto>(readinglistUpdated);
        }

        public async Task<string> DeleteAsync(string id)
        {
            int idInt;
            if (!int.TryParse(id, out idInt))
            {
                // Manejar el caso en el que la conversión no fue exitosa
                throw new Exception("El id proporcionado no es un número válido.");
            }

            var existingReadingList = await _repository.GetAsync(idInt);
            if (existingReadingList != null)
            {
                await _repository.DeleteAsync(existingReadingList);
            }
            else
            {
                throw new Exception("No existe una entidad con ese id.");
            }
            return "Se ha eliminado correctamente";
        }
    }


    /* public async Task<ThemeDto> GetThemesAsync(int id)
     {
         var theme = await _repository.GetAsync(id);

         return ObjectMapper.Map<Theme, ThemeDto>(theme);
     }*/
}