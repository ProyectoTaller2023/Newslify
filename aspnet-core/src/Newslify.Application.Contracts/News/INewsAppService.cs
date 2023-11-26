using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Newslify
{
    public interface INewsAppService : IApplicationService
    {
        Task<ICollection<NewsDto>> GetNewsAsync(string LanguageIntCode, int? amountNews, string? query);
    }
}

