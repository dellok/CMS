<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="NewsList.aspx.cs" Inherits="News_NewsList" %>

<%@ Register Src="~/UserControl/NewsClassDropdownList.ascx" TagName="NewsClass" TagPrefix="uc" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_search">
        <div class="div_search_row">
            <span class="span_search_label">关&nbsp;键&nbsp;&nbsp;字：</span> <span class="span_search_element">
                <asp:TextBox ID="txtKeyWord" runat="server" MaxLength="300"></asp:TextBox></span>
            <span class="span_search_label">发布时间：</span> <span class="span_search_element">
                <asp:TextBox ID="txtSDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp;
                到
                <asp:TextBox ID="txtEDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" />
            </span>
        </div>
        <div class="div_search_row">
            <span class="span_search_label">查询类别：</span> <span class="span_search_element">
                <asp:RadioButtonList ID="radioSearchType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="title" Selected="True">标题</asp:ListItem>
                    <asp:ListItem Value="ftitle">副标题</asp:ListItem>
                    <asp:ListItem Value="newstime">发布时间</asp:ListItem>
                    <asp:ListItem Value="titlepic">标题图片</asp:ListItem>
                    <asp:ListItem Value="smalltext">内容简介</asp:ListItem>
                    <asp:ListItem Value="username">发布者</asp:ListItem>
                    <asp:ListItem Value="writer">作者</asp:ListItem>
                    <asp:ListItem Value="befrom">信息来源</asp:ListItem>
                    <asp:ListItem Value="newstext">新闻正文</asp:ListItem>
                </asp:RadioButtonList>
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
            </span><span class="span_search_label">审核状态：</span> <span class="span_search_element">
                <asp:RadioButtonList ID="radioCheckType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="-1" Selected="True" Text="不限"></asp:ListItem>
                    <asp:ListItem Value="1" Text="审核"></asp:ListItem>
                    <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                </asp:RadioButtonList>
            </span><span class="span_search_btn margin_left_20">
                <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                    Height="23px" OnClick="btnSearch_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="  增  加  " Width="80px" CssClass="btn"
                    Height="23px" OnClick="btnAdd_Click" Style="margin-left: 20px; color: Green;
                    font-weight: bold; height: 23px;" />
                  
                <asp:Button ID="btnRefresh" runat="server" Text="刷新首页" Width="125px" CssClass="btn"
                    Height="27px" 
                Style="margin-left: 20px; color: red; font-weight: bold;" 
                OnClick="btnRefresh_Click" />
                &nbsp;</span></div>
    </div>
    <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_title">
            <th class="th_grid_title   txtcenter">
             <input  id="cboxAll"  type="checkbox" name="cboxAll" />
            </th>
            <th class="th_grid_title">
                ID
            </th>
            <th class="th_grid_title">
                栏目(分类)
            </th>
            <th class="th_grid_title">
                标题
            </th>
            <th class="th_grid_title">
                <font class="font_red">发布者</font>/<font class="font_green">作者</font>/信息来源
            </th>
            <th class="th_grid_title" >
                发布时间
            </th>
            <th class="th_grid_title">
                点击量
            </th>
            <th class="th_grid_title">
                评论
            </th>
            <th class="th_grid_title">
                操作
            </th>
        </tr>
        <asp:ListView ID="dataViewList" runat="server" ItemPlaceholderID="itemList" DataKeyNames="id"
            OnItemDeleting="dataViewList_ItemDeleting">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="tr_grid_row">
                    <td class="td_grid_col w30">
                        <asp:CheckBox ID="cboxItem" ClientIDMode="Static" ToolTip='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td class="td_grid_col w80">
                        <a href='<%#SEO.DetailPage_AdminView(Eval("id"),Eval("classid"))%>' target="_blank">
                            <%#Eval("id")%></a>
                    </td>
                    <td class="td_grid_col w w150">
                        <%#LL.BLL.BLLNewsCommon.GetClassName(Eval("classid"))%>
                    </td>
                    <td class="td_grid_col     textleft txtwrap w300">
                        <%#PageCommon.ShowCheckInfo(Eval("checked"), Eval("firsttitle"), Eval("isgood"), Eval("istop"),Eval("titlepic"))%>
                        <a href='<%#SEO.DetailPage(Eval("id"),Eval("classid"),Eval("newstime"),Eval("havehtml"),Eval("titleurl"))%>'
                            target="_blank">
                            <%#Eval("title")%></a>
                    </td>
                    <td class="td_grid_col  w150">
                        <font class="font_red">
                            <%#Eval("username")%></font>
                        <br>
                        <font class="font_green">
                            <%#Eval("writer")%></font>
                        <br>
                        <%#Eval("befrom") %>
                    </td>
                    <td class="td_grid_col  w80">
                        <%#Eval("newstime")%>
                    </td>
                    <td class="td_grid_col td_wrap  w40">
                        <%#Eval("onclick")%>
                    </td>
                    <td class="td_grid_col w40">

                     <a href="#"  onclick="openwin('newsFeedback.aspx?id=<%#Eval("id")%>','_blank',800,800)" ><%#Eval("plnum")%></a>
                    </td>
                    <td class="td_grid_col w120">
                        <a href='<%#string.Format("NewsEdit.aspx?{0}={1}&{2}={3}",LL.Common.PubConstant.Key_ID, Eval("id"),"ClassID",Eval("classid"))%>'>
                            【编辑】</a>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="【删除】"
                            OnClientClick="return  confirm('确信要删除此记录?，\n删除后数据将不能恢复!')"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <tr class="tr_grid_row">
            <td class="td_grid_col  txtcenter">
               <input  id="cboxAll2" name="cboxAll"  type="checkbox" />
                
            </td>
            <td colspan="8" align="left" valign="middle">
                <p class="div_search_row" style="height: 30px;">
                    <asp:Button ID="btnBatchDelete" runat="server" Text="批量删除" CssClass="btn_2k3" OnClientClick="return  confirm('确信要进行批量删除吗?，\n删除后数据将不能恢复!')"
                        OnClick="btnBatchDelete_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnBatchCheck" runat="server" Text="审核" CssClass="btn_2k3" OnClick="btnBatchCheck_Click" />
                    <asp:Button ID="Button1" runat="server" Text="取消审核" CssClass="btn_2k3" OnClick="btnBatchUnCheck_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="推荐" CssClass="btn_2k3" OnClick="btnBatchRecommend_Click" />
                    <asp:Button ID="Button3" runat="server" Text="取消推荐" CssClass="btn_2k3" OnClick="btnBatchUnRecommend_Click" />
                    &nbsp;
                    <asp:Button ID="Button4" runat="server" Text="头条" CssClass="btn_2k3" OnClick="btnBatchTopNews_Click" />
                    <asp:Button ID="Button5" runat="server" Text="取消头条" CssClass="btn_2k3" OnClick="btnBatchUnTopNews_Click" />
                    &nbsp;
                    <asp:Button ID="Button6" runat="server" Text="归档" CssClass="btn_2k3" OnClick="btnBatchFiling_Click" />
                    <span class="span_search_btn margin_left_20">
                        <asp:Button ID="btnRefresh0" runat="server" Text="刷新选中新闻 " Width="96px" CssClass="btn"
                            Height="23px" Style="margin-left: 20px; color: red; font-weight: bold;" OnClick="btnRefresh_Click" />
                    </span>
                </p>
                <p class="div_search_row" style="height: 30px;">
                    <asp:RadioButtonList ID="radioListIsTop" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="radioListIsTop_SelectedIndexChanged">
                        <asp:ListItem Value="0">0级置顶</asp:ListItem>
                        <asp:ListItem Value="1">1级置顶</asp:ListItem>
                        <asp:ListItem Value="2">2级置顶</asp:ListItem>
                        <asp:ListItem Value="3">3级置顶</asp:ListItem>
                        <asp:ListItem Value="4">4级置顶</asp:ListItem>
                        <asp:ListItem Value="5">5级置顶</asp:ListItem>
                        <asp:ListItem Value="6">6级置顶</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <p class="div_search_row" style="height: 30px;">
                    当前选择项移动到:<uc:NewsClass ID="ucNewsClass" runat="server" />
                    <asp:Button ID="Button7" runat="server" Text=" 移 动 " CssClass="btn_2k3" OnClick="btnMoveInfoClass_Click" />
                </p>
            </td>
        </tr>
    </table>
    <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15" ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
        NextPageText="下一页&gt;" CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页%PageSize%条</span>"
        NumericButtonCount="7">
    </webdiyer:AspNetPager>
</asp:Content>
