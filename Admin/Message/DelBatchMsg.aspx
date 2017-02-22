<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="DelBatchMsg.aspx.cs" Inherits="Send_DelMsg" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">

<style>
  
  
  .tb_info tr{height:30px;width:800px;}
  .left{width:100px;}
 
    .calendarFocus
    {}
  
 
    </style>

  	
      <div class="div_nav_title2">
        <span>位置： 管理信息 > 站内信息管理</span>
    </div>



     <div class="div_search_row">
            <span class="span_search_label">信箱类型：</span> <span class="span_search_element">    <asp:DropDownList ID="drplMsgType" runat="server"  Width="145px">
 
  <asp:ListItem Text="查询全部" Value="0" Selected="True"></asp:ListItem>
  <asp:ListItem Text="收件箱" Value="1"></asp:ListItem>
  <asp:ListItem Text="发件箱" Value="2"></asp:ListItem>
   <asp:ListItem Text="系统群发" Value="3"></asp:ListItem>
 
 </asp:DropDownList></span>
        

              <span class="span_search_label">包含关键字：</span> <span class="span_search_element">
                <asp:TextBox ID="txtKeyWord" runat="server" ></asp:TextBox>
  <asp:DropDownList ID="drplKeyWordType" runat="server" Width="145px">
 
  <asp:ListItem Text="查询标题和内容" Value="0" Selected="True"></asp:ListItem>
  <asp:ListItem Text="只查询标题" Value="1"></asp:ListItem>
  <asp:ListItem Text="只查询内容" Value="2"></asp:ListItem>

 
 </asp:DropDownList>
            </span>
        </div>


     <div class="div_search_row">
            <span class="span_search_label">发&nbsp;&nbsp;件&nbsp;人：</span> <span class="span_search_element"> <asp:TextBox ID="txtFromUser" runat="server" ></asp:TextBox>
 
 <asp:CheckBox  ID="cboxFrom" runat="server" Checked="true" Text="模糊匹配"/> (不填为不限)  </span>
        

              <span class="span_search_label">收&nbsp;&nbsp;件&nbsp;人：</span> <span class="span_search_element">
               <asp:TextBox ID="txtToUser" runat="server" /> <asp:CheckBox  ID="cboxToUser" runat="server" Checked="true" Text="模糊匹配"/> (不填为不限)</td>

            </span>
        </div>
 

 <div class="div_search_row">
            <span class="span_search_label">时&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;间：</span> <span class="span_search_element"> <asp:TextBox ID="txtStart" runat="server"   CssClass="calendarFocus"          Width="128px"   />
                <img  src="../Images/date.gif" alt="" class="calendarFocus"     onclick="javascript:$('#<%=txtStart.ClientID %>').focus()" /> 到<asp:TextBox ID="txtEnd" runat="server"   CssClass="calendarFocus"  Width="128px"   />
                <img  src="../images/date.gif" alt="" class="calendarFocus"            onclick="javascript:$('#<%=txtEnd.ClientID %>').focus()"             />
            </span>
        

              <span class="span_search_label"><asp:Button  ID="btnSearch" runat="server" CssClass="btn_2k3" 
         Text=" 查 询 " onclick="btnSearch_Click" Width="91px" /> 
         <asp:Button  ID="btnDel" 
         runat="server" CssClass="btn_2k3"  Text=" 不查询直接删除 " onclick="btnReset_Click"/></span> 

         
        </div>

 <table class="tb_grid" cellspacing="1" cellpadding="0">
                <tr class="tr_grid_title">
                    <th class="th_grid_title">
                         <asp:CheckBox ID="cboxAll2" runat="server" OnCheckedChanged="cbox_CheckedChanged"
                    AutoPostBack="true" />全选
                    </th>
                    <th class="th_grid_title">
                      收件人
                    </th>
                    <th class="th_grid_title">
                       发件人
                    </th>
                    <th class="th_grid_title">
                       发送日期
                    </th>
                    <th class="th_grid_title">
                        标题/内容
                    </th>
                  
                </tr>
    <asp:ListView ID="dataViewList" runat="server" ItemPlaceholderID="itemList" DataKeyNames="ID">
        <LayoutTemplate>
            
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
         
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="tr_grid_row">
                <td class="td_grid_col  w50">
                    <asp:CheckBox ID="cboxItem" ToolTip='<%#Eval("ID")%>' runat="server" />
                </td>
                <td valign="top" class="td_grid_col  ">

                    <%#Eval("to_username")%>
                </td>
                <td valign="top" class="  td_wrap">
                    <%#Eval("from_username")%>
                </td>
                <td valign="top" class=" w200 td_wrap">
                  <%#Eval("msgtime")%>
                </td>
                <td class="td_grid_col td_wrap w200 " style="text-align: left;"  valign="top">
                    <p  style="color:Red;font-weight:bold;margin:2px 2px;">
                  <%#Eval("title")%>
                    </p>
                    <asp:TextBox ID="txtContent" runat="server" Text=' <%#Eval("msgtext")%>' Rows="5"
                        TextMode="MultiLine" Columns="60"></asp:TextBox>
                </td>
           
            </tr>
        </ItemTemplate>
    </asp:ListView>
         <tr class="tr_grid_row">
                    <td class="td_grid_col  textleft">
                             <asp:CheckBox ID="cboxAll" runat="server" OnCheckedChanged="cbox_CheckedChanged"
                    AutoPostBack="true" />全选<br />
                <asp:CheckBox ID="reCbox" runat="server" OnCheckedChanged="reCbox_CheckedChanged"
                    AutoPostBack="true" />反选
                    </td>
                    <td colspan="4" align="left" valign="middle">
                 
                  <asp:Button ID="btnBatchDelete" runat="server" Text="批量删除" CssClass="btn_2k3" OnClientClick="return  confirm('确信要进行批量删除吗?，\n删除后数据将不能恢复!')"
        OnClick="btnBatchDelete_Click" />

                    </td>
                </tr>
                </table>
<webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15"   showcustominfosection="Left"  width="100%"  CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"   PageIndexBoxStyle="width:24px"
        onpagechanged="pager_PageChanged"  PrevPageText="&lt;上一页" NextPageText="下一页&gt;"  CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页显示%PageSize%条</span>">
        </webdiyer:AspNetPager>
   


</asp:Content>

