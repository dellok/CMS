<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="ExtMember.aspx.cs" Inherits="Member_ExtMember"  %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">

 <div class="div_nav_title2 div_search_row">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="MemberList.aspx">会员列表</a> > 会员数据下载</span></div>
    <div class="div_search">
        <span class="span_search_label">要显示的项：
       
        </span>
        </div>
        
         <div class="div_search_row">
     
        <asp:CheckBoxList ID="cboxMemberField" runat="server"   RepeatDirection="Horizontal"  RepeatLayout="Table"  RepeatColumns="14" >
                    
                    <asp:ListItem value="l.userid"   Selected="True" Text="用户ID"   Enabled="false" />
                    <asp:ListItem value="l.username"   Selected="True" Text="用户名"  />
                    <asp:ListItem Value="g.groupname" Selected="True"    Text="会员级别" Enabled="false"></asp:ListItem>
                    <asp:ListItem Value="l.registertime" Selected="True"    Text="注册时间"></asp:ListItem>
                     
                      <asp:ListItem value="m.company"  Selected="True" Text="公司名称"/>
                      <asp:ListItem value="m.truename"  Selected="True" Text="真实姓名"  />
                       <asp:ListItem value="m.duty"  Selected="True" Text="部门及职务"  />
                         <asp:ListItem value="m.phone" Selected="True"  Text="手机"/>
                    <asp:ListItem value="m.call" Selected="True" Text="联系电话"/>
                    <asp:ListItem value="m.fax"  Selected="True" Text="传真"/>
                    <asp:ListItem value="l.email" Selected="True" Text="邮箱"  />
                      <asp:ListItem value="m.homepage"  Selected="True"  Text="网站地址"/>
                         <asp:ListItem value="m.oicq"  Selected="True" Text="QQ号码"/>
                    
                    <asp:ListItem value="m.address"   Selected="True" Text="联系地址"/>

             
                     
                      <asp:ListItem value="m.city"   Text="公司所在地"/>
                    <asp:ListItem value="m.sex"   Text="性别"  />
                   
                    
                     <asp:ListItem value="m.leixing"   Text="公司类型"/>
                    <asp:ListItem value="m.city"   Text="公司所在地"/>
                    <asp:ListItem value="m.address"   Text="联系地址"/>
                    <asp:ListItem value="m.zip"   Text="邮编"/>
                    <asp:ListItem value="m.industry"   Text="主营行业"/>
                    <asp:ListItem value="m.products"  Text="主营方向"/>
                    <asp:ListItem value="m.products"  Text="主营产品"/>
                    <asp:ListItem value="m.msn"  Text="MSN"/>
                  
              
                    
                    </asp:CheckBoxList>






         
                
           
    </div>

         <div class="div_search_row">

          <span class="span_search_label">时间周期：</span>
         <asp:RadioButtonList ID="rdDate" runat="server"     RepeatDirection="Horizontal"  RepeatLayout="Flow">
         
           <asp:ListItem Text="前一月" Value="1"></asp:ListItem>
         <asp:ListItem Text="前三天(不包括当天)" Value="2"></asp:ListItem>
         <asp:ListItem Text="前天(不包括当天)" Value="3"></asp:ListItem>
         <asp:ListItem Text="当天" Value="4" Selected="True"></asp:ListItem>
         <asp:ListItem Text="本周" Value="5"></asp:ListItem>
          <asp:ListItem Text="本月" Value="6"></asp:ListItem>
         
         </asp:RadioButtonList>
         <%--  <span class="span_search_element">

            <asp:TextBox ID="txtSDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp;
                到
                <asp:TextBox ID="txtEDate" runat="server" Width="100px" CssClass="calendarFocus"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" />
            </span>(不填日期，默认为当天,最多只能导出本月任合时间的数据)--%>


    </div>

     <div class="div_search_row">
         <span class="span_search_label">是否审核：</span><span class="span_search_element">

          <asp:RadioButtonList ID="radMemberCheck" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
           
                     <asp:ListItem Text="不限" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="审核" Value="1"></asp:ListItem>
                        <asp:ListItem Text="未审核" Value="0"></asp:ListItem>

           </asp:RadioButtonList>
               
                </span>
                
                 <%-- <span class="span_search_label">每次Excel记录数：</span>
                  <span class="span_search_element">
                       
                  <asp:TextBox ID="txtPageSize" runat="server" Text="1000"></asp:TextBox>
                        &nbsp;
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
             BackColor="White" BorderStyle="Solid" BorderWidth="0px" 
             ControlToValidate="txtPageSize" Display="Dynamic" ErrorMessage="请输入数字!" 
             Font-Bold="True" ForeColor="#CC3300" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </span>--%>
                    <asp:Button ID="btnExtExcel" runat="server" Text="下载会员数据"    Width="120px" CssClass="btn " ForeColor="Green" Font-Bold="true"
                        Height="22px" onclick="btnExtExcel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
    
    
    </div>

 

    
       

         <div class="div_search_row" style="margin:0px auto;">
        

        <asp:Literal ID="lblBtns" runat="server"></asp:Literal>
       

    </div>
         


       <script>
           function extMember(pageindex) {



               var url = "DownMemberXLS.aspx?PageIndex=" + pageindex + "&PageSize=" + pagesize + "&fields=" + fields + "&sdate" + sdate + "&edate" + edate;

               window.open(url, "_blank","width:200px;height:100px;");
           
           }
       
       </script>
</asp:Content>
