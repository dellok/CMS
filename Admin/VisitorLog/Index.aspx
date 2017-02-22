<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="Index.aspx.cs" Inherits="Index" %>
    <%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <style>
        h3
        {
            margin: 0px;
        }
        
        .logpage_selectedlinkbutton{margin:0px 10px;font-weight:bolder;color:Red; }
        .logpage_LinkButton{margin:0px 10px;}
        
        .style1
        {
            white-space: nowrap;
            word-break: break-all;
            word-wrap: break-word;
            height: 26px;
        }
        
        </style>
    <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="index.aspx">缓存管理</a>>刷新数据</span></div>
    <div class="div_search">
        <div class="th_grid_title txtmiddle font_b  ">
            &nbsp;请选择频道<font class="font_red font_size_12">(没有选择项默认为执行全部频道)</font></div>
        <div class="div_search_row">
            <span class="span_search_label">&nbsp;栏 目：</span> <span class="span_search_element">
              
            
              <asp:DropDownList ID="drplItem" runat="server" Height="22px" Width="120px"  >
              
                         
              
              </asp:DropDownList>
              
              </span>
               <span class="span_search_label">信息ID：</span> <span class="span_search_element">
              
            <asp:TextBox ID="txtInfoID" runat="server" Width="80px"></asp:TextBox>
                <span class="span_search_label">信息标题：</span> <span class="span_search_element">
              
            <asp:TextBox ID="txtInfoTitle" runat="server" Width="445px"></asp:TextBox>
              
              </span>
        </div>
              <div class="div_search_row">
                  <span class="span_search_label">周 期：</span> <span class="span_search_element">
               


             

                 <a  href="javascript:SetSearchDate(1)" class="logpage_SelectedLinkButton"   >当天</a> 
                <a  href="javascript:SetSearchDate(-1)" class="logpage_LinkButton"          >昨天</a>
                <a  href="javascript:SetSearchDate(7)" class="logpage_LinkButton"   >最近七天</a>
                <a  href="javascript:SetSearchDate(30)" class="logpage_LinkButton"  >最近30天</a>

</span>
        
          
   <span class="span_search_label">自定义时间：</span> <span class="span_search_element">
   <asp:TextBox ID="txtSDate" runat="server" Width="166px" CssClass="calendarFocus"
                              ClientIDMode="Static"></asp:TextBox><img alt="单击选择时间" src="../Images/date.gif" class="calendarFocus"
                                    onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp; 到
       <asp:TextBox ID="txtEDate" runat="server" Width="166px" CssClass="calendarFocus"  
                      ClientIDMode="Static"  ></asp:TextBox><img alt="单击选择时间" src="../Images/date.gif" class="calendarFocus"
                                    onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" /></span><span class="font_red b">(不填写,默认为当天时间)</span>

        </div>
    <div class="div_search_row">
    <span class="span_search_label">排序：</span>
     <span class="span_search_label">
     <asp:RadioButtonList ID="radioOrderBy" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
     <asp:ListItem Text="IP数->高-底" Value="ips  desc" Selected="True"></asp:ListItem>
      <asp:ListItem Text="IP数->底-高" Value="ips  asc"></asp:ListItem>
     <asp:ListItem Text="PV数->高-底" Value="pvs  desc"></asp:ListItem>
      <asp:ListItem Text="PV数->底-高" Value="pvs  asc"></asp:ListItem>
     <asp:ListItem Text="点击->高-底(适用广告)" Value="hits  desc"></asp:ListItem>
      <asp:ListItem Text="点击->底-高(适用广告)" Value="hist  asc"></asp:ListItem>
     </asp:RadioButtonList>   
        </span>
      <span class="span_search_label">&nbsp;
      
      <asp:Button  ID="btnSearch" runat="server"  Text="【 查 询 】" 
            onclick="btnSearch_Click" CssClass="btn_2k3" />
      
        </span></div>
    </div>
       
       <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_row ">

       
            <td valign="top" class="th_grid_title txtmiddle font_b  w120">
               
                      
                     信息ID
             
                  </td>
                   <td class="th_grid_title txtmiddle font_b w300">
               
               信息标题
             
                  </td>

                     <td class="th_grid_title txtmiddle font_b w120">
                 IP数
                  </td>
                       <td class="th_grid_title txtmiddle font_b w120">
                 访客数(UV)
                  </td>
                      <td class="th_grid_title txtmiddle font_b w120">
                浏览量(PV)
                  </td>
                
        </tr>

        


        <asp:ListView ID="dataViewList" runat="server" ItemPlaceholderID="itemList" DataKeyNames="infoid"
           >
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                
            <tr class="tr_grid_row  ">
          
            <td class="td_grid_col">
           <%#Eval("InfoID") %>
            </td>
             <td class="td_grid_col">
            <%#Eval("InfoTitle")%>
            </td>
          
           <td class="td_grid_col">
           <%#Eval("IPs") %>
            </td>
             <td class="td_grid_col">
             <%#Eval("Visitors") %>
            </td>
             <td class="td_grid_col">
           <%#Eval("PVs")%>
            </td>
        
        </tr>

            </ItemTemplate>
        </asp:ListView>

    
    </table>

        <webdiyer:aspnetpager ID="pager" runat="server" CssClass="manu " 
        PageSize="15" ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
        NextPageText="下一页&gt;" CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页%PageSize%条</span>"
        NumericButtonCount="7">
    </webdiyer:aspnetpager>
    <div>
    </div>
    <div id="divIndex"></div>
    <div>
        <div id="divFrm">
        </div>
    </div>
    <script type="text/javascript" language="javascript">


        function SetSearchDate(v) {
            var today = new Date();
            var sDate = new Date(today);
            var eDate = new Date(today.setDate(today.getDate() + 1));

            if (v == -1) {

                sDate = new Date(today.setDate(today.getDate() - 2));
               // eDate = new Date(today.setDate(today.getDate() - 2));


            }
            else if (v == 7) {

                sDate = new Date(today.setDate(today.getDate() - 7));
                //eDate = new Date(today);

            }

            else if (v == 30) {
                sDate = new Date(today.setDate(today.getDate() - 30));
                //eDate = new Date(today);
            }


      




            $("#txtSDate").val(sDate.pattern("yyyy-MM-dd"));
           $("#txtEDate").val(eDate.pattern("yyyy-MM-dd"));
        }





        Date.prototype.pattern = function (fmt) {
            var o = {
                "M+": this.getMonth() + 1, //月份     
                "d+": this.getDate(), //日     
                "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, //小时     
                "H+": this.getHours(), //小时     
                "m+": this.getMinutes(), //分     
                "s+": this.getSeconds(), //秒     
                "q+": Math.floor((this.getMonth() + 3) / 3), //季度     
                "S": this.getMilliseconds() //毫秒     
            };
            var week = {
                "0": "\u65e5",
                "1": "\u4e00",
                "2": "\u4e8c",
                "3": "\u4e09",
                "4": "\u56db",
                "5": "\u4e94",
                "6": "\u516d"
            };
            if (/(y+)/.test(fmt)) {
                fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            }
            if (/(E+)/.test(fmt)) {
                fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "\u661f\u671f" : "\u5468") : "") + week[this.getDay() + ""]);
            }
            for (var k in o) {
                if (new RegExp("(" + k + ")").test(fmt)) {
                    fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
                }
            }
            return fmt;
        }   



    </script>
</asp:Content>
