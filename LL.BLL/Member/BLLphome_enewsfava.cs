using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.Model.Member;
using LL.DALFactory;
using LL.IDAL.Member;
using System.Text;
using Project.Common;
namespace LL.BLL.Member
{
	/// <summary>
	/// phome_enewsfava
	/// </summary>
	public partial class BLLphome_enewsfava
	{
		private readonly Iphome_enewsfava dal=DataAccess.Createphome_enewsfava();
		public BLLphome_enewsfava()
		{}
		#region  Method

		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LL.Model.Member.phome_enewsfava model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(LL.Model.Member.phome_enewsfava model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int favaid)
		{
			
			return dal.Delete(favaid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int DeleteList(string favaidlist )
		{
			return dal.DeleteList(favaidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Member.phome_enewsfava GetModel(int favaid)
		{
			
			return dal.GetModel(favaid);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LL.Model.Member.phome_enewsfava> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LL.Model.Member.phome_enewsfava> DataTableToList(DataTable dt)
		{
			List<LL.Model.Member.phome_enewsfava> modelList = new List<LL.Model.Member.phome_enewsfava>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LL.Model.Member.phome_enewsfava model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LL.Model.Member.phome_enewsfava();
					if(dt.Rows[n]["favaid"]!=null && dt.Rows[n]["favaid"].ToString()!="")
					{
						model.favaid=int.Parse(dt.Rows[n]["favaid"].ToString());
					}
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["favatime"]!=null && dt.Rows[n]["favatime"].ToString()!="")
					{
						model.favatime=DateTime.Parse(dt.Rows[n]["favatime"].ToString());
					}
					if(dt.Rows[n]["userid"]!=null && dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					if(dt.Rows[n]["username"]!=null && dt.Rows[n]["username"].ToString()!="")
					{
					model.username=dt.Rows[n]["username"].ToString();
					}
					if(dt.Rows[n]["classid"]!=null && dt.Rows[n]["classid"].ToString()!="")
					{
						model.classid=int.Parse(dt.Rows[n]["classid"].ToString());
					}
					if(dt.Rows[n]["cid"]!=null && dt.Rows[n]["cid"].ToString()!="")
					{
						model.cid=int.Parse(dt.Rows[n]["cid"].ToString());
					}
					modelList.Add(model);
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method

        public DataSet GetList(int PageIndex, int PageSize, string where)
        {

            return dal.GetList(PageIndex, PageSize, where, "");
        }

        public int Delete(int fid, int userid)
        {

            return dal.Delete(fid, userid);
           
        }

        public int DelectAll(List<int> arrID, int userid)
        {

            string ids="";


            foreach (int  item in arrID)
            {


               ids+= string.Format("{0},",item);
                 
               
            }
            ids = Util.SplitStartEndComma(ids);
            string where = string.Format("userid={0}",userid);
            return dal.DeleteList(ids, where);
           

        }
    }
}

