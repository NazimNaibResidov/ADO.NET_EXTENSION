using MyEntity.Command;
using MyEntity.Connected;
using MyEntity.Procedure;
using System.Data.SqlClient;

namespace MyEntity.Helper
{
  public  class ProcedureHelper
    {
        public static void ReCreateProcedureIfInsertExists(dynamic dynamic)
        {
          
            SqlCommand command = new SqlCommand("", Services.Connection);
          var  query = InsertProcedure.ProcedureInsert(dynamic, "ALTER");
            Commond.ExecuteQueryForProcedure(command, query);
            
              

        }
        public static void ReCreateProcedureIfDeleteExists(dynamic dynamic)
        {
                SqlCommand command = new SqlCommand("", Services.Connection);
                var query=   DeleteProcedure.ProcedureDelete(dynamic, "ALTER");
                Commond.ExecuteQueryForProcedure(command, query);
            
        }
        public static void ReCreateProcedureIfUpdateExists(dynamic dynamic)
        {
            SqlCommand command = new SqlCommand("", Services.Connection);
            var query = UpdateProcedure.ProcedureUpdate(dynamic, "ALTER");
            Commond.ExecuteQueryForProcedure(command, query);

        }
        public static void ReCreateProcedureIfSelectExists(dynamic dynamic)
        {
            SqlCommand command = new SqlCommand("", Services.Connection);
            var query = SelectProcedure.ProcedureSelect(dynamic, "ALTER");
            Commond.ExecuteQueryForProcedure(command, query);

        }
    }
}
