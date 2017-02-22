<%@ Control Language="C#"  CodeFile="MainWorldAreaCityCheckboxList.ascx.cs"
    Inherits="UserControl_MainWorldAreaCityCheckboxList" %>
<asp:CheckBoxList ID="cboxWorldAreaCityList" runat="server" RepeatDirection="Horizontal"
    RepeatLayout="Flow">

<asp:ListItem checked="" value="大陆">大陆</asp:ListItem>
<asp:ListItem value="香港">香港</asp:ListItem>
<asp:ListItem value="澳门">澳门</asp:ListItem>
<asp:ListItem value="台湾">台湾</asp:ListItem>
<asp:ListItem value="南美">南美</asp:ListItem>
<asp:ListItem value="东欧">东欧</asp:ListItem>
<asp:ListItem value="东南亚">东南亚</asp:ListItem>
<asp:ListItem value="全球">全球</asp:ListItem>
<asp:ListItem value="非洲">非洲</asp:ListItem>
<asp:ListItem value="中东">中东</asp:ListItem>
<asp:ListItem value="东亚">东亚</asp:ListItem>
<asp:ListItem value="西欧">西欧</asp:ListItem>
<asp:ListItem value="北美">北美 </asp:ListItem>


</asp:CheckBoxList>