using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.Model.Member;
using LL.DALFactory;
using LL.IDAL.Member;
namespace LL.BLL.Member
{

	public partial class BLLphome_enewsfavaclass
	{
		private readonly Iphome_enewsfavaclass dal=DataAccess.Createphome_enewsfavaclass();
		public BLLphome_enewsfavaclass()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LL.Model.Member.phome_enewsfavaclass model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int  Update(LL.Model.Member.phome_enewsfavaclass model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  Delete(int cid)
		{
			
			return dal.Delete(cid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int  DeleteList(string cidlist )
		{
			return dal.DeleteList(cidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LL.Model.Member.phome_enewsfavaclass GetModel(int cid)
		{
			
			return dal.GetModel(cid);
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
		public List<LL.Model.Member.phome_enewsfavaclass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LL.Model.Member.phome_enewsfavaclass> DataTableToList(DataTable dt)
		{
			List<LL.Model.Member.phome_enewsfavaclass> modelList = new List<LL.Model.Member.phome_enewsfavaclass>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LL.Model.Member.phome_enewsfavaclass model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LL.Model.Member.phome_enewsfavaclass();
					if(dt.Rows[n]["cid"]!=null && dt.Rows[n]["cid"].ToString()!="")
					{
						model.cid=int.Parse(dt.Rows[n]["cid"].ToString());
					}
					if(dt.Rows[n]["cname"]!=null && dt.Rows[n]["cname"].ToString()!="")
					{
					model.cname=dt.Rows[n]["cname"].ToString();
					}
					if(dt.Rows[n]["userid"]!=null && dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
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

        public List<phome_enewsfavaclass> GetListByUserID(int userid)
        {
            return dal.GetListByUserID(userid);
        }

    

        public int Delete(int id, int userid)
        {

            return dal.Delete(id, userid);
            
        }

        public bool ExistsClassName(string strFClass, int userid)
        {
            return ExistsClassName(strFClass,userid,0);
        }

        public bool ExistsClassName(string cname, int userid, int id)
        {
            return dal.ExistsClassName(cname,userid,id);
        }
    }
}

