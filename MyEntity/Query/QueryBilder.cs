using MyEntity.Command;
using MyEntity.Connected;
using MyEntity.Core;
using MyEntity.Helper;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MyEntity.Query
{
    public class QueryBilder
    {
        public static bool QueryInserter(dynamic entity)
        {
            Procedures.InsertProcedure(entity);
            SqlCommand command = new SqlCommand(entity.GetType().Name+"_Insert"  , Services.Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var item in entity.GetType().GetProperties())
            {

                if (Tools.FindID(item))
                    continue;
                if (Tools.IsNull(item.GetValue(entity)))
                    command.Parameters.AddWithValue("@" + item.Name, item.GetValue(entity));


            }
            return Commond.ExecuteQuery(command);

        }
        public static bool QueryDelete(dynamic entity, int id)
        {
            string Name = string.Empty;
            Procedures.DeleteProcedure(entity);
            SqlCommand command = new SqlCommand(entity.GetType().Name+"_Delete" , Services.Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var item in entity.GetType().GetProperties())
            {
                if (Tools.FindID(item))
                {
                    Name = "@" + item.Name;
                    command.Parameters.AddWithValue(Name, id);

                }
            }

            return Commond.ExecuteQuery(command);


        }
        public static bool QueryUpdate(dynamic entity, int id)
        {
            Procedures.UpdateProcedure(entity);

            SqlCommand command = new SqlCommand(entity.GetType().Name+"_Update" , Services.Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (PropertyInfo item in entity.GetType().GetProperties())
            {
                if (Tools.FindID(item))
                {
                    item.SetValue(entity, id);
                }

                if (Tools.IsNull(item.GetValue(entity)))
                {
                    command.Parameters.AddWithValue("@" + item.Name, item.GetValue(entity));
                }



            }
            return Commond.ExecuteQuery(command);
        }
        public static DataTable QueryList<T>(T obj)
        {
            string name = obj.GetType().Name + "_Select";
            Procedures.SelectProcedure(obj);
            SqlDataAdapter adapter = new SqlDataAdapter(name, Services.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
           
        }

    }
}
