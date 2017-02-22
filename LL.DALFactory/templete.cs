using System;
using System.Reflection;
using System.Configuration;
using LL.IDAL.Temp;

namespace LL.DALFactory
{

    public sealed partial class DataAccess
    {
        public static ITempItem CreateTempItem()
        {

            string ClassNamespace = AssemblyPath + ".Temp.DALTempItem";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ITempItem)objType;
        }
      
    }
}