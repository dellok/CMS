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
public partial class News_NewsEdit : AdminPage
{
    BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
    BLLphome_enewsclass bllNClass = new BLLphome_enewsclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindNewsInfo();
        }

    }

    #region 属性
    #endregion

    /// <summary>
    /// 显示新闻
    /// </summary>
    private void BindNewsInfo()
    {
        phome_ecms_news model = bllNews.GetModel(base.GetReqIDValue);


        if (model != null)
        {

            if (base.IsTempEditer() && model.userid != CurrentLogin.ID)
            {
                JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent, "只能操作自己发布的新闻!", "newslist.aspx");
                return;
            }

            #region  //审核，头条，推荐,置顶,
            ucNewsCommonInput.IsGood = Format.DataConvertToInt(model.isgood);
            ucNewsCommonInput.IsChecked = Format.DataConvertToInt(model.@checked);
            ucNewsCommonInput.FirstTitle = Format.DataConvertToInt(model.firsttitle);
            ucNewsCommonInput.CloseFeedback = Format.DataConvertToInt(model.closepl);
            ucNewsCommonInput.FilenameQZ = model.filenameqz;
            ucNewsCommonInput.IsTop = Format.DataConvertToInt(model.istop);
            ucNewsCommonInput.TitleFont = model.titlefont;
            ucNewsCommonInput.TitlePicUrl = model.titlepic;
            ucNewsCommonInput.TxtTitle = Util.SplitHTML(model.title);
            ucNewsCommonInput.TitleOutUrl = model.titleurl;
            ucNewsCommonInput.KeyWord = model.keyboard;

        
            #endregion

            #region 分类有关的

            txtCurrentClassID.Text = model.classid.ToString();
            int classid=Format.DataConvertToInt(model.classid);
            lblClassPath.Text = LL.BLL.BLLNewsCommon.GetCurClassToRootUrlPath(classid,false);
            #endregion

            //浏览权限
            drplFH.SelectedIndex = drplFH.Items.IndexOf(drplFH.Items.FindByValue(model.fh.ToString()));
            ucGroupID.SetValue = model.groupid.ToString();


            txtSubHead.Text = model.ftitle;
            //发布时间,作者，来源
            txtPostTime.Text = model.newstime.ToString();

            txtSource.Text = model.befrom;
            txtWriter.Text = model.writer;
            txtUserName.Text = model.username;
            //描述，内容
            txtDescription.Text = Util.SplitHTML(model.smalltext).Replace("&nbsp;","");
         //   txtNewsContent.Value = model.newstext;

            string strDescription = Util.SplitHTML(txtDescription.Text.Trim());

            txtNewsContent.Value = model.newstext;
          
         

            //关键字替换
            cboxDoKey.Checked = Format.DataConvertToBool(model.dokey);
            //取第一张上传图作为标题图片
            cboxGetFirstTitlePic.Checked = Format.DataConvertToBool(model.firsttitle);



        }

    }


    #region 修改
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Edit();

    }

    void Edit()
    {
        int MaxDescriptionLen = txtDescription.MaxLength;

        int NewsID = GetReqIDValue;


        //添加的分类ID
        int intClassID = Format.DataConvertToInt(txtCurrentClassID.Text.Trim());
        //副标题
        string strSubTitle = txtSubHead.Text.Trim();
        string strKeyWord = ucNewsCommonInput.KeyWord;
        string strTitleUrl = ucNewsCommonInput.TitleOutUrl;
        //简介，内容
        string strDescription = txtDescription.Text.Trim();
        string strContent = txtNewsContent.Value.Trim();

        if (string.IsNullOrEmpty(strDescription))
        {
            string tempContent = Server.HtmlDecode( strContent.Replace("&nbsp;", ""));
            strDescription = tempContent.Length > MaxDescriptionLen ? tempContent.Substring(0, MaxDescriptionLen) : tempContent;
        }

        //发布时间，作者，来源
        string strPostTime = txtPostTime.Text.Trim();
        string strWriter = txtWriter.Text.Trim();
        string strSource = txtSource.Text.Trim();
        //关键字替换,远程保存图片,加水印,远程保存FLASH,地址前缀
        bool isDoKey = cboxDoKey.Checked;

        bool isGetFirestTitlePic = cboxGetFirstTitlePic.Checked;
        //置顶级别

        //浏览权限
        //条件，大于或大于等于
        string fh = drplFH.SelectedValue;
        int fhGroupID = Format.DataConvertToInt(ucGroupID.GetValue);
        //文件前缘


        phome_ecms_news model = bllNews.GetModel(NewsID);


        #region 推荐,审核,头条,是否开启评论,标题样式
        //推荐,审核,头条,是否开启评论
        model.isgood = ucNewsCommonInput.IsGood;
        model.@checked = ucNewsCommonInput.IsChecked;
        model.istop = ucNewsCommonInput.IsTop;
        model.closepl = ucNewsCommonInput.CloseFeedback;
        model.filenameqz = ucNewsCommonInput.FilenameQZ;
        model.firsttitle = ucNewsCommonInput.FirstTitle;
        model.title = ucNewsCommonInput.TxtTitle;
        model.titlefont = ucNewsCommonInput.TitleFont;
        model.titlepic = ucNewsCommonInput.TitlePicUrl;
        model.keyboard = ucNewsCommonInput.KeyWord;
        model.titleurl = ucNewsCommonInput.TitleOutUrl;

        #endregion

        //添加 用户ID ,是否为会员,新闻分类ID

        model.ftitle = strSubTitle;
        model.classid = intClassID;

        //浏览权限
        model.fh = Format.DataConvertToInt(fh);
        model.groupid = fhGroupID;


        //发布时间,作者，来源
        model.newstime = Format.DataConvertToDateTime(strPostTime);
        model.befrom = strSource;
        model.writer = strWriter;
        //描述，内容


        model.smalltext = strDescription;
        model.newstext = strContent;
        //关键字替换
        model.dokey = isDoKey ? 1 : 0;
        //远程保存图片





        //加水印
        //内容自动分页,每页页数
        int intR = bllNews.Update(model);
        if (intR > 0)
        {

            string url = string.Format("NewsList.aspx?{0}={1}", PubConstant.Key_ClassID, model.classid);
            JsAlert.ShowAlert(JsAlert.AlertType.OpenWindowInCurrent, PubMsg.Msg_UpdateSuccess, url);
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }




    }
    #endregion


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Edit();
    }
}