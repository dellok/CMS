<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="AdminUpdate.aspx.cs" Inherits="Admin_AdminUpdate" %>
<%@ Register  Src="~/UserControl/AdminRoleDownList.ascx" TagName="AdminRoleDownList" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">

<div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a> > <a href="AdminList.aspx" >Admin会员管理</a> > Admin会员信息修改</span>
    </div>
  <table cellspacing="1" cellpadding="0" width="100%" border="0"  class="tb_info">


        <tr>
            <td align="right" style="width: 30%; height: 26px;">
                登录名&nbsp;：
            </td>
            <td width="*" align="left">
                <asp:TextBox ID="txtLName" runat="server" Width="200px" onblur="ExistsName(this.value,'spanLoginName','L')" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqLoginName" runat="server" ControlToValidate="txtLName"
                    ErrorMessage="登录名不能为空!" SetFocusOnError="True"></asp:RequiredFieldValidator><span
                        id="spanLoginName" class="msgSpan"></span>
            </td>
        </tr>

          
                 <tr>
            <td align="right" style="width: 30%; height: 26px;">
                密码&nbsp;：
            </td>
            <td width="*" align="left">

             
               <input  type="button" value=" 重置密码 " onclick='$("#showpwdinput").show();' class="btn"/>
              &nbsp;&nbsp;
              <span id="showpwdinput" style="display:none;color:red;">
                <asp:TextBox ID="txtNewPwd"   runat="server" Width="200px" TextMode="Password" ></asp:TextBox>

                <asp:Button  ID="btnUpdatePwd" runat="server" Text="修改密码"  />
                (想重置密码请在此修改,不修改则清空此文本内容)
                </span>
            </td>
        </tr>
       
            <tr>
                <td align="right" style="width: 30%; height: 25px">
                    角色&nbsp;:
                </td>
                <td width="*" align="left" style="height: 25px">
                   
                   <UC:AdminRoleDownList id="ucAdminRole" runat="server"></UC:AdminRoleDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 30%; height: 25px">
                    备注&nbsp;:
                </td>
                <td width="*" align="left" style="height: 25px">
                    <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" style="width: 30%">
                    是否启用&nbsp;:
                </td>
                <td height="25" width="*" align="left">
                    <asp:CheckBox ID="cboxAvailable" runat="server" Checked="true" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 25px">
                    <div align="center">
                        <asp:Button ID="btnUpdate" runat="server" Text=" 修改 " OnClick="btnUpdate_Click" CssClass="btn" Width="100px"> </asp:Button>   &nbsp&nbsp;&nbsp;&nbsp;
                     
                              &nbsp&nbsp;&nbsp;&nbsp;

                              <input  type="button" value=" 返回会员列表 " onclick="javascript:location.href='AdminList.aspx';"  class="btn"/>
                            
                    </div>
                </td>
            </tr>
    </table>
</asp:Content>

