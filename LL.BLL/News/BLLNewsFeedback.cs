using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.DALFactory;
using LL.IDAL.News;
using LL.Model.News;

namespace LL.BLL.News
{
    public class BLLNewsFeedback
    {
        private INewsFeedback dal =DataAccess.CreateNewsFeedback();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(NewsFeedback model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 得到对像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsFeedback GetModel(int id)
        {
            return dal.GetModel(id);

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(NewsFeedback model)
        {

            return dal.Update(model);

        }


        /// <summary>
        /// 得到查询信息
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="searchType"></param>
        /// <param name="strSearch"></param>
        /// <param name="NewsClassID"></param>
        /// <param name="IsChecked"></param>
        /// <returns></returns>
        public System.Data.DataSet GetList(int PageIndex, int PageSize, string NewsID, string searchType, string strSearch, string NewsClassID,string pindao, bool IsChecked)
        {
            StringBuilder whereSql = new StringBuilder(" 1=1 ");

            if (!string.IsNullOrEmpty(NewsID))
            {
                whereSql.AppendFormat("  and n.NewsID={0}", NewsID);
            }
            if (Project.Common.Format.DataConvertToInt(NewsClassID) > 0)
            {
                whereSql.AppendFormat("   and   n.NewsClassID ={0}", NewsClassID);
            }

            if (!string.IsNullOrEmpty(pindao))
            {

                whereSql.AppendFormat(" and n.PageUrl='{0}'",pindao.Trim());
            }

            switch (searchType)
            {
                case "1":
                    whereSql.AppendFormat(" and n.UserName like '%{0}%'", strSearch);
                    break;
                case "2":
                    whereSql.AppendFormat(" and n.Content like '%{0}%'", strSearch);
                    break;
                case "3":
                    whereSql.AppendFormat("   and   n.IP like '%{0}%'", strSearch);
                    break;
            }
        
            if (IsChecked)
            {
                whereSql.AppendFormat(" and n.Checked =1");
            }

          return   dal.GetList(PageIndex,PageSize,whereSql.ToString());
        }


        public int  Delete(int ID)
        {
            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除 全部
        /// </summary>
        /// <param name="IDS"></param>
        /// <returns></returns>
        public int  DeleteAll(List<int> IDS)
        {
          return   dal.DeleteAll(IDS);
        }

        public  int  BatchChecked(List<int> IDS, bool  IsChecked)
        {

            return dal.BatchChecked(IDS, IsChecked);
        }

        public int  BatchRecommend(List<int> IDS, bool IsRecommend)
        {
            return dal.BatchRecommend(IDS, IsRecommend);
        }

    
    }
}
