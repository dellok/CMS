<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"    ValidateRequest="false"   
    CodeFile="NewsEdit.aspx.cs" Inherits="News_NewsEdit" %>

<%@ Register Src="~/UserControl/NewsCommonInput.ascx" TagName="NewsCommonInput" TagPrefix="uc" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/UserControl/MemberGroupDownList.ascx" TagName="MemberGroup" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">

    <div class="div_nav_title2" style="margin-top:0px;">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="NewsList.aspx">新闻管理</a>>新闻编辑</span></div>
    <table align="center" class="tb_info" cellspacing="1">
        <tr>
            <td colspan="2">
                <asp:Button ID="Button2" runat="server" Text="提交" OnClick="btnEdit_Click" CssClass="btn_2k3"
                    Width="106px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                  <input type="button" value="新闻管理" class="btn_2k3"  style="width:100px;" onclick="javascript:location.href='NewsList.aspx?ClassID=<%=Request["ClassID"]%>'" />
            </td>
        </tr>

                <tr>
                    <td class="left font_red" >
                        当前分类:
                    </td>
                    <td class="right">
              
                         分类ID：<asp:TextBox ID="txtCurrentClassID" runat="server"  style="border:0px;" ></asp:TextBox> <input  type="button" class="btn" value="修改分类"  onclick="openDialogClass(0,$('#<%=txtCurrentClassID.ClientID%>').val(),'<%=txtCurrentClassID.ClientID%>','<%=lblClassPath.ClientID%>')"  /> <br /> 
                        分类名称：<asp:Label ID="lblClassPath" runat="server"></asp:Label>  

                   
                    </td>
                </tr>
  <uc:NewsCommonInput ID="ucNewsCommonInput" runat="server"></uc:NewsCommonInput>
        <tr>
            <td class="left font_red" >
                权限设置：
            </td>
            <td>
                <asp:DropDownList ID="drplFH" runat="server" Height="20px" Width="49px">
                    <asp:ListItem Value="0">=</asp:ListItem>
                    <asp:ListItem Value="1">>=</asp:ListItem>
                </asp:DropDownList> <uc:MemberGroup ID="ucGroupID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="left" >
                副标题：
            </td>
            <td class="right">
                <asp:TextBox ID="txtSubHead" runat="server" Width="500px" MaxLength="30"></asp:TextBox><b>(最多30字)</b>
            </td>
        </tr>
 
        <tr>
            <td class="left" >
                发布时间：
            </td>
            <td class="right">
                <asp:TextBox ID="txtPostTime" runat="server" Width="200px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtPostTime.ClientID %>').focus()" />
                <span class="span_info_alert">(默认为当前时间)</span>
            </td>
        </tr>
        <tr>
            <td class="left" >
                发布者：
            </td>
            <td class="right">
                <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
              <tr>
            <td class="left" >
                作者：
            </td>
            <td class="right">
                <asp:TextBox ID="txtWriter" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left" >
                信息来源：
            </td>
            <td class="right">
                <asp:TextBox ID="txtSource" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left" >
                内容简介：
             
            </td>
            <td class="right">
                <asp:TextBox ID="txtDescription" runat="server" Style="width: 98%" TextMode="MultiLine" MaxLength="500"
                    Rows="5" Columns="40" Height="61px"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            <td class="left" >
                内容：
            </td>
            <td class="right">
             <FCKeditorV2:FCKeditor ID="txtNewsContent" runat="server" ToolbarSet="Admin" Height="500">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td class="left" >
            </td>
            <td class="right">
                <asp:CheckBox ID="cboxDoKey" runat="server" Checked="true" Text="关键字替换" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="cboxGetFirstTitlePic" runat="server" Checked="true" Text="取第一张上传图作为标题图片" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="btnEdit_Click" CssClass="btn_2k3"
                    Width="106px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
           <input type="button" value="新闻管理" class="btn_2k3"  style="width:100px;" onclick="javascript:location.href='NewsList.aspx?ClassID=<%=Request["ClassID"]%>'" />
            </td>
        </tr>
    </table>

</asp:Content>
