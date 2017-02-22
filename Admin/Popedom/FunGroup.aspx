<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="FunGroup.aspx.cs" Inherits="FunGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： 管理信息 > 权限管理 > 权限组管理</span>
    </div>
    <asp:ListView ID="dataListView" runat="server" ItemPlaceholderID="itemList" DataKeyNames="ID"
        OnItemCanceling="dataListView_ItemCanceling" OnItemDeleting="dataListView_ItemDeleting"
        OnItemEditing="dataListView_ItemEditing" OnItemUpdating="dataListView_ItemUpdating">
        <LayoutTemplate>
            <table class="tb_grid" cellspacing="1" cellpadding="0">
                <tr class="tr_grid_title">
                    <th class="th_grid_title">
                        编号
                    </th>
                    <th class="th_grid_title">
                        名称
                    </th>
                    <th class="th_grid_title">
                        显示顺序
                    </th>
                    <th class="th_grid_title">
                        是否显示在菜单上
                    </th>
                    <th class="th_grid_title">
                        备注
                    </th>
                    <th class="th_grid_title">
                        编辑
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="tr_grid_row">
                <td class="td_grid_col w100">
                    <%#Eval("ID") %>
                </td>
                <td class="td_grid_col w200">
                    <%#Eval("Name")%>
                </td>
                <td class="td_grid_col w80">
                    <%#Eval("Order")%>
                </td>
                <td class="td_grid_col w80">
                    <%#Eval("IsShow")%>
                </td>
                <td class="td_grid_col">
                    <%#Eval("Remark")%>
                </td>
                <td class="td_grid_col w200">
                    <asp:LinkButton ID="linkBtnEdit" runat="server" CommandName="Edit" Text="【编辑】"></asp:LinkButton>
                    <asp:LinkButton ID="linkBtnDelete" runat="server" CommandName="Delete" Text="【删除】"
                        OnClientClick="return confirm('确定要删除此用户吗?')"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr class="tr_grid_title_edit">
                <td class="td_grid_col w100">
                    <%#Eval("ID") %>
                </td>
                <td class="td_grid_col w200">
                    <asp:TextBox ID="txtEditGroupName" runat="server" Text='<%#Eval("Name")%>' Width="98%"></asp:TextBox>
                </td>
                <td class="td_grid_col w80">
                    <asp:TextBox ID="txtEditOrder" runat="server" Text='<%#Eval("Order")%>'></asp:TextBox>
                </td>
                       <td class="td_grid_col w80">

                    
                        <asp:CheckBox  ID="cboxIsShow" runat="server" Checked='<%#Eval("IsShow") %>'/>
                </td>
                <td class="td_grid_col  ">
                    <asp:TextBox ID="txtEditRemark" runat="server" Text='<%#Eval("Remark")%>' Width="96%"></asp:TextBox>
                </td>
                <td class="td_grid_col w200">
                    <asp:LinkButton ID="linkBtnEdit" runat="server" CommandName="Cancel" Text="【取消】"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="【更改】"></asp:LinkButton>
                    <asp:LinkButton ID="linkBtnDelete" runat="server" CommandName="Delete" Text="【删除】"
                        OnClientClick="return confirm('确定要删除此用户吗?')"></asp:LinkButton>
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
    <div class="div_nav_title2">
        <span>位置： 管理信息 > 权限管理 > 增加权限组</span>
    </div>
    <table cellspacing="1" class="tb_info" cellpadding="0" border="0">
        <tr>
            <td height="25" width="30%" class="left">
                组名：
            </td>
            <td height="25" width="*" class="right">
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
         <tr>
                <td height="25" align="right" style="width: 42%">
                   显示在菜单中：
                </td>
                <td height="25" width="*" align="left">
                <asp:RadioButtonList ID="rbtnShowInMenu" runat="server" RepeatLayout="Flow" 
                        RepeatDirection="Horizontal" 
                        >
                    <asp:ListItem Text="是" Value="true" Selected="True"></asp:ListItem>
                       <asp:ListItem Text="否" Value="false"></asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
        <tr>
            <td height="25" width="30%" class="left">
                备注：
            </td>
            <td height="25" width="*" class="right">
                <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" class="left">
                显示顺序：
            </td>
            <td height="25" width="*" class="right">
                <asp:TextBox ID="txtOrder" runat="server" Width="200px" Text="0"></asp:TextBox>（数字形式）
            </td>
        </tr>
        <tr>
            <td height="25" colspan="2">
                <div align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="· 添加 ·" OnClick="btnAdd_Click" CssClass="btn3_mouseup"
                        Width="115px"></asp:Button>
                    <input type="hidden" id="hiddenID" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
