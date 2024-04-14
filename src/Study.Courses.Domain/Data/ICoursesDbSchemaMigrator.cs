using System.Threading.Tasks;

namespace Study.Courses.Data;

public interface ICoursesDbSchemaMigrator
{
    Task MigrateAsync();
}
