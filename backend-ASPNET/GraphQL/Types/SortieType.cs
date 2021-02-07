using API_Test.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Test.GraphQL.Types
{
    public class SortieType : ObjectGraphType<Sortie>
    {
        public SortieType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Motif);
            Field(x => x.Recovery_Date, type: typeof(DateTimeGraphType));
            Field(x => x.Sortie_Date, type: typeof(DateTimeGraphType));
            Field(x => x.EmployeeId, type: typeof(IdGraphType));
            Field<SortieStateEnumType>("SortieState");
            Field<SortieTimeEnumType>("SortieTime");
        }

        public class SortieStateEnumType : EnumerationGraphType<SortieState>
        {
            public SortieStateEnumType()
            {
                Name = "SortieState";
            }
        }

        public class SortieTimeEnumType : EnumerationGraphType<SortieTime>
        {
            public SortieTimeEnumType()
            {
                Name = "SortieTime";
            }
        }
    }
}
