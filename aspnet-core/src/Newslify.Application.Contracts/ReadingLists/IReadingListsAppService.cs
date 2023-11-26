using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Newslify.ReadingLists;

namespace Newslify
{
	public interface IReadingListsAppService : IApplicationService
	{
		Task<ICollection<ReadingListDto>> GetReadingListsAsync();
		Task<ReadingListDto> PostReadingListAsync(CreateReadingListDto input);
		Task<ReadingListDto> PutReadingListAsync(UpdateReadingListDto input);
		Task<string> DeleteAsync(string id);
    }
}