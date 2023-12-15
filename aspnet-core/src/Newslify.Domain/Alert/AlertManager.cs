using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;


namespace Newslify.Alerts
{
    public class AlertManager : DomainService
    {
        private readonly IRepository<Alert, int> _repository;
        public AlertManager(IRepository<Alert, int> repository)
        {
            _repository = repository;
        }

        public async Task<Alert> GetAlertAsync(int id)
        {
            var queryable = await _repository.WithDetailsAsync(a => a.User);
            var query = queryable.Where(a => a.Id == id);
            var alert = await AsyncExecuter.FirstOrDefaultAsync(query);
           
            return alert;
        }
    }
}