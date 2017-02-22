<%@ Page Language="C#" CodeFile="top.aspx.cs" Inherits="Include_top" %>

<link rel="Stylesheet" href="/Css/main.css" type="text/css" />
<script src="/Scripts/Common.js" type="text/javascript"></script>
<style>
    body
    {
        margin-left: 0px;
        margin-top: 0px;
        margin-right: 0px;
        margin-bottom: 0px;
    }
    .title
    {
        font-size:24px;font-weight:bolder;font-family:"隶书";
    }
    .bgHover
    {
        background-image: url(/images/admin/navbgHover.jpg);
        background-repeat: repeat-x;
        padding: 0 10px 0 0px;
    }
    .bgHover a
    {
        color: #ff6600;
        text-decoration: none;
    }
    
    
    
    .bgHover a:hover
    {
        color: #000;
        text-decoration: underline;
    }
    .bgA
    {
        background-image: url(/images/admin/navbg.jpg);
        background-repeat: repeat-x;
        padding: 0 10px 0 16px;
    }
    .bgA a
    {
        color: #444;
        text-decoration: none;
    }
    .bgA a:hover
    {
        color: #ff6600;
        text-decoration: underline;
    }
    .navfont
    {
        background-color: #f8f8f8;
        font-size: 12px;
        color: #444;
        background-image: url(/images/admin/navbg2.jpg);
        background-repeat: repeat-x;
        height: 36px;
    }
</style>
<!--table width="100%" border="0" cellspacing="0" cellpadding="0" style="
    margin: 0; padding: 0">
    <tr>
        <td  valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="77%">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#f8f8f8">
                            <tr>
                                <td style="padding-left: 10px;" width="77%" class="title" valign="middle">
                               医药物流
                                </td>
                                <td align="right">
                                </td>
                                <td style="font-size: 12px; padding: 5px 20px 0 0;" align="right" width="23%" valign="top"
                                    class="style1">
                                    <%
                                        if (HttpContext.Current.Session[LL.Common.PubConstant.Key_Admin] != null)
                                        {
                                            LL.Model.Admin.AdminUser ad = (LL.Model.Admin.AdminUser)HttpContext.Current.Session[LL.Common.PubConstant.Key_Admin];
                                            Response.Write("欢迎您 ,<span style=\"color:#ff6600;\">" + ad.LoginName + "</span><b>[<a href='/logout.aspx'>退出登录</a>]</b>&nbsp;&nbsp;" + DateTime.Now.ToShortDateString() + " ");
                                        }                  
                                    %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table-->
<% if (!base.IsTempEditer())
          { %>
<table class="navfont" width="100%" border="0" cellspacing="0" cellpadding="0" style="margin: 0px;">
    <tr>
        <td align="center" class="title" width="3%">
                医药
        </td>
        <td align="center" width="5%" class="bgHover" id="tdTopBar_1">
            <a href="javascript:SetLoadMain(1)">主界面</a>
        </td>
        <td align="center" width="5%" class="bgA" id="tdTopBar_2">
            <a href="javascript:SetLoadMain(2)">信息管理</a>
        </td>

       
        <td align="center" width="5%" class="bgA" id="tdTopBar_3">
            <a href="javascript:SetLoadMain(3)">公司库管理</a>
        </td>
        <td align="center" width="5%" class="bgA" id="tdTopBar_4">
            <a href="javascript:SetLoadMain(4)">会员相关管理</a>
        </td>
        <td align="center" width="5%" class="bgA" id="tdTopBar_5">
            <a href="javascript:SetLoadMain(5)">广告·数据统计</a>
        </td>
        <td align="center" width="5%" class="bgA" id="tdTopBar_6">
            <a href="javascript:SetLoadMain(6)">Admin用户·权限</a>
        </td>
        <td align="center" width="5%" class="bgA" id="tdTopBar_7">
            <a href="javascript:SetLoadMain(7)">附件上传/管理</a>
        </td>
         <td align="center" width="5%" class="bgA" id="tdTopBar_9">
            <a href="javascript:SetLoadMain(9)">其它</a>
        </td>
       
        <td align="center" width="5%" class="bgA" id="tdTopBar_8">
            <%--<a href="javascript:SetLoadMain(8)">数据同步/更新</a>--%>
            <a onclick="javascript:SetLoadMain(8)" class="aimg">
                <img src="/Images/changedata.gif" alt="刷新数据" align="middle" style="height: 30px;
                    border: 0px;"></img><span style="font-size: 11px;">数据更新</span></a>
        </td>
       
        <td align="center" width="7%" class="bgA">
             <%
                                        if (HttpContext.Current.Session[LL.Common.PubConstant.Key_Admin] != null)
                                        {
                                            LL.Model.Admin.AdminUser ad = (LL.Model.Admin.AdminUser)HttpContext.Current.Session[LL.Common.PubConstant.Key_Admin];
                                            Response.Write("欢迎,<span style=\"color:#ff6600;\">" + ad.LoginName + "</span><b>[<a href='/logout.aspx'>退出登录</a>]</b> ");
                                        }                  
                                    %>
        </td>
    </tr>
</table>
 <%}%>
<script type="text/javascript" language="javascript">
    var tdPrefix = "tdTopBar_";
    var selectCss = "bgHover";
    var unSelectCss = "bgA";
    var PopedomParm = "<%=LL.Common.PubConstant.Key_PopedomGroup%>";
    //总数
    var tdBarCount = 15;

    function SetLoadMain(type) {
        var g = "";

        var rightUrl = "";
        switch (type) {
            case 1:
                g = "";
                rightUrl = "/News/Index.aspx";
                break;
            case 2:
                //信息管理
                g = "3,4,7,8,9,11,12,13";
                rightUrl = "/News/Index.aspx";
                break;
            case 3:
                //产品管理查询推荐
                g = "4";
                rightUrl = "/News/GskIndex.aspx";
                break;



            case 4:
                //会员网站，空间，留言管理
                g = '5,23,14,15,30';
                rightUrl = "/Member/MemberList.aspx";
                break;

            case 5:
                //广告
                g = '18,22,26';
                rightUrl = "/Ad/AdList.aspx";
                break;

            case 6:
                //人员管理
                g = '5,1,2';
                rightUrl = "/Admin/AdminList.aspx";
                break;
            case 7:

                g = '16';
                rightUrl = '/Upload/ImgList.aspx';
                break;
            case 8:
                //其它
                g = '24';
                //openwin('/Cache/INdex.aspx', '_blank', 800, 600);
                rightUrl = "/Cache/Index.aspx";
                break;
            case 9:
                //其它
                g = '28';
                rightUrl = "/News/Index.aspx";
                break;
        }


        var url = "/include/left.aspx?" + PopedomParm + "=" + g + "&mainRightUrl=" + rightUrl;
        parent.document.getElementById("mainLeft").src = url;
        parent.document.getElementById("mainRight").src = "/include/loading.htm";
        SetSelectCss(type);
    }


    //设置选中样式
    function SetSelectCss(index) {

        document.getElementById(tdPrefix + index).className = selectCss;
        for (var i = 1; i <= parseInt(tdBarCount); i++) {
            if (parseInt(index) != parseInt(i)) {
                var id = tdPrefix + i.toString();
                if (document.getElementById(id)) {
                    document.getElementById(id).className = unSelectCss;
                }

            }

        }

    }



</script>
