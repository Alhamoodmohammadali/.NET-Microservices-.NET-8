namespace EduSpot.Services.CourcesAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICourceRepository cource { get; }
        ICategoryRepository category { get; }
        IVideoCourseRepository videoCourse { get; }
        void SaveAsync();
    }
}
