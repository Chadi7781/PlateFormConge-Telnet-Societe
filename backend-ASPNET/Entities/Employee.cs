using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int InitialCongeSolde { get; set; }
        public int RemainingCongeSolde { get; set; }

        public ICollection<Conge> Conges { get; set; }
        public ICollection<Sortie> Sorties { get; set; }
        public ICollection<TeamEmployee> TeamEmployees { get; set; }
    }
}
