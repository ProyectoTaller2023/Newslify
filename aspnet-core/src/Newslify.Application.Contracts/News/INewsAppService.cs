using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

    public interface INewsAppService : IApplicationService
    {
        Task<string> GetNewsAsync(string LanguageIntCode, int amountNews);
    }


