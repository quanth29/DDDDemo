using DDDDemo.Domain.Entities;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
        
    }
}