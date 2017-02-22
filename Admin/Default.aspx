<%@ Page Language="C#"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

     表达式:<asp:TextBox ID="txtRule" runat="server" Width="478px"></asp:TextBox>
        <br />
        <br />
    内容:<asp:TextBox ID="txtText" runat="server" TextMode="MultiLine"
            Height="166px" Width="787px"></asp:TextBox>

        <br />
        <br />

    <asp:Button  ID="btnRun" runat="server"  Text="替换" onclick="btnRun_Click" 
            Width="258px"/>

        <br />
        <br />

    结果：<asp:Label ID="txtResult" runat="server"  TextMode="MultiLine" Width="100%" 
            Height="91px" style="margin-top: 0px"></asp:Label>
    </div>
   
    </form>
</body>
</html>
