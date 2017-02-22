///清空 input 文本信息
function ResetText() {
    $("input:text").each(function () {
        $(this).val('');
    });
}

///---------------
//验证码图片刷新
function refreshImg(imgID) {


    document.getElementById(imgID).src = "/CheckCode/index.ashx?x=" + Math.random();

}


function openDialogClass(pcid, classid, lblClassID, lblClassPathID, pHideClassID) {
    var src = "/NewsClass/DialogClassListBox.aspx?pclassid=" + pcid + "&classid=" + classid + "&lblClassID=" + lblClassID + "&lblClassPathID=" + lblClassPathID + "&pHideClassID=" + pHideClassID;
   $.modal('<iframe src="' + src + '" height="430" width="770" style="border:0;margin:0px;padding:0px;"/>',
     {
         closeHTML: "<a href='#' title='Close' class='modal-close'>x</a>",
         containerCss: {
             backgroundColor: "#fff",
             borderColor: "#ccc",
             top:-15,
	         right:8,
             height: 430,
             margin: 0,
             padding: 0,
             width: 770
         },
         overlayClose: true
     });
 }
 function openCacheAD(adpage, position, seq) {
     if (!position) { position = ""; }
     if (!seq) { seq = ""; }
     var src = "/cache/ad.aspx?adpage=" +  encodeURI(adpage) + "&ADPagePosition=" + position + "&seq=" + seq
//     $.ajax({
//         url: src,
//         cache: false,
//         beforeSend: function () {
//             $.modal("<div style=background:#ffffff>页面正在刷新广告，请稍后.......&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br><br><br><img  src='/images/progressbar_green.gif'/></div>");
//         },
//         success: function (data) {
//             alert(data);
//             //$.modal("<div>" + data + "</div>");

//         }
//     });


    // window.open(src,"_blank","width:800,height:500");
     $.modal('<iframe src="' + src + '" height="500" width="800" style="border:0;margin:0px;padding:0px;"/>',
     {

         closeHTML: "<div class=div_nav_title2 style='text-align:right;cursor:pointer;font-weight:bold;margin:0px;padding:0px;'><div style='float:left;padding-left:20px'>位置：生成广告数据</div><div style='float:right;padding-right:20px;'>关闭</div></div>",
         closeClass: "modalClose",
         escClose: true,
         containerCss: {
             backgroundColor: "#fff",
             borderColor: "#cccccc",

             height: 525,
             margin: 0,
             padding: 0,
             width: 800

         },
         dataCss: {

             height: 500,
             margin: 0,
             padding: 0,
             width: 800
         },
         pacity: 10,
         overlayClose: true
     }) ;
 }


 function openUpload() {
     //var src = "/upload/ImgList.aspx";
     var src = "/fckeditor/editor/dialog/InsertFile/InsertFile.aspx?type=TitlePic"
     $.modal('<iframe src="' + src + '" height="240" width="506" style="border:0;margin:0px;padding:0px;"/>',
     {
         escClose: true,
         containerCss: {
             backgroundColor: "#fff",
             borderColor: "#cccccc",
             height: 240,
             margin: 0,
             padding: 0,
             width: 506
         },
         dataCss: {
             height: 240,
             margin: 0,
             padding: 0,
             width: 506
         },
         pacity: 10,
         overlayClose: true
     });
 }
 function openwin(url, target, w, h) 
 { 
 var  f="width="+w+",height="+h;
 window.open(url, target, f);
 
 }

