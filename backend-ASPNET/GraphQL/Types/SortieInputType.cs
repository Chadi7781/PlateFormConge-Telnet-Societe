using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_Test.GraphQL.Types.SortieType;

namespace API_Test.GraphQL.Types
{
    public class SortieInputType : InputObjectGraphType
    {
        public SortieInputType()
        {
            Name = "sortieInput";
            Field<StringGraphType>("motif");
            Field<DateGraphType>("Recovery_Date");
            Field<DateGraphType>("Sortie_Date");
            Field<IntGraphType>("employeeId");
            Field<SortieStateEnumType>("SortieState");
            Field<SortieTimeEnumType>("SortieTime");
            
        }
    }
}
