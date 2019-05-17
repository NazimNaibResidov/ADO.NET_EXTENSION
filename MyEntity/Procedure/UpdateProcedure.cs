using MyEntity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyEntity.Procedure
{
  public  class UpdateProcedure
    {

        public static string ProcedureUpdate(dynamic entity,string Name = "CREATE")
        {

            string ID = string.Empty;
            PropertyInfo[] info = entity.GetType().GetProperties();
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} PROCEDURE ");
            builder.Append(entity.GetType().Name + "_Update" + " \n");
            foreach (PropertyInfo item in info)
            {

              
                if (Tools.IsNull(item.GetValue(entity)))
                    if (!Tools.NumberType(item))
                        builder.Append("@" + item.Name + " VARCHAR(100) " + ",");

                    else if (Tools.isDateTime(item))
                    {
                        builder.Append("@" + item.Name + " datetime " + ",");
                    }
                    else if (Tools.IsBool(item))
                    {
                        builder.Append("@" + item.Name + " bit " + ",");
                    }
                    else
                    {
                        builder.Append("@" + item.Name + " INTEGER " + ",");
                    }
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(" \n AS \n BEGIN \n\n UPDATE " + entity.GetType().Name +" SET ");
            foreach (PropertyInfo item in info)
            {
                if (Tools.FindID(item))
                {
                    continue;
                }
                if (Tools.IsNull(item.GetValue(entity)))
                {
                    builder.Append(item.Name + " = " + "@" + item.Name +" ,");

                }
                   
            }
            builder.Remove(builder.Length - 1, 1);
            foreach (PropertyInfo item in info)
            {
                if (Tools.FindID(item))
                {
                    builder.Append(" WHERE "+item.Name+" = "+"@"+item.Name);
                }
               

            }
            builder.Append(" \n END");
            string str = builder.ToString();
            return builder.ToString();
        }
    }
}
