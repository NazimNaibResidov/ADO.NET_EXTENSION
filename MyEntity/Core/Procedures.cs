using MyEntity.Command;
using MyEntity.Connected;
using MyEntity.Helper;
using System.Data.SqlClient;

namespace MyEntity.Core
{

    public  class Procedures
    {
    
        public static void InsertProcedure(dynamic dynamic)
        {  
          
            var  query = Procedure.InsertProcedure.ProcedureInsert(dynamic, "Create");
             var data = commoned(dynamic, query);
            if ( data== false)
            {
                ProcedureHelper.ReCreateProcedureIfInsertExists(dynamic);
            }
                
        }
        public static void DeleteProcedure(dynamic dynamic)
        {
        
          
            var query=  MyEntity.Procedure.DeleteProcedure.ProcedureDelete(dynamic, "Create");
            var data= commoned(dynamic, query);
            if (data == false)
            {
                ProcedureHelper.ReCreateProcedureIfDeleteExists(dynamic);
            }
        }
        public static void UpdateProcedure(dynamic dynamic)
        {
            var query=  MyEntity.Procedure.UpdateProcedure.ProcedureUpdate(dynamic);
            var data = commoned(dynamic, query);
            if (data == false)
            {
                ProcedureHelper.ReCreateProcedureIfUpdateExists(dynamic);
            }
        }
        public static void SelectProcedure(dynamic dynamic)
        {
            var query = MyEntity.Procedure.SelectProcedure.ProcedureSelect(dynamic);
            var data = commoned(dynamic, query);
            if (data == false)
            {
                ProcedureHelper.ReCreateProcedureIfSelectExists(dynamic);
            }
        }
        private static bool commoned(dynamic dynamic,string query)
        {
            SqlCommand command = new SqlCommand("", Services.Connection);
            return Commond.ExecuteQueryForProcedure(command, query);
        }


   }
}
