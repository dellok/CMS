﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="ADEdit.aspx.cs" Inherits="PageAD_ADEdit" %>

<%@ Register Src="~/UserControl/ADPage.ascx" TagName="ADPage" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/ADPagePosition.ascx" TagName="ADPagePosition" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： 管理信息 ><a href="AdList.aspx">广告管理</a> >广告编辑</span>
    </div>
    <table class="tb_info">
        <tr>
            <td class="left">
                广告类型：
            </td>
            <td class="right">
                <asp:RadioButtonList ID="radioFileClass" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="left">
                广告页面：
            </td>
            <td class="right">
                <uc:ADPage ID="ucPage" runat="server"  EnableViewState="true"/>
                &nbsp;&nbsp;&nbsp;&nbsp; <span class="span_search_label">所在页面位置:</span>
                <uc:ADPagePosition ID="ucADPosition" runat="server" EnableViewState="true"></uc:ADPagePosition>
                &nbsp;&nbsp;&nbsp;&nbsp;<span class="span_search_label">第:</span>
                <asp:TextBox ID="txtSeq" runat="server" Width="51px" ClientIDMode="Static"></asp:TextBox>
                <span class="span_search_label">位:</span>
            </td>
        </tr>
        <tr>
            <td class="left">
                广告名称：
            </td>
            <td class="right">
                <asp:TextBox ID="txtADName" runat="server" Width="500px"></asp:TextBox>(如:x公司广告,100字内)
            </td>
        </tr>
        <tr>
            <td class="left">
                广告链接地址：
            </td>
            <td class="right">
                <asp:TextBox ID="txtADUrl" runat="server" Width="500px"></asp:TextBox>
                (目前只适用于图片)
            </td>
        </tr>
        <tr>
            <td class="left">
                点击量：
            </td>
            <td class="right">
                <asp:TextBox ID="txtHit" runat="server" Width="315px"></asp:TextBox>
                (添加时不用写入)
            </td>
        </tr>
        <tr>
            <td class="left">
                过期时间：
            </td>
            <td class="right">
                <span class="span_search_element">
                    <asp:TextBox ID="txtSDate" runat="server" Width="150px" CssClass="calendarFocus"></asp:TextBox><img
                        alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp;
                    到&nbsp;
                    <asp:TextBox ID="txtEDate" runat="server" Width="150px" CssClass="calendarFocus"
                        ></asp:TextBox><img   alt="单击选择时间" src="../Images/date.gif" class="calendarFocus"
                            onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" />
                </span>
            </td>
        </tr>
        <tr>
            <td class="left">
                广告大小：
            </td>
            <td class="right">
                <asp:TextBox ID="TextBox1" runat="server" Text="Width:" Width="60px" Style='border-right: 0px;' /><asp:TextBox
                    ID="txtAdWidth" runat="server" Style="border-left: 0px;" />
                <asp:TextBox ID="TextBox2" runat="server" Text="Height:" Width="60px" Style='border-right: 0px;' /><asp:TextBox
                    ID="txtAdHeight" runat="server" Style="border-left: 0px;"></asp:TextBox>
                <b style="color:Red;">(注:请输入图片或flash  在前台显示的宽与高)</b></td>
        </tr>
        <tr>
            <td class="left">
                当前位置广告：
            </td>
            <td class="right">
             <asp:TextBox ID="txtImgPath" runat="server" Target="_blank" Width="500"></asp:TextBox>
                <asp:Label ID="adLink" runat="server" Target="_blank" Width="500"></asp:Label>
                  
            </td>
        </tr>
        <tr>
            <td class="left">
                上传新文件：
            </td>
            <td class="right">
                <asp:CheckBox ID="cboxIsUpdateImg" runat="server" Text="上传新文件" onclick='javascript:document.getElementById("pUP").style.display=this.checked?"":"none"' />
                <p id="pUP" style="display:none;">
                    <asp:FileUpload ID="up" runat="server" />
                    <asp:HiddenField ID="hidUPFileID" runat="server" />
                </p>
            </td>
       
        </tr>
          <tr>
   <td class="left">是否启用：</td>
   <td class="right">
         
          
     <asp:CheckBox  ID="cboxChecked" runat="server"/>

            </td>
  </tr>
        <tr>
            <td class="left">
                放入回收站：
            </td>
            <td class="right">
                <asp:CheckBox ID="cboxIsRecycle" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (在回收站中的广告信息不在前台显示)
            </td>
        </tr>
        <tr>
            <td class="left" style="height: 31px">
                简单注释：
            </td>
            <td class="right" style="height: 31px">
                <asp:TextBox ID="txtRemark" runat="server" MaxLength="100" Width="323px" />
                (100字内)
            </td>
        </tr>
       
        <tr>
            <td  align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text=" 更 新 " CssClass="btn_2k3" Width="104px"
                    OnClick="btnEdit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text=" 删 除 " CssClass="btn_2k3 font_red"
                    Width="104px" OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="返回广告列表" class="btn_2k3" onclick="javascript:document.location.href='AdList.aspx?adpage=<%=adpage%>&position=<%=position%>'" />
            </td>
        </tr>
    </table>

         <script>
             function sUPFile()
             {
                 var cboxid = '<%=cboxIsUpdateImg.ClientID%>';

                 var cd = document.getElementById(cboxid).checked;
                 document.getElementById("pUP").style.display = cd ? "" : "none";
             }
            sUPFile();
            </script>
</asp:Content>
