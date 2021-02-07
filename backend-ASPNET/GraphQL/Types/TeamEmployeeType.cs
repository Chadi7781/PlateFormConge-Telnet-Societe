using API_Test.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.GraphQL.Types
{
    public class TeamEmployeeType : ObjectGraphType<TeamEmployee>
    {
        public TeamEmployeeType()
        {

            Field(x => x.Id);
            Field(x => x.TeamId);
            Field(x => x.EmployeeId);
        }
    }
}
