using Study.Courses.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Study.Courses.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CoursesEntityFrameworkCoreModule),
    typeof(CoursesApplicationContractsModule)
    )]
public class CoursesDbMigratorModule : AbpModule
{
}
