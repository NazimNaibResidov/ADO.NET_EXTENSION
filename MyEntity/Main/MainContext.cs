using MyEntity.Query;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyEntity.Main
{

    public static class MainContext
    {
       

           public static bool Insert<T>(this T expression, T entity)
        {

          return  QueryBilder.QueryInserter(entity);



        }
           public static bool Delete<T>(this T data,int id)
        {
            return QueryBilder.QueryDelete(data, id);


        }
           public static bool Update<T>(this T Entity,int id)
        {
            return QueryBilder.QueryUpdate(Entity,id);
        }
           public static DataTable Select<T>(this T Entity)
        {
            return QueryBilder.QueryList(Entity);
            


        }

       

      
    }
}
