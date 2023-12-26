
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Newslify.APILogs
{
    public class APIStatAppService: NewslifyAppService, IAPIStatAppService
    {
        private readonly IRepository<APILog, int> _APILogRepository;
        public APIStatAppService(IRepository<APILog, int> APILogRepository)
        {
            _APILogRepository = APILogRepository;
        }

        public async Task<int> GetLogsAmount()
        {
            var logs = await _APILogRepository.GetListAsync();
            return logs.Count;
        }

        public async Task<double> GetAverageAPIAccess()
        {
            var logs = await _APILogRepository.GetListAsync();
            var sum = 0.0;

            foreach (var log in logs)
            {
                var reqTime = log.EndTime - log.StartTime;
                sum += reqTime.TotalSeconds;
            }

            var averageInSecs = sum / logs.Count;
            return averageInSecs;
        }

        private (string, int) GetMaxFromDic(Dictionary<string, int> dic)
        {
            var max = int.MinValue; // Inicializar con el valor mínimo posible para int
            var maxValue = "";

            foreach (var item in dic)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    maxValue = item.Key;
                }
            }

            return (maxValue, max);
        }



        public async Task<(string,int)> GetTrendingTopic ()
        {
            var logs = await _APILogRepository.GetListAsync();
            var topicCount = new Dictionary<string, int> ();

            foreach (var log in logs)
            {
                if (topicCount.ContainsKey(log.Search.ToLower()))
                {
                    topicCount[log.Search.ToLower()]++;
                }
                else
                {
                    topicCount[log.Search.ToLower()] = 1;
                }
            }
            return GetMaxFromDic(topicCount);           
        }
    }
}
