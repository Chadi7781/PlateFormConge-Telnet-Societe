using API_Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Contracts
{
    public interface ICongeRepository
    {
        IEnumerable<Conge> GetHistoryByEmployee(int id);
        Task<ILookup<int, Conge>> GetCongesByEmployeeIds(IEnumerable<int> EmployeeIds);
        Conge GetCongeById(int id);
        Conge CreateConge(Conge conge);
        Conge UpdateConge(Conge dbConge, Conge conge);
    }
}
