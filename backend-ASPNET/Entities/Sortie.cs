using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Entities
{
    public class Sortie
    {
        public int Id { get; set; }
        public SortieTime SortieTime { get; set; }
        public DateTime Sortie_Date { get; set; }
        public string Motif { get; set; }
        public DateTime Recovery_Date { get; set; }
        public SortieState SortieState { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
    
    public enum SortieState
    {
        APPROVED, PENDING, REFUSED
    }
    public enum SortieTime
    {
        HALF_HOUR, ONE_HOUR, ONE_AND_HALF_HOUR, TWO_HOURS
    }

}
