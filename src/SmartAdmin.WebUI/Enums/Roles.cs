using System.ComponentModel;

namespace SmartAdmin.WebUI.Enums
{
    public enum Roles
    {
        [Description("SuperAdmin")]SuperAdmin,
        [Description("Admin")] Admin,
        [Description("Moderator")] Moderator,
        [Description("Basic")] Basic
    }
}
