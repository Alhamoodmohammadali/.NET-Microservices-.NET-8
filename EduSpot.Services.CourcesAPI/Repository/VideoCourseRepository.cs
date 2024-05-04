using EduSpot.Services.CourcesAPI.Data;
using EduSpot.Services.CourcesAPI.Models;
using EduSpot.Services.CourcesAPI.Repository.IRepository;

namespace EduSpot.Services.CourcesAPI.Repository
{
    public class VideoCourseRepository : Repository<VideoCourse>, IVideoCourseRepository
    {
        private readonly AppDbContext _db;
        public VideoCourseRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<VideoCourse> UpdateAsync(VideoCourse entity)
        {
            _db.video.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
