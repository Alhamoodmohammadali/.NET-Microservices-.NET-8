using EduSpot.Services.CourcesAPI.Data;
using EduSpot.Services.CourcesAPI.Models;
using EduSpot.Services.CourcesAPI.Repository.IRepository;

namespace EduSpot.Services.CourcesAPI.Repository
{
    public class CourceRepository : Repository<Cource>, ICourceRepository
    {
        private readonly AppDbContext _db;
        public CourceRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Cource> UpdateAsync(Cource entity)
        {
            _db.Cources.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
