using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduSpot.Services.MaterialAPI.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "ArbicName", "CountHours", "Description", "ImageLocalPath", "ImageUrl", "MajorId", "Name", "PdfLocalPath", "PdfUrl", "ShortCut" },
                values: new object[,]
                {
                    { 1, "مهارات الحاسوب", 4, "Description", null, "https://placehold.co/603x403", 1, "Computer Skills", null, null, "GBS101" },
                    { 2, "مقدمة في البرمجة", 4, "Description", null, "https://placehold.co/603x403", 1, "Introduction to Programming", null, null, "IPG101" },
                    { 3, "مقدمة في التعليم الإلكتروني", 4, "Description", null, "https://placehold.co/603x403", 1, "Introduction on-Line Education", null, null, "GBS103" },
                    { 4, "التحليل الرياضي ", 5, "Description", null, "https://placehold.co/603x403", 1, "Mathe matical Analysls", null, null, "GMA101" },
                    { 5, "مقدمة في نمذجة المعطيات", 4, "Description", null, "https://placehold.co/603x403", 1, "Introduction to Data Modeling", null, null, "IIS101" },
                    { 6, "تقانات التجارة الإلكترونية ", 5, "Description", null, "https://placehold.co/603x403", 1, "E-Commerce Technologles", null, null, "IWB101" },
                    { 7, "البرمجة الإجرائية", 5, "Description", null, "https://placehold.co/603x403", 1, "Procedural Programming", null, null, "IPG202" },
                    { 8, "مقدمة في الشبكات", 5, "Description", null, "https://placehold.co/603x403", 1, "Introduction to Networks", null, null, "INT101" },
                    { 9, "مقدمة في نظم التشغيل", 5, "Description", null, "https://placehold.co/603x403", 1, "Introduction to Operating Systems", null, null, "IOS101" },
                    { 10, "إلكترونيات رقمية", 5, "Description", null, "https://placehold.co/603x403", 1, "Digital Electronics", null, null, "GDE101" },
                    { 11, "تصميم وبنيان قواعد المعطيات ", 5, "Description", null, "https://placehold.co/603x403", 1, "Database Archltecture and Design", null, null, "IIS201" },
                    { 12, "تحضير السيرة المهنية", 3, "Description", null, "https://placehold.co/603x403", 1, "Career Preparation", null, null, "GBS102" },
                    { 13, "تصميم وتطوير تطبيقات الويب", 6, "Description", null, "https://placehold.co/603x403", 1, "Web Application Development and Design", null, null, "IWB201" },
                    { 14, "نظم التشغيل الشبكية ", 5, "Description", null, "https://placehold.co/603x403", 1, "Network Operating System", null, null, "IOS201" },
                    { 15, "البرمجة مقادة بالأحداث", 5, "Description", null, "https://placehold.co/603x403", 1, "Event Driven Programming", null, null, "IPG201" },
                    { 16, "التصميم والبرمجة غرضية التوجه", 6, "Description", null, "https://placehold.co/603x403", 1, "Object Oriented Programming", null, null, "IPG203" },
                    { 17, "البرمجة المتقدمة بلغة SQL", 6, "Description", null, "https://placehold.co/603x403", 1, "Advanced SQL Programming", null, null, "IIS202" },
                    { 18, "منصة ويندز", 5, "Description", null, "https://placehold.co/603x403", 1, "windows Platform", null, null, "IOS202" },
                    { 19, "منصة لينوكس", 6, "Description", null, "https://placehold.co/603x403", 1, "Linux Platform ", null, null, "IOS203" },
                    { 20, "إدارة قواعد بيانات", 6, "Description", null, "https://placehold.co/603x403", 1, "MS-SQL Server Administration ", null, null, "IIS303" },
                    { 21, "إدارة قواعد بيانات Oracle", 6, "Description", null, "https://placehold.co/603x403", 1, "Oracle Database Administration ", null, null, "IIS203" },
                    { 22, "برمجة التطبيقات النقالة", 6, "Description", null, "https://placehold.co/603x403", 1, "Mobile Programming", null, null, "IPG204" },
                    { 23, "مشروع", 12, "Description", null, "https://placehold.co/603x403", 1, "TIC Final Project", null, null, "IPI201" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 23);
        }
    }
}
