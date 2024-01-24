using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Newslify.SavedNews;
using Newslify.Keywords;

namespace Newslify.ReadingLists
{
    public class ReadingListManager : DomainService
    {
        private readonly IRepository<ReadingList, int> _repository;
        public ReadingListManager(IRepository<ReadingList, int> repository)
        {
            _repository = repository;
        }

        public async Task<ReadingList> getReadingListToCreate(string name, int? parentId, Volo.Abp.Identity.IdentityUser identityUser)
        {
			ReadingList readingList = null;            
			
            readingList = new ReadingList { Name = name, User = identityUser };

            if (parentId is not null)
            {
                // Si el parent id no es nulo, es una lista lectura hija de alguna padre con id parentId.
                var parentReadingList = await _repository.GetAsync(parentId.Value, includeDetails: true);
			    parentReadingList.ReadingLists.Add(readingList);
            }               
     
            return readingList;
        }

       
        public async Task<ReadingList> getReadingListToUpdate(int id, string? name, int? parentId, string? keyword, SavedNew? news)
        {
            ReadingList readingList = null;

            readingList = await _repository.GetAsync(id, includeDetails: true);

            if (parentId is not null)
             {
               // Si el parent id no es nulo, es un tema hijo de un tema padre.
               var parentReadingList = await _repository.GetAsync(parentId.Value, includeDetails: true);
               parentReadingList.ReadingLists.Add(readingList);
             }

            if (name is not null)
            {
                readingList.Name = name;
            }

            if (keyword is not null)
            {
                readingList.Keywords.Add(new Keyword { KeyWord = keyword });
            }

            if (news is not null)
            {
                readingList.SavedNews.Add(news);
            }

            return readingList;
        }
    }
}