using System;
using System.Collections.Generic;
using System.Text;
using Newslify.Localization;
using Volo.Abp.Application.Services;

namespace Newslify;

/* Inherit your application services from this class.
 */
public abstract class NewslifyAppService : ApplicationService
{
    protected NewslifyAppService()
    {
        LocalizationResource = typeof(NewslifyResource);
    }
}
