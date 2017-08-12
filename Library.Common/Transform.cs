using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Data;

namespace Library.Common
{
    public class Transform
    {
        /// <summary>
        /// Generic method to transform one type of list into other type of list.
        /// </summary>
        /// <typeparam name="T">Target type to be converted.</typeparam>
        /// <typeparam name="J">Source type from which to convert.</typeparam>
        /// <param name="sourceObjects">List of source objects.</param>
        /// <returns>List of Target type.</returns>
        public static IList<T> FromObjectToObject<T, J>(IList<J> sourceObjects)
        {
            List<T> targetList = new List<T>();
            try
            {
                foreach (J sourceObject in sourceObjects)
                {
                    targetList.Add(FromObjectToObject<T, J>(sourceObject));
                }
                return targetList;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                targetList = null;
            }
        }


        /// <summary>
        /// Generic method to copy data from source object to destination object by matching field names.
        /// </summary>
        /// <typeparam name="T">Type of object that is required in return.</typeparam>
        /// <typeparam name="J">Type of source object from where to read data.</typeparam>
        /// <param name="sourceObject">Source object to read data from.</param>
        /// <returns>Generic type.</returns>
        public static T FromObjectToObject<T, J>(J sourceObject)
        {
            T destinationBO = Activator.CreateInstance<T>();
            PropertyInfo[] dtoProperties = sourceObject.GetType().GetProperties();
            PropertyInfo[] boProperties = destinationBO.GetType().GetProperties();

            foreach (PropertyInfo dtoProperty in dtoProperties)
            {
                foreach (PropertyInfo boProperty in boProperties)
                {
                    if (boProperty.Name.Equals(dtoProperty.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        boProperty.SetValue(destinationBO, dtoProperty.GetValue(sourceObject, null), null);
                        break;
                    }
                }
            }
            return destinationBO;
        }



    }
}
