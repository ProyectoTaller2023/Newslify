using Newslify.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Newslify.Permissions;

public class NewslifyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NewslifyPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NewslifyPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NewslifyResource>(name);
    }
}
