<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TotalPostNews.aspx.cs" Inherits="Admin_TotalPostNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">
<div class="div_nav_title2">
        <span>位置:<a href="/LoginSuccess.aspx">管理信息</a> > <a href="AdminList.aspx">Admin会员管理</a>
            >新闻发布统计</span>
    </div>
    <div class="div_search" style="width:100%">
        <span class="span_search_label">统计区间：</span> <span class="span_search_element">
                <asp:TextBox ID="txtSDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp;
                到
                <asp:TextBox ID="txtEDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" /></span>
                    
                    <span class="span_search_label">管理员姓名:</span>
                 <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox>
                  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                    Height="23px" OnClick="btnSearch_Click" />
      </div>

         <table  class="tb_grid" cellpadding="0" border="0"  cellspacing="1">
                <tr class="tr_grid_title">
                    <th class="th_grid_title">
                     管理员姓名
                    </th>
                    <th class="th_grid_title">
                  统计日期区间
                    </th>
                    <th class="th_grid_title">
                      发布新闻数
                    </th>
                  
                </tr>

 <tr class="tr_grid_row">
                <td class="td_grid_col ">
                   <%=aName%>
                </td>
                <td class="td_grid_col ">
              <%=string.Format("【{0}】---【{1}】",sDate,eDate)%>
                </td>
                <td class="td_grid_col   ">
                   <%=totalNews%>
                </td>
          
            </tr>
            </table>

</asp:Content>

