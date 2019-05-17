using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntity.Procedure
{
    public class SelectProcedure
    {
        public static string ProcedureSelect(dynamic entity, string Name = "CREATE")
        {


            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} PROCEDURE ");
            builder.Append(entity.GetType().Name+"_Select"+" \n");
            builder.Append(" AS BEGIN ");
            builder.Append("SELECT * FROM " + entity.GetType().Name);
            builder.Append(" \nEND");
            return builder.ToString();
        }
    }
}
