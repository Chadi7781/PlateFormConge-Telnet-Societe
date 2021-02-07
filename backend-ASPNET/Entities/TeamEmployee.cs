using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities
{
    public class TeamEmployee
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
