using Volo.Abp.Settings;

namespace Newslify.Settings;

public class NewslifySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NewslifySettings.MySetting1));
    }
}
