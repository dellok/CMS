using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.IDAL.AD;
namespace LL.DALFactory
{
    public sealed partial class DataAccess
    {
     
       
        public static IADList CreateADList()
        {
            string classNamespace = AssemblyPath + ".AD.DALADList";
            object objType = CreateObject(AssemblyPath,classNamespace);
            return (IADList)objType;
        }
     
    }
}
