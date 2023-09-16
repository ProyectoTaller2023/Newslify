using Volo.Abp.Modularity;

namespace Newslify;

[DependsOn(
    typeof(NewslifyApplicationModule),
    typeof(NewslifyDomainTestModule)
    )]
public class NewslifyApplicationTestModule : AbpModule
{

}
