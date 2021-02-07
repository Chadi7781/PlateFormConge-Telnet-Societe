using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Test.Entities
{
    public class Conge
    {
        [Key] [Required]
        public int Id { get; set; }
        public string Motif { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime end_Date { get; set; }
        public Reason Reason { get; set; }
        public CongeState CongeState { get; set; }
        public Half_Day half_Day { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

    public enum Half_Day
    {
        MATIN, APRES_MIDI
    } 
    public enum CongeState
    {
        APPROVED, REFUSED, PENDING
    }
    public enum Reason
    {
        PERSONNEL, EXCEPTIONNEL, MATERNITE, HALF_DAY
    }
}
