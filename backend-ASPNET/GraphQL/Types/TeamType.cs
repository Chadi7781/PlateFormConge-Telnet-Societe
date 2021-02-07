using API_Test.Contracts;
using API_Test.Entities;
using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.GraphQL.Types
{
    public class TeamType : ObjectGraphType<Team>
    {
        public TeamType(ITeamEmployeeRepository teamEmployeeRepository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.ManagerId, type: typeof(IdGraphType));

            Field<ListGraphType<TeamEmployeeType>>(
            "teamEmployee",
            resolve: context =>
            {
                var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, TeamEmployee>("GetTeamEmployeeByTeamIds", teamEmployeeRepository.GetTeamEmployeeByTeamIds);
                return loader.LoadAsync(context.Source.Id);
            }
            );
        }
    }
}
