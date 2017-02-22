<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" 
    CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="adminmaster" runat="Server" EnableViewState="false"  >

<script src="/scripts/dtree/dtree.js" type="text/javascript"  language="javascript"></script>
<link   href="/scripts/dtree/dtree.css"  type="text/css" rel="Stylesheet"/>
<script src="../Scripts/treeNewsSelectedNodeCss.js" type="text/javascript"  language="javascript"></script>


    <div class="div_nav_title2">
        <span>位置： 管理信息 ><a href="Index.aspx">分类管理</a> </span></div>
    <table align="center"  cellspacing="1" style="width:100%;clear:both;">
        <tr>
            <td class=" " style="width: 230px;height:200px; overflow:auto; text-align: left;" valign="top">
             <table cellspacing="1" class="tb_info"><tr><td class="category_title div_title" style="height: 26px;" >
                <div>
                    产品目录分类</div></td></tr></table>
                    <p style="margin:5px auto;"><asp:Button  ID="btnOpen" runat="server" Text="展开所有" CssClass="btn"  Width="100"
                   />  &nbsp;&nbsp;
                <asp:Button  ID="btnClose" runat="server" Text="折叠所有" CssClass="btn"  Width="100"
                    />
                    </p>
       
<asp:Label ID="lblDTree" runat="server"></asp:Label>
            </td>
            <td valign="top">
            
             
             <iframe src="ClassEdit.aspx"  id="ClassEdit" name="ClassEdit" style="width:100%;height:800px;" ></iframe>

            </td>
        </tr>
    </table>
    
    <script type="text/javascript" language="javascript">




        var frmClassEdit = "ClassEdit";
        var ClassEidtUrl = "ClassEidt.aspx?id=";
        function toUrl(id) {
            var urlPram = location.search;
            // document.getElementById(frmClassTreeID).src = frmClassUrl + urlPram;

            alert(id);
            document.getElementById(frmClassEdit).src = ClassEidtUrl + id;

        }



     
    
    </script>
</asp:Content>
