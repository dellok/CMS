<%@ Control Language="C#"  CodeFile="TransportTypeDropdownList.ascx.cs"
    Inherits="UserControl_TransportTypeDropdownList" %>
<asp:DropDownList ID="drplTransport" runat="server">
    <asp:ListItem value="公路运输">公路运输</asp:ListItem>
    <asp:ListItem value="铁路运输">铁路运输</asp:ListItem>
    <asp:ListItem value="航空运输">航空运输</asp:ListItem>
    <asp:ListItem value="特快专递">特快专递</asp:ListItem>
    <asp:ListItem value="特种运输">特种运输</asp:ListItem>
    <asp:ListItem value="海洋运输">海洋运输</asp:ListItem>
    <asp:ListItem value="冷藏运输">冷藏运输</asp:ListItem>
    <asp:ListItem value="综合类别">综合类别</asp:ListItem>
    <asp:ListItem value="其他行业">其他行业</asp:ListItem>
</asp:DropDownList>