using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InventoryApp.Models
{
    public class ModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static T Create<T>(IDataRecord arg)
        {
            foreach (var variable in typeof(T).GetProperties())
            {
                var res = variable.MemberType;
            }

            return (T)Activator.CreateInstance(Type.GetType(typeof(T).ToString()));
        }
    }
}