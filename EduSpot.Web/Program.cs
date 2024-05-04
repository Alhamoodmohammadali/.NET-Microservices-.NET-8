using EduSpot.Web.DataAccess.Services;
using EduSpot.Web.DataAccess.Services.CourseApi;
using EduSpot.Web.DataAccess.Services.IServices;
using EduSpot.Web.DataAccess.Services.IServices.ICourseApi;
using EduSpot.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();



builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IUniversityService, UniversityService>();
builder.Services.AddHttpClient<IMajorService, MajorService>();

builder.Services.AddHttpClient<IMaterialService, MaterialService>();
builder.Services.AddHttpClient<ISummaryService, SummaryService>();
builder.Services.AddHttpClient<ILectureService, LectureService>();
builder.Services.AddHttpClient<IChapterService, ChapterService>();


builder.Services.AddHttpClient<ICouponService, CouponService>();
builder.Services.AddHttpClient<ICourceService, CourceServicecs>();
builder.Services.AddHttpClient<ICartService, CartService>();

builder.Services.AddHttpClient<IVideoCourceService, VideoCourceService>();
builder.Services.AddHttpClient<ICategoryService, CategoryService>();




SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.UniversityAPIBase = builder.Configuration["ServiceUrls:UniversityAPI"];
SD.MajorAPIBase = builder.Configuration["ServiceUrls:MagorAPI"];
SD.MaterialAPIBase = builder.Configuration["ServiceUrls:MaterialAPI"];
SD.SummaryAPIBase = builder.Configuration["ServiceUrls:SummaryAPI"];
SD.LectureAPIBase = builder.Configuration["ServiceUrls:LectureAPI"];
SD.ChapterAPIBase = builder.Configuration["ServiceUrls:ChapterAPI"];


SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"];
SD.CourceAPIBase = builder.Configuration["ServiceUrls:CourcesAPI"];
SD.SubscriptionCardAPIBase = builder.Configuration["ServiceUrls:SubscriptionCardAPI"];



builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<IMajorService, MajorService>();

builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ISummaryService, SummaryService>();
builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<IChapterService, ChapterService>();



builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICourceService, CourceServicecs>();

builder.Services.AddScoped<IVideoCourceService, VideoCourceService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=UniversityIndex}/{id?}");
app.Run();