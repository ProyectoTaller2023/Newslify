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

        private TrendingTopicResponse GetMaxFromDic(Dictionary<string, int> dic)
        {
            var tuplaResponse = new TrendingTopicResponse{max=int.MinValue, maxValue=""}; 
            
            foreach (var item in dic)
            {
                if (item.Value > tuplaResponse.max)
                {
                    tuplaResponse.max = item.Value;
                    tuplaResponse.maxValue = item.Key;
                }
            }

            return tuplaResponse;
        }

        public async Task<TrendingTopicResponse> GetTrendingTopic()
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
            var result = GetMaxFromDic(topicCount);
            return result;           
        }

        public async Task<double> GetPercentageSuccessRequests()
        {
            var logs = await _APILogRepository.GetListAsync();
            int amountErrors = 0;

            foreach (var log in logs)
            {
                if (log.ErrorCode == 1) {
                    amountErrors++;
                }
            }

            double percentage = (1 - ((double)amountErrors / logs.Count)) * 100;

            return percentage;
        }
    }
}
