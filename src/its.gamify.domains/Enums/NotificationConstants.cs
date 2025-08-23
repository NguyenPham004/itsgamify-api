namespace its.gamify.domains.Enums;

public static class NotificationType
{
    public const string COURSE_COMPLETED = "COURSE_COMPLETED";
    public const string POINTS_BONUS = "POINTS_BONUS";
    public const string REMIND_COURSE = "REMIND_COURSE";
    public const string NEW_BADGE = "NEW_BADGE";

    private static readonly Dictionary<string, (string Title, string Message)> NotificationDetails =
        new()
        {
           {
                COURSE_COMPLETED,
                ("Chúc mừng bạn đã hoàn thành khóa học", "Chúc mừng! Bạn đã hoàn thành khóa học.")
            },
            {
                POINTS_BONUS,
                ("Điểm thưởng hoàn thành khóa học", "Bạn vừa nhận được 1000 điểm cho quý này sau khi hoàn thành khóa học!")
            },
            {
                REMIND_COURSE,
                ("Nhắc nhở hoàn thành khóa học", "Bạn còn khóa học chưa hoàn thành. Hãy hoàn thành để nhận điểm thưởng!")
            },
            {
                NEW_BADGE,
                ("Chúc mừng bạn đã đạt danh hiệu mới", "Chúc mừng bạn đã đạt được danh hiệu mới!")
            }
        };


    public static string GetTitleByType(string type)
    {
        return NotificationDetails.TryGetValue(type, out var details) ? details.Title : "Thông báo";
    }

    public static string GetContentByType(string type)
    {
        return NotificationDetails.TryGetValue(type, out var details) ? details.Message : "Nội dung không xác định";
    }
}

