<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBtdC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
    .login_input{font-size:12px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">

     <table width="549" height="287" style="margin-top:200px;" border="0" align="center" cellpadding="0" cellspacing="0" background="/images/login/login_bg.jpg">
      <tbody><tr>
        <td width="23"><img src="/images/login/login_leftbg.jpg" width="23" height="287"></td>
        <td width="503" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tbody><tr>
            <td width="49%" valign="bottom"><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
              <tbody><tr>
                <td height="100" valign="top" class="login_text"><div align="left">
                  <h3>  网站后台管理系统<h3></div></td>
              </tr>
              <tr>
                <td><div align="right"><img src="/images/login/login_img.jpg" width="104" height="113"></div></td>
              </tr>
            </tbody></table></td>
            <td width="2%"><img src="/images/login/login_line.jpg" width="6" height="287"></td>
            <td width="49%"><div align="right">
              <table width="223" border="0" cellspacing="0" cellpadding="0">
                <tbody><tr>
                  <td><img src="/images/login/login_tit.jpg" width="223" height="30"></td>
                </tr>
                <tr>
                  <td><table width="100%" border="0" cellspacing="10" cellpadding="0" class="login_input">
                    <tbody><tr>
                      <td width="28%"><div align="left">用户名：</div></td>
                      <td width="72%"><div align="left"><span class="style1">
                            <asp:TextBox ID="txtLoginName" Style="width: 140px; margin-top: 1px;" runat="server"></asp:TextBox>
                      </span></div></td>
                    </tr>
                    <tr>
                      <td><div align="left">密&nbsp;&nbsp;码：</div></td>
                      <td><div align="left"><span class="style1">
                         <asp:TextBox ID="txtPwd" runat="server" Style="width: 140px; margin-top: 1px;" TextMode="Password"></asp:TextBox></span></div></td>
                    </tr>
                    <!--tr>
                      <td><div align="left">验证码：</div></td>
                      <td><div align="left">
                          <asp:TextBox ID="txtCheckCode" runat="server" Style="width: 80px; margin-top: 1px;vertical-align:middle;"
                    title="验证码不区分大小写！"></asp:TextBox>
                <span style="padding-top: 5px">
            
                      <img id="Img1" src="/CheckCode/index.ashx" alt="验证码" runat="server"  style="vertical-align:middle;height:20px;" class="imgCheckCode" onclick="refreshImg(this.id)" />
             
                </span></td>
                    </tr-->
                   
                  </tbody></table></td>
                </tr>
                <tr>
                  <td align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody><tr>
                      <td><div align="center"></div></td>
                      <td><div align="center">

                     <asp:ImageButton   ID="btnLogin" runat="server"  
                              ImageUrl="~/Images/login/login_menu2.jpg" onclick="btnLogin_Click"/>
                            

      </td>
                    </tr>
                  </tbody></table>
                  <div style="color:Red;font-size:12px;"> 后台最好在【IE】浏览器下使用，若在其它浏览器下使用可能某些功能不起用!</div>
                    </td>
                </tr>
              </tbody></table>
            </div></td>
          </tr>
        </tbody></table></td>
        <td width="23"><img src="/images/login/login_rigbg.jpg" width="23" height="287"></td>
      </tr>
    </tbody></table>

















     
     
  
    </form>
</body>
</html>
