using Newslify.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Newslify.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NewslifyEntityFrameworkCoreModule),
    typeof(NewslifyApplicationContractsModule)
    )]
public class NewslifyDbMigratorModule : AbpModule
{
}
