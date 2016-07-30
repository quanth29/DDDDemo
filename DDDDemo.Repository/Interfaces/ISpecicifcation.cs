namespace DDDDemo.Repository.Interfaces
{
    public interface ISpecicifcation<TEntity> where TEntity : class
    {
        void Initialize(IUnitOfWork unitOfWork);

        ISpecicifcationResult<TEntity> ToResult();
    }
}