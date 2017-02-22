using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Common;
using LL.BLL.Admin;
using LL.BLL.Popedom;

using Project.Common;
using LL.Model.Popedom;

public partial class Include_left : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        FillTree();
    }





    /// <summary>
    /// 我的信息 groupid 
    /// </summary>
    private readonly int GroupID_MyInfo = 21;

    void FillTree()
    {
        string target = "mainRight";
        string toUrl = "/loginSuccess.aspx";

       

       List<string>  GroupIDs =new List<string>();

        //取出显示模块
        if (!string.IsNullOrEmpty(Format.RequestToString(PubConstant.Key_PopedomGroup)))
        {
            string g = Format.RequestToString(PubConstant.Key_PopedomGroup);

  
            GroupIDs= g.Split(new char[] { ',' }).ToList();
        }
        if (Request.QueryString["mainRightUrl"] != null)
        {
            toUrl = Request.QueryString["mainRightUrl"];

        }
        //当前会员角色

        int currentLoginRole = CurrentLogin.AdminRoleID;


        //admin全部权限功能列表
        BLLPopedomFunInAdminRole bllFunInAdmin = new BLLPopedomFunInAdminRole();
        List<PopedomFunInAdminRole> arrAdminFun = bllFunInAdmin.GetModelAllByCache().Where(m => m.PopedomRoleID == currentLoginRole).ToList();
        ///功能点
        BLLPopedomFun bllFun = new BLLPopedomFun();
        List<PopedomFun> arrFunList = bllFun.GetModelAllByCache().Where(m => m.showInMenu == true).ToList();
        ///功能组
        BLLPopedomFunGroup bllFunGroup = new BLLPopedomFunGroup();
        List<PopedomGroup> arrGroup = bllFunGroup.GetModelAllByCache().OrderBy(m => m.Order).ToList();

        PopedomGroup myInfoGroup = arrGroup.Where(g => g.ID == GroupID_MyInfo).First();
        //最到请求的组功能,否则显示所有功能组
        if (GroupIDs.Count()>0)
        {
           var   gIDS= from  GS in  GroupIDs  select new  {  ID=Format.DataConvertToInt(GS)};
           arrGroup = (from m in arrGroup join gid in gIDS on m.ID equals gid.ID  select m).ToList();
           //增加我的信息功能组
           arrGroup.Add(myInfoGroup);
           arrGroup = arrGroup.OrderBy(m=>m.Order).ToList();
        }
   

 
        //会员功能组合
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("<script>  d = new dTree('d'); ");
        sb.AppendFormat("  d.add(0,-1,'管理员后台') ;");
        foreach (PopedomGroup g in arrGroup)
        {
            string currGroupName = g.Name;
            string currGroupID = g.ID.ToString();

            var AdminFunList = from f in arrFunList.Where(m=>m.PopedomGroupID==g.ID && m.showInMenu==true).ToList()
                               join a in arrAdminFun
                               on f.ID equals  a.PopedomFunID        
                               select new { FunID = f.ID, Url = f.Url, FunName = f.Name };


            if (AdminFunList.Count()<1)
            {

                continue;
            }

            sb.AppendFormat("   d.add({0},{1},'{2}','javascript:void();','group','','','',true); ", currGroupID, 0, currGroupName);
            foreach (var fun in AdminFunList)
            {

                sb.AppendFormat("d.add(999{0},{1},'{2}','{3}','{4}','{5}','','' ,true);",
               fun.FunID.ToString(), currGroupID, fun.FunName, fun.Url, fun.Url, target);
            }
        }
        sb.AppendFormat("d.config.useIcons='/scripts/dtree/img/';");
        sb.AppendFormat("document.write(d);    var   mainRightUrl='" + toUrl + "';   </script>");
        divTree.InnerHtml = sb.ToString();
    }
}