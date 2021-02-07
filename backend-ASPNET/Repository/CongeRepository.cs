using API_Test.Contracts;
using API_Test.Entities;
using API_Test.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Repository
{
    public class CongeRepository : ICongeRepository
    {
        private readonly TelnetContext _context;

        public CongeRepository(TelnetContext context)
        {
            _context = context;
        }

        public IEnumerable<Conge> GetHistoryByEmployee(int Id) => _context.Conges
        .Where(a => a.EmployeeId.Equals(Id))
        .ToList();

        public async Task<ILookup<int, Conge>> GetCongesByEmployeeIds(IEnumerable<int> EmployeeIds)
        {
            var conges = await _context.Conges.Where(a => EmployeeIds.Contains(a.EmployeeId)).ToListAsync();
            return conges.ToLookup(x => x.EmployeeId);
        }

        public Conge GetCongeById(int id) => _context.Conges.SingleOrDefault(o => o.Id.Equals(id));

        public Conge CreateConge(Conge conge)
        {
            _context.Conges.Add(conge);
            _context.SaveChanges();
            return conge;
        }

        public Conge UpdateConge(Conge conge, Conge inputConge)
        {
            conge.CongeState = inputConge.CongeState;
            if(conge.CongeState == CongeState.APPROVED)
            {
               
                var date1 = conge.start_Date;
                var date2 = conge.end_Date;
                var sub = date2.Subtract(date1);
                int remaining = _context.Employees.Where(x => x.Id == conge.EmployeeId).Select(x => x.RemainingCongeSolde).First();
                remaining = remaining - sub.Days;
                
            }
            
            _context.Entry(conge).State = EntityState.Modified;
            _context.SaveChanges();
            return conge;
           
        }
        
        
    }
}
