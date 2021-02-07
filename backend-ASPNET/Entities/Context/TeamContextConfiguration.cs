using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities.Context 
{
    public class TeamContextConfiguration : IEntityTypeConfiguration<Team>
    {
        public TeamContextConfiguration()
        {
        }
            public void Configure(EntityTypeBuilder<Team> builder)
            {
            builder
              .HasData(
                new Team
                {
                    Id = 1,
                    ManagerId = 1,                  
                },

                new Team
                {
                    Id = 2,
                    ManagerId = 2,
                }
                ) ;
            }
    }
}
