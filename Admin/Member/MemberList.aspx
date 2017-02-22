<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="MemberList.aspx.cs" Inherits="Member_MemberList" %>

<%@ Register Src="~/UserControl/MemberGroupDownList.ascx" TagName="MemberGroup" TagPrefix="uc" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > 会员列表</span></div>
    <div class="div_search">
        <span class="span_search_label">用户名：</span> <span class="span_search_element">
            <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></span>
               <span class="span_search_label">
                会员Email：</span><span class="span_search_element">
                     <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </span>
            
             <span class="span_search_label">
                会员角色：</span><span class="span_search_element">
                    <uc:MemberGroup ID="ucMemberGroupList" runat="server"></uc:MemberGroup>
                </span>
                
              
                <span class="span_search_label">审核：</span><span class="span_search_element">
                    <asp:DropDownList ID="drplMemberCheck" runat="server">
                        <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="审核" Value="1"></asp:ListItem>
                        <asp:ListItem Text="未审核" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </span><span class="span_search_btn">
                    <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                        Height="22px" OnClick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<input   type="button"  value="增加会员"  class="btn" style="color:Green;height;22px;" onclick="javascript:location.href='MemberCompanyInfo.aspx'"/>
                        </span>
    </div>
    <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_title">
            <th class="th_grid_title textcenter">
             <input  id="cboxAll2"  type="checkbox" name="cboxAll" />
            </th>
            <th class="th_grid_title">
                ID(点击进入<br/>会员网站管理)
            </th>
            <th class="th_grid_title">
                用户名(会员级别)
            </th>
            <th class="th_grid_title">
                是否审核
            </th>
                <th class="th_grid_title">
                会员组
            </th>
             <th class="th_grid_title">
                注册时间
            </th>
                <th class="th_grid_title">
             到期时间
            </th>
           
        

           <%-- <th class="th_grid_title">
                Email
            </th>--%>
        
            <th class="th_grid_title">
                操作
            </th>
        </tr>
        <asp:ListView ID="dataViewList" runat="server" ItemPlaceholderID="itemList" DataKeyNames="userid"
            OnItemDeleting="dataViewList_ItemDeleting">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="tr_grid_row">
                    <td class="td_grid_col w80 ">
                        <asp:CheckBox ID="cboxItem" ClientIDMode="Static" ToolTip='<%#Eval("userid")%>' runat="server" />
                    </td>
                    <td class="td_grid_col w80">


                   <%#BindWebSiteUrl(Eval("userid"),Eval("groupid"))%>
                       </td>
                    <td class="td_grid_col td_wrap w200">
                        <a href='<%#string.Format("{0}/vipsite/index.aspx?{1}={2}",LL.Common.Cache.ConfigManager.MainDomain,"u" ,Eval("userid")) %>'
                            target="_blank" title="查看会员网站">
                            <%#Eval("username")%></a>
                    </td>
                    <td class="td_grid_col w80">
                        <%#Eval("checked").ToString()=="0"?"未审核":"<span style='color:green'>已通过</span>" %>
                    </td>
                     <td class="td_grid_col td_wrap w80">
                        <%#PageCommon.GetGroupName(Project.Common.Format.DataConvertToInt(Eval("groupid")))%>
                    </td>
                   <td class="td_grid_col w200">
                        <%#Eval("registertime")%>
                    </td>
                   
                      <td class="td_grid_col w200">
                   <%#Project.Common.Format.DataConvertToInt(Eval("userdate"))>0?Project.Common.Format.UnixTimeStampToDateTime(Eval("userdate").ToString()).ToString():"<font color=#cccccc>"+Eval("userdate").ToString()+"</font>"%>
                    </td>
                   
                   <%-- <td class="td_grid_col w80">
                        <%#Eval("email")%>
                    </td>--%>
                    <td class="td_grid_col ">
                        <a href='<%#string.Format("MemberInfo.aspx?{0}={1}&{2}={3}",LL.Common.PubConstant.Key_ID, Eval("userid"),LL.Common.PubConstant.Key_MemberGroup,Eval("groupid"))%>'>
                            【编辑】</a>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="【删除】"
                            OnClientClick="return  confirm('确信要删除此记录?，\n删除后数据将不能恢复!')"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <tr class="tr_grid_row">
            <td class="td_grid_col  txtcenter" >
           <input  id="Checkbox1"  type="checkbox" name="cboxAll" />
            </td>
            <td class="td_grid_col" colspan="7">
                <asp:Button ID="btnBatchCheck" runat="server" Text="批量审核" CssClass="btn_2k3" OnClick="btnBatchCheck_Click" />
                <asp:Button ID="Button1" runat="server" Text="批量取消审核" CssClass="btn_2k3" OnClick="btnBatchUnCheck_Click" />
                <asp:Button ID="btnBatchDelete" runat="server" Text="批量删除" CssClass="btn_2k3" OnClientClick="return  confirm('确信要进行批量删除吗?，\n删除后数据将不能恢复!')"
                    OnClick="btnBatchDelete_Click" />
            </td>
        </tr>
    </table>
    <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true" PageSize="20"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" CustomInfoHTML="<span>共 <span>%RecordCount%</span> 条记录</span>，<span>%CurrentPageIndex%</span>/%PageCount%，每页 %PageSize% 条">
    </webdiyer:AspNetPager>
</asp:Content>
