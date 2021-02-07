using API_Test.Contracts;
using API_Test.Entities;
using API_Test.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.GraphQL.Queries
{
    public class EmployeeMutation : ObjectGraphType
    {
        public EmployeeMutation(IEmployeeRepository repository, ICongeRepository congeRepository, ISortieRepository sortieRepository)
        {
            Field<EmployeeType>(
                "createEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "emp" }),
                resolve: context =>
                {
                    var empl = context.GetArgument<Employee>("emp");
                    return repository.CreateEmployee(empl);
                }
            );

           
            Field<CongeType>(
                "createConge",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CongeInputType>> { Name = "conge" }),
                resolve: context =>
                {
                    var temp = context.GetArgument<Conge>("conge");
                    return congeRepository.CreateConge(temp);
                }
            );

            Field<CongeType>(
                 "updateConge",
                 arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<CongeInputType>> { Name = "conge" },
                     new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "congeId" }),
                 resolve: context =>
                 {
                     var conge = context.GetArgument<Conge>("conge");
                     var congeId = context.GetArgument<int>("congeId");

                     var dbConge = congeRepository.GetCongeById(congeId);
                     var employeeId = dbConge.EmployeeId;


                     if (dbConge == null)
                     {
                         context.Errors.Add(new ExecutionError("Couldn't find conge in db."));
                         return null;
                     }
                     var dbEmployee = repository.GetEmployeeById(employeeId);
                     if (dbEmployee == null)
                     {
                         context.Errors.Add(new ExecutionError("Couldn't find conge in db."));
                         return null;
                     }


                     var date1 = dbConge.start_Date;
                     var date2 = dbConge.end_Date;
                     var sub = date2.Subtract(date1);
                     int remaining = dbEmployee.RemainingCongeSolde - sub.Days;
                     repository.UpdateEmployeeRemaining(dbEmployee, remaining);

                     return congeRepository.UpdateConge(dbConge, conge);





                 }
                 );

            Field<SortieType>(
                "createSortie",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<SortieInputType>> { Name = "sortie" }),
                resolve: context =>
                {
                    var temp = context.GetArgument<Sortie>("sortie");
                    return sortieRepository.CreateSortie(temp);
                }
                );


            Field<EmployeeType>(
           "updateEmployee",
           arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" },
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "employeeId" }),
           resolve: context =>
           {
               var employee = context.GetArgument<Employee>("employee");
               var employeeId = context.GetArgument<int>("employeeId");

               var dbEmployee = repository.GetEmployeeById(employeeId);
               if (dbEmployee == null)
               {
                   context.Errors.Add(new ExecutionError("Couldn't find conge in db."));
                   return null;
               }

               return repository.UpdateEmployee(dbEmployee, employee);
           }
           );


            Field<SortieType>(
                "updateSortie",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SortieInputType>> { Name = "sortie" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "sortieId" }),
                resolve: context =>
                {
                    var sortie = context.GetArgument<Sortie>("sortie");
                    var sortieId = context.GetArgument<int>("sortieId");

                    var dbSortie = sortieRepository.GetSortieById(sortieId);
                    if (dbSortie == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find sortie in db."));
                        return null;
                    }

                    return sortieRepository.UpdateSortie(dbSortie, sortie);
                }
                );
                

        }
    }
}
