<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="ADList.aspx.cs" Inherits="PageAD_ADList" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register  Src="~/UserControl/ADPage.ascx" TagName="ADPage"  TagPrefix="uc" %>
<%@ Register  Src="~/UserControl/ADPagePosition.ascx" TagName="ADPagePosition"  TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <div class="div_nav_title2">
        <span>位置： 管理信息 > 广告管理</span>
    </div>
    <div class="div_search">
        <div class="div_search_row">
            <span class="span_search_label">广告名称：</span> <span class="span_search_element">
                <asp:TextBox ID="txtKeyWord" runat="server" MaxLength="300" Width="112px"></asp:TextBox></span>
            <span class="span_search_label">文件类型：</span> <span class="span_search_element">
                <asp:DropDownList ID="drplSearchFileType" runat="server" 
                RepeatDirection="Horizontal" Width="96px">
    
                </asp:DropDownList>
            </span>

             <span class="span_search_label">所属页面：</span> <span class="span_search_element">
         <uc:ADPage  ID="ucPage" runat="server" IsSearch="true"/>
                </span>
            <span class="span_search_label">所在位置：</span> <span class="span_search_element">
             
  <uc:ADPagePosition id="ucADPosition" runat="server" IsSearch="true"></uc:ADPagePosition>
            </span>
        </div>
          <div class="div_search_row">
          
          <span class="span_search_label">投放时间：</span> <span class="span_search_element">
                <asp:TextBox ID="txtSDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp; 
            -
                <asp:TextBox ID="txtEDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" />
            </span>
            <span class="span_search_label">到期日期：</span> <span class="span_search_element">
                <asp:TextBox ID="txtSEndDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSEndDate.ClientID %>').focus()" />&nbsp; 
            -
                <asp:TextBox ID="txtEEndDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtEEndDate.ClientID %>').focus()" />
            </span>
        </div>
        <div class="div_search_row">
          <span class="span_search_label">待删除状态：</span><span class="span_search_element">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="-1" Selected="True" Text="不限"></asp:ListItem>
                        <asp:ListItem Value="1" Text="可用"></asp:ListItem>
                        <asp:ListItem Value="0" Text="回收站"></asp:ListItem>
                    </asp:RadioButtonList>
                </span>

        <span class="span_search_label">审核状态：</span><span class="span_search_element">
                    <asp:RadioButtonList ID="radioCheckType" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="-1" Selected="True" Text="不限"></asp:ListItem>
                        <asp:ListItem Value="1" Text="审核"></asp:ListItem>
                        <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                    </asp:RadioButtonList>
                </span><span class="span_search_btn margin_left_50" style="margin-left: 100px;">
                    <asp:Button ID="btnSearch" runat="server" Text=" 查  询 " Width="80px" CssClass="btn"
                        Height="23px" OnClick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp;  <input  type="button"  value="增加新广告"  onclick="javascript:location.href='adadd.aspx'"  class="btn_2k3" style="color:Green;height:23px;"/>  
       
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <input  type="button"  value="广告数据刷新"  onclick='window.open("/cache/index.aspx")'  class="btn_2k3" style="color:red;height:23px;"/>
     </span>
       </div>
    </div>
    <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_title">
            <th class="th_grid_title">
                 <asp:CheckBox ID="cboxAll2" runat="server" OnCheckedChanged="cbox_CheckedChanged"  AutoPostBack="true"/>全选
            </th>
              <th class="th_grid_title">
             更新缓存
            </th>
          <th class="th_grid_title">
                广告状态
            </th>

            <th class="th_grid_title">
                广告名称
            </th>
              <th class="th_grid_title">
                点击量
            </th>
              
            
            <th class="th_grid_title">
                图片\Flash
            </th>
             <th class="th_grid_title">
                广告链接地址
            </th>
            <th class="th_grid_title">
                广告位置(页面:位置-序列)
            </th>
            <th class="th_grid_title">
              投放时间<br>  截止日期
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
                   <td class="td_grid_col w80">
                        <asp:CheckBox ID="cboxItem" ToolTip='<%#string.Format("{0}-{1}_{2}_{3}.js",Eval("ID"),Eval("Page"),Eval("Position"),Eval("Seq"))%>'   runat="server" />
                    
                    </td>
                <td class="td_grid_col w80">
                 <input  type="button"  class="btn_2k3"     style="color:red"  value="更新缓存"  onclick='openCacheAD("<%#Eval("Page")%>","<%#Eval("Position")%>","<%#Eval("Seq")%>")'/>
      
                </td>
                
                           
                 
                     <td class="td_grid_col w80">
                     <span class="spanIsChecked">
                       <%#Project.Common.Format.DataConvertToInt(Eval("checked"))>0?"审":""%></span> 
                        <%#Project.Common.Format.DataConvertToInt(Eval("IsRecycle")) ==0 ? "可用" : "<span style='color: #E6E6E6'>停用</span>"%>
                    </td>
                    <td class="td_grid_col  w150 td_wrap">
                        <%#Eval("Title")%>
                    </td>

                    <td class="td_grid_col  w50 td_wrap">
                    
                    
                    <%#Project.Common.Format.DataConvertToInt(Eval("hit")) + Project.Common.Format.DataConvertToInt(Eval("pv"))%>  </td>
                   
                 
                    <td class="td_grid_col td_wrap   w300" style="text-align:left; vertical-align:top;">
                    &nbsp;&nbsp;&nbsp;&nbsp;前台: <font color="red">(宽:<%#Eval("Width")%>)* (高:<%#Eval("Height")%>)</font><font color="green"> (值为0:为默认图片大小)</font><br/>
                        <%#BindFile(Eval("FileClass"),Eval("FileUrl"),266,50)%>
                    </td>
                       <td class="td_grid_col td_wrap  w150">
                      <%#string.Format("<a  href='{0}' target='_blank'>{0}</a>",Eval("Url"))%>
                    </td>
                    <td class="td_grid_col w150 ">
                        <%#Eval("Page")%> : <%#Eval("Position")%>-<%#Eval("Seq")%></td>
                    <td class="td_grid_col w150">
                        <%#Eval("StartDate","{0:yyyy-MM-dd}")%><br><br>
                         <%#Eval("EndDate","{0:yyyy-MM-dd}")%>   
                    </td>
                   
             
                    <td class="td_grid_col w100">
                        <a href='<%#string.Format("ADEdit.aspx?{0}={1}",LL.Common.PubConstant.Key_ID, Eval("id"))%>'>
                            【编辑】</a>
                        <asp:LinkButton ID="btnD" runat="server" CommandName="Delete" Text="【删除】"  CommandArgument='<%#string.Format("{0}_{1}_{2}.js",Eval("Page"),Eval("Position"),Eval("Seq"))%>'
                            OnClientClick="return  confirm('确信要删除此记录?，\n删除后数据将不能恢复!')"></asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <tr class="tr_grid_row">
            <td class="td_grid_col  textleft">
                <asp:CheckBox ID="cboxAll" runat="server" AutoPostBack="true" 
                    OnCheckedChanged="cbox_CheckedChanged" />
                全选<br />
                <asp:CheckBox ID="reCbox" runat="server" AutoPostBack="true" 
                    OnCheckedChanged="reCbox_CheckedChanged" />
                反选
            </td>
            <td colspan="9" align="left" valign="middle" >
                &nbsp;&nbsp;
                    &nbsp;
                    &nbsp;
             
                    <asp:Button ID="Button2" runat="server" Text="移动到回收站" CssClass="btn_2k3" 
                        OnClick="btnMoveToRecycle_Click" /> <asp:Button ID="Button3" runat="server" Text="还原" CssClass="btn_2k3"  
                        OnClick="btnUNMoveToRecycle_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnBatchDelete"  ForeColor="Red" runat="server" Text="批量删除" CssClass="btn_2k3" OnClientClick="return  confirm('确信要进行批量删除吗?，\n删除后数据将不能恢复!')"
                        OnClick="btnBatchDelete_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnBatchCheck"     ForeColor="Green"   runat="server" Text="审核" CssClass="btn_2k3" OnClick="btnBatchCheck_Click" />
                    <asp:Button ID="Button1"  ForeColor="Green" runat="server" Text="取消审核" CssClass="btn_2k3" OnClick="btnBatchUnCheck_Click" />
                    &nbsp;&nbsp;
                    &nbsp;
                    &nbsp;
                   
             
            </td>
        </tr>
    </table>
       <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15"   showcustominfosection="Left"  width="100%"  CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"   PageIndexBoxStyle="width:24px"
        onpagechanged="pager_PageChanged"  PrevPageText="&lt;上一页" NextPageText="下一页&gt;"  CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>共%PageCount%页</span>，<span>每页显示%PageSize%条</span>">
        </webdiyer:AspNetPager>

        <script type="text/javascript" language="javascript">

            function SetAdImgSize() 
            {
                var arrImg = $(".adimg");
               
                for (var i = 0; i < arrImg.length; i++) {
                    var w = $(arrImg[i]).width();
                    var h = $(arrImg[i]).height();
                    var   w2 = parseInt(w) > 266 ? 266 : w;
                    var h2 = parseInt(h) > 50 ? 50 : h;
                    $(arrImg[i]).css({ "width": w2 + "px", "height": h2 + "px","border":0 }).attr("alt","实际尺寸:"+w+"*"+h+",点击查看图片");

//                    $(arrImg[i]).bind("mouseover", function ()

//                    { $(arrImg[i]).css({ "width": w + "px", "height": h + "px", "border": 0 }); alert(w); }
//                     )
//                     .bind("mouseout", function ()
//                     { $(arrImg[i]).css({ "width": w2 + "px", "height": h2 + "px", "border": 0 }); });
                }
            }
            $(document).ready(function () { SetAdImgSize(); });
        </script>
</asp:Content>
