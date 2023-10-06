using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Newslify.LogReadNews
{
    public interface ILogReadNewAppService : IApplicationService
    {
        Task<ICollection<LogReadNewDto>> GetLogReadNewsAsync();
    }
}