using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;

namespace Study.Courses.Adminstration
{
    [Authorize]
    public class AdminstrationAppService:ApplicationService,ITransientDependency
    {
        private readonly IPermissionManager _permissionManager;

        public AdminstrationAppService(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }

        public async Task GrantRolePermissionAsync(
            string roleName, string permission)
        {
            await _permissionManager
                .SetForRoleAsync(roleName, permission, true);
        }

        public async Task<ICurrentUser> GetCurrentUser()
        {
            return CurrentUser;
                
        }

    }
}
