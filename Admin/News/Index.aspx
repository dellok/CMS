<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>
        <frameset rows="31,*"  id="bodyMain" name="bodyMain" borderColor="0"  border="0"  frameborder="0">
        <frame src="navtitle.html"scrolling="auto" marginheight="0"  width="200"  frameBorder="0"    >
        
        </frame>
  <frameset cols="200,*"  id="bodyMain" name="bodyMain" borderColor="0"  border="0"  frameborder="0">
<frame src="NewsClassTree.aspx" id="frmClass"  name="frmClass"  scrolling="auto" marginheight="0"  width="200"  frameBorder="0"    ></frame>

<frame src="NewsList.aspx" name="newslist" id="newslist"   scrolling="auto"  borderColor="0" border="0" frameBorder="0"></frame>
</frameset>
</frameset>
<%--   <table style="width: 100%; height: 100%; border: 0; vertical-align: top; clear: both;">
        <tr>
            <td style="width: 20%" valign="top">
                <iframe src="" marginheight="0" id="frmClass" marginwidth="0" frameborder="0" name="frmClass"
                    width="100%" height="1000"></iframe>
            </td>
            <td style="width: 80%; padding-left: 5px;">
                <iframe src="" name="newslist" id="newslist" height="1000" width="100%" marginheight="0"
                    marginwidth="0" frameborder="0"></iframe>
            </td>
        </tr>
    </table>--%>
    <script type="text/javascript" language="javascript">
 
        var frmClassTreeID = "frmClass";
        var frmNewsListID = "newslist";
        var frmClassUrl = "NewsClassTree.aspx";
        var frmNewsListUrl = "NewsList.aspx";
        function ReFrmUrl() {
            var urlPram = location.search;
         
            document.getElementById(frmClassTreeID).src = frmClassUrl + urlPram;
            document.getElementById(frmNewsListID).src = frmNewsListUrl + urlPram;
        }
        ReFrmUrl();
    </script>
