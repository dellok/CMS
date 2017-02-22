using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.DALFactory;
using LL.IDAL.Member;
using LL.Model.Member;
namespace LL.BLL.Member
{

	public partial class BLLphome_enewshy
	{
		private readonly Iphome_enewshy dal=DataAccess.Createphome_enewshy();
		public BLLphome_enewshy()
		{}
		#region  Method

        public bool ExistsCName(string cname, int userid,int fid)
        {


            return dal.ExistsCName(cname, userid, fid);

        }
     public  bool   ExistsCName(string cname,int  userid)
        {


            return ExistsCName(cname, userid, 0);

        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(phome_enewshy model)
		{
		return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(phome_enewshy model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int id)
		{
			
			return dal.Delete(id);
        }
        public int Delete(int id, int userid)
        {
            
            return dal.Delete(id, userid);
        }

        public int Update(int id, string cname)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public phome_enewshy GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewshy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<phome_enewshy> DataTableToList(DataTable dt)
		{
			List<phome_enewshy> modelList = new List<phome_enewshy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				phome_enewshy model;
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere,string  by)
        {
            return dal.GetList(PageSize, PageIndex, strWhere,by);
        }

		#endregion  Method

        public DataSet GetList(int PageIndex, int PageSize, string where)
        {
            return dal.GetList(PageSize, PageIndex, where, "");
        }

    }
}

