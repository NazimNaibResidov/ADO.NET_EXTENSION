using MyEntity.Attributes;
using MyEntity.Core;
using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace MyEntity.Helper
{
    public class Tools
    {


        public static bool IsNull(object obj)
        {
             
            if (obj!=null)
            {
                var  data = obj.GetType();
                if (data.Name == "Boolean")
                {

                   return Convert.ToBoolean(obj) ==true ? true:false;
                }
            }
             return obj != null? true : false;

        }
        public static void InsertSubQuery(dynamic entity, SqlCommand command)
        {
            foreach (var item in entity.GetType().GetProperties())
            {

                if (Tools.FindID(item))
                    continue;
                if (Tools.IsNull(item.GetValue(entity)))
                    command.Parameters.AddWithValue("@" + item.Name, item.GetValue(entity));


            }
        }
        public static string GetName(object entity)
        {
            return entity.GetType().Name.ToString();
        }
        public static bool FindID(PropertyInfo item)
        {

            var data = item.GetCustomAttributes(typeof(IdentityAttrubut),true);
            if (data.Length>0)
            {
                return true;
            }
            return false;





        }
        public static void TrimComma(StringBuilder biler)
        {
            biler.Remove(biler.Length - 1, 1);
        }
        public static void GetName(object entity, StringBuilder bilder)
        {
            foreach (var item in entity.GetType().GetProperties())
            {
                if (FindID(item))
                    continue;
                if (IsNull(item.GetValue(entity)))
                    bilder.Append(item.Name + " ,");

            }
        }
        public static void ValueInserted(dynamic entity, StringBuilder bilder)
        {
            foreach (var item in entity.GetType().GetProperties())
            {

                if (FindID(item))
                    continue;
                if (IsNull(item.GetValue(entity)))
                    bilder.Append("@"+item.Name + " ,");

            }
        }
        public static bool NumberType(PropertyInfo  info)
        {

                       return
            info.PropertyType == typeof(int)      ||
            info.PropertyType == typeof(int?)     ||
            info.PropertyType == typeof(byte)     ||
            info.PropertyType == typeof(byte?)    ||
            info.PropertyType == typeof(sbyte)    ||
            info.PropertyType == typeof(sbyte?)   ||
            info.PropertyType == typeof(long)     ||
            info.PropertyType == typeof(long?)    ||
            info.PropertyType == typeof(bool)     ||
            info.PropertyType == typeof(bool?)    ||
            info.PropertyType == typeof(DateTime) ||
            info.PropertyType == typeof(DateTime?)||
            info.PropertyType == typeof(decimal)  ||
            info.PropertyType == typeof(decimal?) ||
            info.PropertyType == typeof(short)    ||
            info.PropertyType == typeof(short?)   ||
            info.PropertyType == typeof(double?)  ||
            info.PropertyType == typeof(double);



        }
        public static bool isDateTime(PropertyInfo info)
        {
            return info.PropertyType == typeof(DateTime) ? true : false;
        }
        public static bool IsBool(PropertyInfo info)
        {
            if (info.PropertyType == typeof(bool))
            {
                return true;
            }
            return false;
        }
        public static string Proc_Declare_Type(dynamic entity,StringBuilder builder)
        {
            foreach (var item in entity.GetType().GetProperties())
            {
                if (Tools.FindID(item))
                    continue;
                if (Tools.IsNull(item.GetValue(entity)))
                    if (!Tools.NumberType(item))
                        builder.Append("@" + item.Name + " VARCHAR(100)" + ",");

                    else if (Tools.isDateTime(item))
                    {
                        builder.Append("@" + item.Name + " datetime" + ",");
                    }
                    else if (Tools.IsBool(item))
                    {
                        builder.Append("@" + item.Name + " bit" + ",");
                    }
                    else
                    {
                        builder.Append("@" + item.Name + " INTEGER " + ",");
                    }



            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
       
       
    }
}
