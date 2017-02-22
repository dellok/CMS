using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.Popedom;

namespace LL.DALFactory
{
    public sealed partial class DataAccess
    {


        public static IPopedomGroup CreateDALPopedomGroup()
        {
            string classNamespace = AssemblyPath + ".Popedom.DALPopedomGroup";
            object objType = CreateObject(classNamespace);
            return (IPopedomGroup)objType;

        }

        public static IPopedomFun CreateDALPopedomFun()
        {
            string classNamespace = AssemblyPath + ".Popedom.DALPopedomFun";
            object objType = CreateObject(classNamespace);
            return (IPopedomFun)objType;

        }


        public static IPopedomFunInAdminRole CreateDALPopedomFunInAdminRole()
        {
            string classNamespace = AssemblyPath + ".Popedom.DALPopedomFunInAdminRole";
            object objType = CreateObject(classNamespace);
            return (IPopedomFunInAdminRole)objType;

        }



    }
}
