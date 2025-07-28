namespace its.gamify.domains.Enums;

public enum CourseParticipationStatusEnum
{
    ENROLLED = 1,
    IN_PROGRESS = 2,
    COMPLETED = 3,
}
public enum CourseStatusEnum
{
    INITIAL,
    CONTENT,
    MATERIAL,
    CONFIRM,
    PUBLISHED
}
public enum CourseTypeEnum
{
    LEADERONLY,
    ALL,
    DEPARTMENTONLY
}

public static class COURSE_STATUS
{
    public const string INITIAL = "INITIAL";
    public const string CONTENT = "CONTENT";
    public const string MATERIAL = "MATERIAL";
    public const string CONFIRM = "CONFIRM";
    public const string PUBLISHED = "PUBLISHED";
}

public static class COURSE_TYPE
{
    public const string LEADERONLY = "LEADERONLY";
    public const string ALL = "ALL";
    public const string DEPARTMENTONLY = "DEPARTMENTONLY";
}

public static class COURSE_PARTICIPATION_STATUS
{
    public const string COMPLETED = "COMPLETED";
    public const string ENROLLED = "ENROLLED";
    public const string INPROGRESS = "IN_PROGRESS";
}

public static class COURSE_CLASSIFY
{
    public const string ALL = "ALL";
    public const string ENROLLED = "ENROLLED";
    public const string SAVED = "SAVED";
    public const string COMPLETED = "COMPLETED";

}