<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoPrint.aspx.cs" Inherits="print_InfoPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        body
        {
            font-family: 宋体;
        }
        td, .f12
        {
            font-size: 12px;
        }
        .f24
        {
            font-size: 24px;
        }
        .f14
        {
            font-size: 14px;
        }
        .title14
        {
            font-size: 14px;
            line-height: 130%;
        }
        .l17
        {
            line-height: 170%;
        }
    </style>
    
    <meta http-equiv="content-type" content="text/html; charset=gb2312"/>
    <title>
        <%=title%></title>
</head>
<body   style="margin:5px;background:#ffffff;" onload='window.print()'>
    <form id="form1" runat="server">
    <center>
        <table width="599" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="83" height="34" align="right" valign="bottom">
                    <a href='javascript:history.back()'>返回</a> <a href='javascript:window.print()'>打印</a>
                </td>
            </tr>
        </table>
        <table width="600" border="0" cellpadding="0" cellspacing="20" bgcolor="#EDF0F5">
            <tr>
                <td>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="560" border="0">
                        <tbody>
                            <tr>
                                <th class="f24">
                                    <font color="#05006c"><%=title%></font>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <hr size="1" bgcolor="#d9d9d9">
                                </td>
                            </tr>
                            <tr>
                                <td  height="20">
                                    <div align="center">
                                        <%=writer%>&nbsp;&nbsp;<%=newstime%>&nbsp;&nbsp;<%=befrom%></div>
                                </td>
                            </tr>
                            <tr>
                                <td height="15">
                                </td>
                            </tr>
                            <tr>
                                <td class="l17">
                                    <font class="f14" id="zoom">
                                        <p>
                                            <%=newstext%><br>
                                            <br clear="all">
                                        </p>
                                    </font>
                                </td>
                            </tr>
                            <tr height="10">
                                <td>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <%=titlelink%>
                </td>
            </tr>
        </table>
    </center>

</form> </body> </html> 