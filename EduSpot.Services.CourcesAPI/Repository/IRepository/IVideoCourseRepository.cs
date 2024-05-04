using EduSpot.Services.CourcesAPI.Models;
namespace EduSpot.Services.CourcesAPI.Repository.IRepository
{
    public interface IVideoCourseRepository : IRepository<VideoCourse>
    {
        Task<VideoCourse> UpdateAsync(VideoCourse entity);
    }
}
