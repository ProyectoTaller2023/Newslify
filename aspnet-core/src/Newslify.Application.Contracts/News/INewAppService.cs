using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Newslify.News
{
    public interface INewAppService : IApplicationService
    {
        Task<ICollection<NewDto>> GetNewsAsync();
    }
}