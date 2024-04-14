using System;
using System.Collections.Generic;
using System.Text;
using Study.Courses.Localization;
using Volo.Abp.Application.Services;

namespace Study.Courses;

/* Inherit your application services from this class.
 */
public abstract class CoursesAppService : ApplicationService
{
    protected CoursesAppService()
    {
        LocalizationResource = typeof(CoursesResource);
    }
}
