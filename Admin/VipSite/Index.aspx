<%@ Page Title="" Language="C#" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="VipWebSite_Index" %>


    <frameset cols="28%,*" border="0" frameborder="0">
<frame src='VipMemberList.aspx?userid=<%=Request["userid"]%>&groupid=<%=Request["groupid"]%>' framborder="no" scrolling="auto" noresize marginwidth="0" margingheight="0"/>
<frame src="Default.aspx" name="frmVipSite" id="newslist" borderColor="0" border="0" frameBorder="0"></frame>
</frameset>

</frameset>


