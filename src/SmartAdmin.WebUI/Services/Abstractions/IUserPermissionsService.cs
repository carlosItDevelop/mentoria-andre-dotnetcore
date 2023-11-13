using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Services.Abstractions
{
    public interface IUserPermissionsService
    {
        Task<IEnumerable<UserPermission>> GetUserPermissionsAsync(string userId);
        Task AddPermissionAsync(UserPermission permission);
        Task RemovePermissionAsync(UserPermission permission);
        Task<bool> HasPermissionAsync(string userId, string controllerName, string actionName);
        // Outros métodos conforme necessário
    }
}
