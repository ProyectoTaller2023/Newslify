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

namespace Newslify.ReadingLists
{
    [Authorize]
    public class ReadingListAppService : NewslifyAppService, IReadingListsAppService 
    {
        private readonly IRepository<ReadingList, int> _repository;
        private readonly UserManager<Volo.Abp.Identity.IdentityUser> _userManager;

        public ReadingListAppService(IRepository<ReadingList, int> repository, UserManager<Volo.Abp.Identity.IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        // hay que editar para que devuelva la lista de lectura de un usuario específico.

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

        public async Task<ReadingListDto> PostReadingListAsync(string Name)
        {
            var userGuid = CurrentUser.Id.GetValueOrDefault();
            var identityUser = await _userManager.FindByIdAsync(userGuid.ToString());

            ReadingList ReadingList = new ReadingList();
            ReadingList.Name = Name;
            ReadingList.User = identityUser;
            var response = await _repository.InsertAsync(ReadingList);
            return ObjectMapper.Map<ReadingList, ReadingListDto>(response);
        }

        public async Task<ReadingListDto> UpdateNameAsync(string id, string newName)
        {

            int idInt = int.TryParse(id, out idInt) ? idInt : -1;
            var existingReadingList = await _repository.GetAsync(idInt); 
            if (existingReadingList == null)
            {
                throw new Exception($"No existe la lista de lectura a modificar, el id es invalido. Id: {id}");
            }

            // Habria que ver que otros parametros recibe y hacer cosas de acuerdo a eso
            // Modificaciones....
            existingReadingList.Name = newName;

            var response = await _repository.UpdateAsync(existingReadingList);
            return ObjectMapper.Map<ReadingList, ReadingListDto>(response);
        }

        public async Task<ReadingListDto> AddKeywordsAsync(string id, ICollection<string> newKeywords)
        {

            int idInt = int.TryParse(id, out idInt) ? idInt : -1;

            var existingReadingList = await _repository.GetAsync(idInt);
            if (existingReadingList == null)
            {
                throw new Exception($"No existe la lista de lectura a modificar, el id es invalido. Id: {id}");
            }

            // Habria que ver que otros parametros recibe y hacer cosas de acuerdo a eso
            // Modificaciones....
            foreach (string keyword in newKeywords)
            {
               // await _repository.
                existingReadingList.Keywords.Add(new Keyword(keyword));
            }

            var response = await _repository.UpdateAsync(existingReadingList);
            return ObjectMapper.Map<ReadingList, ReadingListDto>(response);
        }

        public async Task DeleteAsync(string id)
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
        }
    }


    /* public async Task<ThemeDto> GetThemesAsync(int id)
     {
         var theme = await _repository.GetAsync(id);

         return ObjectMapper.Map<Theme, ThemeDto>(theme);
     }*/
}