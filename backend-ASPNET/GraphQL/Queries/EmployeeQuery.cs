using API_Test.Contracts;
using API_Test.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.GraphQL.Queries
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeRepository repository, ICongeRepository congeRepository, ISortieRepository sortieRepository)
        {
            Field<ListGraphType<EmployeeType>>(
               "employees",
               resolve: context => repository.GetAll()
           );

            Field<EmployeeType>(
                "Employee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "empId" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("empId");
                    return repository.GetEmployeeById(id);
                }
            );

            Field<EmployeeType>(
              "login",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "login" },
             new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }),
              resolve: context =>
              {
                  string login = context.GetArgument<string>("login");
                  string password = context.GetArgument<string>("password");
                  return repository.GetEmployeeByLogin(login, password);
              }
          );



        }
    }
}
