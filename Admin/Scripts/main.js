
/***************************/

function RefreshCheckCode(id) {
    document.getElementById(id).src = "CheckCode/index.ashx?aa=" + Math.random();
}


//控件中选中项========================================================================

var cboxAllID = "cboxAll";
var cboxAllName = "cboxAll";
var cboxItemID = "cboxItem";
function BindCboxSelectAll() {
    var cboxs = $(":checkbox[name='" + cboxAllName + "']");
    for (var i = 0; i < cboxs.length; i++) 
    {
        $(cboxs[i]).bind("click", function () {
            var checked = this.checked;
            var arrCboxAll = $(":checkbox[name='" + cboxAllName + "']");
            var arrCboxItem = $(":checkbox[id='" + cboxItemID + "']");
            for (var i = 0; i < arrCboxAll.length; i++) {
                $(arrCboxAll[i]).attr("checked", checked);
            }
            for (var i = 0; i < arrCboxItem.length; i++) {

                $(arrCboxItem[i]).attr("checked", checked);

            } 
        });
    }
}

$(document).ready(function () { BindCboxSelectAll(); });
//===========================================================================================================================


