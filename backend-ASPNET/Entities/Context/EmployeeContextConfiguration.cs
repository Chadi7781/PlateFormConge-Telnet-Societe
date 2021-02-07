using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Test.Entities.Context
{
    public class EmployeeContextConfiguration : IEntityTypeConfiguration<Employee>
    {
        

        public EmployeeContextConfiguration()
        {
           
        }

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasData(
                new Employee { Id = 1, FirstName = "Tarek", LastName = "ElGhali", Login = "Tarek.ElGhali", Password = "azerty", InitialCongeSolde = 31, RemainingCongeSolde = 29 },
                new Employee { Id = 2, FirstName = "Sameh", LastName = "Ouederni", Login = "Sameh.Ouederni", Password = "123aze", InitialCongeSolde = 25, RemainingCongeSolde = 25 },
                new Employee { Id = 3, FirstName = "Test", LastName = "testing", Login = "test", Password = "admin", InitialCongeSolde = 21, RemainingCongeSolde = 21 },
                new Employee { Id = 4, FirstName = "Mahdi", LastName = "Turki", Login = "Mahdi.Turki", Password = "123", InitialCongeSolde = 21, RemainingCongeSolde = 18 },
                new Employee { Id = 5, FirstName = "5555", LastName = "testing", Login = "test", Password = "admin", InitialCongeSolde = 21, RemainingCongeSolde = 21 },
                new Employee { Id = 6, FirstName = "6666", LastName = "testing", Login = "test", Password = "admin", InitialCongeSolde = 21, RemainingCongeSolde = 21 },
                new Employee { Id = 7, FirstName = "7777", LastName = "testing", Login = "test", Password = "admin", InitialCongeSolde = 21, RemainingCongeSolde = 21 }

                );
        }
    }


}
