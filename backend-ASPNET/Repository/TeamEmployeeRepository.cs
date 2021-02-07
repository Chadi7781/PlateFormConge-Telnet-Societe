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
    public class TeamEmployeeRepository : ITeamEmployeeRepository
    {
        private readonly TelnetContext _context;

        public TeamEmployeeRepository(TelnetContext context)
        {
            _context = context;
        }

        public async Task<ILookup<int, TeamEmployee>> GetTeamEmployeeByTeamIds(IEnumerable<int> TeamEmployeeIds)
        {
            var team = await _context.TeamEmployees.Where(a => TeamEmployeeIds.Contains(a.TeamId)).ToListAsync();
            return team.ToLookup(x => x.TeamId);
        }

        public async Task<ILookup<int, TeamEmployee>> GetTeamEmployeeByEmployeeIds(IEnumerable<int> EmployeeIds)
        {
            var emp = await _context.TeamEmployees.Where(a => EmployeeIds.Contains(a.EmployeeId)).ToListAsync();
            return emp.ToLookup(x => x.EmployeeId);
        }

    }
}
