using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Study.Courses.Data;
using Volo.Abp.DependencyInjection;

namespace Study.Courses.EntityFrameworkCore;

public class EntityFrameworkCoreCoursesDbSchemaMigrator
    : ICoursesDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCoursesDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the CoursesDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CoursesDbContext>()
            .Database
            .MigrateAsync();
    }
}
