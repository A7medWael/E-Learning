using Study.Courses.Samples;
using Xunit;

namespace Study.Courses.EntityFrameworkCore.Applications;

[Collection(CoursesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CoursesEntityFrameworkCoreTestModule>
{

}
