using EduSpot.Services.SubscriptionCardAPI.Models.Dto;
namespace EduSpot.Services.SubscriptionCardAPI.Service.IService
{
    public interface ICourseService
    {
        Task<IEnumerable<CourceDto>> GetCourses();
    }
}
