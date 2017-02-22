using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using LL.Common;
using LL.BLL.News;

using Project.Common;
using LL.Model.News;

public partial class News_NewsAdd : AdminPage
{
    BLLphome_ecms_news bllNews = new BLLphome_ecms_news();

    BLLphome_enewsclass bllNClass = new BLLphome_enewsclass();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            txtPostTime.Text = DateTime.Now.ToString();
            txtUserName.Text = base.CurrentLogin.LoginName;
           // txtWriter.Text = base.CurrentLogin.LoginName;
            this.ShowAddClass();
        }
    }


    private void ShowAddClass()
    {
        int intClassID = base.GetReqNewsClassID;
        
        if (base.GetReqNewsClassID<1)
        {
            intClassID = !string.IsNullOrEmpty(base.GetReqBClassID) ? Format.DataConvertToInt(base.GetReqBClassID) : 0;
        }

        if (intClassID<1)
        {

            return;
        }


        #region 分类有关的
       txtCurrentClassID.Text = intClassID.ToString();

        List<string> cpath = new List<string>();
        bllNClass.GetClassPathFromCache(intClassID, ref cpath);

        string path = "";
        foreach (string item in cpath)
        {
            path += item + ">>";
        }

        lblClassPath.Text = Util.FilterStartAndEndSign(path, ">>");
        #endregion
    }
    #region 添加新闻

    void AddNews()
    {
        //新闻描述最大字符数
        int MaxDescriptionLen=500;
        //添加的分类ID

        StringBuilder strError = new StringBuilder();

        if (string.IsNullOrEmpty(ucNewsCommonInput.TxtTitle))
        {
            strError.AppendFormat("{0}\\n", PubMsg.Msg_Title_NeedInput);
        }

        //if (string.IsNullOrEmpty(txtNewsContent.Value))
        //{
        //    strError.AppendFormat("{0}\\n", PubMsg.Msg_Content_NeedInput);
        //} 

        if (strError.ToString().Trim() != "")
        {
            JsAlert.ShowAlert(strError.ToString());
            return;
        }


        int intClassID = Format.DataConvertToInt(txtCurrentClassID.Text.Trim());


        if (bllNClass.ExistsSonNode(intClassID) > 0)
        {

            JsAlert.ShowAlert("不是最终分类，请重新选择分类!");
        
        }


        //副标题
        string strSubTitle = Util.SplitHTML(txtSubHead.Text.Trim());
        //简介，内容
        
        string strContent = txtNewsContent.Value.Trim();
        string strDescription = Util.SplitHTML(txtDescription.Text.Trim());
        if (string.IsNullOrEmpty(strDescription))
        {
            string tempContent = Util.SplitHTML(strContent).Replace("&nbsp;","");
            strDescription = tempContent.Length > MaxDescriptionLen ? tempContent.Substring(0, MaxDescriptionLen) : tempContent;
        }
        //发布时间，作者，来源
        string strPostTime = string.IsNullOrEmpty(txtPostTime.Text.Trim())?DateTime.Now.ToString():txtPostTime.Text.Trim();
        string strWriter = txtWriter.Text.Trim();
        string strUserName = txtUserName.Text.Trim();
        string strSource = txtSource.Text.Trim();
        //关键字替换,远程保存图片,加水印,远程保存FLASH,地址前缀
        bool isDoKey = cboxDoKey.Checked;
        /* bool isCopyImg = cboxCopyImg.Checked;
         bool isMark = cboxMark.Checked;
         bool isCopyFlash = cboxCopyFlash.Checked;
         string strFlashUrl = txtQz_Url.Text.Trim();

         // 内容自动分页 ,每字一页 ,取第一张上传图作为标题图片
         bool isAutoPage = cboxAutoPage.Checked;
         string strAutoPageSize = txtAutoSize.Text.Trim();
         * */
        bool isGetFirestTitlePic = cboxGetFirstTitlePic.Checked;

        string fh = drplFH.SelectedValue;
        int fhGroupID = Format.DataConvertToInt(ucGroupID.GetValue);


        phome_ecms_news model = new phome_ecms_news();

        //添加 用户ID ,是否为会员,新闻分类ID
        model.userid = base.CurrentLogin.ID;
        model.ismember = 0; ;
        model.classid = intClassID;


        #region 推荐,审核,头条,是否开启评论,标题样式
        //推荐,审核,头条,是否开启评论
        model.isgood = ucNewsCommonInput.IsGood;
        model.@checked = ucNewsCommonInput.IsChecked;
        model.istop = ucNewsCommonInput.IsTop;
        model.closepl = ucNewsCommonInput.CloseFeedback;
        model.filenameqz = ucNewsCommonInput.FilenameQZ;
        model.firsttitle = ucNewsCommonInput.FirstTitle;
        model.title = Util.SplitHTML(ucNewsCommonInput.TxtTitle);
        model.titlefont = ucNewsCommonInput.TitleFont;
        model.titlepic = ucNewsCommonInput.TitlePicUrl;

        model.truetime =Format.DataConvertToInt(Format.DateTimeToUnixTimeStamp(DateTime.Now));
        model.filename = model.truetime.ToString();

        model.keyboard = ucNewsCommonInput.KeyWord;
        model.titleurl = ucNewsCommonInput.TitleOutUrl;
        model.onclick = 0;

        #endregion
        //浏览权限
        model.fh = Format.DataConvertToInt(fh);
        model.groupid = fhGroupID;
        //生成html 前缀

       
        model.ftitle = strSubTitle;
        //发布时间,作者，来源
        model.newstime = Format.DataConvertToDateTime(strPostTime);
        model.befrom = strSource;
        model.writer = strWriter;
        model.username = strUserName;
        //描述，内容
        model.smalltext = Util.SplitHTML(strDescription);
        model.newstext = strContent;
        //关键字替换
        model.dokey = isDoKey?1:0;

     //   model.LastUpdateTime = DateTime.Now.ToString();

        //加水印
        //内容自动分页,每页页数
        int intR = bllNews.Add(model);
        if (intR > 0)
        {


           

            JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent, PubMsg.Msg_AddSuccess, "newslist.aspx");
           // string url = string.Format();                       
           // JsAlert.ShowAlert(JsAlert.AlertType.OpenNewWindow, "刷新新闻", "");
        
       

        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }


    }

 

   
   
    #endregion
 
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        AddNews();

    }
}