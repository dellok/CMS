

function tabChange(index, count, idPrefix) {
    idPrefix += "_";
    for (var i = 1; i < parseInt(count) + 1; i++) {
        var dID = idPrefix + i;
        document.getElementById(dID).className = "itemTabHide"
    }
    var dID = idPrefix + index;

    alert(dID);

    document.getElementById(dID).className = "itemTabShow"
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
/////////////////时间日期
function DateTime() { }
DateTime.getWeek = function (day) { var week = ["星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"]; return week[day]; }
DateTime.GetNowDate = function () {
    var date = new Date(); //日期对象 
    var now = "您好！今天是：" + date.getFullYear() + "年" + (date.getMonth() + 1) + "月" + date.getDate() + "日 " + DateTime.getWeek(date.getDay());
    document.write(now);
}
//////////////////
///---------------
//验证码图片刷新
function refreshImg(imgID) {


    document.getElementById(imgID).src = "/CheckCode/index.ashx?x=" + Math.random();
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
    var ashxUrl = domain + "/ashx/ad.ashx?id=" + id + "&title=" + escape(title) + "&r=" + Math.random();
    HttpReq.Ajax(ashxUrl);
    window.open(url, "_blank");
}
/// 广告计数
function adHit(adid, url) {
    ADClass.ADHit(adHit, url);
}
///////////////
function News() { }
News.ID = 0;
News.ClassID = 0;
News.Title = "";
News.PinDao = "News";
News.PinDaoValue = 0;
//新闻浏览量
News.PageView = function () {
    if (parseInt(News.ID) > 0) {
        // var newsUrl = domain + "/ashx/news.ashx?id=" + News.ID + "&type=vote&dir=" + News.PinDaoValue + "&dirName=" + News.PinDao + "&title=" + News.Title + "&classid=" + News.ClassID + "&r=" + Math.random();
        //var newsUrl = domain + "/ashx/news.ashx?id=" + News.ID + "&type=vote&&title=" + News.Title + "&classid=" + News.ClassID + "&r=" + Math.random();
        var newsUrl = "/ashx/news.ashx?id=" + News.ID + "&type=vote&&title=" + News.Title + "&classid=" + News.ClassID + "&r=" + Math.random();
        HttpReq.Ajax(newsUrl);
    }
}
News.SetUrlFeedback = function () {
    var feedbackID = "#lblFeedbackUrl";
    $(feedbackID).html("<a href='" + domain + "/Feedback/index.aspx?" + News.GetUrlParams() + "' >评论</>");
}
News.GetUrlParams = function () {
    var parm = "id=" + News.ID + "&classid=" + News.ClassID + "&title=" + News.Title + "&PinDao=" + News.PinDao + "&pageurl=" + document.URL;
    return parm;
}

News.SetUrlReport = function () {
    var lblReportID = "#lblReport";
    $(lblReportID).html("<a href='" + domain + "/report/index.aspx?" + News.GetUrlParams() + "' >举报</a>");
}

News.SetReferSelfUrl = function () {
    //  document.getElementById("txtUrlPath").value = document.URL;
}

News.SetUrlFavorite = function () {
    var lblAddFavoriteUrl = "#lblAddFavoriteUrl";

    $(lblAddFavoriteUrl).html("<a href='" + domain + "/Member/Space/Favorite.aspx?" + News.GetUrlParams() + "' >收藏</a>");
}

News.DoZoom(size) {
    document.getElementById('zoom').style.fontSize = size + 'px';
}
News.InitDetailOtherUrl = function () {
    News.SetUrlFavorite();
    News.SetUrlFeedback();
    News.SetUrlReport();
    News.SetReferSelfUrl();
}

///新闻计数
News.NewsHit = function () {
    var controlHitID = "#lblNewsHit";
    var cookiekey = key_Visited + "_" + News.ID;

    if (!Cookie.GetCookie(cookiekey)) {
        var newsUrl = "/ashx/news.ashx?id=" + News.ID + "&type=hit&r=" + Math.random();
        HttpReq.Ajax(newsUrl);
        var hitCount = parseInt($(controlHitID).html());
        $(controlHitID).html(parseInt(hitCount) > 0 ? parseInt(hitCount) + 1 : 1);
        Cookie.SetCookie(cookiekey, true, newsHitExpiredHourse);
    }
}
News.InitNewsHit = function () {
    var controlHitID = "#lblNewsHit";
    var newsUrl = "/ashx/news.ashx?id=" + News.ID + "&type=initHit&r=" + Math.random();
    var hit = HttpReq.Ajax(newsUrl);

    $(controlHitID).html(hit);

}


News.SetZTHitAndFeedback = function (id) {
    var title = $("#t" + id).html();
    var spanHitID = "#n" + id;
    var url = "/ashx/news.ashx?id=" + id + "&type=hit&r=" + Math.random();


    HttpReq.Ajax(newsUrl);
    var hitCount = parseInt($(spanHitID).html());
    $(spanHitID).html(parseInt(hitCount) > 0 ? parseInt(hitCount) + 1 : 1);
    //
}

function HttpReq() { }
HttpReq.Ajax = function (url) {
    var returnR;
    $.ajax({
        async: false,
        url: url,
        type: "GET",
        dataType: 'jsonp',
        jsonp: 'jsoncallback',
        data: "",
        timeout: 5000,
        success: function (json) {
            returnR = json;
        },
        error: function (xhr) {
            alert("请求出错(请检查相关度网络状况.)");
        }
    });
    return returnR;
}



///  查询页内////////////////////////////////////////////////////////////////////////
//首页查询

function SearchInfo() { }
SearchInfo.SelectGolbalInfo = function () {
    var t = $.trim($('#txtSearchWord').val());
    var field = $('#selectDomain').val()

    //默认有查询news下新闻
    if (field.lenght < 1) {
        field = SubDomain_News;
    }
    if (t.length < 1 || t == "请输入关键字...") {
        alert("请输入要查询的关键字!");
        return false;
    }

    if ((t.length < 2 && t.length > 0) || t.length > 125) {
        alert("系统限制的搜索关键字只能在 2~125 个字符之间");
        return false;
    }
    var urlSearch = field + "/List.aspx?title=" + t;
    top.location.href = urlSearch;
}
SearchInfo.Header = function () {
    var t = $.trim($('#txtSearchWord').val());
    if (t.length < 1 || t == "请输入关键字...") {
        alert("请输入要查询的关键字!");
        return false;
    }

    if ((t.length < 2 && t.length > 0) || t.length > 30) {
        alert("系统限制的搜索关键字只能在 2~30个字符之间");
        return false;
    }
    var urlSearch = "/news/List.aspx?title=" + t;
    top.location.href = urlSearch;
}
///展会信息查询
function SearchZhanHuiInfo(keyword, field) {
    var t = $.trim(keyword);
    if (t.length < 1) {
        alert("请输入要查询的关键字");
        return false;
    }

    if ((t.length < 3 && t.length > 0) || t.length > 125) {
        alert("系统限制的搜索关键字只能在 2~125 个字符之间");
        return false;
    }
    var urlSearch = SubDomain_CE + "/List.aspx?" + field + "=" + t;
    document.location = urlSearch;
}

//物流装备查询
function SearchWuLiuZhuangBei(keyword, stype) {
    var parm = "";
    if (keyword == "" || keyword == "请输入关键字...") {
        alert("请输入查询的关键字!");
        return false;
    }
    else {
        parm += stype + "=" + keyword;
        window.location = SubDomain_LE + "/List.aspx?" + parm;
    }
}

///公司库查询
function SearchGsk(keyword, zhizao, leibie) {
    var strKeyWord = $('#txtKeyWord').val();
    var strAddress = $("#selectCity").val();
    var strZhiZao = $('#selectZhiZao').val();
    var strLeiBie = $('#selectLeiBie').val();
    var url = SubDomain_Gsk + "/List.aspx?keyword=" + strKeyWord + "&zhizao=" + encodeURIComponent(strZhiZao) + "&leibie=" + encodeURIComponent(strLeiBie) + "&address=" + strAddress;
    top.window.location = url;

}


function SearchGongSiKu() {
    var keyword = $("#txtKeyword").val();
    keyword = keyword == "空白不填搜索所有，关键字.." ? "" : keyword;


    var address = $("#selectAddress").val();
    var classid = $("#selectClassID").val();
    var cclb = $("#selectCCLB").val();
    var zhizao = $("#selectZhiZao").val();
    var leibie = $("#selectLeiBie").val();
    var url = SubDomain_Gsk + "/List.aspx?keyword=" + keyword + "&address=" + address + "&classid=" + classid + "&cclb=" + cclb + "&zhizao=" + zhizao + "&leibie=" + leibie;
    window.location = url;
}

//==============================================================================



//复制地址
function sendtof(url) {
    window.clipboardData.setData('Text', url);
    alert('复制地址成功，粘贴给你好友一起分享。');
}

/****设置信息页 字体大小***/
function maintext(size) {
    document.getElementById("maintext").className = "black" + size;
}
/*=======================登录验证=============================*/
var divLoginID = "divLogin";
var divLoginSuccessID = "divLoginSuccess";
var spanLoginNameID = "spanLoginName";
var selectExpriesID = "expiresHourse";

var txtLoginName = "txtLoginName";
var txtPwd = "txtPwd";

//页面栽入时验证
var loginInitCheck = "1";
var loginClickCheck = "0";
function BtnCheckLogin() {
    CheckUserLogin(loginClickCheck);
}
function CheckUserLogin(type) {

    var url = MainDomain + "/ashx/CheckUserLogin.ashx?type=login&isClickLogin=false&r=" + Math.random();

    if (type == loginClickCheck) {
        if ($.trim($("#" + txtLoginName).val()).length < 1) {

            alert("请输入登录名!");
            return false;

        }
        if ($.trim($("#" + txtPwd).val()).length < 1) {

            alert("请输入登录密码!");
            return false;
        }

        url = MainDomain + "/ashx/CheckUserLogin.ashx?type=login&isClickLogin=true&expiresHourse=" + $("#" + selectExpriesID).val() + "&LoginName=" + $("#" + txtLoginName).val() + "&password=" + $("#" + txtPwd).val() + "&r=" + Math.random();
    }
    ReqDomainCheckUser(type, url)

}

function ReqDomainCheckUser(type, url) {
    $.ajax({
        async: false,
        url: url,
        type: "GET",
        dataType: 'jsonp',
        jsonp: 'jsoncallback',
        data: "",
        timeout: 5000,
        success: function (json) {
            var IsLogin = json.IsLogin;
            var LoginName = json.LoginName;
            var Msg = json.Msg;
            SetLoginInfo(type, IsLogin, LoginName, Msg);
        },
        error: function (xhr) {

            alert("请求出错(请检查相关度网络状况.)");
        }
    });

}

function SetLoginInfo(type, IsLogin, LoginName, Msg) {

    if (IsLogin == "True") {
        //登录成功
        if (type != loginInitCheck) {
            alert(Msg);
        }
        $("#" + divLoginID).hide();
        $("#" + divLoginSuccessID).show();
        $("#" + spanLoginNameID).html(LoginName);
    }
    else {
        if (type != loginInitCheck) {
            alert(Msg);
        }
        $("#" + divLoginID).show();
        $("#" + divLoginSuccessID).hide();
    }

}


function SafeLogOut() {
    var url = domain + "/ashx/CheckUserLogin.ashx?type=logout";
    $.ajax({
        async: false,
        url: url,
        type: "GET",
        dataType: 'jsonp',
        jsonp: 'jsoncallback',
        data: "",
        timeout: 5000,
        success: function (json) {
            $("#" + divLoginID).show();
            $("#" + spanLoginNameID).html("");
            $("#" + divLoginSuccessID).hide();
        },
        error: function (xhr) {

            alert("请求出错(请检查相关度网络状况.)");
        }
    });



}
//$(document).ready(function () { CheckUserLogin(loginInitCheck); });

/**************页面顶部 信息查询块******************/
function doSearch2() {
    var kword = $.trim($("#keyboard2").val());
    var sUrl = $("#sUrl2").val();
    if (kword != "请输入关键字..." && kword.length > 0) {
        window.location = sUrl + "/list.aspx?title=" + kword;
    }
    else {

        alert("请输入要查询的关键字!");
        return false;
    }

}
/********************** 评价 *************************/
function Feedback() { };
var contentid = "#txtFeedbackContent";
var codeid = "#txtCode";
var loginName = "#txtFLoginName";
var loginPwd = "#txtFPassword";
var hideReplyID = "#hideReplyID";
///////////////////
var c_tbFeedback = "#tbFeedback";
var c_linkFeedback = "#linkFeedback";
var c_spanFCount = "#spanFCount";
var c_linkMoreFeedback = "#linkMoreFeedback";

function ReplayFeedback(id, username) {
    $(hideReplyID).val(id);
    var repStr = "回复" + username + "："
    $(contentid).html(repStr + $(contentid).html());
}

Feedback.IsAnonymity = function () { return $("#cboxIsAnonymity").attr("checked"); }

/***专题征集评论 ***/
Feedback.SubmitZTZJFeedback = function () {

    var newsid = $(":radio[name=radioZtpd]").attr("checked", true).attr("value");
    var newsclassid = "346";
    var newstitle = $(":radio[name=radioZtpd]").attr("checked", true).attr("title");

    var ID = "#txtFeedback";
    var t = $.trim($(ID).val());
    if (t.length < 1) {
        alert("您没什么话要说吗？");
        $(ID).focus();
        return false;
    }
    if (t.length > 100) {
        alert("评价应在100字以内？现字数:" + t.length);
        $(ID).focus();
        return false;
    }

    var url = "/ashx/feedback.ashx?";
    url += "newsid=" + newsid;
    url += "&classid=" + newsclassid;
    url += "&fcontent=" + t;
    url += "&isn=ttrue";
    url += "&title=" + newstitle;
    url += "&pageUrl=News";
    url += "&r=" + Math.random();
    $.ajax({
        async: false,
        url: url,
        type: "GET",
        dataType: 'jsonp',
        jsonp: 'jsoncallback',
        data: "",
        timeout: 5000,
        success: function (json) {
            alert(json);
        },
        error: function (xhr) {

            alert("请求出错(请检查相关度网络状况.)");
        }
    });




}



Feedback.SubmitFeedback = function () {
    var t = $.trim($(contentid).val());
    if (t.length < 1) {
        alert("您没什么话要说吗？");
        $(contentid).focus();
        return false;
    }
    if (t.length > 300) {
        alert("评价应在300字以内？现字数:" + t.length);
        $(contentid).focus();
        return false;
    }
    if ($(codeid).val().length < 1) {
        alert("请输入验证吗!");
        $(codeid).focus();
        return false;
    }


    var url = "/ashx/feedback.ashx?";
    url += "newsid=" + News.ID;
    url += "&classid=" + News.ClassID;
    url += "&fcontent=" + t;
    url += "&code=" + $(codeid).val();
    url += "&isn=" + Feedback.IsAnonymity();
    url += "&loginname=" + $(loginName).val() != "undefined" ? $(loginName).val() : "Lenglian网友";
    url += "&password=" + $(loginPwd).val() != "undefined" ? $(loginPwd).val() : ""
    url += "&ReplayID=" + $(hideReplyID).val();
    url += "&title=" + News.Title;
    url += "&pageUrl=" + News.PinDao;
    url += "&r=" + Math.random();


    $.ajax({
        async: false,
        url: url,
        type: "GET",
        dataType: 'jsonp',
        jsonp: 'jsoncallback',
        data: "",
        timeout: 5000,
        success: function (json) {
            alert(json);
        },
        error: function (xhr) {

            alert("请求出错(请检查相关度网络状况.)");
        }
    });

}
////// 初始化新闻评价信息  /////////////////////////
Feedback.InitNewsFeedback = function () {
    var parm = "id=" + News.ID + "&classid=" + News.ClassID + "&title=" + News.Title + "&PinDao=" + News.PinDao + "&pageurl=" + document.URL + "&domain=" + document.location.host;


    var urlInitFeedbackList = "/ashx/feedback.ashx?type=1&" + parm;
    var urlViewsFeedback = "/Feedback/Index.aspx?" + parm;


    $.ajax({
        async: false,
        url: urlInitFeedbackList,
        type: "GET",
        dataType: 'jsonp',
        jsonp: 'jsoncallback',
        data: "",
        timeout: 5000,
        success: function (json) {

            list = json;
            var listhtml = list[0].ListFeedback;
            var listCount = list[0].RecordCount;
            $(c_linkFeedback).attr("href", urlViewsFeedback);
            $(c_linkMoreFeedback).attr("href", urlViewsFeedback);
            $(c_tbFeedback).append(listhtml);
            $(c_spanFCount).html(parseInt(listCount) > 0 ? listCount : 0);
        },
        error: function (xhr) {

            alert("请求出错(请检查相关度网络状况.)");
        }
    });

}

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
/**********************/
function CreateNewsCache() {
    var isWebSiteIndexPage = false;
    var cUrl = domain + "/ashx/Cache.aspx?t=news";
    var indexPage = ["index.html", "index.aspx"];
    var currentUrl = document.location.href.toLowerCase();
    for (var i = 0; i < indexPage.length; i++) {
        var matchUrl = domain + "/" + indexPage[i];

        var returnV = currentUrl.match(matchUrl);
        if (returnV != null) {
            isWebSiteIndexPage = true;
            break;
        }
    }
    if (isWebSiteIndexPage) {

        alert(HttpReq.Ajax(url));
        //$.get(url, function (data) { alert(data); });
    }
}
/////////////////////////////////////////
function MemberClass() { }
var initErrorMsgDiv = "";
var InitIndex = 0;
////属性与方法 ///////////////////////////////////////
MemberClass.prototype.LevelMsgDivID = "divErrorMsg";
MemberClass.prototype.ShowLevelMsg = function () {
    var m = document.getElementById(this.LevelMsgDivID);
    var className = m.className;
    if (className == "onError") { className = "onErrorNoBackground" }
    else { className = "onError"; }
    m.className = className;
    ++InitIndex;
    if (InitIndex == 6) clearInterval(initErrorMsgDiv);
}
MemberClass.prototype.InitShowLevelMsg = function () { initErrorMsgDiv = setInterval(this.ShowLevelMsg, 500); }
//////////////
function tag_change(tagIndex, tagCount, tagName, cssPrefix) {
    var tagContentPrefix = "content_";
    var tagHideCss = cssPrefix + "Off";
    var tagShowCss = cssPrefix + "On";
    var contentShowCss = "tagContentOn";
    var contentHideCss = "tagContentOff";

    for (var i = 1; i < parseInt(tagCount) + 1; i++) {
        var cTagId = tagName + "_" + i;
        var contentID = tagContentPrefix + cTagId;
        document.getElementById(cTagId).className = tagHideCss;
        document.getElementById(contentID).className = contentHideCss;
    }
    var tagid = tagName + "_" + tagIndex;
    document.getElementById(tagid).className = tagShowCss;
    document.getElementById(tagContentPrefix + tagid).className = contentShowCss;
}

function tagShowContent(tagindex, tagCount, tagName) {
    var tagContentPrefix = "content_";
    var contentShowCss = "tagContentOn";
    var contentHideCss = "tagContentOff";
    for (var i = 1; i < parseInt(tagCount) + 1; i++) {

        var contentID = tagContentPrefix + tagName + "_" + i;
        document.getElementById(contentID).className = contentHideCss;
    }

    var tid = tagContentPrefix + tagName + "_" + tagindex;

    document.getElementById(tid).className = contentShowCss;

}
