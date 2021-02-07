using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_Test.GraphQL.Types.CongeType;

namespace API_Test.GraphQL.Types
{
    public class CongeInputType : InputObjectGraphType
    {
        public CongeInputType()
        {
            Name = "congeInput";
            Field<StringGraphType>("motif");
            Field<DateTimeGraphType>("start_Date");
            Field<DateTimeGraphType>("end_Date");
            Field<IntGraphType>("employeeId");
            Field<ReasonEnumType>("reason");
            Field<CongeStateEnumType>("congeState");
            Field<HalfDayEnumType>("half_Day");
        }
    }
}
