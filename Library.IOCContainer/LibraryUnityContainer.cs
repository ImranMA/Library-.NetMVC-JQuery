using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;


namespace Library.IOCContainer
{
   public class LibraryUnityContainer
    {
        private static volatile UnityContainer instance = null;
        private static object syncRoot = new object();

        public static UnityContainer Instance
        {
            get
            {
                // only create a new instance if one doesn't already exist.
                if (instance == null)
                {
                    // use this lock to ensure that only one thread can access
                    // this block of code at once.
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new UnityContainer();
                        }
                    }
                }
                // return instance where it was just created or already existed.
                return instance;
            }
        }
    }
}
