using Newslify.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Newslify.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NewslifyController : AbpControllerBase
{
    protected NewslifyController()
    {
        LocalizationResource = typeof(NewslifyResource);
    }
}
