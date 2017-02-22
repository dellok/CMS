<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="CategoryEdit" %>

<%@ Register Src="~/UserControl/NewsClassDropdownList.ascx" TagName="NewsClass" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">


    <div class="div_nav_title2" style="margin-top:0px;">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > 新闻分类编辑</span></div>
      

      <table  style="width:100%;">
     
      <tr>
      <td valign="top"  width="50%">   <div class="div_title" style="height: 25px;" >
                
                            当前分类&nbsp;:
                            <asp:Label ID="lblCurrentClassName0" runat="server" CssClass="font_red"></asp:Label>
                            &nbsp; ID: <asp:Label ID="lblNodeID" runat="server"  CssClass="font_red"></asp:Label>
                      
                    </div>
      <table cellspacing="1" class="tb_info">
                  
                    <tr>
                        <td class="left">
                            父分类ID：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtParenID" runat="server" Width="180px" ></asp:TextBox>
                            (修改父分类ID，则当前分类下所有子项都相应改变 )
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            父类名称：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtParentName" runat="server" Width="180px" Enabled="false"    BackColor="ActiveBorder"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            当前分类ID：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtID" runat="server" Width="180px" Enabled="false" BackColor="ActiveBorder"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            当前分类名称：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtCName" runat="server" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left" >
                            当前分类别名：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtOtherName" runat="server" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
        
                      <tr>
                        <td class="left">
                            所属表名：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtTbName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
            
                    <tr>
                        <td class="left">
                            描述：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtDescription" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 25px; font-size: 12px; text-align:center;">
                        <asp:Button
                                    ID="btnUpdate" runat="server" Text=" 修   改 " OnClick="btnUpdate_Click" Width="100px" CssClass="btn_2k3" ValidationGroup="edit">
                                </asp:Button>&nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text=" 删   除 " CssClass="btn_2k3 font_red" Width="100px" 
                                OnClick="btnDelete_Click" OnClientClick="return  confirm('确定要删除?它的子项一同删除!');"  />&nbsp;
                        </td>
                    </tr>
                </table>
      </td>
      

      <td valign="top" width="50%">    
                                
               <div style="height: 26px" class="div_title">
                            在当前分类&nbsp;<asp:Label ID="lblCurrentClassName" runat="server" CssClass="font_red"></asp:Label>
                            下添加子分类
                        </div> 
                        
                        
                         <table cellspacing="1" class="tb_info">
             
             
                        
                    <tr>
                        <td class="left">
                            子类名称 ：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtAddClassName" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="请输入分类名称" ControlToValidate="txtAddClassName" 
                                ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            子类别名：
                        </td>
                        <td class="right" style="height: 20px">
                            <asp:TextBox ID="txtAddClassAliasName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                        <td class="left">
                            所属新闻表名：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtAddTbName" runat="server" Width="200px"></asp:TextBox>
                            (默认为news)</td>
                    </tr>
                 
                    <tr>
                        <td class="left">
                            简单描述 ：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtAddDescription" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td align="right" class="leftTD">
                            &nbsp;
                        </td>
                        <td class="right">
                            &nbsp;
                        </td>
                    </tr>
                          <tr >
                        <td align="right" class="leftTD">
                            &nbsp;
                        </td>
                        <td class="right">
                            &nbsp;
                        </td>
                    </tr>
                  
                          <tr >
                        <td align="right" class="leftTD">
                            &nbsp;
                        </td>
                        <td class="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 25px; font-size: 12px;text-align:center;">
                            <asp:Button ID="btnAdd" runat="server" Text="【添加栏目分类】"  CssClass="btn_2k3" Width="145px"  ForeColor="Red" ValidationGroup="add"
                                OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                </table></td>
      </tr>
      
      </table>
 
            <table cellspacing="1" class="tb_info" style="margin-top:20px">
                    <tr class="div_title">
                            
                     <td class="right">
                        当前分类&nbsp;:
                            <asp:Label ID="lblCurrentClassName2" runat="server" CssClass="font_red"></asp:Label>下的新闻   移动  到
                      
                      <uc:newsclass ID="ucNewsClass" runat="server" />
                    <asp:Button ID="Button7" runat="server" Text=" 移 动 " CssClass="btn_2k3 black-red color_blue" OnClick="btnMoveInfoClass_Click" />
                    </td>
                    </tr>
                  
                    </table>

             
</asp:Content>


