using Study.Courses.Samples;
using Xunit;

namespace Study.Courses.EntityFrameworkCore.Domains;

[Collection(CoursesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CoursesEntityFrameworkCoreTestModule>
{

}
