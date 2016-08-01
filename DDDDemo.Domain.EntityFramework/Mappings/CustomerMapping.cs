using System.Data.Entity.ModelConfiguration;
using DDDDemo.Domain.Entities;

namespace DDDDemo.Domain.EntityFramework.Mappings
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            HasKey(c => c.Id);
            Property(c => c.Name).HasMaxLength(255);

            Map(config =>
            {
                config.Properties(c => new
                {
                    c.Id, c.Name, c.Age
                });
                config.ToTable("Customers");
            });

        }
    }
}
