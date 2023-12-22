using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;


namespace Newslify.APILogs
{
    public class APILogManager : DomainService
    {
        private readonly IRepository<APILog, int> _repository;
        public APILogManager(IRepository<APILog, int> repository)
        {
            _repository = repository;
        }

        public async Task<APILog> Create(string search)
        {
            var APILog = new APILog{Search=search};
            await _repository.InsertAsync(APILog);
            return APILog;
        
        }

        public async Task<APILog> Update(APILog ApiLog)
        {
            var ApiLogUpdated = await _repository.UpdateAsync(ApiLog);
            return ApiLogUpdated;
        }
    }
}