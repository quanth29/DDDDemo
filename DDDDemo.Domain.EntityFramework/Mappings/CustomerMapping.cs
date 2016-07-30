using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Id = c.Id,
                    Name = c.Name,
                    Age = c.Age
                });
                config.ToTable("Customers");
            });

        }
    }
}
