﻿namespace its.gamify.domains.Enums;

public enum LessonType
{
    VIDEO,
    DOCUMENT,
    QUIZ,
    PRACTICE
}

public static class LESSON_TYPES
{
    public const string VIDEO = "video";
    public const string DOCUMENT = "article";
    public const string QUIZ = "quiz";
    public const string PRACTICE = "practice";

}


public static class PROGRESS_STATUS
{
    public const string IN_PROGRESS = "IN_PROGRESS";
    public const string COMPLETED = "COMPLETED";
}