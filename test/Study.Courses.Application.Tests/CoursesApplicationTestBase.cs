using Volo.Abp.Modularity;

namespace Study.Courses;

public abstract class CoursesApplicationTestBase<TStartupModule> : CoursesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
