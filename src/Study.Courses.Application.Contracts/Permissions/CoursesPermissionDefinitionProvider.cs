using Study.Courses.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Study.Courses.Permissions;

public class CoursesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var instructorsGroup = context.AddGroup(CoursesPermissions.Instructor.Default, L("Permission:Instructors"));
  
        var instructorsPermission = instructorsGroup.AddPermission(CoursesPermissions.Instructor.Default, L("Permission:Instructors"));
        instructorsPermission.AddChild(CoursesPermissions.Instructor.Create, L("Permission:Instructors.Create"));
        instructorsPermission.AddChild(CoursesPermissions.Instructor.Edit, L("Permission:Instructors.Edit"));
        instructorsPermission.AddChild(CoursesPermissions.Instructor.Delete, L("Permission:Instructors.Delete"));
        instructorsPermission.AddChild(CoursesPermissions.Instructor.View, L("Permission:Instructors.View"));



        //var studentsGroup = context.AddGroup(CoursesPermissions.Student.Default, L("Permission:Students"));

        //var studentsPermission = studentsGroup.AddPermission(CoursesPermissions.Student.Default, L("Permission:Students"));
        //studentsPermission.AddChild(CoursesPermissions.Student.Create, L("Permission:Students.Create"));
        //studentsPermission.AddChild(CoursesPermissions.Student.Edit, L("Permission:Students.Edit"));
        //studentsPermission.AddChild(CoursesPermissions.Student.Delete, L("Permission:Students.Delete"));



        var subjectsGroup = context.AddGroup(CoursesPermissions.Subject.Default, L("Permission:Subjects"));

        var subjectsPermission = subjectsGroup.AddPermission(CoursesPermissions.Subject.Default, L("Permission:Subjects"));
        subjectsPermission.AddChild(CoursesPermissions.Subject.Create, L("Permission:Subjects.Create"));
        subjectsPermission.AddChild(CoursesPermissions.Subject.Edit, L("Permission:Subjects.Edit"));
        subjectsPermission.AddChild(CoursesPermissions.Subject.Delete, L("Permission:Subjects.Delete"));
        subjectsPermission.AddChild(CoursesPermissions.Subject.View, L("Permission:Subjects.View"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CoursesResource>(name);
    }
}
