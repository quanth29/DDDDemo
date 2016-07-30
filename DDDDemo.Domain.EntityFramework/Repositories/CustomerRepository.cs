using DDDDemo.Domain.Entities;
using DDDDemo.Domain.Repositories;
using DDDDemo.Repository;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Domain.EntityFramework.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ISpecificationLocator specificationLocator, IUnitOfWork unitOfWork) : base(specificationLocator, unitOfWork)
        {
        }
    }
}
