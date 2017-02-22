using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using LL.BLL.News;
using LL.Common;
using LL.Model.News;
public partial class UserControl_NewsClassDropdownList : System.Web.UI.UserControl
{
    BLLphome_enewsclass bllClass = new BLLphome_enewsclass();

    /// <summary>
    /// 像素步长
    /// </summary>
    private const int paddingStep = 20;
    //不选择任何项
    private const string DefultValue = "-1";

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {

            ShowClassList();

        }
     

    }



    private void ShowClassList()
    {
        phome_enewsclass model = new phome_enewsclass();
     
        List<phome_enewsclass> allClass = bllClass.GetSonClassByIDFromCache(ClassID);

        if (ClassID <1)
        {
            model.classid = 0;
            model.classname = "分类目录";
        }
        else
        { 
           model = bllClass.GetModelByCache(ClassID);
        }
        ///
        int padding = paddingStep;
        //进行填充
        ListItem newItem = new ListItem();
        newItem.Text = string.Format("{0}{1}", PubConstant.Key_Sign_ClassSplitSign, model.classname);
        newItem.Value = model.classid.ToString();
        newItem.Attributes.Add("style","font-weight:bolder;");

        listBoxNewsClassList.Items.Add(newItem);

        string strSign=string.Format("{0}",PubConstant.Key_Sign_ClassSplitSign);
        if (!IsSearchSonList)
        {
            FillClass(allClass,    padding);
        }
        else
        {
            FillOneLevelClass(allClass, padding);

        }
    }


    /// <summary>
    /// 只真充当前分类下的子类
    /// </summary>
    private void FillOneLevelClass(List<phome_enewsclass> allClass,int  padding)
    {
       //进行子类填充
        foreach (var item in allClass)
        {
            ListItem newItem = new ListItem();
            newItem.Text = string.Format("{0}{1}", PubConstant.Key_Sign_ClassSplitSign, item.classname);
            newItem.Value = item.classid.ToString();
            newItem.Attributes.Add("style", string.Format("padding-left:{0}px;",padding));
            listBoxNewsClassList.Items.Add(newItem);

          
        }
    }
    /// <summary>
    /// 进行数据绑定
    /// </summary>
    /// <param name="sonList"></param>
    /// <param name="currentClassID"></param>
    private void FillClass(List<phome_enewsclass>  sonClass,int  padding)
    {
        if (sonClass!=null)
        {
        if (sonClass.LongCount() > 0)
        {
            foreach (var item in sonClass)
            {
                ListItem newItem = new ListItem();
                newItem.Text = string.Format("{0}{1}",PubConstant.Key_Sign_ClassSplitSign,item.classname);
                newItem.Value = item.classid.ToString();
                //判断有无子类
                int classid = (int)item.classid;
                var   sonClass2 = bllClass.GetSonClassByIDFromCache(classid).OrderBy(c => c.classid).ToList<phome_enewsclass>();
              //填充子项


                string pd = Server.HtmlDecode("&nbsp;&nbsp;");

                for (int i = 1; i <padding/10; i++)
                {
                    pd += Server.HtmlDecode("&nbsp;&nbsp;");
                    
                }


                newItem.Text = pd + newItem;


                newItem.Attributes.Add("style", string.Format("background:#66ccff;"));
            //    newItem.Attributes.Add("style", string.Format("padding-left:{0}px;background:#66ccff;", padding));
                newItem.Attributes.Add("title", "true");
                listBoxNewsClassList.Items.Add(newItem);

                if (sonClass2 != null)
                {
                    if (sonClass2.LongCount() > 0)
                    {
                        //重新设置属性
                        newItem.Attributes.Add("style", string.Format("font-weight:bolder;padding-left:{0}px;", padding));
                      

                        FillClass(sonClass2, padding + paddingStep);
                    }

                }
              
            }
        }
            else
            {

                return;
        
            }

        }




    }

    #region  属性

    /// <summary>
    /// 设置控件宽度
    /// </summary>
    public   int    Width
    {
        set {

            if (value>0)
            {

                listBoxNewsClassList.Width = value;

            }
            else
            {
               listBoxNewsClassList.Width = 280;
            }
        }
    }
    /// <summary>
    /// 设置高度
    /// </summary>
    public int Height
    {
        set
        {
            if (value > 0)
            {
                listBoxNewsClassList.Height = value;

            }
            else
            {
                listBoxNewsClassList.Height = 400;
            }
        }
    
    }


    private const  string  Key_V_IsSearchSonClass="sc";
    /// <summary>
    /// 是否只查询基子类
    /// </summary>
    public bool IsSearchSonList
    {
        get {
            if (ViewState[Key_V_IsSearchSonClass] != null)
            {
                return Project.Common.Format.DataConvertToBool(ViewState[Key_V_IsSearchSonClass]);
            }
            else
            {
                return false;
            }
        }
        set { ViewState[Key_V_IsSearchSonClass] = value; }
    
    }

    private const string Key_V_ClassID = "classid";
    /// <summary>
    /// 是类ID
    /// </summary>
    public  int  ClassID
    {
        get
        {
            if (ViewState[Key_V_ClassID] != null)
            {
                return Project.Common.Format.DataConvertToInt(ViewState[Key_V_ClassID]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState[Key_V_ClassID] = value; }

    }


    private const string Key_V_ClassIDS = "classidS";
    /// <summary>
    /// 是根ID 组 中间用,隔开
    /// </summary>
    public int ClassIDS
    {
        get
        {
            if (ViewState[Key_V_ClassIDS] != null)
            {
                return Project.Common.Format.DataConvertToInt(ViewState[Key_V_ClassIDS]);
            }
            else
            {
                return 0;
            }
        }
        set { ViewState[Key_V_ClassIDS] = value; }

    }

    /// <summary>
    /// 设置显示选择项
    /// </summary>
    public string SetValue
    {


        set
        {

            if (string.IsNullOrEmpty(value))
            {
                listBoxNewsClassList.SelectedIndex = listBoxNewsClassList.Items.IndexOf(listBoxNewsClassList.Items.FindByValue(DefultValue));
            }
            else
            {
                listBoxNewsClassList.SelectedIndex = listBoxNewsClassList.Items.IndexOf(listBoxNewsClassList.Items.FindByValue(value));
            }
        }
    }

    /// <summary>
    /// 得到选择项
    /// </summary>
    public string GetValue
    {
        get
        {
            return listBoxNewsClassList.SelectedValue;
        }


    }






    /// <summary>
    /// 得到选择的item
    /// </summary>
    public ListItem SelectedItem
    {
        get
        {
            return listBoxNewsClassList.SelectedItem;
        }


    }

    #endregion

}