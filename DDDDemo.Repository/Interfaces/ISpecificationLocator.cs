namespace DDDDemo.Repository.Interfaces
{
    public interface ISpecificationLocator
    {
        TSpecification Resolve<TSpecification, TEntity>()
            where TSpecification : ISpecicifcation<TEntity>
            where TEntity : class;
    }
}