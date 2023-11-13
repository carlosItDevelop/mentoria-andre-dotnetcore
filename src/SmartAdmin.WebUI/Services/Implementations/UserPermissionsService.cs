using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Data;
using SmartAdmin.WebUI.Models;
using SmartAdmin.WebUI.Services.Abstractions;

namespace SmartAdmin.WebUI.Services.Implementations
{
    public class UserPermissionsService : IUserPermissionsService
    {
        private readonly ApplicationDbContext _context;

        public UserPermissionsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserPermissionViewModel>> GetUserPermissionsAsync(string userId)
        {
            return await _context.UserPermissions
                .Where(up => up.UserId == userId)
                .ToListAsync();
        }

        public async Task AddPermissionAsync(UserPermissionViewModel permission)
        {
            _context.UserPermissions.Add(permission);
            await _context.SaveChangesAsync();
        }

        public async Task RemovePermissionAsync(UserPermissionViewModel permission)
        {
            _context.UserPermissions.Remove(permission);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasPermissionAsync(string userId, string controllerName, string actionName)
        {
            return await _context.UserPermissions.AnyAsync(up =>
                up.UserId == userId &&
                up.ControllerName == controllerName &&
                up.ActionName == actionName);
        }

        // Implementar outros métodos conforme necessário
    }
}
