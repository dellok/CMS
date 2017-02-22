<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="SolutionList.aspx.cs" Inherits="SolutionList" %>
    <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <table width="98%" height="1107" border="0" align="center" cellpadding="0" cellspacing="1"
        bgcolor="#DBDBDB">
        <tr>
            <td valign="top" bgcolor="#FFFFFF">
                <table border="0" align="center" cellpadding="0" cellspacing="1" class="tb_info">
                    <tr style="background: #EEEEEE;">
                        <th>
                         Vip会员 解决方案 管理
                        </th>
                    </tr>
                </table>
                <table border="0" class="tbSearchTitle" align="center">
                    <tr>
                        <td align="left">
                        </td>
                        <td style="text-align: right">
                            <span class="spanSearch">搜索：</span><asp:TextBox ID="txtSearchKey" runat="server"
                                Text="" CssClass="txtSearch"></asp:TextBox>
                            <asp:DropDownList ID="drplSearchType" runat="server" CssClass="selectSearch">
                                <asp:ListItem Value="标题" Text="标题"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnSearch" runat="server" Text="搜索" class="btn_2k3" OnClick="btnSearch_Click"
                                Width="100px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAdd" runat="server" Text="增加" class="btn_2k3" 
                                onclick="btnAdd_Click" />
                        </td>
                    </tr>
                </table>

               
                <asp:Repeater ID="repDataList" runat="server">

                <HeaderTemplate>
                       <table class="tb_grid" border="0" cellspacing="1" cellpadding="0" align="center">
                    <tr class="tr_grid_title">
                        <td class="th_grid_title ">
                            标题
                        </td>
                        <td class="th_grid_title">
                            发布时间
                        </td>
                        <td class="th_grid_title">
                            评论
                        </td>
                     
                        <td class="th_grid_title">
                            操作
                        </td>
                    </tr>
                
                </HeaderTemplate>
                <ItemTemplate>
               
               <tr class="tr_grid_row">
                                <td class="td_grid_col td_wrap textleft">
                           
                 
                        <span  >·</span><a href='<%#string.Format("http://liot.org.cn/vipsite/newsdetail.aspx?u={0}_{1}_{2}&Admin=true",Eval("userid"),(int)LL.Common.EnumClass.VipSiteItemsClassID.新闻动态,Eval("id"))%>' target="_blank">
                       
                                        <%#Eval("title")%></a>
                                </td>
                                <td class="td_grid_col  td_wrap  w150">
                                    <%#Eval("newstime","{0:yyyy-MM-dd}")%>
                                </td>
                                <td class="td_grid_col  w30">
                                    <%#Eval("plnum","{0:G}")%>
                                </td>
                          
                                <td class="td_grid_col    w120  txtcenter" align="center">
                                    <a  style="width: 60px; color: green;" href='SolutionManager.aspx?id=<%#Eval("id")%>&userid=<%#Eval("userid")%>'>
                                        【修改】</a> &nbsp;&nbsp;
                                    <asp:LinkButton runat="server" Text="【删除】" ID="btnDel" CommandArgument='<%#Eval("id")%>'
                                        OnClick="btnDel_Click" OnClientClick="return confirm('确信要删除此条数据!\r\n删除后数据将不能恢复!');"
                                        Style="width: 60px; color: Red;" ></asp:LinkButton>
                                </td>
                            </tr>
                
                
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
                </asp:Repeater>




                 <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15" ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
        NextPageText="下一页&gt;" CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页%PageSize%条</span>"
        NumericButtonCount="7">
    </webdiyer:AspNetPager>
   
            </td>
        </tr>
    </table>
</asp:Content>
