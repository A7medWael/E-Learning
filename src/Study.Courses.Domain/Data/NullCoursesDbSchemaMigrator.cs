using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Study.Courses.Data;

/* This is used if database provider does't define
 * ICoursesDbSchemaMigrator implementation.
 */
public class NullCoursesDbSchemaMigrator : ICoursesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
