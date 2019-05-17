using MyEntity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntity.Procedure
{
   public class InsertProcedure
    {
        public static string ProcedureInsert(dynamic entity, string Name = "CREATE")
        {

            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} PROCEDURE ");
            builder.Append(entity.GetType().Name+ "_Insert" + " ");
            foreach (var item in entity.GetType().GetProperties())
            {
                if (Tools.FindID(item))
                    continue;
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
            builder.Append(" AS  BEGIN  INSERT  INTO ");
            builder.Append(entity.GetType().Name);
            builder.Append(" ( ");
            foreach (var item in entity.GetType().GetProperties())
            {
                var data = Tools.FindID(item);
                if (data)
                    continue;

                if (Tools.IsNull(item.GetValue(entity)))
                    builder.Append(item.Name + ",");




            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(" ) VALUES ( ");
            foreach (var item in entity.GetType().GetProperties())
            {
                if (Tools.FindID(item))
                    continue;
                if (Tools.IsNull(item.GetValue(entity)))
                    if (!Tools.NumberType(item))
                        builder.Append("@" + item.Name + ",");

                    else if (Tools.isDateTime(item))
                    {
                        builder.Append("@" + item.Name + ",");
                    }
                    else if (Tools.IsBool(item))
                    {
                        builder.Append("@" + item.Name + ",");
                    }
                    else
                    {
                        builder.Append("@" + item.Name + ",");
                    }



            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(" ) ");
            builder.Append(" END ");
            string str = builder.ToString();
            return builder.ToString();
        }
    }
}
