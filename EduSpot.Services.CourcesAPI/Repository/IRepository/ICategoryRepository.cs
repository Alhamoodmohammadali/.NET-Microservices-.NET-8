using EduSpot.Services.CourcesAPI.Models;
namespace EduSpot.Services.CourcesAPI.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> UpdateAsync(Category entity);
    }

}