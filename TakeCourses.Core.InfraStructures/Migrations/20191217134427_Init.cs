using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeCourses.InfraStructures.DAL.SQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_AddressType",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddressTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EducationLevel",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LevelName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EducationLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmploymentType",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EmploymentTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmploymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Field",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FieldCode = table.Column<string>(nullable: true),
                    FieldName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Field", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PhoneType",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PhoneTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PhoneType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Term",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Term", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    NationCode = table.Column<string>(unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FatherName = table.Column<string>(maxLength: 30, nullable: true),
                    Addresses = table.Column<string>(nullable: true),
                    PhoneNumbers = table.Column<string>(nullable: true),
                    UserGroup = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Course",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CourseCode = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    CourseName = table.Column<string>(maxLength: 50, nullable: false),
                    FieldId = table.Column<short>(nullable: false),
                    UnitCount = table.Column<byte>(nullable: false),
                    UnitType = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Course_Tbl_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Tbl_Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    StudentCode = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    FieldId = table.Column<short>(nullable: false),
                    EducationLevelId = table.Column<byte>(nullable: false),
                    EnteringDate = table.Column<DateTime>(nullable: false),
                    GraduationDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Student_Tbl_EducationLevel_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "Tbl_EducationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Student_Tbl_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Tbl_Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Student_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    FieldId = table.Column<short>(nullable: false),
                    EducationLevelId = table.Column<byte>(nullable: false),
                    EmploymentCode = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    EmploymentDate = table.Column<DateTime>(nullable: false),
                    EmploymentTypeId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Teacher_Tbl_EducationLevel_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "Tbl_EducationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Teacher_Tbl_EmploymentType_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "Tbl_EmploymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Teacher_Tbl_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Tbl_Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Teacher_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Syllabus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CourseId = table.Column<short>(nullable: false),
                    TermOrder = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Categury = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PrerequisiteCourses = table.Column<string>(nullable: true),
                    NeededCourses = table.Column<string>(nullable: true),
                    RequiredPassedCount = table.Column<byte>(nullable: false),
                    ApplyEnteringDate = table.Column<DateTime>(nullable: false),
                    ApplyEndEnteringDate=table.Column<DateTime>(nullable:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Syllabus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Syllabus_Tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Tbl_Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_StudentCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    TermId = table.Column<int>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    RegisterStatus = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_StudentCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_StudentCourse_Tbl_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Tbl_Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_StudentCourse_Tbl_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Tbl_Term",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_TermCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TermId = table.Column<int>(nullable: false),
                    CourseId = table.Column<short>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    Capacity = table.Column<byte>(nullable: false),
                    PresentationDays = table.Column<string>(nullable: false),
                    TestDate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_TermCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_TermCourse_Tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Tbl_Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_TermCourse_Tbl_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Tbl_Teacher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_TermCourse_Tbl_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Tbl_Term",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_StudentCourseDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StudentCourseId = table.Column<int>(nullable: false),
                    TermCourseId = table.Column<int>(nullable: false),
                    TakenDate = table.Column<DateTime>(nullable: false),
                    Grade = table.Column<decimal>(nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_StudentCourseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_StudentCourseDetail_Tbl_StudentCourse_StudentCourseId",
                        column: x => x.StudentCourseId,
                        principalTable: "Tbl_StudentCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_StudentCourseDetail_Tbl_TermCourse_TermCourseId",
                        column: x => x.TermCourseId,
                        principalTable: "Tbl_TermCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tbl_AddressType",
                columns: new[] { "Id", "AddressTypeName", "IsDeleted" },
                values: new object[,]
                {
                    { (byte)1, "محل سکونت", false },
                    { (byte)2, "محل کار", false },
                    { (byte)3, "محل تحصیل", false }
                });

            migrationBuilder.InsertData(
                table: "Tbl_EducationLevel",
                columns: new[] { "Id", "IsDeleted", "LevelName" },
                values: new object[,]
                {
                    { (byte)1, false, "دیپلم" },
                    { (byte)2, false, "کاردانی" },
                    { (byte)3, false, "کارشناسی" },
                    { (byte)4, false, "کارشناسی ارشد" },
                    { (byte)5, false, "دکتری" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_EmploymentType",
                columns: new[] { "Id", "EmploymentTypeName", "IsDeleted" },
                values: new object[,]
                {
                    { (byte)4, "پیمانی", false },
                    { (byte)3, "رسمی", false },
                    { (byte)1, "هیئت علمی رسمی", false },
                    { (byte)2, "هیئت علمی پیمانی", false }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Field",
                columns: new[] { "Id", "FieldCode", "FieldName", "IsDeleted" },
                values: new object[,]
                {
                    { (short)1, null, "ریاضی", false },
                    { (short)2, null, "کامپیوتر", false },
                    { (short)3, null, "برق", false },
                    { (short)4, null, "مخابرات", false },
                    { (short)5, null, "الکترونیک", false }
                });

            migrationBuilder.InsertData(
                table: "Tbl_PhoneType",
                columns: new[] { "Id", "IsDeleted", "PhoneTypeName" },
                values: new object[,]
                {
                    { (byte)4, false, "فکس" },
                    { (byte)1, false, "تلفن محل سکونت" },
                    { (byte)2, false, "تلفن محل کار" },
                    { (byte)3, false, "موبایل" }
                });

            migrationBuilder.InsertData(
                table: "Tbl_User",
                columns: new[] { "Id", "Addresses", "BirthDate", "FatherName", "FirstName", "IsActive", "IsDeleted", "LastName", "NationCode", "Password", "PhoneNumbers", "UserGroup", "UserName" },
                values: new object[] { 1, null, new DateTime(1987, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mohsen", true, false, "Yousefiyan", "1190005646", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, "Admin", "mohsen" });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Course_FieldId",
                table: "Tbl_Course",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Student_EducationLevelId",
                table: "Tbl_Student",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Student_FieldId",
                table: "Tbl_Student",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_StdCode",
                table: "Tbl_Student",
                column: "StudentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Student_UserId",
                table: "Tbl_Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentCourse_StudentId",
                table: "Tbl_StudentCourse",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentCourse_TermId",
                table: "Tbl_StudentCourse",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentCourseDetail_StudentCourseId",
                table: "Tbl_StudentCourseDetail",
                column: "StudentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentCourseDetail_TermCourseId",
                table: "Tbl_StudentCourseDetail",
                column: "TermCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Syllabus_CourseId",
                table: "Tbl_Syllabus",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Teacher_EducationLevelId",
                table: "Tbl_Teacher",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpCode",
                table: "Tbl_Teacher",
                column: "EmploymentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Teacher_EmploymentTypeId",
                table: "Tbl_Teacher",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Teacher_FieldId",
                table: "Tbl_Teacher",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Teacher_UserId",
                table: "Tbl_Teacher",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TermCourse_CourseId",
                table: "Tbl_TermCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TermCourse_TeacherId",
                table: "Tbl_TermCourse",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_TermCourse_TermId",
                table: "Tbl_TermCourse",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_NationCode",
                table: "Tbl_User",
                column: "NationCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserName",
                table: "Tbl_User",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_AddressType");

            migrationBuilder.DropTable(
                name: "Tbl_PhoneType");

            migrationBuilder.DropTable(
                name: "Tbl_StudentCourseDetail");

            migrationBuilder.DropTable(
                name: "Tbl_Syllabus");

            migrationBuilder.DropTable(
                name: "Tbl_StudentCourse");

            migrationBuilder.DropTable(
                name: "Tbl_TermCourse");

            migrationBuilder.DropTable(
                name: "Tbl_Student");

            migrationBuilder.DropTable(
                name: "Tbl_Course");

            migrationBuilder.DropTable(
                name: "Tbl_Teacher");

            migrationBuilder.DropTable(
                name: "Tbl_Term");

            migrationBuilder.DropTable(
                name: "Tbl_EducationLevel");

            migrationBuilder.DropTable(
                name: "Tbl_EmploymentType");

            migrationBuilder.DropTable(
                name: "Tbl_Field");

            migrationBuilder.DropTable(
                name: "Tbl_User");
        }
    }
}
