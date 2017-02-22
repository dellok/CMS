
function tabChange2(index, count, idPrefix) {
    idPrefix += "_";
    for (var i = 1; i < parseInt(count) + 1; i++) {
        var dID = idPrefix + i;
        document.getElementById(dID).className = "itemTabHide";
    }
    var dID = idPrefix + index;



    document.getElementById(dID).className = "itemTabShow";
}

function tabChange(index, count, idPrefix, navPrefix) {

    if ($.trim(navPrefix).length < 1) {
        tabChange2(index, count, idPrefix);
        return;

    }
    idPrefix += "_";
    navPrefix += "_";
    for (var i = 1; i < parseInt(count) + 1; i++) {
        var dID = idPrefix + i;
        var nID = navPrefix + i;
        document.getElementById(dID).className = "itemTabHide";
        document.getElementById(nID).className = "";
    }
    var dID = idPrefix + index;
    var nID = navPrefix + index;


    document.getElementById(dID).className = "itemTabShow";
    document.getElementById(nID).className = "current";
}


var domain = document.domain;
///新闻浏览顶一下限制
var key_Visited = "visited";
var newsHitExpiredHourse = 8;
////////////
///清空 input 文本信息
function ResetText() {
    $("input:text").each(function () {
        $(this).val('');
    });
}
//广告类
function ADClass() { }
ADClass.ADPV = function (id) {
    var ashxUrl = domain + "/ashx/ad.ashx?type=pv&id=" + id + "&r=" + Math.random();
    //HttpReq.Ajax(ashxUrl); 
    //$.get(ashxUrl);
}
ADClass.ADHit = function (adid, url) {
    var ashxUrl = domain + "/ashx/ad.ashx?id=" + adid + "&r=" + Math.random();
    HttpReq.Ajax(ashxUrl);
    window.open(url, "_blank");
}
ADClass.ADHit2 = function (id, url, title) {


    //var ashxUrl = domain + "/ashx/ad.ashx?id=" + id + "&title=" + escape(title) + "&r=" + Math.random();
    // HttpReq.Ajax(ashxUrl);

    window.open(url, "_blank");
}
/// 广告计数
function adHit(adid, url) {
    ADClass.ADHit(adHit, url);
}




var _hmt = _hmt || [];
(function () {
    var hm = document.createElement("script");
    hm.src = "//hm.baidu.com/hm.js?c8d7ef5cfa58a66d6694f5c9cb1f0bdf";
    var s = document.getElementsByTagName("script")[0];
    s.parentNode.insertBefore(hm, s);
})();

/***查询***********/

/***Cookies****************************************************/
function Cookie() { }
Cookie.SetCookie = function (key, value, hours) {
    var exdate = new Date()
    exdate.setHours(exdate.getHours() + hours);
    document.cookie = key + "=" + escape(value) + ";expires=" + exdate.toGMTString();
}
Cookie.GetCookie = function (key) {
    var cks = document.cookie.split(";");
    var value = "";
    for (var i = 0; i < cks.length; i++) {
        var items = cks[i].split("=");
        if (key == items[0].replace(" ", ""))
            return unescape(items[1].replace(" ", ""));
    }

    return value;
}

/////////////////


function SearchInfo() { }

SearchInfo.InputKeyWordId = "#txtKeyWord";
SearchInfo.InitInputKeyWord = function () {
    var kw = Cookie.GetCookie(SearchInfo.InputKeyWordId);
    if ($.trim(kw).length > 0) {
        $(SearchInfo.InputKeyWordId).val(kw);
    }
}
SearchInfo.SelectGolbalInfo = function () {
    var t = $.trim($(SearchInfo.InputKeyWordId).val());
    //默认有查询news下新闻
    if (t.length < 1 || t == "请输入关键字...") {
        alert("请输入要查询的关键字!");
        return false;
    }

    if ((t.length < 2 && t.length > 0) || t.length > 125) {
        alert("系统限制的搜索关键字只能在 2~125 个字符之间");
        return false;
    }
    var urlSearch = "/Search/" + t + "/";
    //
    //Cookie.SetCookie(SearchInfo.InputKeyWordId, t, 0.01);
    top.location.href = urlSearch;
}



