<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"     validateRequest="false"  CodeFile="MemberCompanyInfo.aspx.cs" Inherits="Member_MemberCompanyInfo" %>
  <%@ Register Src="~/UserControl/CityList.ascx" TagName="City" TagPrefix="UC" %>
<%@ Register Src="~/UserControl/SexRadioList.ascx" TagName="Sex" TagPrefix="UC" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="Editor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">

    <div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a> ><a href="../Member/MemberList.aspx">会员管理</a>>修改会员信息</span>
    </div>
    <table cellspacing="1" cellpadding="0" width="100%" border="0" class="tb_info"  >
    <tr bgcolor="#EFEFEF">
        <td height="25" colspan="2">
            <strong  class="margin_left_20">登录信息
 
            </strong>说明：带*项为必填。
        </td>
    </tr>
    <tr>
        <td  class="left">
            用户名：
        </td>
        <td  class="right">
            <asp:TextBox ID="txtLoginName" runat="server" Width="300px"></asp:TextBox>
            &nbsp;*&nbsp;
        </td>
    </tr>
    <tr>
        <td  class="left">
            密码：
        </td>
        <td  class="right">
            <asp:TextBox ID="txtPassword" runat="server" Width="300px"></asp:TextBox>(修改时：如不想修改,请留空) *
        </td>
    </tr>
    <tr>
        <td  class="left">
            审核:
        </td>
        <td  class="right">
            <asp:CheckBox ID="cboxChecked" runat="server" />
            *
        </td>
    </tr>
    <tr>
        <td  class="left">
            所属会员组:
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
            <asp:TextBox ID="txtUseDays" runat="server" Width="57px"></asp:TextBox>天，<span class="left">到期日期:</span><asp:TextBox 
                ID="txtEnd" runat="server" Width="124px"></asp:TextBox>&nbsp;&nbsp;&nbsp; 到期后转向用户组:<asp:DropDownList
                ID="drplMemberGroup" runat="server" Width="100px">
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:Button ID="btnModifyDays" runat="server" 
                CssClass="btn_2k3   b   margin_left_20 " style="color:#006600"  Text="修改【会员使用天数】" 
                onclick="btnModifyDays_Click" />
        </td>
    </tr>
    <tr>
        <td  class="left">
            邮箱：
        </td>
        <td  class="right">
            <asp:TextBox ID="txtLoginEmail" runat="server"  Width="279px"></asp:TextBox>*
        </td>
    </tr>
    <tr>
        <td  class=" txtcenter" colspan="2" >
        
           
      
            <asp:Button ID="btnModifyMemberLogin" runat="server" 
                CssClass="btn_2k3   b   margin_left_20 " style="color:#0000FF"  
                Text="修改【会员登录信息】" onclick="btnModifyMemberLogin_Click" 
               />
        </td>
    </tr>
    <tr bgcolor="#EFEFEF">
        <td height="25" colspan="2">
           <strong class="margin_left_20"> 公司详细信息
            </strong>说明：带*项为必填。
        </td>
    </tr>
    <tr>
        <td height="25" colspan="2" bgcolor="#FFFFFF">
            <table cellspacing="1" cellpadding="0" width="100%" border="0" class="tb_info"  >
               <tr>
        <td  class="left">
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
                    <td  class="left">
                        真实姓名：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtTruename" runat="server"  Width="300px"></asp:TextBox>*
                        <asp:RequiredFieldValidator ID="reqTruename" runat="server" BorderColor="#FFCCCC"
                            ControlToValidate="txtTruename" Display="Dynamic" ErrorMessage="真实姓名不以为空!" ForeColor="#CC0000"
                            ToolTip="输入真实姓以便好的为你服务" Width="270px"  ValidationGroup="m,a">输入真实姓以便好的为你服务</asp:RequiredFieldValidator>
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
                        <asp:TextBox ID="txtDuty" runat="server" Width="300px"></asp:TextBox>
                        *
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        联系电话：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtCall" runat="server" Width="300px"></asp:TextBox>
                        *
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        传真：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtFax" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        手机：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtPhone" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        公司类型：
                    </td>
                    <td  class="right">
                        <asp:RadioButtonList ID="radioListLeixing" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="企业单位" Value="企业单位" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="事业单位或社会团体" Value="事业单位或社会团体"></asp:ListItem>
                            <asp:ListItem Text="个体经营" Value="个体经营"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        贵公司名称：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtCompany" runat="server" Width="450px"></asp:TextBox>
                        *
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        公司所在地：
                    </td>
                    <td  class="right">
                        <UC:City ID="ucCity" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        联系地址：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtAddress" runat="server" MaxLength="200" Width="450px"></asp:TextBox>
                        *
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        邮编：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtZip" runat="server" MaxLength="8" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        主营行业：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtIndustry" runat="server" MaxLength="300" Width="450px"></asp:TextBox>
                        *
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        主营方向：
                    </td>
                    <td  class="right">
                        <asp:RadioButtonList ID="radioListDirection" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Text="销售" Value="销售" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="采购" Value="采购"></asp:ListItem>
                            <asp:ListItem Text="两者都有" Value="两者都有"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td  class="left">
                        主营产品：
                    </td>
                    <td  class="right">
                        <asp:TextBox ID="txtProducts" runat="server" MaxLength="300" Width="451px"></asp:TextBox>
                        *
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
                    <td height="25"  class="left">
                        公司LOGO：
                    </td>
                    <td  class="right">
                        <asp:FileUpload ID="fileLogo" runat="server" />
                        &nbsp;(会员空间Banner，Banner大小：960x150)<br />
                        <asp:Image ID="logoImg" runat="server" Visible="false" />
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
                        <asp:TextBox ID="txtHomepage" runat="server" MaxLength="50" Width="450px"></asp:TextBox>
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
                    <asp:Button ID="btnModifyMemberInfo" runat="server" 
                CssClass="btn_2k3   b   margin_left_20 " 
    style="color:#0000FF"  Text="修改【会员基本信息】" onclick="btnModifyMemberInfo_Click" ValidationGroup="m" 
               />   
            <asp:Button ID="btnEdit" CssClass="btn_2k3   b   margin_left_20 "  ValidationGroup="a" runat="server"  style="color:#FF0033;" Text="修改【登录及基本信息】" OnClick="btnEdit_Click" />
            &nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server"  
                        CssClass="btn_2k3   b   margin_left_20  green" Text=" 增 加 会 员" Width="106px" 
                        onclick="btnAdd_Click" />
            <input type='button' class="btn_2k3   b   margin_left_20 "  name='Submit2' value=' 返 回 ' onclick='history.go(-1)'>
        </td>
    </tr>
    <tr bgcolor="#FFFFFF">
        <td height="25" colspan="2">
            说明：带*项为必填。
        </td>
    </tr>
</table>

  </asp:Content>

