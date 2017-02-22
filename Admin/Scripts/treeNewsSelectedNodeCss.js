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
function SetNewsCurrentNodCss() {
    var arrA = $("a");
    for (var i = 0; i < arrA.length; i++) {

        var currentNodeID = arrA[i].id;
        var currentNodeTitle = arrA[i].title.toLowerCase();

        if (currentNodeTitle == toUrl.toLowerCase()) {
            d.s(currentNodeID.replace("sd", ""));
            break;
        }
    }

//  if ($.trim(toUrl).length < 1) toUrl = "?";
// parent.document.getElementById("newslist").src = toUrl
  

}

$(document).ready(function () { SetTitleCssAndHidePageImg(); SetNewsCurrentNodCss(); }); ;