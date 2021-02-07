using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities.Context
{
    public class TeamEmployeeContextConfiguration :IEntityTypeConfiguration<TeamEmployee>
    {
        public TeamEmployeeContextConfiguration()
        { }
        public void Configure(EntityTypeBuilder<TeamEmployee> builder)
        {
            builder.HasData(
                new TeamEmployee
                {
                    Id =1,
                     EmployeeId = 3,
                     TeamId = 1,               
                },

                new TeamEmployee
                {
                    Id =2,
                    EmployeeId = 4,
                    TeamId = 1,
                },

                new TeamEmployee
                {
                    Id=3,
                    EmployeeId = 5,
                    TeamId = 1,
                },

                new TeamEmployee
                {
                    Id=4,
                    EmployeeId = 1,
                    TeamId = 2,
                }
                );
            
        }
    }
}
