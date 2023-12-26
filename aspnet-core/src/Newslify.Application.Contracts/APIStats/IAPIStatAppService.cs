using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
namespace Newslify.APILogs;

public interface IAPIStatAppService : IApplicationService
{
    Task<int> GetLogsAmount();
    Task<double> GetAverageAPIAccess();
    Task<(string, int)> GetTrendingTopic();
}