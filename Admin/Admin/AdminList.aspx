<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="AdminList.aspx.cs" Inherits="Admin_AdminList" %>
    <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/UserControl/AdminRoleDownList.ascx" TagName="AdminRoleDownList"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > 管理员列表</span>
    </div>
    <div class="div_search" style="width:100%">
        <span class="span_search_label">登录名：</span> <span class="span_search_element">
            <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
            &nbsp;&nbsp; <span class="span_search_label">角色：</span><span class="search_element">

                <UC:AdminRoleDownList ID="ucAdminRoleList" runat="server" IsSearch="true"></UC:AdminRoleDownList>
            </span><span class="search_btn">&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text=" 查 询 " Width="100px" 
            CssClass="btn" onclick="btnSearch_Click" />
      
        </span>
        </span>
    </div>


    <asp:ListView ID="dataListView" runat="server"  ItemPlaceholderID="itemList"
        DataKeyNames="ID" OnItemDeleting="dataList_ItemDeleting"
        OnItemCommand="dataList_ItemCommand">
        <LayoutTemplate>
            <table  class="tb_grid" cellpadding="0" border="0"  cellspacing="1">
                <tr class="tr_grid_title">
                    <th class="th_grid_title">
                        登录名
                    </th>
                    <th class="th_grid_title">
                        角色
                    </th>
                    <th class="th_grid_title">
                        备注
                    </th>
                    <th class="th_grid_title">
                        是否启用
                    </th>
                    <th class="th_grid_title ">
                        操作
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="tr_grid_row">
                <td class="td_grid_col w200">
                    <%#Eval("LoginName") %>
                </td>
                <td class="td_grid_col">
                    <%#LL.BLL.Admin.BLLAdminRole.GetRoleName(Project.Common.Format.DataConvertToInt(Eval("AdminRoleID")))%>
                </td>
                <td class="td_grid_col w200">
                    <%#Eval("Remark")%>
                </td>
                <td class="td_grid_col  w200">
 <asp:CheckBox id="cboxEnabled" runat="server"    Checked='<%#Project.Common.Format.DataConvertToBool(Eval("Checked"))%>' ToolTip='<%#Eval("ID")%>'   AutoPostBack="true"   oncheckedchanged="cboxEnabled_CheckedChanged"/>
          
                </td>
                <td class="td_grid_col w200">
                    <a href='<%#string.Format("{0}?{1}={2}","AdminUpdate.aspx" ,LL.Common.PubConstant.Key_ID,Eval("ID"))%>'>
                        【修改】</a>

                         <a href='<%#string.Format("{0}?{1}={2}","AdminPasswordUpdate.aspx" ,LL.Common.PubConstant.Key_ID,Eval("ID"))%>'>
                        【重置密码】</a>
              
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
     <div class="manu datapager" >
 <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15" ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
        NextPageText="下一页&gt;" CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页%PageSize%条</span>"
        NumericButtonCount="7">
    </webdiyer:AspNetPager>
 </div>
</asp:Content>
