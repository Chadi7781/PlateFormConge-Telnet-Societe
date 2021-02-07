using API_Test.Contracts;
using API_Test.Entities;
using API_Test.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TelnetContext _context;

        public TeamRepository(TelnetContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAll() => _context.Teams.ToList();
    }
}
