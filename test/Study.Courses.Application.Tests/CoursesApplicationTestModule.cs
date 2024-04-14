using Volo.Abp.Modularity;

namespace Study.Courses;

[DependsOn(
    typeof(CoursesApplicationModule),
    typeof(CoursesDomainTestModule)
)]
public class CoursesApplicationTestModule : AbpModule
{

}
