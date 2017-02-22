using LL.IDAL.Log;
namespace LL.DALFactory
{
    public sealed partial class DataAccess
    {


        public static IVisitorLog CreateDALVisitorLog()
        {
            string classNamespace = AssemblyPath + ".Log.DALVisitorLog";
            object objType = CreateObject(AssemblyPath,classNamespace);
            return (IVisitorLog)objType;

        }

       




    }
}
