using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenFootballApi.DTO.Attributes
{
    /// <summary>
    /// Marker attribute to indicate will will store this DTO as a table
    /// </summary>
    public class TableAttribute : Attribute
    {

        /// <summary>
        /// Get all the DTOs/classes that will be stored in our data storage
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTableClasses(System.Reflection.Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TableAttribute), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
