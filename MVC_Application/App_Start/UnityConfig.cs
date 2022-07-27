using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Application.Entities;
using Application.DataAccess;

namespace MVC_Application
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IDataAccess<Department,int>, DepartmentDataAccess>();
            container.RegisterType<IDataAccess<Employee,int>,EmployeeDataAccess>();
           
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}