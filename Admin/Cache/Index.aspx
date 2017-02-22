<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="Index.aspx.cs" Inherits="Cache_Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">
    <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="index.aspx">缓存管理</a>>刷新数据</span></div>
    <div class="div_search">
        <div class="th_grid_title txtmiddle font_b  ">
            &nbsp;请选择频道<font class="font_red font_size_12">(没有选择项默认为执行全部频道)</font></div>
        <div class="div_search_row">
            <span class="span_search_label">频&nbsp; 道&nbsp; /&nbsp; 栏&nbsp; 目：</span> <span class="span_search_element">
                <%=strPinDao.ToString()%>
                <input type="checkbox" class="cboxPinDaoAll" id="cboxAllPinDao" name="" value=""  
                    onclick="AllChange(this.checked)" /><b class="green">全部频道</b></span>

                      <div class="div_search_row">  <input type="button" value="刷新所选【频道首页】" class="btn_2k3 margin_left_20 font_blue" id="btnCreateItemIndexHtml"
onclick="return btnCreateItemIndexHtml_onclick()"  /></div>
            </div>
    </div>
    <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_row div_search">
            <td valign="top" class="td_grid_col txtleft">
                <div class="th_grid_title txtleft font_b">
                    广告缓存与频道首布缓存</div>
                <input type="button" value="刷新【网站首页】" class="btn_2k3 margin_left_20 font_red" id="btnCreateWebSiteIndexHtml"
                    onclick="btnCreateWebSiteIndexHtml_onclick()" />
                <input type="button" value="刷新所选【频道广告】" class="btn_2k3 margin_left_20 font_green" id="btnCreateADJs"
                    onclick="btnCreateADJs_onclick()" />
                &nbsp;
                       <br/>
                       &nbsp;
                  </td>
        </tr>
        <tr class="tr_grid_row txtleft div_search">
            <td class="td_grid_col">
                <div class="th_grid_title txtmiddle font_b">
                    生成频道信息内容页</div>
                <div class="div_search">
                     <div class="div_search_row">

                         <span class="span_search_label">信 息&nbsp;数&nbsp;据 库 ：</span>
                          <span class="span_search_element"> 
                          
                           
                           
                          <input  type="checkbox"  class="cboxTable"   id="cboxGsk"  name="公司库" value="gsk"   />公司库表
                            <input  type="checkbox"  class="cboxTable"  id="cboxNews" name="公司库" value="news"   />新闻表
                
                          </span>
                    </div>
                    <div class="div_search_row">

                        <span class="span_search_label">详 细&nbsp;页&nbsp;时 间 ：</span> <span class="span_search_element">
                            <asp:TextBox ID="txtSDate" runat="server" Width="100px" CssClass="calendarFocus"
                                ClientIDMode="Static"></asp:TextBox><img alt="单击选择时间" src="../Images/date.gif" class="calendarFocus"
                                    onclick="javascript:$('#<%=txtSDate.ClientID %>').focus()" />&nbsp; 到
                            <asp:TextBox ID="txtEDate" runat="server" Width="100px" CssClass="calendarFocus"
                                ClientIDMode="Static"></asp:TextBox><img alt="单击选择时间" src="../Images/date.gif" class="calendarFocus"
                                    onclick="javascript:$('#<%=txtEDate.ClientID %>').focus()" />
                        </span><span class="font_red b">(不填写,默认为当天时间)</span>
                    </div>
                    <div class="div_search_row">
                        <span class="span_search_label">每页执行记录数：</span> <span class="span_search_element">
                            <input id="txtPageSize" type="text" value="500" /><span class="font_red b">(最大不要超过3000)</span>
                        </span>
                    </div>
                    <div class="div_search_row">
                        <span class="span_search_label">生 成 过 H t m l：</span> <span class="span_search_element">
                            <input type="radio" name="radioHaveHtml"  value="0" />只生成未生成过Html的信息页
                            <input type="radio" name="radioHaveHtml" value="-1" checked="checked" />全部(生成过与未生成)信息页 </span>
                        &nbsp;&nbsp;</div>
                    <div class="div_search_row">
                        <span class="span_search_label">信息 审 核 状 态：</span> <span class="span_search_element">
                            <input type="radio" name="radioCheck" value="1" />只生成审核过的信息
                            <input type="radio" name="radioCheck" value="0" />只生成未审核过的信息
                            <input type="radio" name="radioCheck" value="-1" checked="checked" />全部(审核与未审核)状态 </span>&nbsp;&nbsp;</div>
                    <input id="btnExe" type="button" class="btn_2k3" value="生成【频道信息内容页】" onclick="btnCreateHtml_onclick()" onclick="return btnExe_onclick()" onclick="return btnExe_onclick()" />
                </div>
            </td>
        </tr>
    </table>

       <script type="text/javascript" language="javascript">

           var MainDomin = "<%=LL.Common.Cache.ConfigManager.MainDomain%>";
           var frmPrefix = "frm";
           var cboxPinDaoClass = "cboxPinDao";
           var cboxTypeClass = "cboxType";
           var cboxAllPinDao = "cboxAllPinDao";
        var   cboxTableClass = "cboxTable"

           var arrAllPinDao = new Array();
           var arrCheckedPinDao = new Array();

           var arrType = new Array();

           var sDate = "";
           var eDate = "";
           var PageSize = 100;
           var HaveHtml = 0;
           var PageChecked = 1;

           function InitInputValue() {
               sDate = $("#txtSDate").val();
               eDate = $("#txtEDate").val();


               PageSize = $("#txtPageSize").val();
               HaveHtml = GetRadioValue("radioHaveHtml");
               PageChecked = GetRadioValue("radioCheck");

               GetSelectedTable();

           }

           function GetSelectedTable() {

               arrCheckedPinDao.length = 0;
               var cbox = $("." + cboxPinDaoClass);
               for (var i = 0; i < cbox.length; i++) {
                   if (cbox[i].checked) {
                       arrCheckedPinDao.push({ "Name": cbox[i].name, "Value": cbox[i].value });

                   }
               }
               return arrCheckedPinDao;
           }
           function GetSelectedPinDao() {

               arrCheckedPinDao.length = 0;
               var cbox = $("." + cboxTableClass);
               for (var i = 0; i < cbox.length; i++) {
                   if (cbox[i].checked) {
                       arrCheckedPinDao.push({ "Name": cbox[i].name, "Value": cbox[i].value });

                   }
               }
               return arrCheckedPinDao;
           }
           function SetAllPinDaoArray() {
               var cbox = $("." + cboxPinDaoClass);
               for (var i = 0; i < cbox.length; i++) {
                   arrAllPinDao.push({ "Name": cbox[i].name, "Value": cbox[i].value });
               }

           }


           function GetRadioValue(rName) {

               var rs = document.getElementsByName(rName);
               var v = "";
               for (var i = 0; i < rs.length; i++) {
                   if (rs[i].type == "radio") {
                       if (rs[i].checked) {

                           v = rs[i].value;
                           break;
                       }
                   }
               }
               return v;
           }

           //得到要进行操作的频道
           function GetCheckedDirs(type) {
               GetSelectedPinDao();
               var dirs = "";
               if ($("#" + cboxAllPinDao).attr("checked")) {
                   for (var i = 0; i < arrAllPinDao.length; i++) {


                       switch (type) {
                           case 1:
                               dirs += arrAllPinDao[i].Name + ",";
                               break;
                           case 2:
                               dirs +=   encodeURI(arrAllPinDao[i].Value) + ",";
                               break;

                           default:

                               dirs += arrAllPinDao[i].Name + "-" + arrAllPinDao[i].Value + ",";
                       }



                   }
               }
               else {
                   for (var i = 0; i < arrCheckedPinDao.length; i++) {
                       switch (type) {
                           case 1:
                               dirs += arrCheckedPinDao[i].Name + ",";
                               break;
                           case 2:
                               dirs += arrCheckedPinDao[i].Value + ",";
                               break;

                           default:

                               dirs += arrCheckedPinDao[i].Name + "-" + arrCheckedPinDao[i].Value + ",";
                       }

                   }
               }
               alert(dirs);
               return dirs;
           }







           //===========生成新闻内容页
           function btnCreateHtml_onclick() {

               InitInputValue();
               var tableName = "";
               if ($("#cboxGsk").attr("checked")) { tableName += ",公司库-gsk"; }
               if ($("#cboxNews").attr("checked")) { tableName += ",新闻库-news"; }
               if (tableName.length < 1) {
                   alert("请选择要生成详细 的 【信息数据库】!");
                   return false;
               }
               else {
                   CreateDetailHtml(tableName);
               }
             
           }
           function CreateDetailHtml(tableName) {
               //得到要生成静态的数据表
              ;
               var url = "CreateDetailHtml.aspx?tbName=" + encodeURI(tableName) + "&sdate=" + sDate + "&edate=" + eDate + "&havehtml=" + HaveHtml + "&checked=" + PageChecked + "&PageSize=" + PageSize;
               window.location = url;
           }
           //=============================================
           function CreateADHtml(arrPinDao) {
               var pam = "<%=LL.Common.PubConstant.Key_ADPage%>";
               var url = "ad.aspx?" + pam + "=" + encodeURI(arrPinDao.toLocaleString());
               $("#frmAD").attr("src", "/images/progressbar_green.gif");
               $("#frmAD").attr("src", url);
           }

           function AllChange(ched) {
               var cbox = $("." + cboxPinDaoClass);
               for (var i = 0; i < cbox.length; i++) {
                   cbox[i].checked = ched;
               }
           }
           //网站首页静态
           function btnCreateWebSiteIndexHtml_onclick() {

               var url = "CreateIndexHtml.aspx";
               window.location = url;
           }
           //网频道广告js
           function btnCreateADJs_onclick() {

               var dirs = encodeURI(GetCheckedDirs(1));

               var url = "ad.aspx?adpage=" + dirs;
               window.location = url;
           }
           //所选频道首页
           function btnCreateItemIndexHtml_onclick() {
               var dirs = encodeURI(GetCheckedDirs());
               var url = "CreateIndexHtml.aspx?dirs=" + dirs;
               window.location = url;
           }
           function CreateListHtml() {
               $("#divIndex").html("");
               for (var i = 0; i < arrCheckedPinDao.length; i++) {
                   var url = arrCheckedPinDao[i];
                   var msg = $("#divIndex").html();
                   var itemName = arrPinDaoName[i];
                   $("#divIndex").html(msg + "<br>" + "正在进行【" + itemName + "频道】首页静态化...");
                   $.get(url, { "CreateHtml": true }, function (data) {
                       $("#divIndex").html(msg + "<br>" + "静态化【" + itemName + "频道】," + data + "...");
                   }
                );
               }

           }


           //生成站点地图

           function btnCreateSiteMap_onclick(spider) {




               if (arrCheckedPinDao.length > 1) {
                   alert("每次只能选择一个栏目建立站点地图");

               }
               //只取value值
               var dirs = encodeURI(GetCheckedDirs(2));


               if (spider == -1) {

                   dirs = "subdomain";
                   spider = "";
               }

               var url = "CreateSiteMap.aspx?dirs=" + dirs + "&spider=" + spider;

               window.location = url;

           }
           function btnCreateSiteMapIndex_onclick() {
               var url = "CreateSiteMap.aspx";
               window.location = url;

           }
           //=============================================================================
           $(document).ready(function () {
               SetAllPinDaoArray();
           });








function btnExe_onclick() {

}

       </script>
</asp:Content>

