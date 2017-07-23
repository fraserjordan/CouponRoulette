using System.Web.Script.Serialization;

namespace Customer.Helpers
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