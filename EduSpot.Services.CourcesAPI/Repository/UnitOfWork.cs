using EduSpot.Services.CourcesAPI.Data;
using EduSpot.Services.CourcesAPI.Repository.IRepository;

namespace EduSpot.Services.CourcesAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public ICourceRepository cource { get; private set; }
        public ICategoryRepository category { get; private set; }

        public IVideoCourseRepository videoCourse { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            cource = new CourceRepository(_db);
            category = new CategoryRepositorycs(_db);
            videoCourse = new   VideoCourseRepository (_db);
        }

        public void SaveAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
