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
	/// 反馈
	/// </summary>
	public partial class BLLphome_enewsmemberfeedback
	{
		private readonly Iphome_enewsmemberfeedback dal=DataAccess.Createphome_enewsmemberfeedback();
		public BLLphome_enewsmemberfeedback()
		{}
		#region  Method

	
		public int  Add(phome_enewsmemberfeedback model)
		{
		return 	dal.Add(model);
		}

	
		public int  Update(phome_enewsmemberfeedback model)
		{
			return dal.Update(model);
		}


		public int  Delete(int id)
		{
		
			return dal.Delete(id);
		}

	
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
	
		public List<phome_enewsmemberfeedback> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		

		public List<phome_enewsmemberfeedback> DataTableToList(DataTable dt)
		{
			List<phome_enewsmemberfeedback> modelList = new List<phome_enewsmemberfeedback>();
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

		#endregion  Method

        public DataSet GetList(int PageIndex, int PageSize, string where, string orderby)
        {

            return dal.GetList(PageIndex,PageSize,where,orderby);
        }

        public int DeleteAll(List<int> arrSelectID)
        {

            return DeleteAll(arrSelectID,0);
        }
        public int DeleteAll(List<int> arrSelectID,int userid)
        {


            if (arrSelectID.Count > 0)
            {
                string ids = "";
                foreach (int item in arrSelectID)
                {
                    ids += string.Format("{0},", item);
                }
                ids = Util.FilterStartAndEndSign(ids,",");
                return dal.DeleteAll(ids, userid);
            }
            else
            {

                return 0;
            }
            
        }

        public phome_enewsmemberfeedback GetModel(int id,int userid)
        {
           
            return dal.GetModel(id,userid);
        }
        public phome_enewsmemberfeedback GetModel(int id)
        {

            return dal.GetModel(id, 0);
        }
    }
}

