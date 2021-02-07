using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ManagedId")]
        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
        public ICollection<TeamEmployee> TeamEmployees { get; set; }
    }
}
