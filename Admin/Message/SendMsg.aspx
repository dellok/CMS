<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="SendMsg.aspx.cs" Inherits="Send_SendMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">
    <div class="div_nav_title2">
        <span>位置： 管理信息 > 批量发送站内信</span>
    </div>

   <table align="center"  class="tb_info"  cellspacing="1" >
        
<tr>
 
 <td class="left">会员组：</td>
 <td class="right">

<asp:CheckBoxList ID="cboxMemberGroup" runat="server"   RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="8"></asp:CheckBoxList>

 
 </td>

 </tr>
 
<tr>
 
 <td class="left" style="height: 39px">每组发送个数：</td>
 <td class="right" style="height: 39px"><asp:TextBox ID="txtEveryGroupSendNum" runat="server" Text="0"></asp:TextBox>(0或空默认为发送全部会员)<asp:RegularExpressionValidator 
         ID="RegularExpressionValidator1" runat="server" 
         ControlToValidate="txtEveryGroupSendNum" ErrorMessage="请输入法数字格式" 
         ValidationExpression="\d{1,8}" ValidationGroup="add"></asp:RegularExpressionValidator>
    </td>

</tr>

<tr>
 
 <td class="left" valign="top">标题：</td>
 <td class="right">
     <asp:TextBox ID="txtTitle" runat="server"  MaxLength="100" 
         Width="78%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="send" ControlToValidate="txtTitle" Text="标题不能为空!"></asp:RequiredFieldValidator>
     <p class="" style="margin:0px;" >
     可以在标题与内容中使用：<asp:Label ID="lblTagUserName" runat="server" Text="MUserName"/>代表用户名，<br />
     发送到会员收件箱中将解析为 会员名</p></td>

</tr>


<tr>
 
 <td class="left" style="height: 303px">内容：<br />
&nbsp;<br />
     (支持html代码)<br/>
     (最大字数500)</td>
 <td class="right" style="height: 303px">
 <asp:TextBox ID="txtContent" runat="server"  TextMode="MultiLine"   Rows="10" 
         Columns="60" Height="293px" MaxLength="500" Width="90%"></asp:TextBox>
 
     <br />
 
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="send" ControlToValidate="txtContent" Text="内容不能为空!"></asp:RequiredFieldValidator>

 
 </td>

</tr>



<tr style="height:30px">
 
 <td class="left"></td>
 <td class="right">
     <asp:Button  ID="btnSend" runat="server" CssClass="btn_2k3" 
         Text=" 发  送 " onclick="btnSend_Click" ValidationGroup="add" /> <asp:Button  ID="btnReset" 
         runat="server" CssClass="btn_2k3"  Text=" 重 置 " onclick="btnReset_Click"/></td>

</tr>


</table>


</asp:Content>

