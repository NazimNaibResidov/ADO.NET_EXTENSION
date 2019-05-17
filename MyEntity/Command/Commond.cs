using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntity.Command
{
   public class Commond
    {
        public static bool ExecuteQuery(SqlCommand command)
        {
            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                int data= command.ExecuteNonQuery();
                if(data>0)
                {
                   
               return  true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                string str = e.Message;
                return false;
            }
            finally
            {
                command.Connection.Close();
            }

        }
        public static bool ExecuteQueryForProcedure(SqlCommand command, string query)
        {


            try
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;
                    command.Connection.Open();
                //return true;
                int a = command.ExecuteNonQuery();
                if (0<a+2)
                {
                    return true;
                }
               else
               {
                    return false;
                }

                   




            }
            catch (Exception e)
            {
                string ErrorMessage = e.Message;
                return false;
            }
            finally
            {
                command.Connection.Close();
              //  return true;
            }

        }
    }
}
