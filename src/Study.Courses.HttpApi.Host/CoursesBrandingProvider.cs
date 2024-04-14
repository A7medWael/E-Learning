using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Study.Courses;

[Dependency(ReplaceServices = true)]
public class CoursesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Courses";
}
