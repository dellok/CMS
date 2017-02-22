<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="FeedbackDetail.aspx.cs" Inherits="Member_Space_FeedbackDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="spacenav" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="spaceRight" runat="Server">
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="tableborder"
        style='word-break: break-all'>
        <tr class="header">
            <td height="25" colspan="2">
                标题：<%=title%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td width="12%" height="25">
                提交者:
            </td>
            <td width="81%" height="25">
                <a href='<%=SEO.MainDomain %>/space/?userid=<%=submitUserID%>' target='_blank'><%=submitName%></a>&nbsp;&nbsp;
                (<a href='<%=SEO.MainDomain%>/Mebmer/msg/Send.aspx?username=<%=submitName%>'   target='_blank'>消息回复</a>)
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                发布时间:
            </td>
            <td height="25">
               <%=addtime%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                IP地址:
            </td>
            <td height="25">
                <%=ip%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                姓名:
            </td>
            <td height="25">
               <%=name%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                公司名称:
            </td>
            <td height="25">
               <%=company%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                联系邮箱:
            </td>
            <td height="25">
               <%=email%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                联系电话:
            </td>
            <td height="25">
               <%=tel%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                传真:
            </td>
            <td height="25">
               <%=fax%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                联系地址:
            </td>
            <td height="25">
                <%=address%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;邮编：<%=zip%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25">
                信息标题:
            </td>
            <td height="25">
               <%=title%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25" valign="top">
                信息内容:
            </td>
            <td height="25">
               <%=fContent%>
            </td>
        </tr>
        <tr bgcolor="#FFFFFF">
            <td height="25" colspan="2">
                <div align="center">
                    [ <a href="javascript:window.close();">关 闭</a> ]</div>
            </td>
        </tr>
    </table>
</asp:Content>
