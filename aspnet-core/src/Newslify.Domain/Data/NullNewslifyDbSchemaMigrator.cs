using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Newslify.Data;

/* This is used if database provider does't define
 * INewslifyDbSchemaMigrator implementation.
 */
public class NullNewslifyDbSchemaMigrator : INewslifyDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
