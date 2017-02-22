<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="VipMemberList.aspx.cs" Inherits="News_NewsClassTree" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">

<script src="/scripts/dtree/dtree.js" type="text/javascript"  language="javascript"></script>
<link   href="/scripts/dtree/dtree.css"  type="text/css" rel="Stylesheet"/>
<script src="../Scripts/treeNewsSelectedNodeCss.js" type="text/javascript"  language="javascript"></script>



   <div class="div_search">
    <div class="div_search_row">
          <span class="span_search_label">级别：</span> <span class="span_search_element">

          <asp:DropDownList ID="drplSearchType" runat="server" Height="22px" Width="100px">
          </asp:DropDownList>
          
        </div>
          <div class="div_search_row">
          <span class="span_search_label">会员：</span> <span class="span_search_element">
              <asp:TextBox ID="txtMemberName" runat="server" Width="85px"></asp:TextBox>
    <asp:Button  ID="btnSearchMember" runat="server" Text="查询" 
        onclick="btnSearchMember_Click" CssClass="btn_2k3"/>
        </div>

          <div class="div_search_row">
          共：<%=pager.RecordCount %>条记录，<%=pager.PageCount %>页，每页<%=pager.PageSize %>条
        </div>

          <div class="div_search_row">
           <webdiyer:aspnetpager ID="pager" runat="server" CssClass="manu "
        Width="200"   ShowCustomInfoSection="Never" ShowPrevNext="false" 
        AlwaysShowFirstLastPageNumber="true" PageSize="30" NumericButtonCount="3"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" >
     
    </webdiyer:aspnetpager>
        </div>
        </div>




                 
      


      


   
<asp:Label ID="lblDTree" runat="server"></asp:Label>





</asp:Content>

