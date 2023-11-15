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

       /* public async Task<ReadingListDto> UpdateName (string id)
        {

            int idInt = int.TryParse(id, out idInt) ? idInt : -1;
            var existingReadingList = await _repository.GetAsync(idInt);
            if (existingReadingList == null)
            {
                throw new Exception($"No existe la lista de lectura a modificar, el id es invalido. Id: {id}");
            }

            // Habria que ver que otros parametros recibe y hacer cosas de acuerdo a eso
            // Modificaciones....
            existingReadingList.ParentReadingList = null;


            var response = await _repository.UpdateAsync(existingReadingList);
            return ObjectMapper.Map<ReadingList, ReadingListDto>(response);
        }*/



        /* public async Task<ThemeDto> GetThemesAsync(int id)
         {
             var theme = await _repository.GetAsync(id);

             return ObjectMapper.Map<Theme, ThemeDto>(theme);
         }*/
    }
}