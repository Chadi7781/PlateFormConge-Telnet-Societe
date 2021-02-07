using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities.Context
{
    public class CongeContextConfiguration : IEntityTypeConfiguration<Conge>
    {
        public CongeContextConfiguration()
        {
            
        }

        public void Configure(EntityTypeBuilder<Conge> builder)
        {
            builder
              .HasData(
                new Conge
                {
                    Id = 1,
                    Motif = "Sickness",
                    Reason = Reason.PERSONNEL,

                    CongeState = CongeState.REFUSED,
                    start_Date = new DateTime(2019,10,10),
                    end_Date = new DateTime(2019,10,11),
                    EmployeeId = 1,
                },
                new Conge
                {
                    Id = 2,
                    Motif = "Pregnancy",
                    Reason = Reason.MATERNITE,
                    CongeState = CongeState.APPROVED,
                    start_Date = new DateTime(2018, 8, 25),
                    end_Date = new DateTime(2019, 9, 1),
                    EmployeeId = 3,
                }
            );
        }
    }
}
