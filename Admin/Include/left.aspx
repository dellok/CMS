<%@ Page Language="C#"  CodeFile="left.aspx.cs" Inherits="Include_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script src="/scripts/jquery-1.4.1.js" type="text/javascript" language="javascript"></script>
<script src="/scripts/dtree/dtree.js" type="text/javascript"  language="javascript"></script>
<link   href="/scripts/dtree/dtree.css"  type="text/css" rel="Stylesheet"/>
</head>

<body>
    <form id="form1" runat="server">
    <div id="divTree" runat="server" >

    </div>
    </form>
</body>
</html>
  <script language="javascript" type="text/javascript">

      var imgsrc = "page.gif";
      var title = "group";
      var cssFb = "fb";
  
      function SetTitleCssAndHidePageImg() {
      var arrTitle = $("a[title='" + title + "']");
          for (var i = 0; i < arrTitle.length; i++) {

              arrTitle[i].className = arrTitle[i].className + ' ' + cssFb;
          }

      }
      //选中高亮显示
      function SetCurrentNodCss() {
          var arrA = $("a");
          for (var i = 0; i < arrA.length; i++) {

              var currentNodeID = arrA[i].id;
              var currentNodeTitle = arrA[i].title.toLowerCase();

              if (currentNodeTitle == mainRightUrl.toLowerCase()) {

                  d.s(currentNodeID.replace("sd", ""));
                  break;
              }
          }

          if ($.trim(mainRightUrl).length < 1) mainRightUrl = "../loginSuccess.aspx";
          parent.document.getElementById("mainRight").src = mainRightUrl;

      }

      $(document).ready(function () { SetTitleCssAndHidePageImg(); SetCurrentNodCss(); }); ;
     
     </script>
