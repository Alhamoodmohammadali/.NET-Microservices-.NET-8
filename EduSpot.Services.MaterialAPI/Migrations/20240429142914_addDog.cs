using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduSpot.Services.MaterialAPI.Migrations
{
    /// <inheritdoc />
    public partial class addDog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "ArbicName", "CountHours", "Description", "ImageLocalPath", "ImageUrl", "MajorId", "Name", "PdfLocalPath", "PdfUrl", "ShortCut" },
                values: new object[,]
                {
                    { 24, "مهارات الحاسوب", 4, "Description", null, "https://placehold.co/603x403", 2, "Computer Skills", null, null, "GBS101" },
                    { 25, "مقدمة في البرمجة", 4, "Description", null, "https://placehold.co/603x403", 2, "Introduction to Programming", null, null, "IPG101" },
                    { 26, "مقدمة في التعليم الإلكتروني", 4, "Description", null, "https://placehold.co/603x403", 2, "Introduction on-Line Education", null, null, "GBS103" },
                    { 27, "التحليل الرياضي ", 5, "Description", null, "https://placehold.co/603x403", 2, "Mathe matical Analysls", null, null, "GMA101" },
                    { 28, "مقدمة في نمذجة المعطيات", 4, "Description", null, "https://placehold.co/603x403", 2, "Introduction to Data Modeling", null, null, "IIS101" },
                    { 29, "تقانات التجارة الإلكترونية ", 5, "Description", null, "https://placehold.co/603x403", 2, "E-Commerce Technologles", null, null, "IWB101" },
                    { 30, "البرمجة الإجرائية", 5, "Description", null, "https://placehold.co/603x403", 2, "Procedural Programming", null, null, "IPG202" },
                    { 31, "مقدمة في الشبكات", 5, "Description", null, "https://placehold.co/603x403", 2, "Introduction to Networks", null, null, "INT101" },
                    { 32, "مقدمة في نظم التشغيل", 5, "Description", null, "https://placehold.co/603x403", 2, "Introduction to Operating Systems", null, null, "IOS101" },
                    { 33, "إلكترونيات رقمية", 5, "Description", null, "https://placehold.co/603x403", 2, "Digital Electronics", null, null, "GDE101" },
                    { 34, "تصميم وبنيان قواعد المعطيات ", 5, "Description", null, "https://placehold.co/603x403", 2, "Database Archltecture and Design", null, null, "IIS201" },
                    { 35, "تحضير السيرة المهنية", 3, "Description", null, "https://placehold.co/603x403", 2, "Career Preparation", null, null, "GBS102" },
                    { 36, "تصميم وتطوير تطبيقات الويب", 6, "Description", null, "https://placehold.co/603x403", 2, "Web Application Development and Design", null, null, "IWB201" },
                    { 37, "نظم التشغيل الشبكية ", 5, "Description", null, "https://placehold.co/603x403", 2, "Network Operating System", null, null, "IOS201" },
                    { 38, "البرمجة مقادة بالأحداث", 5, "Description", null, "https://placehold.co/603x403", 2, "Event Driven Programming", null, null, "IPG201" },
                    { 39, "التصميم والبرمجة غرضية التوجه", 6, "Description", null, "https://placehold.co/603x403", 2, "Object Oriented Programming", null, null, "IPG203" },
                    { 40, "البرمجة المتقدمة بلغة SQL", 6, "Description", null, "https://placehold.co/603x403", 2, "Advanced SQL Programming", null, null, "IIS202" },
                    { 41, "منصة ويندز", 5, "Description", null, "https://placehold.co/603x403", 2, "windows Platform", null, null, "IOS202" },
                    { 42, "منصة لينوكس", 6, "Description", null, "https://placehold.co/603x403", 2, "Linux Platform ", null, null, "IOS203" },
                    { 43, "إدارة قواعد بيانات", 6, "Description", null, "https://placehold.co/603x403", 2, "MS-SQL Server Administration ", null, null, "IIS303" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 43);
        }
    }
}
