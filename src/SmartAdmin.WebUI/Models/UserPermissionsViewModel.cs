using System.Collections.Generic;

namespace SmartAdmin.WebUI.Models
{
    public class UserPermissionsViewModel
    {
        public ApplicationUser User { get; set; }
        public List<UserPermission> Permissions { get; set; }
    }
}
