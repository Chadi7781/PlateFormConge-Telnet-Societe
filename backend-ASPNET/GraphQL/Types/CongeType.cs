using API_Test.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.GraphQL.Types
{
    public class CongeType : ObjectGraphType<Conge>
    {
        public CongeType()
            {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(x => x.Motif).Description("Description property from the account object.");
            Field(x => x.start_Date, type: typeof(DateTimeGraphType));
            Field(x => x.end_Date, type: typeof(DateTimeGraphType));
            Field(x => x.EmployeeId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field<ReasonEnumType>("Reason");
            Field<CongeStateEnumType>("CongeState");
            Field<HalfDayEnumType>("half_Day");     
            }
        public class HalfDayEnumType : EnumerationGraphType<Half_Day>
        {
            public HalfDayEnumType()
            {
                Name = "Half_Day";
            }
        }

        public class CongeStateEnumType : EnumerationGraphType<CongeState>
        {
            public CongeStateEnumType()
            {
                Name = "CongeState";
            }
        }

        public class ReasonEnumType : EnumerationGraphType<Reason>
        {
            public ReasonEnumType()
            {
                Name = "Reason";
            }

        }
    }
}
