

var checkCodeHtml = "";
var checkCodeUrl="";
/***************************/

function RefreshCheckCode(id) 
{
  document.getElementById(id).src = "CheckCode/index.aspx?aa=" + Math.random();
 }
checkCodeHtml += "<img  id=\"imgCheckCode\"  src=\""+checkCodeUrl+"\"  alt=\"看不清在换一张\"     onclick=\"RefreshCheckImg('imgCheckCode')\"  /> ";
checkCodeHtml+="<a href=\"#\" onclick=\"RefreshCheckImg('imgCheckCode')\">换一张</a>";

document.write(checkCodeHtml);