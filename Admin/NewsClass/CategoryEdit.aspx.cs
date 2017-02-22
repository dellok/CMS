using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.News;
using LL.Common;

using Project.Common;
using LL.Model;
using LL.Common.Cache;
using LL.Model.News;

public partial class CategoryEdit : AdminPage
{

    BLLphome_enewsclass bllNewsClass = new BLLphome_enewsclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ShowNodeInfo();

        }
    }

    private void ShowNodeInfo()
    {
        string id = "0";
        string cid = Format.RequestToString(PubConstant.Key_ClassID);
        string bid = Format.RequestToString(PubConstant.Key_BClassID);



        if (!string.IsNullOrEmpty(cid)  &&  cid!="0")
        {
            id = cid;
            
        }
        if (!string.IsNullOrEmpty(bid) && bid != "0")
        {
            id = bid;

        }



        if (id == "0")
        {
            txtID.Text = "0";
            txtCName.Text = "根节点";
        }
        else if (!string.IsNullOrEmpty(id))
        {

            phome_enewsclass currentClass = bllNewsClass.GetModelFromCache(Format.DataConvertToInt(id));
           

            txtID.Text = currentClass.classid.ToString();
            txtCName.Text = currentClass.classname;

            txtParenID.Text = currentClass.bclassid.ToString();


            txtDescription.Text = currentClass.intro;
            txtOtherName.Text = currentClass.bname;

            txtTbName.Text = currentClass.tbname;
            lblCurrentClassName.Text = currentClass.classname;
            lblCurrentClassName0.Text = currentClass.classname;
            lblCurrentClassName2.Text = currentClass.classname;

            lblNodeID.Text = currentClass.classid.ToString();
         

            // drplNewsClassType.SelectedIndex = drplNewsClassType.Items.IndexOf(drplNewsClassType.Items.FindByValue(node.Value));

        }
    }
    /// <summary>
    /// 增加节点
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strErr = "";
        string CName = txtAddClassName.Text.Trim();
        int parentId = Format.DataConvertToInt(lblNodeID.Text.Trim());
        string aliasName = txtAddClassAliasName.Text.Trim();
        string description = txtAddDescription.Text.Trim();
        string path = "";



        strErr = "";
        if (string.IsNullOrEmpty(CName))
        {
            strErr += "请输入分类的名称！\\n";

        }
        if (!string.IsNullOrEmpty(strErr))
        {
            JsAlert.ShowAlert(strErr);
            return;
        }
        else
        {

            phome_enewsclass newClass = new phome_enewsclass();
            newClass.bclassid = parentId;
            newClass.classname = CName;
            newClass.bname = aliasName;
            newClass.classpath = path;
            newClass.intro = description;


            newClass.sonclass = string.Empty;
            newClass.featherclass = string.Empty;

            newClass.classtype = ".aspx";
            newClass.newspath = "Y-m-d";
            newClass.filetype = ".aspx";
            newClass.classurl = "";
            newClass.filename_qz = "";
            newClass.bname = lblCurrentClassName.Text.Trim();
            newClass.checkuser = "";
            newClass.bname = "news";

            newClass.listorderf = "";
            newClass.listorder = "";
            newClass.reorderf = "";
            newClass.reorder = "";
            newClass.classimg = "";
            newClass.classpagekey = "";
            newClass.ipath = "";
           



            int intR = bllNewsClass.Add(newClass);
            if (intR > 0)
            {


                TreeNode node = new TreeNode(CName, parentId.ToString());
               
                txtAddClassName.Text = "";
                txtAddClassAliasName.Text = "";
                txtAddDescription.Text = "";
               
                JsAlert.ShowAlert(PubMsg.Msg_AddSuccess);
            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
        }

    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string strErr = "";

        string currentClassName = txtCName.Text.Trim();
        string currentClassAlisaName = txtOtherName.Text.Trim();

        string description = txtDescription.Text.Trim();
        int currentClassID = Format.DataConvertToInt(txtID.Text.Trim());
        int parentClassID = Format.DataConvertToInt(txtParenID.Text.Trim());
        string tbName = txtTbName.Text.Trim();

        if (string.IsNullOrEmpty(currentClassName))
        {
            strErr += string.Format("分类名称不能为空!\\n");
        }

        if (!string.IsNullOrEmpty(strErr))
        {
            JsAlert.ShowAlert(strErr);
            return;
        }
        else
        {

            phome_enewsclass updateModel = bllNewsClass.GetModel(currentClassID);
            updateModel.classname = currentClassName;
            updateModel.bname = currentClassAlisaName;

            updateModel.tbname = tbName;

            updateModel.intro = description;
            updateModel.bclassid = parentClassID;

            int intR = bllNewsClass.Update(updateModel);
            if (intR > 0)
            {

                JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
        }

    }
    private void CreateDir(string path)
    {
        string strDir = string.Format("{0}/{1}", ConfigManager.DirMainDomainRoot, path.Replace(@"\", @"/"));
        // FileCommon.ExistsDir(strDir, true);

    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int id = Format.DataConvertToInt(txtID.Text.Trim());
        //判断是否有子节点
        int intSonCount = bllNewsClass.ExistsSonNode(id);
        if (intSonCount > 0)
        {
            JsAlert.ShowAlert(string.Format("请选删除子节点"));
        }
        else
        {
            int intR = bllNewsClass.DeleteAndSonNode(id);
        }

        ClearInfo();

    }

    public void ClearInfo()
    {
        txtCName.Text = "";
        txtDescription.Text = "";
        //  txtHit.Text = "";
        txtID.Text = "";
        lblNodeID.Text = "";
        txtParenID.Text = "";
        txtParentName.Text = "";
 
    }
    protected void btnMoveInfoClass_Click(object sender, EventArgs e)
    {
        int intR = 0;
        int intClassID = Format.DataConvertToInt(ucNewsClass.GetValue);
        BLLphome_ecms_news bllNews = new BLLphome_ecms_news();
        bllNews.MoveNewsClass(intClassID, Format.DataConvertToInt(lblNodeID.Text));
        JsAlert.ShowAlert(string.Format("已取移动 [{0}] 条记录!", intR));
    }


}

