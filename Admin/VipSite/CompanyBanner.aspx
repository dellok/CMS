<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true"
    CodeFile="CompanyBanner.aspx.cs" Inherits="Member_VipWebSite_CompanyBanner"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">


                 
                <table border="0" align="center" cellpadding="0" cellspacing="1"  class="tb_info" >
                    <tr style="background: #EEEEEE;">
                        <th  >
                            公司Banner
                        </th>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="25" style="background: #EEEEEE">
                            <span class="STYLE9">&nbsp;&nbsp; &nbsp;&nbsp;温馨提示</span>：上传图片大小&lt;512Kb,公司Banner!如果上传新Banner则装替换原来的!
                        </td>
                    </tr>
                </table>
                <table  style="width:100%">
                 
                    <tr>
                     <td colspan="2">

                              
                     <asp:Literal ID="imgEdit" runat="server"></asp:Literal>

                     </td>
                    </tr>
                    <tr>
                        <td class="w80" >
                            <b>上传文件：</b>
                        </td>
                        <td class="right">
                            <asp:FileUpload ID="up" runat="server"  />
                            <asp:Button ID="btnModeif" runat="server" Text="上传" OnClick="btnModeif_Click"  
                                CssClass="btn_2k3" style="margin-left:50px; height: 21px;" Width="90px" />
                            <br />
                        </td>
                    </tr>
                </table>
      
    <asp:HiddenField  ID="hideID" runat="server"/>
</asp:Content>
