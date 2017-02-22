using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.News;


namespace LL.IDAL.News
{
   public  interface INewsFeedback:IBase<NewsFeedback>
    {

        System.Data.DataSet GetList(int PageIndex, int PageSize, string where);

        int DeleteAll(List<int> IDS);

        int BatchChecked(List<int> IDS, bool IsChecked);

        int BatchRecommend(List<int> IDS, bool IsRecommend);
    }
}
