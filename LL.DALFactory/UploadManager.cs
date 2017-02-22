using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using LL.IDAL.Upload;

namespace LL.DALFactory
{
    public sealed partial class DataAccess
    {


        public static IDAL.Upload.IUploadFile CreateUploadFile()
        {
            string ClassNamespace = AssemblyPath + ".Upload.DALUploadFile";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IUploadFile)objType;
        }




    }
}
