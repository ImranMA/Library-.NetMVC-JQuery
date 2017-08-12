using Library.Interface;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;


namespace Library.IOCContainer
{
    public class LibraryUnityManager
    {
         public static void Register()
        {


            //Registering all the interfaces and their dependent repositories in IOC Container

            LibraryUnityContainer.Instance.RegisterType<IBooks, BooksRepository>(new ContainerControlledLifetimeManager());
            LibraryUnityContainer.Instance.RegisterType<IBorrowers, BorrowersRepository>(new ContainerControlledLifetimeManager());
            LibraryUnityContainer.Instance.RegisterType<IAssignBook, AssignBookRepository>(new ContainerControlledLifetimeManager());


        }
     
    }
}
