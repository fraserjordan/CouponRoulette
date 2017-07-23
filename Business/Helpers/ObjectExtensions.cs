using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Business.Helpers
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// For use in views. Use IJsonSerializer when IoC is available
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJson(this object o)
        {
            var serializer = new JavaScriptSerializer();

            return serializer.Serialize(o);
        }
    }
}