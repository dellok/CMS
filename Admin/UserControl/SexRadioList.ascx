<%@ Control Language="C#"  CodeFile="SexRadioList.ascx.cs" Inherits="UserControl_SexRadioList" %>
<asp:RadioButtonList ID="radioSexList" runat="server" RepeatDirection="Horizontal"   RepeatLayout="Flow">
    <asp:ListItem Value="男" Text="男"  />
    <asp:ListItem Value="女" Text="女" />
</asp:RadioButtonList>