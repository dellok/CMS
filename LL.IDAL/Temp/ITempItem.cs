using System;
using System.Data;
using LL.Model.Temp;
namespace LL.IDAL.Temp
{
	
	public interface ITempItem:IBase<TempItem>
	{
		#region  成员方法

         TempItem GetModelByDataRow(DataRow row);
       
		#endregion  成员方法

        int DeleteList(string IDlist);
        /// <summary>
        /// 判断栏目名称是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ExistsName(string name, int id);
    } 
}
