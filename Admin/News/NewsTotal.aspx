<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="NewsTotal.aspx.cs" Inherits="NewsTotal" %>

<%@ Register Src="~/UserControl/NewsClassDropdownList.ascx" TagName="NewsClass" TagPrefix="uc" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">



    <div class="div_search">
        <div class="div_search_row">
           <span class="span_search_label">标题关键字：</span> <span class="span_search_element">
                <asp:TextBox ID="txtKeyWord" runat="server" MaxLength="300" Width="351px"></asp:TextBox></span>
          
        </div>
        <div class="div_search_row">
             <span class="span_search_label">发布时间：</span> <span class="span_search_element">
                <asp:TextBox ID="txtSDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp;
                到
                <asp:TextBox ID="txtEDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" />
            </span>
        </div>
        <div class="div_search_row">
            <span class="span_search_label">发&nbsp;布&nbsp;&nbsp;者：</span> <span class="span_search_element">
                <asp:RadioButtonList ID="radioPostRole" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="-1" Selected="True" Text="不限"></asp:ListItem>
                    <asp:ListItem Value="0" Text="管理员"></asp:ListItem>
                    <asp:ListItem Value="1" Text="前台会员"></asp:ListItem>
                </asp:RadioButtonList>
            </span>
            
      </div>
<div class="div_search_row">
            <span class="span_search_label">文章类别：</span> 
            <span class="span_search_element">
            <uc:NewsClass  ID="newsClass" runat="server"/>
            </span>
            
            <span class="span_search_btn margin_left_20">
                <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                    Height="23px" OnClick="btnSearch_Click" />
            
                  
                </span>
            
            </div>

    </div>



    <style>
     
     .td_grid_col{background:#ffffff; padding-left:10px;text-align:left;}
    
    </style>
    <h2>查询结果</h2>

    <table class="tb_grid" cellspacing="1" cellpadding="0">
    <tr class="tr_grid_title">
            <th class="th_grid_title "  style="width:240px;">
              查询关键字
            </th>
             <td class="td_grid_col ">
                   
                   <asp:Label ID="lblTitleMsg" runat="server"></asp:Label>
                    </td>

           
        </tr>
        <tr class="tr_grid_title">
            <th class="th_grid_title "  style="width:240px;">
              查询时间段
            </th>
             <td class="td_grid_col ">
                   
                   <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </td>

           
        </tr>
  
     <tr class="tr_grid_title">
            <th class="th_grid_title  " style="width:240px;">
             文章分类
            </th>
             <td class="td_grid_col ">
                     <asp:Label ID="lblClassName" runat="server"></asp:Label>
                    </td>

           </tr>
       <tr class="tr_grid_title">
            <th class="th_grid_title  " style="width:240px;">
             总点击量
            </th>
             <td class="td_grid_col ">
                     <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </td>

           </tr>
          
    </table>
   


    </asp:Content>
