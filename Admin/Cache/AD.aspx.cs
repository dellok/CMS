using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.Common.Cache;
using System.Text;
using Project.Common;
using System.IO;
using LL.BLL.News;
using LL.Model.News;
using LL.Model.AD;
using LL.BLL.AD;
using System.Data;
using LL.Common.EnumClass;

public partial class Cache_AD : AdminPage
{

    BLLADList bllAD = new BLLADList();
    /// <summary>
    /// 存储广告JS路径(位于主域名/cache/adjs中)
    /// 此为绝对物理路径
    /// </summary>
    string dir = ConfigManager.PhyDir_JsAD;
    public string adpage = "";
    public string ADPagePosition = "";
    public string seq = "";

    public List<string> arrPosi = new List<string>();// Data.PagePosition();
    public StringBuilder msg = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        string adpage = Request[PubConstant.Key_ADPage];
        string position = Request[PubConstant.Key_ADPagePosition];
        string seq = Request[PubConstant.Key_ADSeq];


        adpage = HttpUtility.UrlDecode(adpage);



        //生成单个广告js
        if (!string.IsNullOrEmpty(adpage) && !string.IsNullOrEmpty(position) && !string.IsNullOrEmpty(seq) && position.ToUpper().Trim() != "H")
        {
            int iSeq = Format.DataConvertToInt(seq);
            iSeq = iSeq > 0 ? iSeq : 1;
            msg.Append(GetADInfo(adpage, position, iSeq));
        }
        else if (!string.IsNullOrEmpty(adpage) && !string.IsNullOrEmpty(position))
        {
            msg.Append(GetADInfo(adpage, position, 0));
        }
        else if (!string.IsNullOrEmpty(adpage))
        {

            msg.Append(GetADInfo(adpage, string.Empty, 0));
        }
        else
        {

            msg.Append(GetADInfo(string.Empty, string.Empty, 0));
        }
    }
    private string GetADInfo(string ADPage, string ADPagePosition, int Seq)
    {
        StringBuilder msg2 = new StringBuilder();
        List<ADList> arrItems = bllAD.GetAllADList(true);

     
        //if (arrItems.Count > 0)
        //{
        //    arrItems = arrItems.Where(m => m.IsRecycle == false && m.Checked == true).OrderByDescending(m => m.InDate).ToList();
        //}
        if (!string.IsNullOrEmpty(ADPage) && !string.IsNullOrEmpty(ADPagePosition) && Seq > 0)
        {
            arrItems = arrItems.Where(m => m.Page == ADPage && m.Position == ADPagePosition && m.Seq == Seq).ToList();
        }
        else if (!string.IsNullOrEmpty(ADPage) && !string.IsNullOrEmpty(ADPagePosition))
        {

            arrItems = arrItems.Where(m => m.Page == ADPage && m.Position == ADPagePosition).ToList();
        }
        else if (!string.IsNullOrEmpty(ADPage))
        {

            string[] arrADPage = ADPage.Split(new char[] { ',' });


            List<ADList> temp = new List<ADList>();

            if (arrADPage.Length > 1)
            {

                foreach (string p in arrADPage)
                {

                    if (string.IsNullOrEmpty(p))
                    {
                        continue;
                    }
                    foreach (ADList item in arrItems.Where(m => m.Page == p).ToList())
                    {

                        temp.Add(item);
                    }
                }
                arrItems = temp;
            }
            else
            {
                arrItems = arrItems.Where(m => m.Page.Contains(ADPage)).ToList();
            }
        }
        //幻灯片广告
        #region  生成幻灯片广告
        List<ADList> arrSildeItems = new List<ADList>();

        if (arrItems.Count > 0)
        {
            arrSildeItems = arrItems.Where(m => m.Position.Contains("H") || m.Position.Contains("h")).ToList();
        }
        if (arrSildeItems.Count > 0)
        {
            //找到分组
            var groupSlideItem = from p in arrSildeItems group p by p.Page into g select g;
            foreach (var item in groupSlideItem)
            {
                List<ADList> arrPageSlideItems = arrSildeItems.Where(m => m.Page == item.Key.ToString()).ToList();
                msg2.Append(WriteADSlideJs(arrPageSlideItems));
            }
            msg2.Append("<br/>");
        }
        //不包含幻灯片广告
        arrItems = arrItems.Where(m => !m.Position.Contains("H")).ToList();
        //生成首页top幻灯片广告
        List<ADList> arrIndexA1Items = arrItems.Where(m => m.Page.Trim() == "首页" && m.Position.ToLower() == "a1").ToList();

        if (arrIndexA1Items.Count() > 1)
        {
            msg2.AppendFormat(WriteIndexTopADJs(arrIndexA1Items));
            foreach (var item in arrIndexA1Items)
            {
                arrItems.Remove(item);
            }
        }
        #endregion
        foreach (ADList item in arrItems)
        {
            if (item != null)
            {
                msg2.AppendFormat(WriteADJs(item));
            }
        }



     string  delMsg=  DelExpiredAD();

     return msg2.ToString() + "<br/>=======================【删除广告文本信息】 ================================<br/>" + delMsg;
    }





    private string WriteIndexTopADJs(List<ADList> arrAD)
    {
        int itopCount = arrAD.Count();
        string fileName = "";
        string filePhyPath = "";
        if (arrAD.Count > 0)
        {
            fileName = string.Format("{0}_{1}_{2}.js", arrAD[0].Page, arrAD[0].Position, arrAD[0].Seq);
        }
        filePhyPath = dir + "/" + fileName;
        filePhyPath = filePhyPath.Replace(@"/", @"\");


        StringBuilder js = new StringBuilder();
        js.AppendFormat("<div id='slideBox' class='slideBox'>");
        js.AppendFormat("	<div class='hd'>");
        js.AppendFormat("<ul>");
        for (int i = 1; i < itopCount + 1; i++)
        {

            js.AppendFormat("<li>{0}</li>", i);
        }
        js.AppendFormat("</ul>");
        js.AppendFormat("	</div>");

        js.AppendFormat("	<div class='bd'>");
        js.AppendFormat("		<ul>");


        foreach (ADList adItem in arrAD)
        {
            int w = adItem.Width;
            int h = adItem.Height;
            string css = "";
            string img = "";
            string eventFun = string.Format("javascript:ADClass.ADHit2({0},'{1}','{2}')", adItem.ID, adItem.Url, adItem.Title);
            if (w > 0) { css += string.Format("width:{0}px;", w); }
            if (h > 0) { css += string.Format("height:{0}px;", h); }
            if (adItem.FileClass == (int)FileClass.Image)
            {
                img = string.Format(@"<img  src='{0}'  style='{1}' onclick={2}  />", adItem.FileUrl, css, eventFun);
            }
            else { img = string.Format(@"<embed src='{0}'    style={1} />", adItem.FileUrl, css); }

            js.AppendFormat("<li>{0}</li>", img);
        }
        js.AppendFormat("</ul>");
        js.AppendFormat("</div>");
        js.AppendFormat("</div>");

        js.Append("<script> jQuery('.slideBox').slide({ mainCell: '.bd ul', effect: 'topLoop', autoPlay: true }); </script> ");

        string script = string.Format("document.write(\"{0}\");", js.ToString());
        string msg = string.Format("生成幻灯片广告【{0}】成功！\r\n<br>", fileName);

        WriteJS(filePhyPath, script);
        return msg;
    }

    private string WriteADSlideJs(List<ADList> arrAD)
    {

        StringBuilder script = new StringBuilder();
        string fileName = "";
        string filePhyPath = "";
        if (arrAD.Count > 0)
        {
            fileName = string.Format("{0}_{1}.js", arrAD[0].Page, arrAD[0].Position);
        }
        filePhyPath = dir + "/" + fileName;
        filePhyPath = filePhyPath.Replace(@"/", @"\");
        //script.AppendFormat("       kss_content_id = \"{0}\";", KssContentID);
        //script.AppendFormat("       kss_content_w = \"{0}\";", SlideImgWidth);
        //script.AppendFormat("       kss_content_h = \"{0}\";", SlideImgHeight);
        script.AppendFormat("       var kss_imgUrl = new Array();");
        script.AppendFormat("       var kss_imgLink = new Array();");
        script.AppendFormat("       var kss_imgTz = new Array();");
        script.AppendFormat("       var kss_hitEvent = new Array();");
        script.AppendFormat("       var adNum = 0;");

        for (int i = 0; i < arrAD.Count(); i++)
        {
            ADList item = arrAD[i];

            int w = Format.DataConvertToInt(item.Width);
            int h = Format.DataConvertToInt(item.Height);
            string url = item.Url;
            string id = item.ID.ToString();
            string eventFun = string.Format("javascript:ADClass.ADHit({0},'{1}'))", id, url);
            string imgUrl = item.FileUrl;
            string title = item.Title;
            script.AppendFormat("       kss_imgUrl[{0}] = \"{1}\";", i, imgUrl);
            script.AppendFormat("       kss_imgLink[{0}]= \"{1}\";", i, url);


            if (string.IsNullOrEmpty(title))
            {
                script.AppendFormat("kss_imgTz[{0}] =' ';", i);
            }
            else
            {
                script.AppendFormat("kss_imgTz[{0}] =   decodeURI(\"{1}\");", i, HttpUtility.UrlEncode(title, Encoding.UTF8));
            }
            //script.AppendFormat("kss_imgTz[{0}] =   decodeURI(\"{1}\");", i,  HttpUtility.UrlEncode(title,Encoding.UTF8));
            script.AppendFormat("kss_hitEvent[{0}] = \"{1}\";", i, eventFun);
        }


       string msg = string.Format("生成幻灯片广告【{0}】成功！\r\n<br>", fileName);

        WriteJS(filePhyPath, script.ToString());
        return msg;
    }

    private string WriteADJs(ADList adItem)
    {

        StringBuilder adHtml = new StringBuilder();
        string img = "";
        string fileName = "";
        string filePhyPath = "";

        int w = Format.DataConvertToInt(adItem.Width);
        int h = Format.DataConvertToInt(adItem.Height);
        string url = adItem.Url;
        string id = adItem.ID.ToString();
        string css = "";
        string title = adItem.Title;
        string eventFun = string.Format("javascript:ADClass.ADHit2({0},'{1}','{2}')", id, url, title);

        fileName = string.Format("{0}_{1}_{2}.js", adItem.Page, adItem.Position, adItem.Seq);
        filePhyPath = dir + "/" + fileName;
        filePhyPath = filePhyPath.Replace(@"/", @"\");

        string msg = string.Format("生成广告【{0}】成功！广告存入服务器地址:{1}\r\n<br>", fileName, filePhyPath);
        if (w > 0)
        {
            css += string.Format("width:{0}px;", w);
        }
        if (h > 0)
        {
            css += string.Format("height:{0}px;", h);
        }
        if (adItem.FileClass == (int)FileClass.Image)
        {
            img = string.Format(@"<img  src=\""{0}\""  style=\""{1}\"" onclick=\""{2}\""  />", adItem.FileUrl, css, eventFun);
        }
        else
        {
            img = string.Format(@"<embed src=\""{0}\""    style=\""{1}\"" />", adItem.FileUrl, css);
        }
        adHtml.AppendFormat("document.write(\"{0}\");", img);
        //adHtml.AppendFormat(@"$(document).ready(function(){1}  ADClass.ADPV({0});{2});", id, "{", "}");
        WriteJS(filePhyPath, adHtml.ToString());
        return msg;
    }

    private void WriteJS(string filePhyPath, string js)
    {

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        try
        {
            FileInfo file = new FileInfo(filePhyPath);
            FileStream fs = file.Open(FileMode.Create);
            fs.Lock(0, fs.Length);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            sw.Write(js.ToString());
            sw.Close();
        }
        catch (Exception ee)
        {
            //BLLErrorMsg bllError = new BLLErrorMsg();
            //msg = string.Format("生成广告【{0}】JS出错!原因:{1}", filePhyPath + "-" + fileName, ee.StackTrace + "--" + ee.TargetSite + "--" + ee.Source);
            //bllError.Add(msg);
        }
    }



    /// <summary>
    /// 删除已存在,但已过期的广告,
    /// </summary>
    /// <param name="arrItems"></param>
    /// <returns></returns>
    private string DelExpiredAD()
    {
        StringBuilder SS = new StringBuilder();

        List<ADList> arrItems = bllAD.GetAllADList(true);
        DirectoryInfo f = new DirectoryInfo(dir);
        FileInfo[] files = f.GetFiles();
        List<string> delFile = new List<string>();
        foreach (var item in files)
        {
            String filename = item.Name;
            string[] s = filename.Replace(".js", "").Split('_');


          

            if (!arrItems.Exists(m => m.Page == s[0] && m.Position == s[1] && m.Seq == Format.DataConvertToInt(s[2])))
            {
                delFile.Add(item.FullName);
            }

         
        }
      
    return   DelAdJsFile(delFile);
    }

    private string  DelAdJsFile(List<string> delFile)
    {
        //删除已存在，但不启用的广告
        StringBuilder msg = new StringBuilder();
        foreach (string  fileName in delFile)
        {
            msg.AppendFormat("<BR/>删除广告文件:[{0}],删除结果:{1}<BR/>", fileName, FileCommon.DelFile(fileName));
        }
       return msg.ToString();
    }
    }
   
