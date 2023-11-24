using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Newslify.ReadingLists
{
	public interface IReadingListsAppService : IApplicationService
	{
		Task<ICollection<ReadingListDto>> GetReadingListsAsync();
		Task<ReadingListDto> PostReadingListAsync(CreateReadingListDto input);
        Task<ReadingListDto> UpdateNameAsync(string id, string newName);
		Task<ReadingListDto> AddKeywordsAsync(string id, ICollection<string> newKeywords);
		Task<string> DeleteAsync(string id);
    }
}