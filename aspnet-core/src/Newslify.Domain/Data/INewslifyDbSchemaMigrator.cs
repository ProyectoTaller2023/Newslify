using System.Threading.Tasks;

namespace Newslify.Data;

public interface INewslifyDbSchemaMigrator
{
    Task MigrateAsync();
}
