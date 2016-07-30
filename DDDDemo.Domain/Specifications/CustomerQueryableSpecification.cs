using System.Linq;
using DDDDemo.Domain.Entities;
using DDDDemo.Repository.Interfaces;
using DDDDemo.Repository.QueryableSpecification;

namespace DDDDemo.Domain.Specifications
{
    public class CustomerQueryableSpecification : QueryableSpecification<Customer>,ICustomerSpecification
    {
        public CustomerQueryableSpecification(IUnitOfWorkConvertor unitOfWorkConvertor) : base(unitOfWorkConvertor)
        {
        }

        public ICustomerSpecification WithName(string name)
        {
            Queryable = Queryable.Where(c => c.Name == name);
            return this;
        }

        public ICustomerSpecification WithAge(int age)
        {
            Queryable = Queryable.Where(c => c.Age == age);
            return this;
        }
    }
}
