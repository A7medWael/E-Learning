namespace Study.Courses.Permissions;

public static class CoursesPermissions
{
    public static class Subject
    {
    public const string  Default = "Subjects";
    public const string View = Default + ".view";
    public const string Edit = Default + ".edit";
    public const string Create = Default + ".create";
    public const string Update = Default + ".update";
    public const string Delete = Default + ".delete";
    }

    public static class Instructor
    {
    public const string Default = "Instructors";
    public const string View = Default + ".view";
    public const string Edit = Default + ".create";
    public const string Create = Default + ".edit";
    public const string Update = Default + ".update";
    public const string Delete = Default + ".delete";
    }

    //public static class Student
    //{
    //public const string Default = "Students";
    //public const string View = Default + ".view";
    //public const string Edit = Default + ".create";
    //public const string Create = Default + ".edit";
    //public const string Update = Default + ".update";
    //public const string Delete = Default + ".delete";
    //}

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
