using DDDDemo.Domain.Entities;
using DDDDemo.Repository.Interfaces;

namespace DDDDemo.Domain.Specifications
{
    public interface ICustomerSpecification : ISpecicifcation<Customer>
    {
        ICustomerSpecification WithName(string name);

        ICustomerSpecification WithAge(int age);
    }
}
