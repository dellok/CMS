<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" CodeFile="CategoryTree.aspx.cs"
    Inherits="CategoryTree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" runat="Server">
    <script src="/scripts/dtree/dtree.js" type="text/javascript" language="javascript"></script>
    <link href="/scripts/dtree/dtree.css" type="text/css" rel="Stylesheet" />
    <script src="../Scripts/treeNewsSelectedNodeCss.js" type="text/javascript" language="javascript"></script>
    <div style="position: fixed; top: 0px; z-index: 6; height: 25px; background: #F5F5F5;
        line-height: 25px; padding-left: 2px; width: 196px; border: solid 1px black;
        margin: 0px auto; padding-left: 4px;">
        <asp:TextBox ID="txtClassName" runat="server" Width="60"  onfocus="javascript:this.value=''"></asp:TextBox>
        <asp:Button ID="btnSearch" Text="查询" runat="server" ForeColor="BlueViolet" OnClick="btnSearch_Click" />
        <input type="button" value="[刷新]" style="color:Green;" onclick="javascript:document.location.reload();"></input>
    </div>
    <div style="position: fixed; top: 0px; z-index: 6; height: 25px; background: #F5F5F5;
        line-height: 25px; padding-left: 2px; width: 196px; border: solid 1px black;
        margin: 0px auto; top: 25px; padding-left: 4px;">
        <font color="green">绿字:分类ID</font>,<font color="red">红字:新闻数量</font>
    </div>
    <div style="margin-top: 50px;">
        <asp:Label ID="lblDTree" runat="server"></asp:Label></div>
</asp:Content>
