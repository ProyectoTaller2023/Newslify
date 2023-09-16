using Newslify.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Newslify;

[DependsOn(
    typeof(NewslifyEntityFrameworkCoreTestModule)
    )]
public class NewslifyDomainTestModule : AbpModule
{

}
