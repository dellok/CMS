<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="AdminRole.aspx.cs" Inherits="Admin_AdminRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">


        <div class="div_nav_title2">
        <span>位置： 管理信息 > 会员管理 >会员角色列表</span>
    </div>

    <asp:ListView ID="dataViewList" runat="server" ItemPlaceholderID="itemList" DataKeyNames="ID"
        OnItemCanceling="dataViewList_ItemCanceling" OnItemDeleting="dataViewList_ItemDeleting"
        OnItemEditing="dataViewList_ItemEditing" OnItemUpdating="dataViewList_ItemUpdating">
        <LayoutTemplate>
            <table class="tb_grid" cellspacing="1" cellpadding="0">
                <tr class="tr_grid_title">
                    <th class="th_grid_title ">
                        ID
                    </th>
                    <th class="th_grid_title">
                        名称
                    </th>
                    <th class="th_grid_title ">
                        是否有效
                    </th>
                    <th class="th_grid_title">
                        备注
                    </th>
                    <th class="th_grid_title ">
                        添加时间
                    </th>
                    <th class="th_grid_title">
                        添加时间
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>

     
        <ItemTemplate>
             <tr class="tr_grid_row">
                <td class="td_grid_col w80">
                    <%#Eval("ID")%>
                </td>
                <td class="td_grid_col td_wrap w200">
                   <%#Eval("RoleName")%>
                </td>
                <td class="td_grid_col w80">
                 

              
                 <input  type="checkbox"  checked='  <%#Project.Common.Format.DataConvertToBool(Eval("Enabled"))?"checked":""%>'   />

                </td>
                <td class="td_grid_col td_wrap w200">
                  <%#Eval("Remark")%>
                </td>
                <td class="td_grid_col td_wrap w150" >
                    <%#Eval("InDate") %>
                </td>
                <td class="td_grid_col w150" >
                    <asp:LinkButton ID="linkBtnEdit" runat="server" CommandName="Edit" Text="【编辑】"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="【删除】"  OnClientClick="return confirm('确定要删除此角色吗?')"></asp:LinkButton>
             
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr class="tr_grid_row">
                <td class="td_grid_col w80">
                    <%#Eval("ID")%>
                </td>
                <td class="td_grid_col w200">
                    <asp:TextBox ID="txtEditName" runat="server" Text='<%#Eval("RoleName")%>' Width="96%"></asp:TextBox>
                </td>
                <td class="td_grid_col w80">
        
                    <asp:CheckBox ID="cboxEditEnabled" runat="server"  Checked='<%#Eval("Enabled").ToString()=="True"?true:false %>'   ToolTip='<%#Eval("Enabled")%>'  />
               
                </td>
                <td class="td_grid_col w200">
                    <asp:TextBox ID="txtEditRemark" runat="server" Text='<%#Eval("Remark")%>' Width="96%"></asp:TextBox>
                </td>
                <td class="td_grid_col  w150">
                    <%#Eval("InDate") %>
                </td>
                <td class="td_grid_col  w150">
                    <asp:LinkButton ID="linkBtnEdit" runat="server" CommandName="Cancel" Text="【取消】"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="【更改】"></asp:LinkButton>
                    <%--         <asp:LinkButton ID="linkBtnDelete" runat="server" CommandName="Delete" Text="【删除】"
                        OnClientClick="return confirm('确定要删除此角色吗?')"></asp:LinkButton>--%>
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>


        <div class="div_nav_title2">
        <span>位置： 管理信息 > 会员管理 >会员角色添加</span>
    </div>
    <table cellspacing="1" class="tb_info" cellpadding="0" border="0">

        <tr>
            <td height="25" width="30%" align="right">
                角色名称：
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValName" ErrorMessage="角色名称不能为空!" runat="server" ControlToValidate="txtName"  ValidationGroup="add"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="right">
                是否开启：
            </td>
            <td height="25" width="*" align="left">
                <asp:CheckBox ID="cboxEnabled" runat="server" Checked="true" />
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="right">
                备注：
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" colspan="2">
                <div align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="· 添加 ·" ValidationGroup="add" OnClick="btnAdd_Click" CssClass="btn"></asp:Button>
                    <input type="hidden" id="hiddenID" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
