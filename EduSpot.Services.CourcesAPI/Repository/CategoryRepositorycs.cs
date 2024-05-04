using EduSpot.Services.CourcesAPI.Data;
using EduSpot.Services.CourcesAPI.Models;
using EduSpot.Services.CourcesAPI.Repository.IRepository;

namespace EduSpot.Services.CourcesAPI.Repository
{
    public class CategoryRepositorycs : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepositorycs(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _db.categories.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
