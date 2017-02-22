using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.BLL.News;

using System.Data;
using LL.Common;
using System.Text;
using LL.Model.News;

public partial class NewsTotal : Page
{
    BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
    BLLphome_enewsclass bllClass = new BLLphome_enewsclass();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindList();

        }
    }


    #region 绑定列表

    /// <summary>
    /// 显示信息列表
    /// </summary>
    private void BindList()
    {
        string strDateMsg = "";
        string strClassPath = "全部分类";
        string strTitleMsg = "无";

        StringBuilder where = new StringBuilder();
        string strKeyWord = txtKeyWord.Text.Trim();
        string strSDate = txtSDate.Text.Trim();
        string strEDate = txtEDate.Text.Trim();
   
      //  string strChecked = radioCheckType.SelectedValue;
        string isMebmer = radioPostRole.SelectedValue;
        
      

        int cid =Format.DataConvertToInt(newsClass.GetValue);
        

        if (cid>0)
	{

        strClassPath = bllClass.GetClassPath(cid," > ");
            
            
            if (bllClass.GetSonClassByIDFromCache(cid).Count()>0 )
        {
            where.AppendFormat("     and  classid in(select classid from phome_enewsclass where bclassid ={0}  )    ", cid);

        }
        else
        {

                where.AppendFormat(" and  classid={0}", cid);
            
        }
	}


      

         
            ///新闻发布时间
            if (!string.IsNullOrEmpty(strSDate))
            {
                where.AppendFormat(" and  cast(newstime as datetime)>='{0}'", strSDate);
                strDateMsg += "从  " + strSDate;
            }
            if (!string.IsNullOrEmpty(strEDate))
            {
                where.AppendFormat(" and   cast(newstime as datetime)<='{0}'", strEDate);
                strDateMsg += " 至 " + strEDate;
            }


            ////审核状态
            //if (!string.IsNullOrEmpty(strChecked) && strChecked != "-1")
            //{
            //    where.AppendFormat(" and   checked={0}", strChecked);
            //}
            //判断关键字
            if (!string.IsNullOrEmpty(strKeyWord))
            {
              
                    where.AppendFormat(" and  title like '%{0}%'  ", strKeyWord);

                    strTitleMsg = strKeyWord;
            }


            if (!string.IsNullOrEmpty(isMebmer) && isMebmer != "-1")
            {


                where.AppendFormat(" and  ismember={0}", isMebmer);

            }

          
        


     string sql=string.Format("select count(onclick) from phome_ecms_news  where 1=1 {0}",where.ToString());

      object totel=  DBUtility.DbHelperSQL.GetSingle(sql);



      lblClassName.Text = strClassPath;
      lblTotal.Text = Format.DataConvertToInt(totel).ToString();
      lblDate.Text = string.IsNullOrEmpty(strDateMsg)?"全部时间":strDateMsg;
      lblTitleMsg.Text = strTitleMsg;



       

    }
    #endregion


   

    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindList();
    }

    protected void pager_PageChanged(object sender, EventArgs e)
    {
        this.BindList();
    }

  
}