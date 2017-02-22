<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Conact.aspx.cs" Inherits="Conact" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">



    <table border="0" align="center" cellpadding="0" cellspacing="1"  class="tb_info" >
                    <tr style="background: #EEEEEE;">
                        <th  ><h3>联系我们</h3>
                           
                            </th>
                    </tr>
                </table>
                
              <table align="center" cellpadding="3" cellspacing="1"  class="tb_info">
                                                <tbody>
                                            
                                                    <tr>
                                                        <td style="height:38px; text-align:left;">
                                                            地&nbsp;&nbsp;&nbsp;&nbsp;址 ：<asp:TextBox ID="txtAddress" runat="server" Width="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:38px; text-align:left;">
                                                            邮&nbsp;&nbsp;&nbsp;&nbsp;编 ：<asp:TextBox ID="txtZip" runat="server" Width="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:38px; text-align:left;">
                                                            电&nbsp;&nbsp;&nbsp;&nbsp;话 ：<asp:TextBox ID="txtCall" runat="server" Width="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:38px; text-align:left;">
                                                            传&nbsp;&nbsp;&nbsp;&nbsp;真 ：<asp:TextBox ID="txtFax" runat="server" Width="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:38px; text-align:left;">
                                                            网站地址 ：<asp:TextBox ID="txtWebSite" runat="server" Width="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:38px; text-align:left;">
                                                            邮件地址 ：<asp:TextBox ID="txtEmail" runat="server" Width="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                      <tr>
                                                        <td style="height:38px; text-align:center;">
                                                      
                                                      <asp:Button  ID="btnSubmit" runat="server"  Text="【 提    交 】" 
                                                                onclick="btnSubmit_Click" Height="25px"/>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>                
       

</asp:Content>

