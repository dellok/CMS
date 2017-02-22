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
using System.IO;
public partial class Category_CategoryList : AdminPage
{

    BLLphome_enewsclass bllNewsClass = new BLLphome_enewsclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
         this.InitTreeView("");
         BindNewsClassType();
        
        }
    }



    /// <summary>
    /// 初始化
    /// </summary>
    private void InitTreeView(string currentNodeV)
    {
      
         tvCategory.Nodes[0].ChildNodes.Clear();
         tvCategory.ExpandAll();
         FillSonNodes(tvCategory.Nodes[0],"");
    }
    public void FillSonNodes(TreeNode node, string currentNodeV)
    {
        ReFillNode(node, currentNodeV);
    }
    /// <summary>
    /// 重新fill 节点
    /// </summary>
    /// <param name="node"></param>
    private void ReFillNode(TreeNode node,string currentNodeV)
    {
        node.Expand();
       
        if (node.Value==currentNodeV)
        {
             node.Selected = true;
        }

        List<phome_enewsclass> sonNode = bllNewsClass.GetSonClassByIDFromCache(Format.DataConvertToInt(node.Value));
        TreeNode newNode;

        foreach (phome_enewsclass var in sonNode)
        {
            newNode = new TreeNode(var.classname, var.classid.ToString());
            node.ChildNodes.Add(newNode);
            newNode.Expand();
            if (var.classid.ToString() == currentNodeV)
            {
                newNode.Selected = true;
                
            }

            ReFillNode(newNode,currentNodeV);
        }
    }



    protected void tvCategory_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeView node = (TreeView)sender;
       
        this.ShowNodeInfo(node.SelectedNode);
    }


    private void ShowNodeInfo(TreeNode node)
    {
        if (node.Value == "0")
        {
            txtID.Text = node.Value;
            txtCName.Text = "新闻分类";
        }
        else
        {
            phome_enewsclass currentClass = bllNewsClass.GetModelFromCache(Format.DataConvertToInt(node.Value));

            txtID.Text = node.Value;
            txtCName.Text = currentClass.classname;

            txtParenID.Text = currentClass.bclassid.ToString();
            txtParentName.Text = node.Parent.Text;
            txtDescription.Text = currentClass.intro;
            txtOtherName.Text = currentClass.bname;
            txtDirectory.Text = currentClass.classpath;

            cboxIsList.Checked = currentClass.islist > 0 ? true : false;
            lblCurrentClassName.Text = currentClass.classname;
            lblCurrentClassName0.Text = currentClass.classname;

            lblNodeID.Text = currentClass.classid.ToString();
            lblParentNodeID.Text = currentClass.bclassid.ToString();
            txtInitDir.Value = currentClass.classpath;
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

        } if (string.IsNullOrEmpty(path))
        {
            strErr += "存放文件夹不能为空！\\n";

        }
        if (CheckClassPath("2"))
        {
            strErr += "存放文件夹 已存在请选用其它名称!";
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
            newClass.islist = cboxIsList0.Checked ? 1 : 0;

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
                    InitTreeView("");
                }
                else
                { //重新填充节点
                    //当前节点
                    InitTreeView(lblNodeID.Text.Trim());
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
            strErr += "存放文件夹不能为空！\\n";

        }
  
        if (CheckClassPath("1"))
        {
            strErr += "存放文件夹不能为空！\\n";
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
            updateModel.intro = description;
            updateModel.bclassid = parentClassID;
            updateModel.islist = cboxIsList.Checked ? 1 : 0;
            int intR = bllNewsClass.Update(updateModel);
            if (intR > 0)
            {
                InitTreeView(lblNodeID.Text.Trim());
                JsAlert.ShowAlert(PubMsg.Msg_UpdateSuccess);
            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
            }
        }
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
            InitTreeView(lblParentNodeID.Text.Trim());
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

    protected void btnClose_Click(object sender, EventArgs e)
    {
        tvCategory.Nodes[0].CollapseAll();
    }
    protected void btnOpen_Click(object sender, EventArgs e)
    {
        tvCategory.Nodes[0].ExpandAll();
    }




    private void BindNewsClassType()
    {
        //List<phome_enewsclass> arrItem = bllNewsClass.GetSonClassByIDFromCache(Data.Class_ClassType_ClassID);
        //drplNewsClassType.DataSource = arrItem;
        //drplNewsClassType.DataValueField = "classid";
        //drplNewsClassType.DataTextField = "classname";
        //drplNewsClassType.DataBind();
        //drplNewsClassType2.DataSource = arrItem;
        //drplNewsClassType2.DataValueField = "classid";
        //drplNewsClassType2.DataTextField = "classname";
        //drplNewsClassType2.DataBind();
    }
    protected void btnCheckDirectory_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //找到根目录
        CheckClassPath(btn.CommandArgument);
    }
    bool  CheckClassPath(string i)
    {
        string domainroot = SEO.DominRoot;
        string dir1 = txtDirectory.Text.Trim();
        string dir2 = txtAddDirectoryInfo.Text.Trim();
        string cheDir =  dir1;
        if (i == "2")
        {
            cheDir = dir2;
        }
        cheDir = domainroot + "/" + cheDir;
        return Directory.Exists(cheDir); 
    }
}
