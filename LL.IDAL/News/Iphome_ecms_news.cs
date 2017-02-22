using System;
using System.Data;
using LL.Model.News;
using LL.IDAL;
namespace LL.IDAL.News
{

	public interface Iphome_ecms_news: IRepository<phome_ecms_news>
    {
		#region  成员方法

        DataSet GetList(int pageindex, int pagesize, string where, string orderby);
		int Add(LL.Model.News.phome_ecms_news model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        int Update(LL.Model.News.phome_ecms_news model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
        int Delete(int id);
        int DeleteList(string idlist);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		LL.Model.News.phome_ecms_news GetModel(int id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		

		#endregion  成员方法

        int GetDataRows(string where);



        DataSet GetTopTitleByClassID(int TopNum, string ClassID, string orderby);

       
        int  SelectNewsHit(int id, int classid, int down);


        Model.News.phome_ecms_news GetModel(int NewsID, int userid);

        DataSet GetModelByIDAndClassID(int id, int classid);

        int BatchChecked(System.Collections.Generic.List<int> arrIDS, bool check);

        int BatchDel(System.Collections.Generic.List<int> arrIDS);

        int BatchRecomend(System.Collections.Generic.List<int> arrIDS, bool isRecomend);

        int BatchFirstTitle(System.Collections.Generic.List<int> arrIDS, bool isFirstTitle);

        int BatchIsTop(System.Collections.Generic.List<int> arrIDS, int topNum);

        int BatchChecked(System.Collections.Generic.List<int> arrIDS, bool check, int userid);

        int BatchDel(System.Collections.Generic.List<int> arrIDS, int userid);

        int BatchRecomend(System.Collections.Generic.List<int> arrIDS, bool isRecomend, int userid);

        int BatchFirstTitle(System.Collections.Generic.List<int> arrIDS, bool isFirstTitle, int userid);

        int BatchIsTop(System.Collections.Generic.List<int> arrIDS, int topNum,int userid);

        int BatchFiling(System.Collections.Generic.List<int> arrIDS);

        int UpdateNewsClass(System.Collections.Generic.List<int> arrIDS, int intClassID);

        DataSet GetTitleList(int PageIndex, int PageSize, string where, string orderby);

        DataSet GetTopTitleList(int topNum, string where, string orderby);

        DataSet GetMemberPostNewsCount(int userid);

        int  UpdateHit(int id);
        int GetHit(int id);
        int UpdateVoteNum(int id);
        int GetVoteNum(int id);

        phome_ecms_news GetModelByDataRow(DataRow dataRow);

        int SignHaveHtml(int id, int havehtml);

        int  Delete(int id, int userid);





        int MoveNewsClass(int intClassID, int toClassID);

        DataSet GetIndexTitleList();

        DataSet GetIndexZhanHui();
    } 
}
