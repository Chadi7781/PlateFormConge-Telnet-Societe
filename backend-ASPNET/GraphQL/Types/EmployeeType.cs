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
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(ICongeRepository congeRepository, ISortieRepository sortieRepository, ITeamEmployeeRepository teamEmployeeRepository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.FirstName).Description(" First Name property from the owner object.");
            Field(x => x.LastName).Description("Last Name property from the owner object");
            Field(x => x.Login);
            Field(x => x.Password);
            Field(x => x.RemainingCongeSolde);
            Field(x => x.InitialCongeSolde).Description("Initial Conge Solde property from the owner object.");

            Field<ListGraphType<CongeType>>(
            "conges",
            resolve: context =>
            {
                var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, Conge>("GetCongesByEmployeeIds", congeRepository.GetCongesByEmployeeIds);
                return loader.LoadAsync(context.Source.Id);
            }

            );

            Field<ListGraphType<SortieType>>(
            "sorties",
            resolve: context =>
            {
                var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, Sortie>("GetSortiesByEmployeeIds", sortieRepository.GetSortiesByEmployeeIds);
                return loader.LoadAsync(context.Source.Id);
            }
            );

            Field<ListGraphType<TeamEmployeeType>>(
            "teamEmployee",
            resolve: context =>
            {
                var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<int, TeamEmployee>("GetTeamEmployeeByEmployeeIds", teamEmployeeRepository.GetTeamEmployeeByEmployeeIds);
                return loader.LoadAsync(context.Source.Id);
            }
            );

        }
        
    }
}
