using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class MemoryCache
    {/// <summary>

        /// In-memory cache dictionary
        /// </summary>
        private static Dictionary<string, object> _cache;
        private static object _sync;


        /// <summary>
        /// Cache initializer
        /// </summary>
        static MemoryCache()
        {

            _cache = new Dictionary<string, object>();

            _sync = new object();

        }


        /// Get an object from cache       
        public static T Get<T>() where T : class
        {
            Type type = typeof(T);

            lock (_sync)
            {
                if (_cache.ContainsKey(type.Name) == false)

                    throw new ApplicationException("This type of object does not exists " + type.Name);

                lock (_sync)
                {
                    return (T)_cache[type.Name];
                }
            }
        }


        /// <summary>
        /// Get an object from cache
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="key">Name of key in cache</param>
        /// <returns>Object from cache</returns>
        public static T Get<T>(string key) where T : class
        {

            Type type = typeof(T);

            lock (_sync)
            {

                if (_cache.ContainsKey(key + type.Name) == false)

                    throw new ApplicationException(String.Format("An object with key '{0}' does not exists", key));

                lock (_sync)
                {

                    return (T)_cache[key + type.Name];

                }

            }

        }

        /// <summary>
        /// Add the object in cache
        /// </summary>          
        /// <param> Key of object</param>
        ///   <param> type of object</param>
     
        public static void Add<T>(string key, T value)
        {

            Type type = typeof(T);



            //if (value.GetType() != type)
           
                //throw new ApplicationException(String.Format("The type of value passed to cache {0} does not match the cache type {1} for key {2}", value.GetType().FullName, type.FullName, key));

            lock (_sync)
            {
                if (_cache.ContainsKey(key + type.Name))
                    throw new ApplicationException(String.Format("An object with key '{0}' already exists", key));

                lock (_sync)
                {
                    _cache.Add(key + type.Name, value);
                }

            }

        }

          /// <summary>
        /// Remove an object stored with a key from cache
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="key">Key of the object</param>
        public static void Remove<T>(string key)
        {
            Type type = typeof(T);
            lock (_sync)
            {
                if (_cache.ContainsKey(key + type.Name) == false)
                    throw new ApplicationException(String.Format("An object with key '{0}' does not exists in cache",
                                                                 key));
                lock (_sync)
                {
                    _cache.Remove(key + type.Name);
                }
            }
        }



    }
}
