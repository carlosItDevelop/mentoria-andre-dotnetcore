using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Services.Abstractions
{
    public interface IUserPermissionsService
    {
        Task<IEnumerable<UserPermissionViewModel>> GetUserPermissionsAsync(string userId);
        Task AddPermissionAsync(UserPermissionViewModel permission);
        Task RemovePermissionAsync(UserPermissionViewModel permission);
        Task<bool> HasPermissionAsync(string userId, string controllerName, string actionName);
        // Outros métodos conforme necessário
    }
}
