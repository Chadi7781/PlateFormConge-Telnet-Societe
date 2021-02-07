using API_Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Contracts
{
    public interface ITeamEmployeeRepository
    {
        Task<ILookup<int, TeamEmployee>> GetTeamEmployeeByTeamIds(IEnumerable<int> TeamIds);
        Task<ILookup<int, TeamEmployee>> GetTeamEmployeeByEmployeeIds(IEnumerable<int> EmployeeIds);

    }
}
