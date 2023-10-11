using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Newslify.SavedNews
{
    public interface ISavedNewsAppService : IApplicationService
    {
        Task<ICollection<SavedNewDto>> GetSavedNewsAsync();
    }
}