using System;
using System.Data;
using LL.Model.News;
using LL.IDAL;

namespace LL.IDAL.News
{
/// <summary>
/// 公司库
/// </summary>
	public interface Iphome_ecms_gsk:IRepository<phome_ecms_gsk>,IBase<phome_ecms_gsk>
	{
		

        phome_ecms_gsk GetModel(int NewsID, int userid);

        int BatchChecked(System.Collections.Generic.List<int> arrIDS, bool check);

        int BatchDel(System.Collections.Generic.List<int> arrIDS);

        int BatchRecomend(System.Collections.Generic.List<int> arrIDS, bool isRecomend);

        int BatchFirstTitle(System.Collections.Generic.List<int> arrIDS, bool isFirstTitle);

        int BatchIsTop(System.Collections.Generic.List<int> arrIDS, int topNum);

        int BatchFiling(System.Collections.Generic.List<int> arrIDS);

        int SignHaveHtml(int ID, int p);
    } 
}
