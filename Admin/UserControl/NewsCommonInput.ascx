<%@ Control Language="C#"  CodeFile="NewsCommonInput.ascx.cs"
    Inherits="UserControl_NewsCommonInput" %>
<tr class="left">
    <td class="left">
        <asp:Label ID="lblTitle" runat="server" Text="标题"></asp:Label>：
    </td>
    <td class="right">
        <div>
            <asp:TextBox ID="txtTitle" runat="server" Width="88%" MaxLength="125"></asp:TextBox>(最多125字)
        </div>
        <div>
            <asp:CheckBoxList ID="cboxTitleFontStyle" runat="server" RepeatDirection="Horizontal"
                RepeatLayout="Flow">
                <asp:ListItem Text="粗体" Value="b"></asp:ListItem>
                <asp:ListItem Text="斜体" Value="i"></asp:ListItem>
                <asp:ListItem Text="删除线" Value="s"></asp:ListItem>
            </asp:CheckBoxList>
            <span style="margin-left: 50px;">颜色：</span>
            <input type="button" onclick="showColorGrid2('<%=txtFontColor.ClientID%>','<%=txtShowColor.ClientID%>');"
                value="...">&nbsp;<asp:TextBox ID="txtFontColor" runat="server" Width="60px" ToolTip="单击选择颜色" />&nbsp;
            <asp:TextBox ID="txtShowColor" runat="server" size="1"></asp:TextBox>
            <div id="colorpicker201" class="colorpicker201">
            </div>
        </div>
    </td>
</tr>
<tr>
    <td class="left">
        信息属性：
    </td>
    <td class="right">
        <div>
            <asp:CheckBox ID="cboxIsGood" runat="server" Text="推荐" Value="isgood" CssClass="b"></asp:CheckBox>
            <asp:CheckBox ID="cboxChecked" runat="server" Text="审核" Value="checked" Checked="true" CssClass="b">
            </asp:CheckBox>
            <asp:CheckBox ID="cboxFirstTitle" runat="server" Text="头条" Value="firsttitle" CssClass="b"></asp:CheckBox>
             <span class="b" style="margin-left:50px;">置顶级别：</span>
            <asp:DropDownList ID="drplIsTop" runat="server" Width="100px">
                <asp:ListItem Value="0">0级置顶</asp:ListItem>
                <asp:ListItem Value="1">1级置顶</asp:ListItem>
                <asp:ListItem Value="2">2级置顶</asp:ListItem>
                <asp:ListItem Value="3">3级置顶</asp:ListItem>
                <asp:ListItem Value="4">4级置顶</asp:ListItem>
                <asp:ListItem Value="5">5级置顶</asp:ListItem>
                <asp:ListItem Value="6">6级置顶</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <span class="b">关&nbsp;&nbsp;键&nbsp;字：</span><asp:TextBox ID="txtKeyWord" runat="server" Width="70%" MaxLength="100"></asp:TextBox>(多个请用","格开)
        </div>
        <div>
            <span class="b" style="color:blue;">外部链接：</span><asp:TextBox ID="txtOutUrl" runat="server" Width="70%" MaxLength="200"></asp:TextBox>(填写后信息连接地址将为此链接)
        </div>
        <div>
            <span class="b">标题图片：</span><asp:TextBox ID="txtTitlePicUrl" runat="server" Width="70%" MaxLength="200" ClientIDMode="Static"></asp:TextBox>
         <img  id="imgFrm" src="../Images/icon_img.jpg" style="border:1px solid #cccccc" alt="查找或上传图片"   onclick='javascript:openUpload();'/>
        </div>
    </td>
</tr>
<tr>
    <td class="left">
        文件前缀：
    </td>
    <td class="right">
        <asp:TextBox ID="txtFilenameQZ" runat="server" Width="139px" MaxLength="10"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="cboxClosePL" runat="server" Text="关闭评论" Font-Bold="true" />
    </td>
</tr>

