using Volo.Abp.Modularity;

namespace Study.Courses;

/* Inherit from this class for your domain layer tests. */
public abstract class CoursesDomainTestBase<TStartupModule> : CoursesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
