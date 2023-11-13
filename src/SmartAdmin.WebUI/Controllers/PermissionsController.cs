using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Models;
using SmartAdmin.WebUI.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.WebUI.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class PermissionsController : Controller
    {
        private readonly IUserPermissionsService _permissionsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionsController(IUserPermissionsService permissionsService, UserManager<ApplicationUser> userManager)
        {
            _permissionsService = permissionsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userPermissionsViewModel = new List<UserPermissionsViewModel>();

            foreach (var user in users)
            {
                var permissions = await _permissionsService.GetUserPermissionsAsync(user.Id);
                userPermissionsViewModel.Add(new UserPermissionsViewModel
                {
                    User = user,
                    Permissions = permissions.ToList()
                });
            }

            return View(userPermissionsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPermission(string userId, string controllerName, string actionName)
        {
            var permission = new UserPermissionViewModel
            {
                UserId = userId,
                ControllerName = controllerName,
                ActionName = actionName,
                // Definir os valores de CanRead, CanWrite, etc.
            };

            await _permissionsService.AddPermissionAsync(permission);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public async Task<IActionResult> RemovePermission(Guid permissionId)
        //{
        //    var permission = await _context.UserPermissions.FindAsync(permissionId);

        //    if (permission != null)
        //    {
        //        await _permissionsService.RemovePermissionAsync(permission);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
