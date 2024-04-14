using Volo.Abp.Modularity;

namespace Study.Courses;

[DependsOn(
    typeof(CoursesDomainModule),
    typeof(CoursesTestBaseModule)
)]
public class CoursesDomainTestModule : AbpModule
{

}
