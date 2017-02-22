using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace Project.Common
{
    public class JsAlert : Page
    {
        /// <summary>
        /// 提示信息的操作类型
        /// </summary>
        public enum AlertType
        {

            /// <summary>
            /// 在父窗口打开链接
            /// </summary>
            OpenWindowInParent,
            /// <summary>
            /// 在当前窗口打开链接
            /// </summary>
            OpenWindowInCurrent,
            /// <summary>
            /// 在新窗口打开一个页
            /// </summary>
            OpenNewWindow,
            /// <summary>
            /// 在框架中打开一个页
            /// </summary>
            OpenWindowInFrame,
            /// <summary>
            /// 关闭所有窗口
            /// </summary>
            CloseWindow,
            /// <summary>
            /// 重新加裁当前页
            /// </summary>
            ReLoatCurrentPage,
            /// <summary>
            /// 重新加载父窗
            /// </summary>
            ReLoadParentPage,
            /// <summary>
            ///只显示对话框不做其它操作
            /// </summary>
            OnlyMsgAlert,
            /// <summary>
            /// 返回上一页
            /// </summary>
            Back
        }
        #region
        /// <summary>
        /// 在客户端弹出提示框 或转发URL
        /// </summary>
        /// <param name="alertType">操作类型</param>
        /// <param name="strURL">转发链接</param>
        /// <param name="strMsg">提示信息</param>
        /// <param name="strFrameName">框架名称</param>
        private static void ShowAlert(AlertType alertType, string strMsg, string strURL, string strFrameName)
        {

            StringBuilder strJs = new StringBuilder("<script language='javascript' type='text/javascript'>");
            if (!string.IsNullOrEmpty(strMsg))
            {
                //strJs.AppendFormat(" onload=function () {1} alert('{0}');{2}", strMsg,"{","}");
                strJs.AppendFormat(" alert('{0}');", strMsg);
            }
            string strTempJs = null;
            if (!string.IsNullOrEmpty(strURL))
            {
                switch (alertType)
                {
                    case AlertType.OpenWindowInParent:
                        strTempJs = string.Format("top.window.location='{0}';", strURL);
                        break;
                    case AlertType.OpenWindowInCurrent:
                        strTempJs = string.Format("window.location='{0}';", strURL);
                        break;
                    case AlertType.OpenNewWindow:
                        strTempJs = string.Format("window.open({0},'_black');", strURL);
                        break;
                    case AlertType.OpenWindowInFrame:
                        strTempJs = CreateFrameJs(strURL, strFrameName, strTempJs);
                        break;

                    case AlertType.CloseWindow:
                        strTempJs = string.Format("parent.opener=null;top.window.close();");
                        break;
                    case AlertType.Back:
                        strTempJs = string.Format("history.back();");
                        break;
                    case AlertType.ReLoatCurrentPage:
                        strTempJs = string.Format("window.location='{0}';", HttpContext.Current.Request.Url.AbsoluteUri);
                        break;

                    case AlertType.ReLoadParentPage:
                        strTempJs = string.Format("top.window.location.reload();");
                        break;
                    default:
                        break;
                }

            }

            strJs.Append(strTempJs);
            strJs.Append("</script>");
    ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(System.Web.HttpContext.Current.Handler.GetType(), "jsKey", strJs.ToString(), false);
     
        }
        /// <summary>
        /// 在客户端弹出提示框 或转发URL
        /// </summary>
        /// <param name="alertType">操作类型</param>
        /// <param name="strURL">转发链接</param>
        /// <param name="strMsg">提示信息</param>
        /// <param name="strFrameName">框架名称</param>
        public static string CreateClientJs(AlertType alertType, string strMsg, string strURL, string strFrameName)
        {

            StringBuilder strJs = new StringBuilder("<script language='javascript' type='text/javascript'>");
            if (!string.IsNullOrEmpty(strMsg))
            {
                strJs.AppendFormat("alert('{0}');", strMsg);

            }
            string strTempJs = null;
            if (!string.IsNullOrEmpty(strURL))
            {
                switch (alertType)
                {
                    case AlertType.OpenWindowInParent:
                        strTempJs = string.Format("top.window.location='{0}';", strURL);
                        break;
                    case AlertType.OpenWindowInCurrent:
                        strTempJs = string.Format("window.location='{0}';", strURL);
                        break;
                    case AlertType.OpenNewWindow:
                        strTempJs = string.Format("window.open({0},'_black');", strURL);
                        break;
                    case AlertType.OpenWindowInFrame:
                        strTempJs = CreateFrameJs(strURL, strFrameName, strTempJs);
                        break;

                    case AlertType.CloseWindow:
                        strTempJs = string.Format("parent.opener=null;top.window.close();");
                        break;
                    case AlertType.Back:
                        strTempJs = string.Format("window.back(-1);");
                        break;
                    case AlertType.ReLoatCurrentPage:
                        strTempJs = string.Format("window.location='{0}';", HttpContext.Current.Request.Url.AbsoluteUri);
                        break;

                    case AlertType.ReLoadParentPage:
                        strTempJs = string.Format("top.window.location.reload();");
                        break;
                    default:
                        break;
                }

            }

            strJs.Append(strTempJs);
            strJs.Append("</script>");





            return strJs.ToString();



        }


        public void RegisterClientJs(string js)
        {



        }


        private static string CreateFrameJs(string strURL, string strFrameName, string strTempJs)
        {


            if (!string.IsNullOrEmpty(strFrameName))
            {
                strTempJs = string.Format("{0}.location={1}", strFrameName, strURL);
            }
            return strTempJs;
        }




        #endregion

        /// <summary>
        /// 提示信息，不做任何操作
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowAlert(string msg)
        {
            ShowAlert(AlertType.OnlyMsgAlert, msg, null, null);
        }
        /// <summary>
        /// 在框架中加裁页
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="strUrl">转发链接</param>
        /// <param name="FrameName">框架名称</param>
        public static void ShowAlertInFrame(string strMsg, string strUrl, string strFrameName)
        {
            ShowAlert(AlertType.OpenWindowInFrame, strMsg, strUrl, strFrameName);
        }

        /// <summary>
        /// 客户端提示信息
        /// </summary>
        /// <param name="alertType">操作类型</param>
        /// <param name="strMsg">提示信息</param>
        /// <param name="strURL">转发链接</param>
        public static void ShowAlert(AlertType alertType, string strMsg, string strURL)
        {
            ShowAlert(alertType, strMsg, strURL, string.Empty);
        }


  /// <summary>
  /// 
  /// </summary>
  /// <param name="js"></param>
  /// <param name="IsCludeScriptTag"></param>
        public static void WriteJs(string js, bool IsCludeScriptTag)
        {
            if (!IsCludeScriptTag)
            {
                js = string.Format("<script type='text/javascript'>{0}</script>", js);
            }
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(System.Web.HttpContext.Current.Handler.GetType(), "jsKey", js, false);
        }

     

        public static void WriteJs(string js)
        {
            js = string.Format("<script type='text/javascript'>{0}</script>", js);
            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).ClientScript.RegisterStartupScript(System.Web.HttpContext.Current.Handler.GetType(), "jsKey", js, false);
        }

        /// <summary>
        /// 提示操作信息并返回上一页
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowAlertBack(string msg)
        {
            ShowAlert(AlertType.Back, null, null);
        }
        /// <summary>
        /// 转向Url制定的页面
        /// </summary>
        /// <param name="url">连接地址</param>
        public static void JavaScriptLocationHref(string url)
        {
            string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            string js = @"<Script language='JavaScript'>
                    parent.opener=null;window.close();  
                  </Script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
        }
        #region 弹窗函数


        /// <summary>
        /// 打开指定大小的新窗体
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="width">宽</param>
        /// <param name="heigth">高</param>
        /// <param name="top">头位置</param>
        /// <param name="left">左位置</param>
        public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
        {

            string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

            HttpContext.Current.Response.Write(js);

        }



        /**/
        /// <summary>x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        /// 打开指定大小位置的模式对话框x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        /// </summary>x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        /// <param name="webFormUrl">连接地址</param>x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        /// <param name="width">宽</param>x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        /// <param name="height">高</param>x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        /// <param name="top">距离上位置</param>x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        /// <param name="left">距离左位置</param>x>°n.é¼Ùbbs.51aspx.comÐnEW7øØÞ
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {

            string features = "dialogWidth:" + width.ToString() + "px"
                         + ";dialogHeight:" + height.ToString() + "px"
                         + ";dialogLeft:" + left.ToString() + "px"
                         + ";dialogTop:" + top.ToString() + "px"
                         + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
            ShowModalDialogWindow(webFormUrl, features);
        }


        private static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        private static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            #region
            string js = @"<script language=javascript>                            
                            showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
            #endregion
        }

        #endregion
    }
}
