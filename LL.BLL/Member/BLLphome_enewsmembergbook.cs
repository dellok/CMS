using System;
using System.Data;
using System.Collections.Generic;

using LL.Model;
using LL.DALFactory;
using LL.IDAL;
using LL.Model.Member;
using LL.IDAL.Member;
using Project.Common;
namespace LL.BLL.Member
{
	/// <summary>
	/// phome_enewsmembergbook
	/// </summary>
	public partial class BLLphome_enewsmembergbook
	{
		private readonly Iphome_enewsmembergbook dal=DataAccess.Createphome_enewsmembergbook();
		public BLLphome_enewsmembergbook()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewsmembergbook model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(phome_enewsmembergbook model)
		{
			return dal.Update(model);
		}

	

		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewsmembergbook> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewsmembergbook> DataTableToList(DataTable dt)
		{
			List<phome_enewsmembergbook> modelList = new List<phome_enewsmembergbook>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{

				for (int n = 0; n < rowsCount; n++)
				{
					
					modelList.Add(dal.GetModelByDataRow(dt.Rows[n]));
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere,"");
        }

		#endregion  Method

        public phome_enewsmembergbook GetModel(int id,int userid)
        {

            return dal.GetModel(id, userid);
        }

        public int  Delete(int id)
        {
            return dal.Delete(id,0);
        }

        public int  Delete(int id, int userid)
        {
            return dal.Delete(id, userid);
        }

        public int  DeleteList(List<int> arrSelectID, int userid)
        {
            if (arrSelectID.Count > 0)
            {
                string ids = "";
                foreach (int item in arrSelectID)
                {
                    ids += string.Format("{0},", item);
                }
                ids = Util.FilterStartAndEndSign(ids, ",");
                return dal.DeleteAll(ids, userid);
            }
            else
            {

                return 0;
            }
        }

        public int CheckedList(List<int> arrSelectID, int ched, int userid)
        {
            if (arrSelectID.Count > 0)
            {
                string ids = "";
                foreach (int item in arrSelectID)
                {
                    ids += string.Format("{0},", item);
                }
                ids = Util.FilterStartAndEndSign(ids, ",");
                return dal.CheckedAll(ids,ched, userid);
            }
            else
            {

                return 0;
            }
        }



        public int DeleteList(List<int> arrids)
        {
            return DeleteList(arrids,0);
        }
    }
}

