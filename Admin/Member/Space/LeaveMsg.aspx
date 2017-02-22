<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="LeaveMsg.aspx.cs" Inherits="Member_MemberLeaveMsg" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="../MemberList.aspx">会员管理</a>
            > 会员留言管理</span></div>
    <div class="div_search">
        <span class="span_search_label">搜索：</span> <span class="span_search_element">
            <asp:TextBox ID="txtSearchKeyword" runat="server"></asp:TextBox></span> <span class="span_search_element">
                <asp:DropDownList ID="drplWhereField" runat="server" Height="20">
                    <asp:ListItem Value="gbtext">留言内容</asp:ListItem>
                    <asp:ListItem Value="retext">回复内容</asp:ListItem>
                    <asp:ListItem Value="uname">留言者</asp:ListItem>
                    <asp:ListItem Value="userid">空间主人ID</asp:ListItem>
                    <asp:ListItem Value="ip">留言者IP</asp:ListItem>
                </asp:DropDownList>
            </span><span class="span_search_btn">
                <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                    Height="22px" OnClick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp; </span>
    </div>
    <asp:ListView ID="repList" runat="server" DataKeyNames="gid"  
        ItemPlaceholderID="itemList" onitemdeleting="repList_ItemDeleting">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="tb_grid">
                <tr class="tr_grid_title">
                    <td height="23" class="th_grid_title textleft">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="76%">
                                    <asp:CheckBox ID="cboxID" runat="server" CssClass="cboxItem" ToolTip='<%=Eval("gid") %>' />&nbsp;&nbsp;|&nbsp;&nbsp;
                                    空间主人:<a href="?userid=<%#Eval("userid")%>">
                                        <%#Eval("spaceusername")%></a> &nbsp;&nbsp;|&nbsp;&nbsp;发布者:<b><%#Eval("uname")%></b>&nbsp;&nbsp;|&nbsp;&nbsp;留言于:<b><%#Eval("addtime")%></b>&nbsp;&nbsp;|&nbsp;&nbsp;IP:<b><%#Eval("ip")%></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;
                                    <asp:LinkButton ID="btnDel" runat="server" Text="【删除】" OnClientClick="return confirm('确认要删除?');"
                                        CommandName="Delete"  />
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td height="25" style='word-break: break-all' class="txtleft">
                        <table border="0" width="100%" cellspacing="1" cellpadding="10" bgcolor='#cccccc'>
                            <tr>
                                <td width='100%' bgcolor='#FFFFFF' style='word-break: break-all'>
                                    <%#Eval("gbtext")%>
                                </td>
                            </tr>
                        </table>
                        <%#BindReplyLeavaMsg(Eval("retext"))%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tdDataCol manu datapager">
                <asp:Button ID="btnChecked" runat="server" Text="审核" CommandArgument="1" CssClass="btn"
                    OnClick="btnChecked_Click" Width="80px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" CommandArgument="0" Text="取消审核" ForeColor="Green"
                    CssClass="btn" OnClick="btnChecked_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="删除所选" ForeColor="Red" CssClass="btn"
                    OnClick="btnDeleteAll_Click" />
            </td>
        </tr>
    </table>
    <table class="tbPager" width="100%">
        <tr>
            <td class="tdPager">
                <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15" ShowCustomInfoSection="Left"
                    Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
                    PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
                    NextPageText="下一页&gt;" CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页%PageSize%条</span>"
                    NumericButtonCount="5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
</asp:Content>
