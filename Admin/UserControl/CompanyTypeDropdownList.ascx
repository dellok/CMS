<%@ Control Language="C#"  CodeFile="CompanyTypeDropdownList.ascx.cs" Inherits="UserControl_CompanyTypeDropdownList" %>
<asp:RadioButtonList ID="drplCompanyList" runat="server" RepeatDirection="Horizontal"   RepeatLayout="Flow">
    <asp:ListItem Value="内资" Text="内资" Selected="True" />
    <asp:ListItem Value="合资" Text="合资" />
    <asp:ListItem Value="外资" Text="外资" />
</asp:RadioButtonList>