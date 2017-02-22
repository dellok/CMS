<%@ Page Language="C#"  CodeFile="CreateIndexHtml.aspx.cs" Inherits="Cache_CreateIndexHtml" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link  rel="Stylesheet" href="../Css/main.css" type="text/css"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="div_nav_title2">
        <span>位置： <a href="/LoginSuccess.aspx">管理信息</a> > <a href="index.aspx">缓存管理</a>>刷新频道首页</span></div>
        
        <%=iframeHtml.ToString()%>
    </form>

</body>
</html>