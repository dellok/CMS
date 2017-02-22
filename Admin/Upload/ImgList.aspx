<%@ Page Language="C#"  CodeFile="ImgList.aspx.cs" Inherits="ImgList" AutoEventWireup="true"
    MasterPageFile="~/Admin.master" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<asp:Content ID="picList" ContentPlaceHolderID="adminmaster" runat="server">

    <div class="div_nav_title2">
        <span>位置： 管理信息 > 图片管理</span>
    </div>
    <div class="div_search">
        <div class="div_search_row">
            <span class="span_search_label">附件类别：</span> <span class="span_search_element">
                <asp:RadioButtonList ID="radioFileInfoType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:RadioButtonList>
            </span>
        </div>
        <div class="div_search_row">
            <asp:Button ID="btnSearch" runat="server" Text=" 查 询 " CssClass="btn" OnClick="btnSearch_Click"
                Width="100px" />
            &nbsp;&nbsp;
            <input type="button" value=" 上 传 文 件 " class="btn" onclick="javascript:document.getElementById('divUpload').style.display='';" />
        </div>
        <div id="divUpload" style="display: none; border-bottom: 2px solid #538B2A; width: 900;">
            <span class="span_search_label">上传附件：</span>
            <asp:FileUpload ID="up" runat="server"  />
            &nbsp;&nbsp;<asp:Button ID="btnUpload" runat="server" Text=" 上 传 " CssClass="btn"
                 OnClick="btnUpload_Click" />
            <br />
        </div>
        <asp:Label ID="lblUpPath" runat="server"></asp:Label>
    </div>
    <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_title">
            <th class="th_grid_title textcenter">
                <input  id="cboxAll2"  type="checkbox" name="cboxAll" />
            </th>
            <th class="th_grid_title  textleft">
                ID
            </th>
            <th class="th_grid_title  textleft">
                附件信息
            </th>
            <th class="th_grid_title  textleft">
                添加者
            </th>
            <th class="th_grid_title  textleft">
                文件大小(KB)
            </th>
            <th class="th_grid_title  textleft">
                添加时间
            </th>
        </tr>
        <asp:ListView ID="dataViewList" runat="server" DataKeyNames="ID" ItemPlaceholderID="itemList"
            OnItemDeleting="dataViewList_ItemDeleting">
            <LayoutTemplate>
                <div class="div_piclist">
                    <asp:PlaceHolder ID="itemList" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class="tr_grid_row">
                    <td class="td_grid_col w80">
                        <asp:CheckBox ID="cboxItem" ClientIDMode="Static" ToolTip='<%#Eval("id")%>' runat="server" />
                    </td>
                    <td class="td_grid_col w300 textleft">
                        <p>
                            <span class="span_search_label">ID:</span>
                            <%#Eval("id")%></p>
                        <p>
                            <span class="span_search_label">路径:</span><a href='<%#string.Format("{0}{1}{2}", LL.Common.Cache.ConfigManager.ImgDomin, Eval("Path"),Eval("FileName"))%>'
                                target="_blank"><%#string.Format("{0}{1}{2}", LL.Common.Cache.ConfigManager.ImgDomin, Eval("Path"),Eval("FileName"))%></a><p>
                                <span class="span_search_label">操作:</span>
                                <input type="button" class="btn_2k3" name="btnyy" value="添加引用" style="color: Green;"
                                    onclick="returnImgUrl('<%#string.Format("{0}{1}{2}", LL.Common.Cache.ConfigManager.ImgDomin, Eval("Path"),Eval("FileName"))%>')" />
                                <asp:Button ID="btnDel" runat="server" CommandName="Delete" Text="删 除" class="btn_2k3"
                                    Style="margin-left: 20px; color: Red;" OnClientClick="return  confirm('确信要删除此记录?，\n删除后图片将移置图片回收站中!')" />
                            </p>
                    </td>
                    <td class="td_grid_col   w300  textleft">
                        <%#BindFile(Eval("Path"),Eval("FileName"),Eval("FileClass")) %>
                    </td>
                    <td class="td_grid_col  w100">
                        <%#Eval("UploadUser")%>
                    </td>
                    <td class="td_grid_col  w100">
                        <%#Eval("FileSize")%>
                    </td>
                    <td class="td_grid_col  ">
                        <%#Eval("InDate")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <tr class="tr_grid_row">
            <td class="td_grid_col  textcenter">
               <input  id="Checkbox1"  type="checkbox" name="cboxAll" />
            </td>
            <td colspan="5" align="left" valign="middle">
                <p class="div_search_row" style="height: 30px;">
                    <asp:Button ID="btnBatchDelete" runat="server" Text="批量删除" CssClass="btn_2k3" OnClientClick="return  confirm('确信要进行批量删除吗?，\n删除后图片将移置图片回收站中!')"
                        OnClick="btnBatchDelete_Click" />&nbsp;&nbsp;
                </p>
            </td>
        </tr>
    </table>
    <webdiyer:AspNetPager ID="pager" runat="server" CssClass="manu " PageSize="15" ShowCustomInfoSection="Left"
        Width="100%" CustomInfoStyle="width:20%;" AlwaysShowFirstLastPageNumber="true"
        PageIndexBoxStyle="width:24px" OnPageChanged="pager_PageChanged" PrevPageText="&lt;上一页"
        NextPageText="下一页&gt;" CustomInfoHTML="<span>共<span>%RecordCount%</span>条记录</span>，<span>%PageCount%页</span>，<span>每页%PageSize%条</span>">
    </webdiyer:AspNetPager>
    &nbsp;<script type="text/javascript" language="javascript">

              var param = document.location.search;
              var reTxtID = "reTxtID";
              var reTxtIDV = "";
              var btnName = "btnyy";
              var disabled = '<%=Request["disabled"]%>';
              function InitParam() {
                  param = param.replace("?", "").split("&")
                  for (var i = 0; i < param.length; i++) {
                      var tempStr = param[i];
                      if (tempStr.indexOf(reTxtID) >= 0) {
                          reTxtIDV = tempStr.replace(reTxtID, "").replace("=", "");
                          break;
                      }
                  }

                  var btns = document.getElementsByName(btnName);
                  if (disabled == "disabled") {

                      for (var i = 0; i < btns.length; i++) {

                          btns[i].disabled = true;


                      }
                  }


              }
              function returnImgUrl(imgUrl) {
                  if (window.opener.document.getElementById(reTxtIDV) != null) {
                      window.opener.document.getElementById(reTxtIDV).value = imgUrl;
                      window.close();
                  }
                  else {

                      alert("此功能不可用");

                  }

              }
              document.onload = InitParam();
    </script>
</asp:Content>
