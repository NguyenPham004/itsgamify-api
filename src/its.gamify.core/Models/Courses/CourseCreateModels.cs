﻿using its.gamify.core.Models.CourseSections;
using its.gamify.domains.Enums;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Courses;

public class CourseCreateModels
{

    public string Title { get; set; } = string.Empty;
    [JsonPropertyName("classify")]
    public string CourseType { get; set; } = CourseTypeEnum.ALL.ToString();
    [JsonPropertyName("short_description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string LongDescription { get; set; } = string.Empty;
    [JsonPropertyName("thumbnail_image_id")]
    public Guid ThumbnailId { get; set; } = Guid.Empty;
    [JsonPropertyName("introduction_video_id")]
    public Guid IntroVideoId { get; set; } = Guid.Empty;
    public List<string> Tags { get; set; } = new();

    public List<string> Targets { get; set; } = [];
    [JsonPropertyName("requirement")]
    public string Requirements { get; set; } = string.Empty;
    [JsonPropertyName("department_id")]
    public Guid? DepartmentId { get; set; }
    [JsonPropertyName("category_id")]
    public Guid CategoryId { get; set; }
    public Guid QuarterId { get; set; }
    public bool IsOptional { get; set; } = false;
}


public class CourseUpdateModel : CourseCreateModels
{
    public Guid? Id { get; set; }
    [JsonPropertyName("current_step")]
    public string? Status { get; set; }
    [JsonPropertyName("drafted")]
    public bool? IsDraft { get; set; } = false;
    [JsonPropertyName("is_update_module")]
    public bool IsUpdateModule { get; set; } = false;
    [JsonPropertyName("modules")]
    public List<CourseSectionUpdateModel>? CourseSections { get; set; }
}

