using Xunit;

namespace Study.Courses.EntityFrameworkCore;

[CollectionDefinition(CoursesTestConsts.CollectionDefinitionName)]
public class CoursesEntityFrameworkCoreCollection : ICollectionFixture<CoursesEntityFrameworkCoreFixture>
{

}
