<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="MemberGroupList.aspx.cs" Inherits="Member_MemberGroupList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
<div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a>  > 会员组列表</span>
    </div>
    <asp:ListView ID="dataViewList" runat="server" ItemPlaceholderID="itemList" 
        DataKeyNames="groupid" onitemdeleting="dataViewList_ItemDeleting"
       >
        <LayoutTemplate>
            <table class="tb_grid" cellspacing="1" cellpadding="0">
                <tr class="tr_grid_title">
                    <th class="th_grid_title">
                        ID
                    </th>
                    <th class="th_grid_title">
                        名称
                    </th>
                    <th class="th_grid_title">
                        级别值
                    </th>
                    <th class="th_grid_title">
                        最大收藏夹数
                    </th>
                    <th class="th_grid_title">
                        每天最大下载数
                    </th>
                    <th class="th_grid_title">
                        每天最大短信息数
                    </th>
                    <th class="th_grid_title">
                        短信息最大字数
                    </th>
                    <th class="th_grid_title">
                        前台可注册
                    </th>
                    <th class="th_grid_title">
                        注册需审核
                    </th>
                    <th class="th_grid_title">
                        操作
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="tr_grid_row">
                <td class="td_grid_col w80">
                    <%#Eval("groupid")%>
                </td>
                <td class="td_grid_col td_wrap w200">
                    <%#Eval("groupname")%>
                </td>
                <td class="td_grid_col w80">
                    <%#Eval("level") %>
                </td>
                <td class="td_grid_col td_wrap w80">
                    <%#Eval("favanum")%>
                </td>
                <td class="td_grid_col w80">
                    <%#Eval("daydown") %>
                </td>
                <td class="td_grid_col w80">
                    <%#Eval("msglen")%>
                </td>
                <td class="td_grid_col w80">
                    <%#Eval("msgnum") %>
                </td>
                <td class="td_grid_col w80">
                    <%#Project.Common.Format.DataConvertToBool(Eval("canreg"))%>
                </td>
                <td class="td_grid_col w80">
                    <%#Project.Common.Format.DataConvertToBool(Eval("regchecked"))%>
                </td>
                <td class="td_grid_col w150">
                    <a href='<%#string.Format("MemberGroupUpdate.aspx?{0}={1}",LL.Common.PubConstant.Key_ID, Eval("groupid"))%>'>
                        【编辑】</a>
                    <asp:LinkButton ID="LinkButton1" Enabled="false" runat="server" CommandName="Delete" Text="【删除】"  OnClientClick="return confirm('确定删除吗?删除后数据将不能恢复')"></asp:LinkButton>
               
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
<div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a>  > 会员组添加</span>
    </div>
  <table cellspacing="1" cellpadding="0" width="100%" border="0"  class="tb_info">
        <tr>
            <td   class="left">
                会员组名称：
            </td>
            <td  class="right">
                <asp:TextBox ID="txtMemberGroupName" runat="server" Width="200px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMemberGroupName"
                    ErrorMessage="会员组名不能为空!" ToolTip="会员组名不能为空!" ValidationGroup="add"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
               <td   class="left">
                会员组级别值：
            </td>
         <td  class="right">
                <asp:TextBox ID="txtMemberGroupLevel" runat="server" Width="200px" Text="1"></asp:TextBox>
                (如：1,2...等，级别值越高权限越大)
            </td>
        </tr>
        <tr>
                   <td   class="left">
                最大收藏夹数：
            </td>
           <td  class="right">
                <asp:TextBox ID="txtMemberFavoriteLimitNum" runat="server" Width="200px" Text="120"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td   class="left">
                每天最大下载数：
            </td>
     <td  class="right">
                <asp:TextBox ID="txtDownLimitNum" runat="server" Width="200px" Text="0"></asp:TextBox>
                <font color="#666666">(0为不限制)</font>
            </td>
        </tr>
        <tr>
           <td   class="left">
                每天最大短信息数：
            </td>
         <td  class="right">
                <asp:TextBox ID="txtMsgLimitNum" runat="server" Width="200px" Text="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
               <td   class="left">
                短信息最大字数：
            </td>
         <td  class="right">
                <asp:TextBox ID="txtMsgContentLimtNum" runat="server" Width="200px" Text="250"></asp:TextBox>
            </td>
        </tr>
        <tr>
                 <td   class="left">
                前台可注册：
            </td>
           <td  class="right">
                <asp:RadioButtonList ID="radioListRegisterInWeb" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="True" Text="否" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
              <td   class="left">
                注册需要审核：
            </td>
             <td  class="right">
                <asp:RadioButtonList ID="radiolistNeedCheck" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="是" Value="true"></asp:ListItem>
                    <asp:ListItem Selected="True" Text="否" Value="false"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td height="25" colspan="2">
                <div align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="· 添加 ·" OnClick="btnAdd_Click" CssClass="btn"></asp:Button>
                    <input type="hidden" id="hiddenID" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
