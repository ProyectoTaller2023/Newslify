using System;
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

        public async Task<APILog> Create(string search, DateTime StartRequestTime, DateTime EndRequestTime, Volo.Abp.Identity.IdentityUser User)
        {
            var APILog = new APILog { Search = search, StartTime = StartRequestTime, EndTime = EndRequestTime , User = User};
            await _repository.InsertAsync(APILog);
            return APILog;  
        }
    }
}