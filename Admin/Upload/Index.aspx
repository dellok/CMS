<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="Index.aspx.cs" Inherits="Upload_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
<style>
    .tb_grid  tr{height:50px;}
</style>
    <div class="div_nav_title2">
        <span>位置： 管理信息 > 批量上传附件</span>
    </div>
    <div class="div_search" style="clear: both">
        <div class="div_search_row">
            <span class="span_search_label">上传信息栏目：</span>
            <asp:RadioButtonList ID="radioFileInfoType" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow">
            </asp:RadioButtonList>
        </div>
<%-- <div class="div_search_row">
            <span class="span_search_label">上传附件类别：</span> <span class="span_search_element">
                <asp:RadioButtonList ID="radioFileType" runat="server" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                </asp:RadioButtonList>
            </span>
        </div>--%>
    </div>
    <table class="tb_grid" cellspacing="1" cellpadding="0">
        <tr class="tr_grid_title" style="height:30px;">
            <th class="th_grid_title ">
                序列
            </th>
            <th class="th_grid_title textleft" style="padding-left:50px;">
                 上传组件
            </th>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>1</b>
            </td>
            <td class="td_grid_col  textleft">
              
                    <div id="div0"> <asp:FileUpload ID="FileUpload0" runat="server" />
                        <div id="divm0">
                        </div>
                    </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>2</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div1">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <div id="divm1">
                    </div>
                </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>3</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div2">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <div id="divm2">
                    </div>
                </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>4</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div3">
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                    <div id="divm3">
                    </div>
                </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>5</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div4">
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                    <div id="divm4">
                    </div>
                </div>
            </td>
        </tr>
           <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>6</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div5">
                    <asp:FileUpload ID="FileUpload5" runat="server" />
                    <div id="divm5">
                    </div>
                </div>
            </td>
        </tr>
     <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>7</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div6">
                    <asp:FileUpload ID="FileUpload6" runat="server" />
                    <div id="divm6">
                    </div>
                </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>8</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div7">
                    <asp:FileUpload ID="FileUpload7" runat="server" />
                    <div id="divm7">
                    </div>
                </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>9</b>
            </td>
            <td class="td_grid_col  textleft">
                <div id="div8">
                    <asp:FileUpload ID="FileUpload8" runat="server" />
                    <div id="divm8">
                    </div>
                </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
            <td class="td_grid_col w100">
                <b>10</b>
            </td>
            <td class="td_grid_col textleft">
                <div id="div9">
                    <asp:FileUpload ID="FileUpload9" runat="server" />
                    <div id="divm9">
                    </div>
                </div>
            </td>
        </tr>
        <tr class="tr_grid_row">
       
            <td class="td_grid_col textleft " colspan="2">
              
                    <asp:Button ID="btnUpload" runat="server" CssClass="btn_2k3" Text=" 上 传 附 件 " Width="176px" style="margin-left:150px;"
                        OnClick="btnUpload_Click" />
             
                
            </td>
        </tr>
    </table>
</asp:Content>
