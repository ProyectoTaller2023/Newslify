using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.BackgroundWorkers;
using System.Threading.Tasks;
using Volo.Abp;
using Newslify.BackgroundWorkers;

namespace Newslify;

[DependsOn(
    typeof(NewslifyDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(NewslifyApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]

[DependsOn(typeof(AbpBackgroundWorkersModule))]
public class NewslifyApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<NewslifyApplicationModule>();
        });

        //se registra el servicio de noticias. Deberia registrarse solo, pero como me dio error lo incorporo aca
        context.Services.AddTransient<INewsAPI, HandlerNewsAPI>();
    }

    public override async Task OnApplicationInitializationAsync(
        ApplicationInitializationContext context)
    {
        await context.AddBackgroundWorkerAsync<NotificationWorker>();
    }
}
