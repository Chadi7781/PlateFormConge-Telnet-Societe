using API_Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Contracts
{
    public interface ISortieRepository
    {
        Task<ILookup<int, Sortie>> GetSortiesByEmployeeIds(IEnumerable<int> EmployeeIds);
        Sortie GetSortieById(int id);
        Sortie CreateSortie(Sortie sortie);
        Sortie UpdateSortie(Sortie dbSortie, Sortie sortie);
    }
}
