using Microsoft.AspNetCore.Identity;
using Polly;
using Study.Courses.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Study.Courses
{
    public class DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IIdentityRoleRepository _roleRepository;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IdentityRoleManager _roleManager;
        private readonly ILookupNormalizer _lookupNormalizer;
        private readonly IPermissionManager _permissionManager;

        public DataSeedContributor(IPermissionManager permissionManager,ILookupNormalizer lookupNormalizer,IIdentityRoleRepository roleRepository,IGuidGenerator guidGenerator, IdentityRoleManager roleManager)
        {
            _lookupNormalizer= lookupNormalizer;
            _guidGenerator = guidGenerator;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
            _permissionManager = permissionManager;

        }
        public async Task SeedAsync(DataSeedContext context)
        {
            await SeedInstructorRole(context);
            await SeedStudentRole(context);
        }

        private async Task SeedInstructorRole(DataSeedContext context) {

            Volo.Abp.Identity.IdentityRole instructorRole = await _roleRepository.FindByNormalizedNameAsync(_lookupNormalizer.NormalizeName(CouresesRoles.InstructorRole));
            if (instructorRole == null)
            {
                instructorRole = new Volo.Abp.Identity.IdentityRole(
                    _guidGenerator.Create(),
                    CouresesRoles.InstructorRole, context.TenantId)
                {
                    IsStatic = true,
                    IsPublic = true,
                    IsDefault = false,
                };
                (await _roleManager.CreateAsync(instructorRole)).CheckErrors();
            }

            var instructorRoles = (await _permissionManager.GetAllForRoleAsync("admin")).Where(x => x.Name.Contains("Students"));
            if (instructorRoles.Any())
            {
                foreach (var permission in instructorRoles)
                {
                    await _permissionManager.SetForRoleAsync(CouresesRoles.InstructorRole, permission.Name, true);
                }
            }
        }

        private async Task SeedStudentRole(DataSeedContext context)
        {

            Volo.Abp.Identity.IdentityRole studentRole = await _roleRepository.FindByNormalizedNameAsync(_lookupNormalizer.NormalizeName(CouresesRoles.StudentRole));
            if (studentRole == null)
            {
                studentRole = new Volo.Abp.Identity.IdentityRole(
                    _guidGenerator.Create(),
                    CouresesRoles.StudentRole, context.TenantId)
                {
                    IsStatic = true,
                    IsPublic = true,
                    IsDefault = true,
                };
                (await _roleManager.CreateAsync(studentRole)).CheckErrors();
            }
           var studentRoles= (await _permissionManager.GetAllForRoleAsync("admin")).Where(x => x.Name.Contains("Students"));
            if(studentRoles.Any())
            {
                foreach (var permission in studentRoles)
                {
                    await _permissionManager.SetForRoleAsync(CouresesRoles.StudentRole,permission.Name , true);
                }
            }
        }

    }
}
