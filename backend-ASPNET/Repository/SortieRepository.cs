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
    public class SortieRepository : ISortieRepository
    {
        private readonly TelnetContext _context;

        public SortieRepository(TelnetContext context)
        {
            _context = context;
        }
        public async Task<ILookup<int, Sortie>> GetSortiesByEmployeeIds(IEnumerable<int> EmployeeIds)
        {
            var sorties = await _context.Sorties.Where(a => EmployeeIds.Contains(a.EmployeeId)).ToListAsync();
            return sorties.ToLookup(x => x.EmployeeId);
        }

        public Sortie GetSortieById(int id) => _context.Sorties.SingleOrDefault(o => o.Id.Equals(id));
        public Sortie CreateSortie(Sortie sortie)
        {
            _context.Sorties.Add(sortie);
            _context.SaveChanges();
            return sortie;
        }


        public Sortie UpdateSortie(Sortie dbSortie, Sortie sortie)
        {
            dbSortie.SortieState = sortie.SortieState;
            _context.Entry(sortie).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return dbSortie;
        }

    }
}
