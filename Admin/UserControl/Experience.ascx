<%@ Control Language="C#"  CodeFile="Experience.ascx.cs" Inherits="UserControl_ExperienceRadioList" %>
         <asp:RadioButtonList  ID="radioExperienceList" runat="server"   RepeatDirection="Horizontal" RepeatLayout="Flow"  >
                <asp:ListItem Text="不限" Value="" ></asp:ListItem>
                 <asp:ListItem Text="半年以上" Value="半年以上"></asp:ListItem>
                  <asp:ListItem Text="一年以上" Value="一年以上"></asp:ListItem>
                   <asp:ListItem Text="两年以上" Value="两年以上"></asp:ListItem>
                    <asp:ListItem Text="5年以上" Value="5年以上"></asp:ListItem>
                </asp:RadioButtonList>

