using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class RentalTypeConfiguration : IEntityTypeConfiguration<RentalType>
    {
        public void Configure(EntityTypeBuilder<RentalType> builder)
        {
            builder.HasData(
                new RentalType
                {
                    Id = Guid.Parse("B090A296-D3A3-4828-B2F9-0B6C360AD77B"),
                    Name = "Hour",
                    Price = (decimal) 5.0
                },
                new RentalType
                {
                    Id = Guid.Parse("3CDB0CE0-6C5E-4C2D-9252-54ED5683B854"),
                    Name = "Day",
                    Price = (decimal) 20.0
                },
                new RentalType
                {
                    Id = Guid.Parse("36346EBC-523D-4D0E-8C75-3BCC0F380DA0"),
                    Name = "Week",
                    Price = (decimal) 60.0
                }
            );
        }
    }
}
