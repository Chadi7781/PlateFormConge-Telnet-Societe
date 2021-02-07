using API_Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.Contracts
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        //Team GetTeamById(int id);
    }
}
