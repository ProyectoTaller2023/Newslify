using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Newslify.ReadingLists
{
    public class ReadingListManager : DomainService
    {
        private readonly IRepository<ReadingList, int> _repository;
        public ReadingListManager(IRepository<ReadingList, int> repository)
        {
            _repository = repository;
        }

        public async Task<ReadingList> getReadingListUpdated(int? id, string name, int? parentId, Volo.Abp.Identity.IdentityUser identityUser)
        {
			ReadingList readingList = null;            

            if (id is not null)
            {
				// Si el id no es nulo significa que se modifica el tema
				readingList = await _repository.GetAsync(id.Value, includeDetails: true);

				readingList.Name = name;
            }
            else
            {
				//Si el id es nulo, es un tema nuevo
				readingList = new ReadingList { Name = name, User = identityUser };

                if (parentId is not null)
                {
                    // Si el parent id no es nulo, es un tema hijo de un tema padre.
                    var parentReadingList = await _repository.GetAsync(parentId.Value, includeDetails: true);
					parentReadingList.ReadingLists.Add(readingList);
                }               
            };

            return readingList;
        }
    }
}