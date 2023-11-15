using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Newslify.Keywords;

namespace Newslify.ReadingLists
{
    public class ReadingListAppService : NewslifyAppService, IReadingListsAppService 
    {
        private readonly IRepository<ReadingList, int> _repository;

        public ReadingListAppService(IRepository<ReadingList, int> repository)
        {
            _repository = repository;
        }

        // hay que editar para que devuelva la lista de lectura de un usuario específico.

        public async Task<ICollection<ReadingListDto>> GetReadingListsAsync()
        {
            var readingLists = await _repository.GetListAsync();

            return ObjectMapper.Map<ICollection<ReadingList>, ICollection<ReadingListDto>>(readingLists);
        }

        public async Task<ReadingListDto> PostReadingListAsync(string UserId, string Name, string? ParentListId)
        {
            ReadingList ReadingList = new ReadingList(UserId, Name, ParentListId);
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

        public async Task<ReadingListDto> UpdateParentIdAsync(string id, string newParentId)
        {

            int idInt = int.TryParse(id, out idInt) ? idInt : -1;
            int newParentIdInt = int.TryParse(newParentId, out newParentIdInt) ? newParentIdInt : -1;

            if (newParentIdInt == -1)
            {
                throw new Exception($"El id del padre es invalido. Id: {newParentId}");
            }

            var existingReadingList = await _repository.GetAsync(idInt);
            if (existingReadingList == null)
            {
                throw new Exception($"No existe la lista de lectura a modificar, el id es invalido. Id: {id}");
            }

            // Habria que ver que otros parametros recibe y hacer cosas de acuerdo a eso
            // Modificaciones....
            existingReadingList.ParentListId = newParentIdInt;
            existingReadingList.ParentReadingList = await _repository.GetAsync(newParentIdInt);

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



        /* public async Task<ThemeDto> GetThemesAsync(int id)
         {
             var theme = await _repository.GetAsync(id);

             return ObjectMapper.Map<Theme, ThemeDto>(theme);
         }*/
    }
}