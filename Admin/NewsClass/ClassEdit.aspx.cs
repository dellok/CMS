using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.BLL.News;
using LL.Common;

using Project.Common;
using LL.Model.News;
using LL.Common.Cache;
public partial class ClassEdit : AdminPage
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

        string  id = Format.RequestToString(PubConstant.Key_ID);


        if (id == "0")
        {
            txtID.Text = "0";
            txtCName.Text = "根节点";
        }
        else if (!string.IsNullOrEmpty(id))
        {
        
            phome_enewsclass currentClass = bllNewsClass.GetModelFromCache(Format.DataConvertToInt(id));
            phome_enewsclass fClass = bllNewsClass.GetModel(currentClass.bclassid);

            txtID.Text = currentClass.classid.ToString();
            txtCName.Text = currentClass.classname;

            txtParenID.Text = currentClass.bclassid.ToString();


            txtParentName.Text = fClass != null ? fClass.classname : "根节点";
            txtDescription.Text = currentClass.intro;
            txtOtherName.Text = currentClass.bname;
            txtDirectory.Text = currentClass.classpath;
            txtTbName.Text = currentClass.tbname;
            lblCurrentClassName.Text = currentClass.classname;
            lblCurrentClassName0.Text = currentClass.classname;

            lblNodeID.Text = currentClass.classid.ToString();
            lblParentNodeID.Text = currentClass.bclassid.ToString();

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
        string path = txtAddDirectoryInfo.Text.Trim();



        strErr = "";
        if (string.IsNullOrEmpty(CName))
        {
            strErr += "请输入分类的名称！\\n";

        }
        if (string.IsNullOrEmpty(path))
        {
            strErr += string.Format("栏目存放文件夹不能为空!\\n");
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
            CreateDir(path);
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
            newClass.tbname = txtAddClassName.Text;
            newClass.listorderf = "";
            newClass.listorder = txtAddOrder.Text.Trim();
            newClass.reorderf = "";
            newClass.reorder = "";
            newClass.classimg = "";
            newClass.classpagekey = "";
            newClass.ipath = "";
            // newClass.CodeNumber = "";
            //newClass.tbname = "news";



            int intR = bllNewsClass.Add(newClass);
            if (intR > 0)
            {


                TreeNode node = new TreeNode(CName, parentId.ToString());
                if (parentId == 0)
                {
                   
                }
                else
                { //重新填充节点
                    //当前节点
                  
                }
                txtAddClassName.Text = "";
                txtAddClassAliasName.Text = "";
                txtAddDescription.Text = "";
                txtAddDirectoryInfo.Text = "";
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
        string path = txtDirectory.Text.Trim();
        string description = txtDescription.Text.Trim();
        int currentClassID = Format.DataConvertToInt(txtID.Text.Trim());
        int parentClassID = Format.DataConvertToInt(txtParenID.Text.Trim());

        if (string.IsNullOrEmpty(currentClassName))
        {
            strErr += string.Format("分类名称不能为空!\\n");
        }
        if (string.IsNullOrEmpty(path))
        {
            strErr += string.Format("栏目存放文件夹不能为空!\\n");
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
            updateModel.classpath = path;
            CreateDir(path);
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
        FileCommon.ExistsDir(strDir, true);
        
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
        txtHit.Text = "";
        txtID.Text = "";
        lblNodeID.Text = "";
        txtParenID.Text = "";
        txtParentName.Text = "";
        lblParentNodeID.Text = "";
    }






    protected void btnCheckDirectory_Click(object sender, EventArgs e)
    {

        string strDir = txtDirectory.Text.Trim();


        CheckDir(strDir);


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string strDir = txtAddDirectoryInfo.Text.Trim();


        CheckDir(strDir);


    }

    void CheckDir(string strDir)
    {
        if (!string.IsNullOrEmpty(strDir))
        {
            strDir = string.Format("{0}/{1}", ConfigManager.DirMainDomainRoot, strDir.Replace(@"\", @"/"));
            if (FileCommon.ExistsDir(strDir))
            {

                JsAlert.ShowAlert("此文件夹已存在，请选用其它名称文件夹!");
            }
            else
            {

                JsAlert.ShowAlert("可以使用!");
            }
        }
        else
        {
            JsAlert.ShowAlert("文件夹名称不能为空!");
        }
    }
}
