<%@ Page Language="C#"  CodeFile="Feedback.aspx.cs" Inherits="Member_Space_Index"
    MasterPageFile="~/Admin.master" %>
    
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="c" runat="server" ContentPlaceHolderID="adminmaster">
    <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="../MemberList.aspx">会员管理</a>
            > 会员空间反馈管理</span></div>
    <div class="div_search">
        <span class="span_search_label">搜索：</span> <span class="span_search_element">
            <asp:TextBox ID="txtSearchKeyword" runat="server"></asp:TextBox></span> <span class="span_search_element">
                <asp:DropDownList ID="drplWhereField" runat="server" Height="22">
                    <asp:ListItem Value="title">反馈标题</asp:ListItem>
                    <asp:ListItem Value="retext">反馈内容</asp:ListItem>
                    <asp:ListItem Value="userid">空间主人ID</asp:ListItem>
                    <asp:ListItem Value="ip">留言者IP</asp:ListItem>
                </asp:DropDownList>
            </span><span class="span_search_btn">
                <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                    Height="22px" OnClick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp; </span>
    </div>
        
                <asp:ListView ID="listData" runat="server" ConvertEmptyStringToNull="true" DataKeyNames="fid"
                    ItemPlaceholderID="pagePlace" onitemdeleting="listData_ItemDeleting">
                    <LayoutTemplate>
                        <table class="tb_grid" cellspacing="1" cellpadding="0" style="width: 100%">
                            <tr class="tr_grid_title">
                                <th class="th_grid_title textleft">
                                <input  type="checkbox" onclick="Util.CboxCheckedAll(this.checked,'cboxItem')"/>
                                </th>
                                <th class="th_grid_title textleft ">
                                    标题
                                </th>
                                  <th class="th_grid_title textleft w100">
                                   空间主人
                                </th>
                                <th class="th_grid_title textleft w100">
                                    提交时间
                                </th>
                                <th class="th_grid_title textleft w200">
                                    操作
                                </th>
                            </tr>
                            <asp:PlaceHolder ID="pagePlace" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="tr_grid_row">
                            <td class="td_grid_col     textleft">
                                <asp:CheckBox ID="cboxID" runat="server" CssClass="cboxItem" ToolTip='<%#Eval("fid") %>' />
                            </td>
                            <td class="td_grid_col     textleft">
                               
                                <a href='FeedbackDetail.aspx?ID=<%#Eval("fid")%>'><%#Eval("title")%></a>(反馈者: <a href="?userid=<%#Eval("uid")%>"><%# Eval("uname")%></a>)</td>
                         <td class="td_grid_col     textleft">
                              <a href="?userid=<%#Eval("userid")%>"><%# Eval("spacename")%></a>
                            </td>
                            <td class="td_grid_col     textleft">
                                <%# Eval("addtime")%>
                            </td>
                            <td class="td_grid_col     textleft">
                                <asp:LinkButton ID="del" runat="server" CommandName="Delete" CommandArgument='<%#Eval("fid")%>' Text="删除"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

             <table class="tbPager">
             <tr>
              <td>
               
               <asp:Button  ID="btnDeleteAll" runat="server" Text="删除所选" CssClass="btn" 
                      onclick="btnDeleteAll_Click"/>
              
              </td>

              <td class="tdPager">
                <webdiyer:aspnetpager id="pager" runat="server" cssclass="manu " pagesize="15" showcustominfosection="Left"
                    width="100%" custominfostyle="width:20%;" alwaysshowfirstlastpagenumber="true"
                    pageindexboxstyle="width:24px" onpagechanged="pager_PageChanged" prevpagetext="&lt;上一页"
                    nextpagetext="下一页&gt;" custominfohtml="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页%PageSize%条</span>"
                    numericbuttoncount="5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;
                </webdiyer:aspnetpager>
                </td>
             </tr>
             
        
             </table>
  
</asp:Content>
