<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="AdminPostNewsTotal.aspx.cs" Inherits="AdminPostNewsTotal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > 管理员发布信息统计</span></div>
    <div class="div_search">

    <span class="span_search_label">管理员：</span><span class="span_search_element">
           
            <asp:DropDownList ID="drplAdmin" runat="server" Height="20px" Width="118px" 
            onselectedindexchanged="drplAdmin_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

        </span>
        <span class="span_search_label">选择统计数据表：</span><span class="span_search_element">
            <asp:DropDownList ID="drplTbName" runat="server" Width="200" Height="20" AutoPostBack="True"
                OnSelectedIndexChanged="drplTbName_SelectedIndexChanged">
                <asp:ListItem Text="新闻表" Value="phome_ecms_news"></asp:ListItem>
                <asp:ListItem Text="公司库" Value="phome_ecms_gsk"></asp:ListItem>
            </asp:DropDownList>
        </span>
    </div>
    <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_title">
            <th class="th_grid_title ">
                管理员
            </th>
            <th class="th_grid_title">
                今天发布数
            </th>
            <th class="th_grid_title">
                昨天发布数
            </th>
            <th class="th_grid_title">
                上月发布数
            </th>
            <th class="th_grid_title">
                本月发布数
            </th>
            <th class="th_grid_title">
                总发布数
            </th>
            <th class="th_grid_title">
                未审核数
            </th>
            <th class="th_grid_title">
                详细
            </th>
        </tr>
        <asp:ListView ID="dataViewList" runat="server" ItemPlaceholderID="itemList" >
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="tr_grid_row">
                    <td class="td_grid_col w80">
                        <%#Eval("AdminName")%>
                    </td>
                    <td class="td_grid_col td_wrap w200">
                        <%#Eval("tnum")%>
                    </td>
                    <td class="td_grid_col w80">
                        <%#Eval("ynum")%>
                    </td>
                    <td class="td_grid_col w80">
                        <%#Eval("pnum")%>
                    </td>
                    <td class="td_grid_col td_wrap w80">
                        <%#Eval("mnum")%>
                    </td>
                    <td class="td_grid_col w200">
                        <%#Eval("totalnum")%>
                    </td>
                    <td class="td_grid_col w200">
                        <%#Eval("ntnum")%>
                    </td>
                    <%-- <td class="td_grid_col w80">
                        <%#Eval("email")%>
                    </td>--%>
                    <td class="td_grid_col ">
                        【详细】
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
</asp:Content>
