﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Study.Courses.Registeration;
using Study.Courses.Students;
using Study.Courses.Subjects;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Emailing;
using Volo.Abp.Account.Localization;
using Volo.Abp.Account.Settings;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Settings;

namespace Study.Courses.Account
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IAccountAppService), typeof(AccountAppService), typeof(RegisterationAppService))]
    public class RegisterationAppService : AccountAppService
    {
        protected IdentityRoleManager _roleManager;
        protected IRepository<Student, Guid> _studentRepository;
        //protected IIdentityRoleRepository RoleRepository { get; }
        //protected IdentityUserManager UserManager { get; }
        //protected IAccountEmailer AccountEmailer { get; }
        //protected IdentitySecurityLogManager IdentitySecurityLogManager { get; }
        //protected IOptions<IdentityOptions> IdentityOptions { get; }

        public RegisterationAppService(
            IRepository<Student, Guid> studentRepository,
            IdentityUserManager userManager,
            IIdentityRoleRepository roleRepository,
            IAccountEmailer accountEmailer,
            IdentitySecurityLogManager identitySecurityLogManager,
            IOptions<IdentityOptions> identityOptions, IdentityRoleManager roleManager) : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
        {
            _roleManager = roleManager;
            //RoleRepository = roleRepository;
            //AccountEmailer = accountEmailer;
            //IdentitySecurityLogManager = identitySecurityLogManager;
            //UserManager = userManager;
            //IdentityOptions = identityOptions;
            _studentRepository = studentRepository;
            LocalizationResource = typeof(AccountResource);
        }

        //public override async Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        //{
        //    await CheckSelfRegistrationAsync();

        //    await IdentityOptions.SetAsync();

        //    var user = new IdentityUser(GuidGenerator.Create(), input.UserName, input.EmailAddress, CurrentTenant.Id);

        //    input.MapExtraPropertiesTo(user);

        //    (await UserManager.CreateAsync(user, input.Password)).CheckErrors();

        //    await UserManager.SetEmailAsync(user, input.EmailAddress);
        //    await UserManager.AddDefaultRolesAsync(user);

        //    return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
        //}
        public  async Task<IdentityUserDto> StudentRegisterAsync(StudentRegisterDto input)
        {
            await CheckSelfRegistrationAsync();

            await IdentityOptions.SetAsync();

            var user = new Volo.Abp.Identity.IdentityUser(GuidGenerator.Create(), input.UserName, input.EmailAddress, CurrentTenant.Id) { Name=input.Name};

            input.MapExtraPropertiesTo(user);

            (await UserManager.CreateAsync(user, input.Password)).CheckErrors();

            await UserManager.SetEmailAsync(user, input.EmailAddress);
            await UserManager.AddDefaultRolesAsync(user);
            Student student = new Student()
            {
                User = user,
                Subjects = new List<Subject> { },
                Name = input.Name,
                
            };
            await _studentRepository.InsertAsync(student);

            return ObjectMapper.Map<Volo.Abp.Identity.IdentityUser, IdentityUserDto>(user);
        }
        //public override async Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
        //{
        //    var user = await GetUserByEmailAsync(input.Email);
        //    var resetToken = await UserManager.GeneratePasswordResetTokenAsync(user);
        //    await AccountEmailer.SendPasswordResetLinkAsync(user, resetToken, input.AppName, input.ReturnUrl, input.ReturnUrlHash);
        //}

        //public override async Task<bool> VerifyPasswordResetTokenAsync(VerifyPasswordResetTokenInput input)
        //{
        //    var user = await UserManager.GetByIdAsync(input.UserId);
        //    return await UserManager.VerifyUserTokenAsync(
        //        user,
        //        UserManager.Options.Tokens.PasswordResetTokenProvider,
        //        UserManager<IdentityUser>.ResetPasswordTokenPurpose,
        //        input.ResetToken);
        //}

        //public override async Task ResetPasswordAsync(ResetPasswordDto input)
        //{
        //    await IdentityOptions.SetAsync();

        //    var user = await UserManager.GetByIdAsync(input.UserId);
        //    (await UserManager.ResetPasswordAsync(user, input.ResetToken, input.Password)).CheckErrors();

        //    await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
        //    {
        //        Identity = IdentitySecurityLogIdentityConsts.Identity,
        //        Action = IdentitySecurityLogActionConsts.ChangePassword
        //    });
        //}

        //protected override async Task<IdentityUser> GetUserByEmailAsync(string email)
        //{
        //    var user = await UserManager.FindByEmailAsync(email);
        //    if (user == null)
        //    {
        //        throw new UserFriendlyException(L["Volo.Account:InvalidEmailAddress", email]);
        //    }

        //    return user;
        //}

        //protected virtual async Task CheckSelfRegistrationAsync()
        //{
        //    if (!await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled))
        //    {
        //        throw new UserFriendlyException(L["SelfRegistrationDisabledMessage"]);
        //    }
        //}
    }
}