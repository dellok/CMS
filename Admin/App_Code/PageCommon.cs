using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
using Project.Common;
using System.Web.Routing;
using LL.Common;

/// <summary>
///PageCommon 的摘要说明
/// </summary>
public class PageCommon
{
	public PageCommon()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static string EncodingGb2312(string param)
    {
        return HttpUtility.UrlEncode(param, Encoding.GetEncoding("gb2312"));

    }

    public static List<int> GetCheckedValues(string cboxid, ListView dataViewList)
    {


        List<int> ids = new List<int>();
        foreach (var item  in dataViewList.Items)
        {

            CheckBox cbox = item.FindControl(cboxid) as CheckBox;

            if (cbox.Checked)
            {
                ids.Add(Format.DataConvertToInt(cbox.ToolTip));
            }
        }
        return ids;
    }
    public static Dictionary<int,string> GetCheckedKeyValue(string cboxid, ListView dataViewList)
    {


        Dictionary<int, string> ids = new Dictionary<int, string>();
        foreach (var item in dataViewList.Items)
        {

            CheckBox cbox = item.FindControl(cboxid) as CheckBox;

            if (cbox.Checked)
            {
                string[] c = cbox.ToolTip.Split('-');
                ids.Add(Format.DataConvertToInt(c[0]),c[1]);
            }
        }
        return ids;
    }

    #region 生成审核 ，顶,头条，置顶 html
    /// <summary>
    /// 生成审核 ，顶
    /// </summary>
    /// <param name="chk"></param>
    /// <param name="isFirstTitle"></param>
    /// <param name="isgood"></param>
    /// <param name="istop"></param>
    /// <returns></returns>
    public static string ShowCheckInfo(object chk, object isFirstTitle, object isgood, object istop, object titlepic)
    {
        StringBuilder html = new StringBuilder();

        html.AppendFormat(" <span>");
        html.AppendFormat("<span class=\"spanIsChecked\">{0} </span>", Format.DataConvertToInt(chk) > 0 ? "[审]" : "");
        if (  titlepic!=null &&  !string.IsNullOrEmpty(titlepic.ToString()))
        {
          html.AppendFormat("<span class=\"spanTitlePic\"><a href=\"{0}\" target=_blank><img src=\"/images/showimg.gif\"/></a></span>", titlepic);
        }
        html.AppendFormat("<span class=\"spanFirstTitle\">{0} </span>", Format.DataConvertToInt(isFirstTitle) > 0 ? "[头]" : "");
        html.AppendFormat("<span class=\"spanIsGood\">{0} </span>", Format.DataConvertToInt(isgood) > 0 ? "[推]" : "");
        html.AppendFormat("<span class=\"spanIsTop\">{0} </span>", Format.DataConvertToInt(istop) > 0 ? "[顶-" + istop.ToString() + "]" : "");
        html.AppendFormat(" </span>   ");
        return html.ToString();
    }
    #endregion
    private static HttpRequest req = System.Web.HttpContext.Current.Request;
    private static HttpResponse res = System.Web.HttpContext.Current.Response;
    private static System.Web.Routing.RouteData rd = new RouteData();


    #region Request RouteData.Value
    public static string GetReqRouteListParms()
    {
        StringBuilder where = new StringBuilder();
        string[] parms;
        string[] values;
        if (!string.IsNullOrEmpty(GetReqValue(PubConstant.Key_Route_ListParams)))
        {
            parms = GetReqValue(PubConstant.Key_Route_ListParams).Split(new char[] { '+' });
            for (int i = 0; i < parms.Length; i++)
            {
                values = parms[i].Split(new char[] { '_' });
                if (values.Length == 2)
                {
                    where.AppendFormat("  and  {0}='{1}'", values[0], values[1]);
                }
            }
        }
        return where.ToString();
    }
    /// <summary>
    /// 得到请求的ID
    /// </summary>
    /// <returns></returns>
    public static int GetReqID()
    {
        string id = GetReqValue(PubConstant.Key_ID);
        if (!string.IsNullOrEmpty(id))
        {
            return Format.DataConvertToInt(id);
        }
        else
        {
            return 0;
        }
    }
    public static string GetReqValue(string key)
    {
        if (!string.IsNullOrEmpty(req.Params[key]))
        {

            return Filter.FilterSqlInput(req[key].ToString()).Trim();
        }

        else if (rd.Values[key] != null)
        {

            return Filter.FilterSqlInput(rd.Values[key].ToString()).Trim();
        }
        else
        {

            return string.Empty;
        }
    }

    public static string GetReqValueNoSqlFilter(string key)
    {
        if (!string.IsNullOrEmpty(req.Params[key]))
        {
            return req[key].ToString();
        }
        else if (rd.Values[key] != null)
        {

            return rd.Values[key].ToString();
        }
        else
        {
            return string.Empty;
        }
    }
    /// <summary>
    /// 得到分类ID
    /// </summary>
    public static int GetReqClassID()
    {
        string classid = GetReqValue(PubConstant.Key_ClassID);

        if (!string.IsNullOrEmpty(classid))
        {
            return Format.DataConvertToInt(classid);
        }
        else
        {

            return 0;
        }


    }

    #endregion

    #region 批量删除数据所得到的ID

    /// <summary>
    /// checkbox id
    /// listview 控件
    /// 返回List<int> 数组
    /// 得到选中与非选中的值
    /// </summary>
    /// <param name="checkID"></param>
    /// <param name="control"></param>
    /// <returns></returns>
    public static void GetCheckedValues(string checkID, ListView control, ref  List<int> arrCheckedIDS, ref List<int> arrUnCheckedIDS)
    {
        try
        {
            foreach (var item in control.Items)
            {
                CheckBox cbox = item.FindControl(checkID) as CheckBox;
                if (!string.IsNullOrEmpty(cbox.ToolTip))
                {
                    int id = Project.Common.Format.DataConvertToInt(cbox.ToolTip);
                    if (id > 0)
                    {

                        if (cbox.Checked)
                        {
                            arrCheckedIDS.Add(id);
                        }
                        else
                        {
                            arrUnCheckedIDS.Add(id);
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public static List<string> GetCheckedValues2(string checkID, ListView control)
    {
        List<string> arrCheckedIDS = new List<string>();
        try
        {
            foreach (var item in control.Items)
            {
                CheckBox cbox = item.FindControl(checkID) as CheckBox;
                if (!string.IsNullOrEmpty(cbox.ToolTip))
                {
                    string id = cbox.ToolTip;
                    if (cbox.Checked)
                    {
                        arrCheckedIDS.Add(id);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        if (arrCheckedIDS.Count == 0)
        {
            JsAlert.ShowAlert("没有可操作项!");
        }
        return arrCheckedIDS;
    }
    #endregion

    /// <summary>
    /// 得到会员组名
    /// </summary>
    /// <param name="gid"></param>
    /// <returns></returns>
    public static string  GetGroupName(int gid)
    {
        LL.BLL.Member.BLLphome_enewsmembergroup bll = new LL.BLL.Member.BLLphome_enewsmembergroup();
        return bll.GetGroupName(gid);
    }
}