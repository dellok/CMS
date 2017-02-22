<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="FunInAdminRole.aspx.cs" Inherits="Popedom_FunInAdminRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
  


        <div class="div_nav_title2">
        <span>位置： 管理信息 > 权限管理 > 会员角色关联功能</span>
    </div>
    <br/>
    

    <div class="mainbody">
            <div class="mainbody_fun_button_block" > 
            
            <span style="color:#d63004">请选择要绑定角色与权限进行添加修改:</span> &nbsp;&nbsp;&nbsp;&nbsp &nbsp;&nbsp;&nbsp;&nbsp; 
 <asp:Button ID="btnEditFunInRole" runat="server" CssClass="btn_2k3" Width="100px" Height="25px" Text=" 更 新 "
                        OnClick="btnEditFunInRole_Click" /></div>
 

  <div class="mainbody_left">
  <div class="mainbody_sonitem_title" >Admin会员角色</div>
  <div style="width:100%;margin-top:5px;"> <asp:ListBox ID="listboxAdminRole" runat="server"  
          SelectionMode="Single" AutoPostBack="true" Width="200px" Height="600px" 
          onselectedindexchanged="listboxAdminRole_SelectedIndexChanged">
   </asp:ListBox></div>
 
   </div>
                <div   class="mainbody_right">
                   <div class="mainbody_sonitem_title">功能组权限列表</div>
                    <div style="width:100%"><asp:Label ID="lblFunList" runat="server"></asp:Label></div>
                </div>
                     
            <div class="mainbody_fun_button_block" > 
            
            <span style="color:#d63004">请选择要绑定角色与权限进行添加修改:</span> &nbsp;&nbsp;&nbsp;&nbsp &nbsp;&nbsp;&nbsp;&nbsp; 
 <asp:Button ID="Button1" runat="server" CssClass="btn_2k3" Width="100px" Height="25px" Text=" 更 新 "
                        OnClick="btnEditFunInRole_Click" /></div>    
</div>
</asp:Content>
