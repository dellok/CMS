<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="ClassEdit.aspx.cs" Inherits="ClassEdit" %>
<%@ Register Src="~/UserControl/TempDropDownList.ascx" TagName="TempList"  TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">
 <table cellspacing="1" class="tb_info">
                    <tr>
                        <th colspan="2" class="div_title" style="height: 30px;">
                            当前分类&nbsp;
                            <asp:Label ID="lblCurrentClassName0" runat="server" CssClass="font_red"></asp:Label>
                            &nbsp; 信息
                        </th>
                    </tr>
                    <tr>
                        <td class="left">
                            父分类ID：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtParenID" runat="server" Width="180px" ></asp:TextBox>
                            (修改父分类ID，则当前分类下所有子项都相应改变 )
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            父类名称：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtParentName" runat="server" Width="180px" Enabled="false"    BackColor="ActiveBorder"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            当前分类ID：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtID" runat="server" Width="180px" Enabled="false" BackColor="ActiveBorder"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            当前分类名称：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtCName" runat="server" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left" >
                            当前分类别名：
                        </td>
                        <td  class="right">
                            <asp:TextBox ID="txtOtherName" runat="server" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                <%--         <tr>
                        <td class="left" >
                            当前分类类型：
                        </td>
                        <td  class="right">
                            <asp:DropDownList ID="drplNewsClassType" runat="server" Height="16px" 
                                Width="174px"></asp:DropDownList>

                        </td>
                    </tr>--%>
                    <tr>
                        <td class="left">
                            栏目存放文件夹：
                        </td>
                        <td class="right">
                            根目录/
                            <asp:TextBox ID="txtDirectory" runat="server" Width="200px"></asp:TextBox>
                            <asp:Button ID="btnCheckDirectory" Text="检查目录" CssClass="btn3_mouseover" 
                                runat="server" onclick="btnCheckDirectory_Click" ValidationGroup="add" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtDirectory" ErrorMessage="目录名称不能为空!" ForeColor="Red" 
                                ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr>
                        <td class="left">
                            所属新闻表名：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtTbName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left" >
                            列表页模板：
                        </td>
                        <td class="right" > <uc:TempList id="TempList1" runat="server"></uc:TempList>
                          <span class="left">封面模板</span><uc:TempList id="TempList2" runat="server"></uc:TempList>
                       
                        </td>
                    </tr>
                            <tr>
                        <td class="left" >
                            详细页模板：
                        </td>
                        <td class="right" > <uc:TempList id="TempList3" runat="server"></uc:TempList>
                          
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            描述：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtDescription" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            同级序列 ：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtOrder" runat="server" Width="200px"></asp:TextBox>
                            <asp:RegularExpressionValidator ValidationGroup="edit" ErrorMessage="请输入数字!" ControlToValidate="txtOrder"
                                ID="RegularExpressionValidator1" runat="server"  ForeColor="Red" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="left">
                            点击量 ：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtHit" runat="server" Width="198px"></asp:TextBox>        <asp:RegularExpressionValidator ValidationGroup="edit" ErrorMessage="请输入数字!" ControlToValidate="txtHit"
                                ID="RegularExpressionValidator2" runat="server"  ForeColor="Red" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                         
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td  colspan="2">
                               <asp:Label ID="lblParentNodeID" runat="server"></asp:Label>
                               <asp:Label ID="lblNodeID" runat="server"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 25px; font-size: 12px; text-align:center;">
                        <asp:Button
                                    ID="btnUpdate" runat="server" Text=" 修   改 " OnClick="btnUpdate_Click" Width="100px" CssClass="btn_2k3" ValidationGroup="edit">
                                </asp:Button>&nbsp;
                            <asp:Button ID="btnDelete" runat="server" Text=" 删   除 " CssClass="btn_2k3 font_red" Width="100px" 
                                OnClick="btnDelete_Click" OnClientClick="return  confirm('确定要删除?它的子项一同删除!');" Visible="false" />&nbsp;
                        </td>
                    </tr>
                </table>
           

                <table class="tb_info" cellspacing="1" style="margin-top:15px;">
                  <tr>
                        <th colspan="2" style="height: 26px" class="div_title">
                            在当前分类&nbsp;<asp:Label ID="lblCurrentClassName" runat="server" CssClass="font_red"></asp:Label>
                            下添加子分类
                        </th>
                    </tr>
                    <tr>
                        <td class="left">
                            分类名称 ：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtAddClassName" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="请输入分类名称" ControlToValidate="txtAddClassName" 
                                ValidationGroup="add" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            栏目别名：
                        </td>
                        <td class="right" style="height: 20px">
                            <asp:TextBox ID="txtAddClassAliasName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                        <td class="left">
                            所属新闻表名：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtAddTbName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            栏目存放文件夹 ：
                        </td>
                        <td class="right">
                            根目录/
                            <asp:TextBox ID="txtAddDirectoryInfo" runat="server" Width="154px"></asp:TextBox>
                            <asp:Button ID="Button3" Text="检查目录" CssClass="btn3_mouseover" runat="server" 
                                onclick="Button3_Click" ValidationGroup="edit" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtAddDirectoryInfo" ErrorMessage="目录名称不能为空!" 
                                ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                                    <tr>
                        <td class="left">
                            目录所属模板：
                        </td>
                        <td class="right">
                          

                      <uc:TempList id="temp2" runat="server"></uc:TempList>
                        </td>
                    </tr>

                    <tr>
                        <td class="left">
                            同级序列 ：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtAddOrder" runat="server" Width="200px"></asp:TextBox> <asp:RegularExpressionValidator ValidationGroup="add" ErrorMessage="请输入数字!" ControlToValidate="txtAddOrder"
                                ID="RegularExpressionValidator3" runat="server"  ForeColor="Red" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                         
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            简单描述 ：
                        </td>
                        <td class="right">
                            <asp:TextBox ID="txtAddDescription" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right" class="leftTD">
                            &nbsp;
                        </td>
                        <td class="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 25px; font-size: 12px;text-align:center;">
                            <asp:Button ID="btnAdd" runat="server" Text="添加栏目分类"  CssClass="btn_2k3" Width="145px"  ValidationGroup="add"
                                OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                </table>
</asp:Content>

