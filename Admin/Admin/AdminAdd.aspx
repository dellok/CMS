<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="AdminAdd.aspx.cs" Inherits="Admin_AdminAdd" %>
<%@ Register  Src="~/UserControl/AdminRoleDownList.ascx" TagName="AdminRoleDownList" TagPrefix="UC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">
<div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a> > <a href="AdminList.aspx" >Admin会员管理</a> > Admin会员添加</span>
    </div>
  <table cellspacing="1" cellpadding="0" width="100%" border="0"  class="tb_info">

        <tr>
            <td align="right" style="width:30%; height:25px;">
                真实姓名：
            </td>
            <td width="*" align="left" style="height:25px">
                <asp:TextBox ID="txtRealName" runat="server" Width="200px" onblur="ExistsName(this.value,'spanRealName','R')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqRealName" runat="server" ControlToValidate="txtRealName"
                    ErrorMessage="姓名不能为空!" SetFocusOnError="True"></asp:RequiredFieldValidator><span
                        id="spanRealName" class="msgSpan"></span>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:30%; height:26px;">
                登录名：
            </td>
            <td width="*" align="left">
                <asp:TextBox ID="txtLoginName" runat="server" Width="200px" onblur=" ExistsName(this.value,'spanLoginName','L')"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqLoginName" runat="server" ControlToValidate="txtLoginName"
                    ErrorMessage="登录名不能为空!" SetFocusOnError="True"></asp:RequiredFieldValidator><span
                        id="spanLoginName" class="msgSpan"></span>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:30%; height:25px;">
                登录密码：
            </td>
            <td width="*" align="left" style="height:25px">
                <asp:TextBox ID="txtLoginPwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginPwd"
                    ErrorMessage="密码不能为空!" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
            <tr>
                <td align="right" style="width:30%; height:25px;">
                    重复密码：
                </td>
                <td width="*" align="left" style="height:25px">
                    <asp:TextBox ID="txtReplyPwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReplyPwd"
                        ErrorMessage="密码不能为空!" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtLoginPwd"
                        ControlToValidate="txtReplyPwd" ErrorMessage="两次输入密码不一致"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width:30%; height:25px">
                    角色：
                </td>
                <td width="*" align="left" style="height:25px">
                   
                   <UC:AdminRoleDownList id="ucAdminRole" runat="server"></UC:AdminRoleDownList>

                </td>
            </tr>
            <tr>
                <td align="right" style="width:30%; height:25px">
                    备注：
                </td>
                <td width="*" align="left" style="height:25px">
                    <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" style="width:30%">
                    是否启用：
                </td>
                <td height="25" width="*" align="left">
                    <asp:CheckBox ID="cboxAvailable" runat="server" Checked="true" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height:25px">
                    <div align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="· 增加 ·" OnClick="btnAdd_Click"  CssClass="btn"></asp:Button>&nbsp&nbsp;&nbsp;&nbsp;
                                   &nbsp&nbsp;&nbsp;&nbsp;

                              <input  type="button" value=" 返回会员列表 " onclick="javascript:location.href='AdminList.aspx';"  class="btn"/>
                    </div>
                </td>
            </tr>
    </table>





</asp:Content>

