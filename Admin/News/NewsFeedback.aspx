<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"   AutoEventWireup="false"
    CodeFile="NewsFeedback.aspx.cs" Inherits="News_NewsFeedback" %>

<%@ Register Src="~/UserControl/NewsClassDropdownList.ascx" TagName="NewsClass" TagPrefix="uc" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： 管理信息 ><a href="NewsList.aspx">新闻管理</a> > 新闻反馈管理</span></div>
    <div class="div_search">
        <span class="span_search_label">信息ID：</span> <span class="span_search_element">
            <asp:TextBox ID="txtNewsID" runat="server" Width="63px"></asp:TextBox></span>
        <span class="span_search_label">关键词：</span> <span class="span_search_element">
            <asp:TextBox ID="txtSearchContent" runat="server" Width="130px"></asp:TextBox><span
                class="span_search_element">
                <asp:DropDownList ID="drplSearchType" runat="server" Width="61px">
                    <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="评价人" Value="1"></asp:ListItem>
                    <asp:ListItem Text="内容" Value="2"></asp:ListItem>
                    <asp:ListItem Text="IP" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <uc:NewsClass ID="ucNClass" runat="server" />
            </span><span class="span_search_element">&nbsp;<asp:CheckBox ID="cboxChecked" runat="server"
                Text="<b>是否审核</b>" />
            </span><span class="span_search_btn">
                <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                    Height="23px" OnClick="btnSearch_Click" /></span>
            <div class="">
            </div>
    </div>
    <table cellpadding="0" cellspacing="1" class="tb_grid">
        <tr class="tr_grid_title">
            <th class="th_grid_title txtcenter">
                                <input  id="cboxAll2"  type="checkbox" name="cboxAll" />
            </th>
            <th class="th_grid_title  w100">
                评论<font color=green>是否审核</font>/ <b>评论人</b>
                <th class="th_grid_title w100">
                    时间 /IP
                </th>
                <th class="th_grid_title">
                    新闻标题/反馈内容
                </th>
        </tr>
        <asp:ListView ID="dataViewList" runat="server" DataKeyNames="ID" ItemPlaceholderID="itemList">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="tr_grid_row">
                    <td class="td_grid_col  w50">
                        <asp:CheckBox ID="cboxItem" ClientIDMode="Static" runat="server" ToolTip='<%#Eval("ID")%>' CssClass="cboxItem" />
                    </td>
                    <td class="td_grid_col  1200">
                        <%#PageCommon.ShowCheckInfo(Eval("checked"), 0,0, 0,"")%><br />
                        <%#Project.Common.Format.DataConvertToInt(Eval("UserID")) > 0 ? string.Format("<a href='/Member/MemberInfo.aspx?{0}={1}&groupid=1'><b class='green'>{2}</b></a>", LL.Common.PubConstant.Key_Member,Eval("UserID"), Eval("UserName")) : Eval("UserName")%>
                    </td>
                    <td class=" w150 td_wrap  txtmiddle   " style="padding-left: 2px; text-align: left;">
                        <%#Eval("InDate","{0:yyyy-MM-dd HH:mm:ss}")%><br />
                        <br>
                        <font class="b green">
                            <%#Eval("IP")%></font>
                    </td>
                    <td class="td_grid_col td_wrap  " style="text-align: left; padding-left: 2px;">
                        <p style="color: Red; font-weight: bold; margin: 2px 2px;">
                            <a href="<%#Eval("PageUrl")%>" target="_blank">
                                <%#Project.Common.Util.CutString(Eval("title"),60)%></a>
                        </p>
                        <asp:TextBox ID="txtContent" runat="server" Columns="60" Rows="5" Text=' <%#Eval("Content")%>'
                            TextMode="MultiLine" Width="96%"></asp:TextBox>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
    <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="10" ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
        NextPageText="下一页&gt;" CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>共%PageCount%页</span>，<span>每页显示%PageSize%条</span>">
    </webdiyer:AspNetPager>
    <asp:Button ID="btnBatchCheck" runat="server" Text="批量审核" CssClass="btn_2k3" OnClick="btnBatchCheck_Click" />
    <asp:Button ID="Button1" runat="server" Text="批量取消审核" CssClass="btn_2k3" OnClick="btnBatchUnCheck_Click" />
    <%--    <asp:Button  ID="Button2" runat="server"  Text="批量推荐"  CssClass="btn_2k3" 
        onclick="btnBatchRecommend_Click" />
    
        <asp:Button  ID="Button3" runat="server"  Text="批量取消推荐"  CssClass="btn_2k3" 
        onclick="btnBatchUnRecommend_Click" />--%>
    <asp:Button ID="btnBatchDelete" runat="server" Text="批量删除" CssClass="btn_2k3" OnClientClick="return  confirm('确信要进行批量删除吗?，\r\n删除后数据将不能恢复!')"
        OnClick="btnBatchDelete_Click" />
    </span>
</asp:Content>
