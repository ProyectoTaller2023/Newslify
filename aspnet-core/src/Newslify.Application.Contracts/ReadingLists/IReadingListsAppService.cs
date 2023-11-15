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
		Task<ReadingListDto> PostReadingListAsync(string UserId, string Name, string? ParentListId);
        Task<ReadingListDto> UpdateNameAsync(string id, string newName);
		Task<ReadingListDto> UpdateParentIdAsync(string id, string newParentId);
		Task<ReadingListDto> AddKeywordsAsync(string id, ICollection<string> newKeywords);
    }
}