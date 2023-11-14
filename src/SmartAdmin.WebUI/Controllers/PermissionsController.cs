using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Data;
using SmartAdmin.WebUI.Models;
using SmartAdmin.WebUI.Services.Abstractions;

namespace SmartAdmin.WebUI.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class PermissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserPermissionsService _permissionsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionsController(IUserPermissionsService permissionsService, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _permissionsService = permissionsService;
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userPermissionsViewModelList = new List<UserPermissionsViewModel>();

            foreach (var user in users)
            {
                var permissions = await _permissionsService.GetUserPermissionsAsync(user.Id);
                userPermissionsViewModelList.Add(new UserPermissionsViewModel
                {
                    User = user,
                    Permissions = permissions.ToList()
                });
            }

            return View(userPermissionsViewModelList);
        }


        [HttpPost]
        public async Task<IActionResult> AddPermission(string userId, string controllerName, string actionName, bool canRead, bool canWrite, bool canDelete, bool canAccessAll)
        {
            var permission = new UserPermission
            {
                UserId = userId,
                ControllerName = controllerName,
                ActionName = actionName,
                CanRead = canRead,
                CanWrite = canWrite,
                CanDelete = canDelete,
                CanAccessAll = canAccessAll
            };

            await _permissionsService.AddPermissionAsync(permission);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePermission(Guid permissionId, bool canRead, bool canWrite, bool canDelete, bool canAccessAll)
        {
            // Lógica para atualizar a permissão
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public async Task<IActionResult> RemovePermission(Guid permissionId)
        {
            var permission = await _context.UserPermissions
                                          .FirstOrDefaultAsync(p => p.Id == permissionId);

            if (permission != null)
            {
                await _permissionsService.RemovePermissionAsync(permission);
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
