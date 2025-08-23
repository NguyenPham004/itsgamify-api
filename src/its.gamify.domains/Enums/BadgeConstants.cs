namespace its.gamify.domains.Enums;

public static class BadgeType
{
    public const string KNOWLEDGE_SEEKER = "KNOWLEDGE_SEEKER";
    public const string QUIZ_MASTER = "QUIZ_MASTER";
    public const string SKILL_BUILDER = "SKILL_BUILDER";
    public const string OUTSTANDING_ACHIEVEMENT = "OUTSTANDING_ACHIEVEMENT";
    public const string EXPLORER = "EXPLORER";
    public const string CERTIFICATE_HUNTER = "CERTIFICATE_HUNTER";
    public const string FIRST_VICTORY = "FIRST_VICTORY";
    public const string COMBO_MASTER = "COMBO_MASTER";
    public const string INVINCIBLE = "INVINCIBLE";
    public const string TOP_CHALLENGER = "TOP_CHALLENGER";

    private static readonly Dictionary<string, (string Title, string Description)> BadgeDetails =
        new()
        {
          {
              KNOWLEDGE_SEEKER,
              ("Kẻ Tìm Kiếm Tri Thức", "Hoàn thành 5 khóa học")
          },
          {
              QUIZ_MASTER,
              ("Bậc Thầy Trắc Nghiệm", "Đạt điểm tuyệt đối trong một bài kiểm tra")
          },
          {
              SKILL_BUILDER,
              ("Người Xây Dựng Kỹ Năng", "Nhận 3 chứng chỉ")
          },
          {
              OUTSTANDING_ACHIEVEMENT,
              ("Thành Tích Vượt Trội", "Top 5 học viên của phòng ban trong một quý")
          },
          {
              EXPLORER,
              ("Nhà Khám Phá", "Tham gia ít nhất 3 lĩnh vực khác nhau")
          },
          {
              CERTIFICATE_HUNTER,
              ("Thợ Săn Chứng Chỉ", "Nhận 10 chứng chỉ học tập")
          },
          {
              FIRST_VICTORY,
              ("Chiến Thắng Đầu Tiên", "Thắng trận đầu tiên")
          },
          {
              COMBO_MASTER,
              ("Cao Thủ Liên Hoàn", "Thắng 3 trận liên tiếp")
          },
          {
              INVINCIBLE,
              ("Bất Khả Chiến Bại", "Thắng 5 trận liên tiếp")
          },
          {
              TOP_CHALLENGER,
              ("Thách Đấu Đỉnh Cao", "Top 5 người chơi toàn công ty trong một quý")
          }
        };

    public static string GetTitleByType(string type)
    {
        return BadgeDetails.TryGetValue(type, out var details) ? details.Title : "Huy hiệu không xác định";
    }

    public static string GetDescriptionByType(string type)
    {
        return BadgeDetails.TryGetValue(type, out var details) ? details.Description : "Mô tả không xác định";
    }

    public static IEnumerable<string> GetAllBadgeTypes()
    {
        return BadgeDetails.Keys;
    }

    public static (string Title, string Description) GetBadgeDetailsByType(string type)
    {
        return BadgeDetails.TryGetValue(type, out var details)
            ? details
            : ("Huy hiệu không xác định", "Mô tả không xác định");
    }
}