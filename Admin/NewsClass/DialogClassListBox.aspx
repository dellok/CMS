<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="DialogClassListBox.aspx.cs" Inherits="Category_DialogClassListBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <style>
         body{padding;0px;}
     div{margin:0px;padding;0px;}
     p{margin:0px;padding;0px;}
     .newsclasslistbox{border:2px none #EDEFEF;}
    .divSelect{width:760px;height:290px;overflow-x:scroll;border:2px groove #EDEFEF;}
     select{margin:2px 3px;float:left;height:255px;width:190px;border:1px none #00ccff;}
</style>
    <div style="width: 760px; margin: 0px auto;float:left; padding: 0px; background: #ffffff;">
        <div class="div_nav_title2" style="margin: 0px; width: 760px; padding-left: 5px;">
            位置： 选择新闻分类
        </div>
        <p>
            <span>温馨提示: 请核对发布的产品是否符合 为保证您完整输入信息，请不要使用</span> 浏览器的<span> 刷新</span> 和<span> 后退</span>。
        </p>
        <div class="divSelect">
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:ListBox ID="lstboxClass_0" runat="server" CssClass="newsclasslistbox" Rows="15" Width="255px"
                            TabIndex="0" ToolTip="0" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_1" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="1" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_2" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="2" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_3" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="3" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                   <%-- <td>
                        <asp:ListBox ID="lstboxClass_4" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="4" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_5" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="5" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_6" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="6" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_7" runat="server" Rows="15"  Width="255px" CssClass="newsclasslistbox"
                            ToolTip="7" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_8" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="8" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_9" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="9" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_10" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="10" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="lstboxClass_11" runat="server" Rows="15" Width="255px" CssClass="newsclasslistbox"
                            ToolTip="11" AutoPostBack="True" OnSelectedIndexChanged="lstboxClass_SelectedIndexChanged">
                        </asp:ListBox>
                    </td>--%>
                </tr>
            </table>
        </div>
        <p>
            <span class="span_search_label">当前选择的新闻分类:</span>
            <asp:Label ID="lblCurrentClassName" runat="server"></asp:Label>
            <asp:HiddenField ID="hideCurrentClassID" runat="server" />
            <asp:HiddenField ID="hideIsHaveSonNode" runat="server" />
        </p>
        <p>
            <input type="button" value="【确定选择】" onclick="setSelectedClass()" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="【关闭窗口】" onclick="parent.$.modal.close();" />
        </p>
    </div>
    <script type="text/javascript" language="javascript">
        function setSelectedClass() {
            var sClassID = $('#<%=hideCurrentClassID.ClientID%>').val();
            var sClassPath = $('#<%=lblCurrentClassName.ClientID%>').html();
            var sIsHaveSonNode = $('#<%=hideIsHaveSonNode.ClientID%>').val();


            if (parseInt(sIsHaveSonNode) > 0) {


                alert("不是最终的分类！");
                return false;

            }

            parent.$(lblClassID).val(sClassID);
            parent.$(pHideClassID).val(sClassID);

            parent.$(lblClassPath).html(sClassPath);

            parent.$.modal.close();
        }
    </script>
</asp:Content>
