<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="ADAdd.aspx.cs" Inherits="PageAD_ADAdd" %>

<%@ Register  Src="~/UserControl/ADPage.ascx" TagName="ADPage"  TagPrefix="uc" %>
<%@ Register  Src="~/UserControl/ADPagePosition.ascx" TagName="ADPagePosition"  TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">

    <div class="div_nav_title2">
        <span>位置： 管理信息 ><a href="AdList.aspx">广告管理</a> >广告添加</span>
  </div>

  <table class="tb_info">
  <tr>
   <td class="left">广告类型：</td>
   <td class="right">
    <asp:RadioButtonList ID="radioFileClass" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">

    </asp:RadioButtonList>
   
   </td>
  </tr>
    <tr>
   <td class="left">广告页面：</td>
   <td class="right">
   <uc:ADPage  ID="ucADPage" runat="server"/>

     &nbsp;&nbsp;&nbsp;&nbsp;
    <span class="span_search_label">所在页面位置:</span>

    <uc:ADPagePosition id="ucADPosition" runat="server"></uc:ADPagePosition>

       &nbsp;&nbsp;&nbsp;&nbsp;<span class="span_search_label">第:</span>
     <asp:TextBox ID="txtSeq" runat="server" Width="51px"></asp:TextBox>
     
   <span class="span_search_label">位:</span>
   </td>
  </tr>
      <tr>
   <td class="left">广告名称：</td>
   <td class="right">
  <asp:TextBox ID="txtADName" runat="server" Width="500px"></asp:TextBox>(如:x公司广告,100字内)
   
   </td>
  </tr>
        <tr>
   <td class="left">广告链接地址：</td>
   <td class="right">
  <asp:TextBox ID="txtADUrl" runat="server" Width="500px"></asp:TextBox>
       (目前只适用于图片)</td>
  </tr>
          <tr>
   <td class="left">点击量：</td>
   <td class="right">
  <asp:TextBox ID="txtHit" runat="server" Width="315px"></asp:TextBox>
       (添加时不用写入)</td>
  </tr>
          <tr>
   <td class="left">过期时间：</td>
   <td class="right">
   <span class="span_search_element">
                <asp:TextBox ID="txtSDate" runat="server" Width="150px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp; 
       到&nbsp;
                <asp:TextBox ID="txtEDate" runat="server" Width="150px" 
           CssClass="calendarFocus" Height="19px"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" />
            </span>
            </td>
  </tr>



  
            <tr>
   <td class="left">广告大小：</td>
   <td class="right">
            
            <asp:TextBox ID="TextBox1" runat="server" Text="Width:" Width="60px" 
                style='border-right:0px;'/><asp:TextBox ID="txtAdWidth" runat="server" style="border-left:0px;"/>
         
                <asp:TextBox ID="TextBox2" runat="server" Text="Height:" Width="60px" 
                style='border-right:0px;'/><asp:TextBox ID="txtAdHeight" runat="server" style="border-left:0px;"></asp:TextBox>
            </td>
  </tr>


    
              <tr>
   <td class="left">上传文件：</td>
   <td class="right">
         
          
          <asp:FileUpload  ID="up" runat="server"/>        

            </td>
  </tr>
                 <tr>
   <td class="left">广告图片/Flash路径：</td>
   <td class="right">
         
 
 <asp:TextBox ID="txtAdFilePath" runat="server" Width="500px"></asp:TextBox><b style="color:Red;">(注:如果上传件与广告文件引用路径共同有值,则取上传文件图片路径)</b>

            </td>
  </tr>

                <tr>
   <td class="left">简单注释：</td>
   <td class="right">
         
          
       <asp:TextBox ID="txtRemark" runat="server" MaxLength="100" Width="499px"/>  (100字内) 

            </td>
  </tr>
   <tr>
   <td class="left">是否启用：</td>
   <td class="right">
         
          
     <asp:CheckBox  ID="cboxChecked" runat="server"/>

            </td>
  </tr>

                <tr>
   <td class="left" colspan="2">
       <input class="btn_2k3" 
           onclick="openCacheAD('<%=page%>','<%=position%>',<%=seq%>)" type="button" 
           value="刷新此广告数据" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button  ID="btnAdd2" runat="server" Text=" 添  加 并 继 续 添 加 "  
           CssClass="btn_2k3" onclick="btnAdd2_Click" 
           />&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button  ID="btnAdd" runat="server" Text=" 添  加(成功后返回广告列表页) "  CssClass="btn_2k3" 
           onclick="btnAdd_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Button  ID="btnReturn" runat="server" Text=" 返回广告列表 "  CssClass="btn_2k3"    
           Width="104px" onclick="btnReturn_Click"/>
            
            </td>
  </tr>

  </table>

  <div class="divRemark">
  注:广告生成js 方式 : 前缀_AD栏目ID_广告所在页面位置_序列(例：AD1_A1_3)
  </div>

</asp:Content>

