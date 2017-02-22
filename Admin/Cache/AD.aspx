<%@ Page Language="C#"  CodeFile="AD.aspx.cs" Inherits="Cache_AD"   %>
 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link  rel="Stylesheet" href="../Css/main.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
 <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="index.aspx">缓存管理</a>>刷新广告数据</span></div>
        <%=msg.ToString()%>
    </form>
</body>
</html>

