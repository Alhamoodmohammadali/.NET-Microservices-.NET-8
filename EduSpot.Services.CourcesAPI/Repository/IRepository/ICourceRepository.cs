using EduSpot.Services.CourcesAPI.Models;
namespace EduSpot.Services.CourcesAPI.Repository.IRepository
{
    public interface  ICourceRepository : IRepository<Cource>
    {
        Task<Cource> UpdateAsync(Cource entity);
    }
}