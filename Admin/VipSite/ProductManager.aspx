<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" 
    CodeFile="ProductManager.aspx.cs" Inherits="ProductManager" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <script type="text/javascript">

        //公司名称简介
        var txtNewstext = "#<%=txtNewstext.ClientID%>";


        //验证码:
        //验证码:
        //var txtCheckCode = "#txtCheckCode.ClientID%>";
        //var checkcodeTip = "#<txtCheckCode.ClientID%>Tip";

        function CheckCodeNum() {
            var url = "/ashx/checkcode.ashx?cd=" + $(txtCheckCode).val() + "&r=" + Math.random();
            var tipID = checkcodeTip;
            if ($.trim($(txtCheckCode).val()).length < 4) {
                $(tipID).attr("class", "onError");
                $(tipID).html("请输入4个字符的验证码!");
                return false;
            }
            $.get(url, function (data) {
                if (data == "true") {
                    $(tipID).attr("class", "oncorrect");
                    $(tipID).html("验证通过");
                    return true;
                }
                else {
                    $(tipID).attr("class", "onError");
                    $(tipID).html("验证码不正确定，请重新输入!");
                    return false;
                }
            });
        }


        $(document).ready(function () {
            $.formValidator.initConfig({onerror:function(){alert("校验没有通过，具体错误请看错误提示")}});
            //  $.formValidator.initConfig({ formid: "frm", onerror: function (msg) { alert(msg) }, onsuccess: function () { return true; } });

            //  $(txtTitle).formValidator({ onshow: "请输入信息标题", onfocus: "请输入信息标题", oncorrect: "输入正确" }).inputValidator({ min: 5, max: 100, onerror: "信息标题不能为空，并且长度在5-100字!" });

            $(txtNewstext).formValidator({ onshow: "请输入信息内容", onfocus: "请输入请输入信息内容", oncorrect: "输入正确" }).inputValidator({ min: 1, max: 2000, onerror: "信息内容不能为空！输入字符在1-10000之内!" });
            // $(txtCheckCode).formValidator({ onshow: "请输入正确定的验证码", onfocus: "主输入验证码", oncorrect: "谢谢你的合作，你的验证号码正确" }).inputValidator({ min: 4, max: 4, onerror: "请输入4个字符的验证码!" });

        });
    </script>
  
                <table border="0" align="center" cellpadding="0" cellspacing="1" class="tb_info">
                    <tr style="background: #EEEEEE;">
                        <th>
                            公司产品</th>
                    </tr>
                </table>
                <table align="center" cellpadding="3" cellspacing="1" class="tb_info">
                
                    <tr>
                        <td class="left" style="width: 79px; height: 32px;">
                            产品标题：
                        </td>
                        <td colspan="2" class="right" style="height: 32px">
                            <asp:TextBox ID="txtTitle" runat="server"  Width="800px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left" style="width: 79px">
                            标题图片：
                        </td>
                        <td colspan="2" class="right">
                            <asp:TextBox ID="txtTitlePic" runat="server"  Width="800px"></asp:TextBox>
                        </td>
                    </tr>
               
       <tr>  
                <td class="left" style="width: 79px" >
                        <b>内容：</b>  
                    </td>
                    <td colspan="2" class="right">
                    <asp:CheckBox  ID="cboxChecked" runat="server" Text="审核" Checked="true"/>
                    
                     
                        <b style="margin-left:30px;">新闻时间：</b>  
                       <asp:TextBox ID="txtPostTime" runat="server" Width="150px" 
                            CssClass="calendarFocus" ClientIDMode="Static" Height="19px"></asp:TextBox><img
                    alt="单击选择时间" src="../Images/date.gif" class="calendarFocus" onclick="javascript:$('#txtPostTime').focus()" />
                <span class="span_info_alert">(默认为当前时间)</span>
                    
                    
                    
                    </td>
           </tr>



        <tr>
            <td colspan="3">
                <FCKeditorV2:FCKeditor ID="txtNewstext" runat="server" Debug="false" Height="600"
                    Width="100%" StartupFocus="false">
                </FCKeditorV2:FCKeditor>
                <div id="<%=txtNewstext.ClientID%>Tip" class="divVTip">
                </div>
            </td>
        </tr>
        <tr>
            <td bgcolor='ffffff' colspan="3">
            </td>
        </tr>
        <%--              <tr>
                            <td class="left" style="width: 79px">
                                验证码：
                            </td>
                            <td class="right" style="width: 268px">
                                <asp:TextBox ID="txtCheckCode" runat="server" MaxLength="6" 
                                    onblur="CheckCodeNum()"  class="txtcheckcode"/>
                                <img id="Img1" src="/CheckCode/Index.aspx" alt="验证码" runat="server" class="imgCheckCode"
                                    onclick="refreshImg(this.id)" />
                                *
                            </td>
                            <td class="tdTip" >
                                <div id="<%=txtCheckCode.ClientID%>Tip" class="divVTip">
                                </div>
                            </td>
                        </tr>--%>
        <tr>
            <td colspan="3" class="txtcenter">
 <asp:Button  ID="btnAdd" Text="【提 交】" runat="server" CssClass="btn_2k3" 
                    OnClick=" btnEdit_Click" Width="66px" />&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button  ID="btnClear" Text="【清 空】" runat="server" CssClass="btn_2k3" 
                    OnClick="btnClear_Click" Width="66px" />&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Button  ID="btnAdd2" Text="【继续添产品】" runat="server" CssClass="btn_2k3" 
                    onclick="btnAdd2_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Button  ID="btnReturnNewsList" Text="【返回-公司产品-列表】" runat="server" CssClass="btn_2k3" onclick="btnReturnNewsList_Click" 
                   />&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;
 
                  
                <asp:HiddenField ID="hideID" runat="server" />
            </td>
        </tr>
    </table>

  
  
</asp:Content>
