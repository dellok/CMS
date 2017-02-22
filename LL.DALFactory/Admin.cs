using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Admin;
using LL.IDAL.News;
namespace LL.DALFactory
{

    public sealed partial class DataAccess
    {


        public static IAdminUser CreateDALAdminUser()
        {
            string classNamespace = AssemblyPath + ".Admin.DALAdminUser";
            object objType = CreateObject(classNamespace);
            return (IAdminUser)objType;

        }

        public static IAdminRole CreateDALAdminRole()
        {
            string classNamespace = AssemblyPath + ".Admin.DALAdminRole";
            object objType = CreateObject(classNamespace);
            return (IAdminRole)objType;

        }

      


        public static IAdminInAdminRole CreateDALAdminInAdminRole()
        {
            string classNamespace = AssemblyPath + ".Admin.DALAdminInAdminRole";
            object objType = CreateObject(classNamespace);
            return (IAdminInAdminRole)objType;
        }



    }
}

