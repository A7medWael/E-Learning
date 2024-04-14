using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using Volo.Abp.SettingManagement;

namespace Study.Courses
{
    public class CustomSwaggerFilter : IDocumentFilter
    {


        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
        swaggerDoc.Paths.Where(x=>x.Key.ToLowerInvariant().StartsWith("/api/abp")).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        swaggerDoc.Paths.Where(x=>x.Key.ToLowerInvariant().StartsWith("/api/app/registeration/register")).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        swaggerDoc.Paths.Where(x=>x.Key.ToLowerInvariant().StartsWith("/api/account") && !( x.Key.ToLowerInvariant().StartsWith("/api/account/log")|| x.Key.ToLowerInvariant().StartsWith("/api/account/check"))).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        swaggerDoc.Paths.Where(x =>x.Key.ToLowerInvariant().StartsWith("/api/setting-management/emailing")).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        swaggerDoc.Paths.Where(x =>x.Key.ToLowerInvariant().StartsWith("/api/feature-management")).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        swaggerDoc.Paths.Where(x =>x.Key.ToLowerInvariant().StartsWith("/api/setting-management/timezone")).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        swaggerDoc.Paths.Where(x =>x.Key.ToLowerInvariant().StartsWith("/api/multi-tenancy/")).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        swaggerDoc.Paths.Where(x =>x.Key.ToLowerInvariant().StartsWith("identity/users/lookup/search")).ToList().ForEach(x=>swaggerDoc.Paths.Remove(x.Key));
        }
    }
}