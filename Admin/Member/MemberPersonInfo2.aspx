<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="MemberPersonInfo2.aspx.cs"  ValidateRequest="false"  Inherits="Member_MemberPersonInfo2" %>

<%@ Register Src="~/UserControl/SexRadioList.ascx" TagName="Sex" TagPrefix="UC" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="Editor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">

    <div class="div_nav_title2">
         <span>位置:<a href="/LoginSuccess.aspx">管理信息</a> ><a href="../Member/MemberList.aspx">会员管理</a>>修改会员信息</span>
    </div>
    <table cellspacing="1" cellpadding="0" width="100%" border="0" class="tb_info txtmiddle" >
        <tr bgcolor="#EFEFEF">
            <td height="25" colspan="2">
                <strong>登录信息
                    <input name="groupid" type="hidden" id="groupid" value="1">
                </strong>
            </td>
        </tr>
        <tr>
            <td class="left">
                用户名：
            </td>
            <td class="right">
                <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                &nbsp;* 判断判断若用增加
            </td>
        </tr>
        <tr>
            <td class="left">
                密码：
            </td>
            <td  class="right">
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>(修改时：如不想修改,请留空) *
            </td>
        </tr>
        <tr>
            <td class="left">
                审核：
            </td>
            <td  class="right">
                <asp:CheckBox ID="cboxChecked" runat="server" />
                *
            </td>
        </tr>
        <tr>
            <td class="left">
                所属会员组：
            </td>
            <td  class="right">
                <asp:ListBox ID="listboxMemberGroup" runat="server" Height="140px" Width="159px">
                </asp:ListBox>
                *
            </td>
        </tr>
     <tr>
        <td  class="left" >
            剩余天数：
        </td>
        <td  class="right">
            <asp:TextBox ID="txtUseDays" runat="server" Width="40px"></asp:TextBox><b>天</b>，<span class="left">到期日期:</span><asp:TextBox 
                ID="txtEnd" runat="server" Width="124px"></asp:TextBox>&nbsp;&nbsp;&nbsp; 到期后转向用户组:<asp:DropDownList
                ID="drplMemberGroup" runat="server" Width="100px">
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:Button ID="btnModifyDays" runat="server" 
                CssClass="btn_2k3   b   margin_left_20 " style="color:#006600"  Text="修改会员使用天数" 
                onclick="btnModifyDays_Click" />
        </td>
    </tr>
        <tr>
            <td class="left">
                邮箱：
            </td>
            <td  class="right">
                <asp:TextBox ID="txtLoginEmail" runat="server" Height="19px"></asp:TextBox>*
            </td>
        </tr>
        <tr>
            <td class="left">
                空间使用模板:
            </td>
            <td  class="right">
                <asp:DropDownList ID="drplSpaceStyleID" runat="server">
                    <asp:ListItem Value="1">默认个人空间模板</asp:ListItem>
                    <asp:ListItem Value="2">默认企业空间模板</asp:ListItem>
                    <asp:ListItem Value="3">VIP模板</asp:ListItem>
                </asp:DropDownList>
                *
            </td>
        </tr>
        <tr>
            <td height="25" colspan="2" bgcolor="#FFFFFF">
                 <table cellspacing="1" cellpadding="0" width="100%" border="0" class="tb_info">
                   <tr bgcolor="#EFEFEF">
            <td height="25" colspan="2">
                <strong>个人详细信息
                    <input name="groupid" type="hidden" id="Hidden1" value="1">
                </strong>
            </td>
        </tr>
                    <tr>
                        <td  class="left">
                            真实姓名：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtTruename" runat="server" Text="111111"></asp:TextBox>*
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            性别：
                        </td>
                        <td  class="right">
                            <UC:Sex ID="ucSex" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            所在部门及职务：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtDuty" runat="server"></asp:TextBox>
                            *
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            联系电话：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtCall" runat="server"></asp:TextBox>
                            *
                        </td>
                    </tr>
                       <tr>
                        <td  class="left">
                            传真：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            手机：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            联系地址：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="200"></asp:TextBox>
                            *
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            邮编：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtZip" runat="server" MaxLength="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            QQ号码：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtOicq" runat="server" MaxLength="20"></asp:TextBox>
                            *
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            MSN：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtMsn" runat="server" MaxLength="100"></asp:TextBox>
                            *
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            会员头像：
                        </td>
                        <td  class="right">
                            <asp:FileUpload ID="fileHeadPic" runat="server" /><br />
                            <asp:Image ID="headPicImg" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td  class="left">
                            网站地址：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtHomepage" runat="server" MaxLength="50"></asp:TextBox>
                            *
                        </td>
                    </tr>
                    <tr>
                        <td height="25"  class="left">
                            公司介绍：
                        </td>
                        <td  class="right">
                            
                             
                           <Editor:FCKeditor ID="txtSaytext" runat="server"   Debug="false" Height="500"
                                Width="100%" StartupFocus="false"></Editor:FCKeditor>
                            *
                        </td>
                    </tr>
                   
                </table>
                <br>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td height="37" bgcolor="#FFFFFF" class="style1">
                &nbsp;
            </td>
            <td height="50" bgcolor="#FFFFFF">
                <input type='submit' name='Submit' value='修改'>
                &nbsp;&nbsp;
                <input type='button' name='Submit2' value='返回' onclick='history.go(-1)'>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25" colspan="2">
                说明：带*项为必填。
            </td>
        </tr>
    </table>

</asp:Content>

