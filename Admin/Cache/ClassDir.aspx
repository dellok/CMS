<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master"  CodeFile="ClassDir.aspx.cs" Inherits="Cache_ClassDir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="adminmaster" Runat="Server">


<br>

    <asp:Button ID="Button2" runat="server"  CssClass="btn" Text="只生成分类目录" 
        onclick="btnCreateDir_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="btnCreateDirAndFile_Click" CssClass="btn" Text="生成分类目录及默认首页文件" />




</asp:Content>

