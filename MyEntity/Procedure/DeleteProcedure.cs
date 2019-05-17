using MyEntity.Helper;
using System.Reflection;
using System.Text;

namespace MyEntity.Procedure
{
    public  class DeleteProcedure
    {
      
            public static string ProcedureDelete(dynamic entity,string Name="CREATE")
            {

            string ID = string.Empty;
            PropertyInfo[] info = entity.GetType().GetProperties();
            StringBuilder builder = new StringBuilder();
            builder.Append($"{Name} PROCEDURE ");
            builder.Append(entity.GetType().Name+ "_DELETE" + " ");
            foreach (PropertyInfo item in info)
            {
                if (Tools.FindID(item))
                {
                    ID = item.Name;


                }

            }
            builder.Append("@" + ID + "  INTEGER ");
            builder.Append(" AS BEGIN ");
            builder.Append(" DELETE " + entity.GetType().Name + " WHERE " + ID + " = @" + ID);
            builder.Append("  END");
            return builder.ToString();
        }

    }
    }

