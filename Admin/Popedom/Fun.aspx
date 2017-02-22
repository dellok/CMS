<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="Fun.aspx.cs" Inherits="Popedom_Fun" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/UserControl/PopedomGroupDownList.ascx" TagName="PopedomGroup" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">

    <div class="div_nav_title2"><span>位置： 管理信息 > 权限管理 > 功能页面管理</span> </div>
    <div class="div_search">

    
   
        <span class="span_search_label">选择功能组：</span> <span class="span_search_element">

        
        <asp:DropDownList ID="drplPGroup" runat="server" 
             onselectedindexchanged="drpPGroup_SelectedIndexChanged" 
            Width="148px" Height="20px" AutoPostBack="True"></asp:DropDownList>
           
           &nbsp;&nbsp;
           <asp:Button  ID="btnSearch" runat="server" Text=" 查 询 "  CssClass="btn" 
            onclick="btnSearch_Click"   Visible="false"/> &nbsp;&nbsp; 
           <input  type="button"   value=" 添  加 "  class="btn" onclick="javascript:location.href='#groupadd';"/>
           &nbsp;&nbsp;
                <input  type="button"   value="到功能组管理页"  class="btn" onclick="javascript:location.href='FunGroup.aspx';"/>
           </span>
    </div>



 <asp:ListView ID="dataListView" runat="server"   
        ItemPlaceholderID="itemList"   
        DataKeyNames="ID" onitemcanceling="dataListView_ItemCanceling" 
        onitemdeleting="dataListView_ItemDeleting" 
        onitemediting="dataListView_ItemEditing" 
        onitemupdating="dataListView_ItemUpdating" 
       onitemdatabound="dataListView_ItemDataBound" 
     >
  
  <LayoutTemplate>
   <table width="100%" class="tb_grid" cellspacing="1" cellpadding="0">
          
                <tr class="tr_grid_title">
               
                    <th class="th_grid_title">
                        名称
                    </th>
                               <th class="th_grid_title">
                      所属分组
                    </th>

                              <th class="th_grid_title">
                   功能页面(Path)
                    </th>

                     <th class="th_grid_title">
                       是否在菜单中显示
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
              
                    <td class="td_grid_col w200">
                 <%#Eval("Name")%>
                    </td>

                         <td class="td_grid_col  w200">


                        <%#GetPopedomGroupName(Eval("PopedomGroupID"))%>
                      
                    </td>
                    <td class="td_grid_col " style="text-align:left">
                      <%#Eval("Url")%>
                    </td>
                         <td class="td_grid_col w80">
                      <%#Eval("showInMenu").ToString() == "False"?"<span style='color:#d9d9d9'>False</span>":"True"%>
                    </td>
                    <td class="td_grid_col td_linkbutton w200">
 
                 <asp:LinkButton ID="linkBtnEdit" runat="server"  CommandName="Edit" Text="【编辑】"   CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>

                 <asp:LinkButton ID="linkBtnDelete" runat="server" CommandArgument='<%#Eval("ID") %>'
                            CommandName="Delete" Text="【删除】" OnClientClick="return confirm('确定要删除此用户吗?')"></asp:LinkButton>
                    </td>
                </tr>
  </ItemTemplate>


  <EditItemTemplate>
    <tr class="tr_grid_row" >
                  <td class="td_grid_col w200" >

                  <asp:TextBox ID="txtEditFunName" runat="server" Text='<%#Eval("Name")%>'   Width="98%" ></asp:TextBox>
          
                    </td>

                     <td class="td_grid_col w200" >
                     <asp:HiddenField  ID="hGID" runat="server" Value='<%#Eval("PopedomGroupID")%>'/>
                    <asp:DropDownList ID="drplEditPGroup" runat="server"   Height="22px"   Width="98%"></asp:DropDownList>

                    </td>
                    <td class="td_grid_col">

                    <asp:TextBox ID="txtEditUrl"  Width="98%" runat="server" Text='<%#Eval("Url") %>'></asp:TextBox>

                    </td>
                         <td class="td_grid_col w80" >
                          
                        <asp:CheckBox  ID="cboxIsShow" runat="server" Checked='<%#Eval("showInMenu") %>'/>
                    </td>
                    <td class="td_grid_col w200">
                        <asp:LinkButton ID="linkBtnEdit" runat="server"  CommandName="Cancel" Text="【取消】"   CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                          <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="Update" Text="【更改】"   CommandArgument='<%#Eval("ID")%>'></asp:LinkButton>
                        <asp:LinkButton ID="linkBtnDelete" runat="server" CommandArgument='<%#Eval("ID") %>'
                            CommandName="Delete" Text="【删除】" OnClientClick="return confirm('确定要删除此用户吗?')"></asp:LinkButton>
                    </td>
                </tr>
  
  
  </EditItemTemplate>

 </asp:ListView>


 <div class="manu datapager" >
 <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15" ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
        NextPageText="下一页&gt;" CustomInfoHTML="<span>共 <span>%RecordCount%</span> 条记录</span>，<span>%CurrentPageIndex%</span>/%PageCount%，<span>每页 %PageSize% 条</span>"
        NumericButtonCount="7">
    </webdiyer:AspNetPager>
 </div>

 <div class="div_nav_title2"><span>位置： 管理信息 > 权限管理 > 添加权限  </span>  <a id="groupadd"/></div>

        <table cellspacing="0" class="tb_info" cellpadding="0" style="border: solid 1px #aabbcc;"  width="100%" border="0">
       
            <tr>
                <td height="25" align="right" style="width: 42%">
                    名称：
                </td>
                <td height="25" width="*" align="left">
                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" style="width: 42%">
                    Url：
                </td>
                <td height="25" width="*" align="left">
                    <asp:TextBox ID="txtUrl" runat="server" Width="200px" style="margin-left: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" style="width: 42%">
                   显示在菜单中：
                </td>
                <td height="25" width="*" align="left">
                <asp:RadioButtonList ID="rbtnShowInMenu" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Text="是" Value="true" Selected="True"></asp:ListItem>
                       <asp:ListItem Text="否" Value="false"></asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" style="width: 42%">
                    所属分组：
                </td>
                <td height="25" width="*" align="left">
                      <asp:DropDownList ID="drplPGroupAdd" runat="server"   Height="22px"  Width="148px"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td height="25" colspan="2">
                    <div align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button>
                        <input type="hidden" id="hiddenID" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
</asp:Content>

