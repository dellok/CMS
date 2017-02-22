<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="MyPwd.aspx.cs" Inherits="Admin_MyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a> > <a href="AdminList.aspx">Admin会员管理</a>
            > 修改我的登录密码</span>
    </div>
    <table cellspacing="1" cellpadding="0" width="100%" border="0" class="tb_info">
        <tr>
            <td class="left">
                用户名:
            </td>
            <td  class="right">
                <asp:Label ID="lblLoginName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
          <td class="left">
                新密码:
            </td>
   <td  class="right">
                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="repNewPwd" runat="server" ControlToValidate="txtNewPwd"
                    ErrorMessage="密码不能为空!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
          <td class="left">
                重复新密码:
            </td>
           <td  class="right">
                <asp:TextBox ID="txtReplyNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqReplyPwd" runat="server" ControlToValidate="txtReplyNewPwd"
                    ErrorMessage="重复密码不能为空!"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPwd"
                    ControlToValidate="txtReplyNewPwd" ErrorMessage="两次输入密码不一致!"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnUpdatePwd" runat="server" Text="  确 定  " OnClick="btnUpdatePwd_Click"
                    CssClass="btn" />
           
            </td>
        </tr>
    </table>
</asp:Content>
