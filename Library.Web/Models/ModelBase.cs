using Library.IOCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace Library.Web.Models
{

    public abstract class ModelBase
    {
        public T Resolve<T>() where T : class
        {
            var type = LibraryUnityContainer.Instance.Resolve<T>();
            if (type == null)
            {
                throw new NullReferenceException("Unable to resolve type with service locator; type " + typeof(T).Name);
            }

            return type;
        }
    }
}