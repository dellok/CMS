<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="MemberGroupUpdate.aspx.cs" Inherits="Member_MemberGroupUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a> ><a href="MemberGroupList.aspx">会员组管理</a>
            > 会员组修改</span>
    </div>
    <table cellspacing="1" cellpadding="0" width="100%" border="0" class="tb_info">
        <tr>
            <td class="left">
                会员组名称：
            </td>
            <td class="right">
                <asp:TextBox ID="txtMemberGroupName" runat="server" Width="200px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMemberGroupName"
                    ErrorMessage="会员组名不能为空!" ToolTip="会员组名不能为空!" ValidationGroup="add"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="left">
                会员组级别值：
            </td>
            <td class="right">
                <asp:TextBox ID="txtMemberGroupLevel" runat="server" Width="200px" Text="1"></asp:TextBox>
                (如：1,2...等，级别值越高权限越大)
            </td>
        </tr>
        <tr>
            <td class="left">
                最大收藏夹数：
            </td>
            <td class="right">
                <asp:TextBox ID="txtMemberFavoriteLimitNum" runat="server" Width="200px" Text="120"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left">
                每天最大下载数：
            </td>
            <td class="right">
                <asp:TextBox ID="txtDownLimitNum" runat="server" Width="200px" Text="0"></asp:TextBox>
                <font color="#666666">(0为不限制)</font>
            </td>
        </tr>
        <tr>
            <td class="left">
                每天最大短信息数：
            </td>
            <td class="right">
                <asp:TextBox ID="txtMsgLimitNum" runat="server" Width="200px" Text="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left">
                短信息最大字数：
            </td>
            <td class="right">
                <asp:TextBox ID="txtMsgContentLimtNum" runat="server" Width="200px" Text="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left">
                前台可注册：
            </td>
            <td class="right">
                <asp:RadioButtonList ID="radioListRegisterInWeb" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="True" Text="否" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="left">
                注册需要审核：
            </td>
            <td class="right">
                <asp:RadioButtonList ID="radiolistNeedCheck" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="True" Text="否" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td height="25" colspan="2">
                <div align="center">


           <asp:Button ID="Button1" runat="server" Text="【· 返回会员组 ·】"  CssClass="btn" 
                        onclick="Button1_Click" Height="26px" >
                    </asp:Button>     &nbsp;&nbsp;&nbsp;&nbsp;      <asp:Button ID="btnUpdate" runat="server" 
                        Text="【· 修改 ·】" OnClick="btnUpdate_Click"  CssClass="btn" Height="26px">
                    </asp:Button>
                    <input type="hidden" id="hiddenID" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
