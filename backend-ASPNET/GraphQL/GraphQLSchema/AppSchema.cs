using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Test.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace API_Test.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
        : base(resolver)
        {
            Query = resolver.Resolve<EmployeeQuery>();
            Mutation = resolver.Resolve<EmployeeMutation>();
        }
    }
}
