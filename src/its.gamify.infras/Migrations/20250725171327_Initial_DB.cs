using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace its.gamify.infras.Migrations
{
    /// <inheritdoc />
    public partial class Initial_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseMetric",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    SaveCount = table.Column<int>(type: "integer", nullable: false),
                    CompletionCount = table.Column<int>(type: "integer", nullable: false),
                    ReviewCount = table.Column<int>(type: "integer", nullable: false),
                    StartRating = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMetric", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Extension = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadearBoard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadearBoard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quarter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalMark = table.Column<double>(type: "double precision", nullable: false),
                    PassedMark = table.Column<double>(type: "double precision", nullable: false),
                    TotalQuestions = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<double>(type: "double precision", nullable: false),
                    ChallengeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quiz_Challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    DurationInHours = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LongDescription = table.Column<string>(type: "text", nullable: false),
                    CourseType = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: false),
                    Targets = table.Column<List<string>>(type: "text[]", nullable: false),
                    Requirements = table.Column<string>(type: "text", nullable: false),
                    IntroVideo = table.Column<string>(type: "text", nullable: false),
                    ThumbnailImage = table.Column<string>(type: "text", nullable: false),
                    ThumbnailId = table.Column<Guid>(type: "uuid", nullable: false),
                    IntroVideoId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IsOptional = table.Column<bool>(type: "boolean", nullable: false),
                    QuarterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_Quarter_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    LeadearBoardId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_User_LeadearBoard_LeadearBoardId",
                        column: x => x.LeadearBoardId,
                        principalTable: "LeadearBoard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizResult_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OrderedNumber = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSection_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningMaterial_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningMaterial_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    OptionA = table.Column<string>(type: "text", nullable: false),
                    OptionB = table.Column<string>(type: "text", nullable: false),
                    OptionC = table.Column<string>(type: "text", nullable: false),
                    OptionD = table.Column<string>(type: "text", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "text", nullable: false),
                    Explanation = table.Column<string>(type: "text", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ClaimedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Badge_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeParticipation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ChallengeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeParticipation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipation_Challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipation_User_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseCollection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCollection_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCollection_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseParticipation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EnrolledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseParticipation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseParticipation_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseParticipation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Precedence = table.Column<int>(type: "integer", nullable: false),
                    IsNotified = table.Column<bool>(type: "boolean", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMetrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseParticipatedNum = table.Column<int>(type: "integer", nullable: false),
                    CourseCompletedNum = table.Column<int>(type: "integer", nullable: false),
                    ChallengeParticipateNum = table.Column<int>(type: "integer", nullable: false),
                    ChallengeAwardNum = table.Column<int>(type: "integer", nullable: false),
                    PointInQuarter = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuarterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMetrics_Quarter_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "Quarter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMetrics_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    DurationInMinutes = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ImageFiles = table.Column<string>(type: "json", nullable: true),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: true),
                    CourseSectionId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_CourseSection_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lesson_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizResultId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizAnswer_QuizResult_QuizResultId",
                        column: x => x.QuizResultId,
                        principalTable: "QuizResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Scrore = table.Column<double>(type: "double precision", nullable: false),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseParticipationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResult_CourseParticipation_CourseParticipationId",
                        column: x => x.CourseParticipationId,
                        principalTable: "CourseParticipation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseResult_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseResult_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    ReviewdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseParticipationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseReview_CourseParticipation_CourseParticipationId",
                        column: x => x.CourseParticipationId,
                        principalTable: "CourseParticipation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseReview_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LearningProgress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    LastAccessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VideoTimePosition = table.Column<double>(type: "double precision", nullable: true),
                    CourseParticipationId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizResultId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningProgress_CourseParticipation_CourseParticipationId",
                        column: x => x.CourseParticipationId,
                        principalTable: "CourseParticipation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningProgress_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningProgress_QuizResult_QuizResultId",
                        column: x => x.QuizResultId,
                        principalTable: "QuizResult",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PracticeTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticeTag_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3b72db68-b2c6-40d8-859e-b4996f8535a1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1199), "", false, "TRAININGSTAFF", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1200) },
                    { new Guid("620d170e-c32e-4443-b450-32848c1eb5e9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1162), "", false, "LEADER", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1163) },
                    { new Guid("71874fd3-1892-4d92-a77f-c85c0d16b8db"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(241), "", false, "EMPLOYEE", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(245) },
                    { new Guid("b002d347-66b9-4722-9547-5b2165abaa9f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1208), "", false, "ADMIN", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1209) },
                    { new Guid("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1204), "", false, "MANAGER", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 25, 17, 13, 26, 827, DateTimeKind.Utc).AddTicks(1204) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Badge_UserId",
                table: "Badge",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipation_ChallengeId",
                table: "ChallengeParticipation",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipation_EmployeeId",
                table: "ChallengeParticipation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CategoryId",
                table: "Course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_QuarterId",
                table: "Course",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCollection_CourseId",
                table: "CourseCollection",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCollection_UserId",
                table: "CourseCollection",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseParticipation_CourseId",
                table: "CourseParticipation",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseParticipation_UserId",
                table: "CourseParticipation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_CourseId",
                table: "CourseResult",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_CourseParticipationId",
                table: "CourseResult",
                column: "CourseParticipationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_UserId",
                table: "CourseResult",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReview_CourseId",
                table: "CourseReview",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseReview_CourseParticipationId",
                table: "CourseReview",
                column: "CourseParticipationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_CourseId",
                table: "CourseSection",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterial_CourseId",
                table: "LearningMaterial",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterial_FileId",
                table: "LearningMaterial",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_CourseParticipationId",
                table: "LearningProgress",
                column: "CourseParticipationId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_LessonId",
                table: "LearningProgress",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_QuizResultId",
                table: "LearningProgress",
                column: "QuizResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CourseSectionId",
                table: "Lesson",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_QuizId",
                table: "Lesson",
                column: "QuizId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeTag_LessonId",
                table: "PracticeTag",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CourseId",
                table: "Question",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_ChallengeId",
                table: "Quiz",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswer_QuestionId",
                table: "QuizAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswer_QuizResultId",
                table: "QuizAnswer",
                column: "QuizResultId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResult_QuizId",
                table: "QuizResult",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                table: "User",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LeadearBoardId",
                table: "User",
                column: "LeadearBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMetrics_QuarterId",
                table: "UserMetrics",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMetrics_UserId",
                table: "UserMetrics",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "ChallengeParticipation");

            migrationBuilder.DropTable(
                name: "CourseCollection");

            migrationBuilder.DropTable(
                name: "CourseMetric");

            migrationBuilder.DropTable(
                name: "CourseResult");

            migrationBuilder.DropTable(
                name: "CourseReview");

            migrationBuilder.DropTable(
                name: "LearningMaterial");

            migrationBuilder.DropTable(
                name: "LearningProgress");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PracticeTag");

            migrationBuilder.DropTable(
                name: "QuizAnswer");

            migrationBuilder.DropTable(
                name: "UserMetrics");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "CourseParticipation");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuizResult");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CourseSection");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "LeadearBoard");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Challenge");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Quarter");
        }
    }
}
