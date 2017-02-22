<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Job.aspx.cs" Inherits="VipWebSite_Job" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">



    <table border="0" align="center" cellpadding="0" cellspacing="1"  class="tb_info" >
                    <tr style="background: #EEEEEE;">
                        <th  >
                            企业招聘
                            </th>
                    </tr>
                </table>
                
                         
       <table align="center" cellpadding="3" cellspacing="1"  class="tb_info">
          <tr>
          <td style="height: 19px; width: 136px;"  class="td_left">招聘标题:</td><td  colspan="2"  class="td_left">
         <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
           <td colspan="3" class="td_left">招聘内容:</td>
          </tr>
                    <tr>
                        <td   colspan="3">
                
                            <FCKeditorV2:FCKeditor ID="txtNewstext" runat="server" Debug="false" Height="500"
                                Width="100%" StartupFocus="false"></FCKeditorV2:FCKeditor>
                             <div id="<%=txtNewstext.ClientID%>Tip" class="divVTip">
                            </div>
                        </td>
                 
                    </tr>
                        <tr>
                   
                        <td bgcolor='ffffff' colspan="3">
                           
                        </td>
                    </tr>
           <%--                  <tr>
                            <td  class="td_left" style="width: 136px">
                                验证码：
                            </td>
                            <td class="tdInput">
                                <asp:TextBox ID="txtCheckCode" runat="server" MaxLength="4" onblur="CheckCodeNum()"  class="txtcheckcode"/>
                                <img id="Img1" src="/CheckCode/Index.aspx" alt="验证码" runat="server" class="imgCheckCode"
                                    onclick="refreshImg(this.id)" />
                                *
                            </td>
                            <td class="tdTip">
                                <div id="<%=txtCheckCode.ClientID%>Tip" class="divVTip">
                                </div>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="3">

                                <asp:Button type="submit" ID="btnAdd" Text="提交" runat="server" CssClass="btn_2k3"
                            
                                    OnClick="btnEdit_Click" Width="99px" />
                                <asp:HiddenField ID="hideID" runat="server" />
                            </td>
                        </tr>
                </table>

</asp:Content>

