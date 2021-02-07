using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities.Context
{
    public class SortieContextConfiguration : IEntityTypeConfiguration<Sortie>
    {
        public SortieContextConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<Sortie> builder)
            {
                builder
                  .HasData(
                    new Sortie
                    {
                        Id =1,
                        Motif = "personnel",
                        SortieState = SortieState.PENDING,
                        EmployeeId = 5,
                        SortieTime = SortieTime.TWO_HOURS,
                    },

                    new Sortie
                    {
                        Id = 2,
                        Motif = "personnel",
                        SortieState = SortieState.PENDING,
                        EmployeeId = 3,
                        SortieTime = SortieTime.HALF_HOUR,
                    },

                    new Sortie
                    {
                        Id = 3,
                        Motif = "personnel",
                        SortieState = SortieState.PENDING,
                        EmployeeId = 1,
                        SortieTime = SortieTime.ONE_AND_HALF_HOUR,
                    }

                );
            }
        
    }
}
