using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Newslify;

[Dependency(ReplaceServices = true)]
public class NewslifyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Newslify";
}
