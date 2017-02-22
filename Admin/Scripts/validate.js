
/*
用途：校验ip地址的格式 
输入：strIP：ip地址 
返回：如果通过验证返回true,否则返回false
*/ 

function isIP(strIP) { 
if (isNull(strIP)) return false; 
var re=/^(\d+)\.(\d+)\.(\d+)\.(\d+)$/g //匹配IP地址的正则表达式 
if(re.test(strIP)) 
{ 
if( RegExp.$1 <256 && RegExp.$2<256 && RegExp.$3<256 && RegExp.$4<256) return true; 
} 
return false; 
} 

/* 
用途：检查输入字符串是否为空或者全部都是空格 
输入：str 
返回： 
如果全是空返回true,否则返回false 
*/ 

function isNull(str){ 
if ( str == "" ) return true; 
var regu = "^[ ]+$"; 
var re = new RegExp(regu); 
return re.test(str); 
} 

/* 
用途：检查输入对象的值是否符合整数格式 
输入：str 输入的字符串 
返回：如果通过验证返回true,否则返回false 
*/ 

function isInteger(str){  
var regu = /^[-]{0,1}[0-9]{1,}$/; 
return regu.test(str); 
} 

/* 
用途：检查输入手机号码是否正确 
输入： 
s：字符串 
返回： 
如果通过验证返回true,否则返回false 
*/ 
function checkMobile( s ){   
var regu =/^[1][3][0-9]{9}$/; 
var re = new RegExp(regu); 
if (re.test(s)) { 
return true; 
}else{ 
return false; 
} 
} 

 

/* 
用途：检查输入字符串是否符合正整数格式 
输入： 
s：字符串 
返回： 
如果通过验证返回true,否则返回false 
*/ 
function isNumber( s ){   
var regu = "^[0-9]+$"; 
var re = new RegExp(regu); 
if (s.search(re) != -1) { 
return true; 
} else { 
return false; 
} 
} 
/* 
用途：检查输入字符串是否是带小数的数字格式,可以是负数 
输入： 
s：字符串 
返回： 
如果通过验证返回true,否则返回false 
*/ 

function isDecimal(str){   
if(isInteger(str)) return true; 
var re = /^[-]{0,1}(\d+)[\.]+(\d+)$/; 
if (re.test(str)) { 
if(RegExp.$1==0&&RegExp.$2==0) return false; 
return true; 
} else { 
return false; 
} 
} 
/* 
用途：检查输入对象的值是否符合端口号格式 
输入：str 输入的字符串 
返回：如果通过验证返回true,否则返回false 
*/ 
function isPort(str){  
return (isNumber(str) && str<65536); 
} 

/* 
用途：检查输入对象的值是否符合E-Mail格式 
输入：str 输入的字符串 
返回：如果通过验证返回true,否则返回false 
*/ 

function isEmail(str){  
var myReg = /^[-_A-Za-z0-9]+@([_A-Za-z0-9]+\.)+[A-Za-z0-9]{2,3}$/; 
if(myReg.test(str)) return true; 
return false; 
} 

/* 
用途：检查输入字符串是否符合金额格式 
格式定义为带小数的正数，小数点后最多三位 
输入： 
s：字符串 
返回： 
如果通过验证返回true,否则返回false 
*/ 

function isMoney( s ){   
var regu = "^[0-9]+[\.][0-9]{0,3}$"; 
var re = new RegExp(regu); 
if (re.test(s)) { 
return true; 
} else { 
return false; 
} 
} 
/* 
用途：检查输入字符串是否只由英文字母和数字和下划线组成 
输入： 
s：字符串 
返回： 
如果通过验证返回true,否则返回false 
*/ 
function isNumberOr_Letter( s ){//判断是否是数字或字母 
var regu = "^[0-9a-zA-Z\_]+$"; 
var re = new RegExp(regu); 
if (re.test(s)) { 
return true; 
}else{ 
return false; 
} 
} 
/* 
用途：检查输入字符串是否只由英文字母和数字组成 
输入： 
s：字符串 
返回： 
如果通过验证返回true,否则返回false 
*/ 

function isNumberOrLetter( s ){//判断是否是数字或字母 

var regu = "^[0-9a-zA-Z]+$"; 

var re = new RegExp(regu); 

if (re.test(s)) { 

return true; 

}else{ 

return false; 

} 

} 

/* 

用途：检查输入字符串是否只由汉字、字母、数字组成 
输入： 
value：字符串 
返回： 
如果通过验证返回true,否则返回false 
*/ 
function isChinaOrNumbOrLett( s ){//判断是否是汉字、字母、数字组成 
var regu = "^[0-9a-zA-Z\u4e00-\u9fa5]+$";   
var re = new RegExp(regu); 
if (re.test(s)) { 
return true; 
}else{ 
return false; 
} 
} 
/* 
用途：判断是否是日期 
输入：date：日期；fmt：日期格式 
返回：如果通过验证返回true,否则返回false 
*/ 

function isDate( date, fmt ) { 
if (fmt==null) fmt="yyyyMMdd"; 
var yIndex = fmt.indexOf("yyyy"); 
if(yIndex==-1) return false; 
var year = date.substring(yIndex,yIndex+4); 
var mIndex = fmt.indexOf("MM"); 
if(mIndex==-1) return false; 
var month = date.substring(mIndex,mIndex+2); 
var dIndex = fmt.indexOf("dd"); 
if(dIndex==-1) return false; 
var day = date.substring(dIndex,dIndex+2); 
if(!isNumber(year)||year>"2100" || year< "1900") return false; 
if(!isNumber(month)||month>"12" || month< "01") return false; 
if(day>getMaxDay(year,month) || day< "01") return false; 
return true; 
} 

function getMaxDay(year,month) { 
if(month==4||month==6||month==9||month==11) 
return "30"; 
if(month==2) 
if(year%4==0&&year%100!=0 || year%400==0) 
return "29"; 
else 
return "28"; 
return "31"; 
} 

/* 
用途：字符1是否以字符串2结束 
输入：str1：字符串；str2：被包含的字符串 
返回：如果通过验证返回true,否则返回false 
*/ 

function isLastMatch(str1,str2) 
{  
var index = str1.lastIndexOf(str2); 
if(str1.length==index+str2.length) return true; 
return false; 
} 

 

/* 
用途：字符1是否以字符串2开始 
输入：str1：字符串；str2：被包含的字符串 
返回：如果通过验证返回true,否则返回false 
*/ 
function isFirstMatch(str1,str2) 
{  
var index = str1.indexOf(str2); 
if(index==0) return true; 
return false; 
} 

/* 
用途：字符1是包含字符串2 
输入：str1：字符串；str2：被包含的字符串 
返回：如果通过验证返回true,否则返回false 
*/ 
function isMatch(str1,str2) 
{  
var index = str1.indexOf(str2); 
if(index==-1) return false; 
return true; 
} 

 

/* 

用途：检查输入的起止日期是否正确，规则为两个日期的格式正确， 
且结束如期>=起始日期 
输入： 
startDate：起始日期，字符串 
endDate：结束如期，字符串 
返回： 
如果通过验证返回true,否则返回false 

*/ 

function checkTwoDate( startDate,endDate ) { 

if( !isDate(startDate) ) { 

alert("起始日期不正确!"); 

return false; 

} else if( !isDate(endDate) ) { 

alert("终止日期不正确!"); 

return false; 

} else if( startDate > endDate ) { 

alert("起始日期不能大于终止日期!"); 

return false; 

} 

return true; 

} 

/* 

用途：检查输入的Email信箱格式是否正确 

输入： 

strEmail：字符串 

返回： 

如果通过验证返回true,否则返回false 

*/ 

function checkEmail(strEmail) { 

//var emailReg = /^[_a-z0-9]+@([_a-z0-9]+\.)+[a-z0-9]{2,3}$/; 

var emailReg = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/; 

if( emailReg.test(strEmail) ){ 

return true; 

}else{ 

alert("您输入的Email地址格式不正确！"); 

return false; 

} 

} 

/* 

用途：检查输入的电话号码格式是否正确 

输入： 

strPhone：字符串 

返回： 

如果通过验证返回true,否则返回false 

*/ 

function checkPhone( strPhone ) { 

var phoneRegWithArea = /^[0][1-9]{2,3}-[0-9]{5,10}$/; 

var phoneRegNoArea = /^[1-9]{1}[0-9]{5,8}$/; 

var prompt = "您输入的电话号码不正确!" 

if( strPhone.length > 9 ) { 

if( phoneRegWithArea.test(strPhone) ){ 

return true; 

}else{ 

alert( prompt ); 

return false; 

} 

}else{ 

if( phoneRegNoArea.test( strPhone ) ){ 

return true; 

}else{ 

alert( prompt ); 

return false; 

} 

 

} 

} 

 

/* 

用途：检查复选框被选中的数目 

输入： 

checkboxID：字符串 

返回： 

返回该复选框中被选中的数目 

*/ 

function checkSelect( checkboxID ) { 

var check = 0; 

var i=0; 

if( document.all(checkboxID).length > 0 ) { 

for(  i=0; i<document.all(checkboxID).length; i++ ) { 

if( document.all(checkboxID).item( i ).checked  ) { 

check += 1; 

} 

 

 

} 

}else{ 

if( document.all(checkboxID).checked ) 

check = 1; 

} 

return check; 

} 

function getTotalBytes(varField) { 

if(varField == null) 

return -1; 

var totalCount = 0; 

for (i = 0; i< varField.value.length; i++) { 

if (varField.value.charCodeAt(i) > 127) 

totalCount += 2; 

else 

totalCount++ ; 

} 

return totalCount; 

} 

function getFirstSelectedValue( checkboxID ){ 

var value = null; 

var i=0; 

if( document.all(checkboxID).length > 0 ){ 

for(  i=0; i<document.all(checkboxID).length; i++ ){ 

if( document.all(checkboxID).item( i ).checked ){ 

value = document.all(checkboxID).item(i).value; 

break; 

} 

} 

} else { 

if( document.all(checkboxID).checked ) 

value = document.all(checkboxID).value; 

} 

return value; 

} 

 

function getFirstSelectedIndex( checkboxID ){ 

var value = -2; 

var i=0; 

if( document.all(checkboxID).length > 0 ){ 

for(  i=0; i<document.all(checkboxID).length; i++ ) { 

if( document.all(checkboxID).item( i ).checked  ) { 

value = i; 

break; 

} 

} 

} else { 

if( document.all(checkboxID).checked ) 

value = -1; 

} 

return value; 

} 

function selectAll( checkboxID,status ){ 

if( document.all(checkboxID) == null) 

return; 

if( document.all(checkboxID).length > 0 ){ 

for(  i=0; i<document.all(checkboxID).length; i++ ){ 

document.all(checkboxID).item( i ).checked = status; 

} 

} else { 

document.all(checkboxID).checked = status; 

} 

} 

function selectInverse( checkboxID ) { 

if( document.all(checkboxID) == null) 

return; 

if( document.all(checkboxID).length > 0 ) { 

for(  i=0; i<document.all(checkboxID).length; i++ ) { 

document.all(checkboxID).item( i ).checked = !document.all(checkboxID).item( i ).checked; 

} 

} else { 

document.all(checkboxID).checked = !document.all(checkboxID).checked; 

} 

} 

function checkDate( value ) { 

if(value=='') return true; 

if(value.length!=8 || !isNumber(value)) return false;  

var year = value.substring(0,4); 

if(year>"2100" || year< "1900") 

return false; 

var month = value.substring(4,6); 

if(month>"12" || month< "01") return false; 

var day = value.substring(6,8); 

if(day>getMaxDay(year,month) || day< "01") return false; 

return true;  

} 

/* 

用途：检查输入的起止日期是否正确，规则为两个日期的格式正确或都为空 

且结束日期>=起始日期 

输入： 

startDate：起始日期，字符串 

endDate：  结束日期，字符串 

返回： 

如果通过验证返回true,否则返回false 

*/ 

function checkPeriod( startDate,endDate ) { 

if( !checkDate(startDate) ) { 

alert("起始日期不正确!"); 

return false; 

} else if( !checkDate(endDate) ) { 

alert("终止日期不正确!"); 

return false; 

} else if( startDate > endDate ) { 

alert("起始日期不能大于终止日期!"); 

return false; 

} 

return true; 

} 

/* 

用途：检查证券代码是否正确 

输入： 

secCode:证券代码 

返回： 

如果通过验证返回true,否则返回false 

*/ 

function checkSecCode( secCode ) { 

if( secCode.length !=6 ){ 

alert("证券代码长度应该为6位"); 

return false; 

} 

if(!isNumber( secCode ) ){ 

alert("证券代码只能包含数字"); 

 

return false; 

} 

return true; 

} 

/**************************************************** 

function:cTrim(sInputString,iType) 

description:字符串去空格的函数 

parameters:iType：1=去掉字符串左边的空格 

2=去掉字符串左边的空格 

0=去掉字符串左边和右边的空格 

return value:去掉空格的字符串 

****************************************************/ 

function cTrim(sInputString,iType) 

{ 

var sTmpStr = ' '; 

var i = -1; 

if(iType == 0 || iType == 1) 

{ 

while(sTmpStr == ' ') 

{ 

++i; 

sTmpStr = sInputString.substr(i,1); 

} 

sInputString = sInputString.substring(i); 

} 

if(iType == 0 || iType == 2) 

{ 

sTmpStr = ' '; 

i = sInputString.length; 

while(sTmpStr == ' ') 

{ 

--i; 

sTmpStr = sInputString.substr(i,1); 

} 

sInputString = sInputString.substring(0,i+1); 

} 

return sInputString; 

} 



/***
    用途：验证是不是汉字
    输入:汉字
***/
function allGBK(str) 
{
   for (i = 0; i < str.length; i++) 
   {
      if (!(((str.charCodeAt(i) >= 0x3400) && (str.charCodeAt(i) < 0x9FFF)) || (str.charCodeAt(i) >= 0xF900)))
      {
         return false;
      }
   }
   return true;
}
function isChinese(str)
{
    if(!allGBK(str)){
     // alert("非汉字");
	  return false;
     
	}
	 //alert("是汉字");
    return true;
}





/**
   用途：验证留言信息
   输入：留言内容
   结果：合法不为空就提交否则不提交
**/
function  valileaMsg(obj){
     if(!isNull(obj)){
        var content = $("#"+obj).val();
        alert(content);
     }else{
       alert("不能说空话！");
     }
     
}

/***
   用途：验证输入的用户信息
   输入: 用户联系方式表单
   结果：是否提交
**/
function   valiContact(){
        //qq/msn/mobliePhone/Tel
        var msn=document.getElementById("id_msn").value;
        alert(msn);
}

/**
   用途：验证用户兴趣
   输入：用户兴趣
   结果：合法就提交
**/
function  valiInterest(){


}
/**
   用户：验证注册
**/

function ltrim(s){
return s.replace( /^\s*/, "");
}
//去右空格;
function rtrim(s){
return s.replace( /\s*$/, "");
}
//左右空格;
function trim(s){
return rtrim(ltrim(s));
}

//全局变量
var tipimg="<img src=http://pic.uusee.com/images/ch01.jpg align=absmiddle style=float:left; />";


function valiReg(){
var key=$("#tipemail").text();
  var email=document.reg.email.value;
  var resideprovince=document.reg.resideprovince.value;
  var residecity=document.reg.residecity.value;
  
  if(ckmail() && ckNick() && ckPass()&&key=="可以使用")
    {
         if(document.reg.protocol.checked==false)
		   {
		     //alert("是否接受协议？");
		     $("#xieyi").show();
		     return false;  
		   }
		  else{
		    $("#xieyi").hide;
		     if(resideprovince==""||residecity=="")
		     {
		       //alert("");
		       document.getElementById("tipcity").innerHTML=tipimg+"选择居住地！";
		       return false;
		     }
		     else{
		     //document.reg.regbut.disabled=true;
		     document.getElementById('regbut').style.display='none';
		     return true;
		     }
		    
		  } 
        return false;
    }
  else{
      return false;
  }
  return false;
}

//email失去了焦点

function ckmail(){
  var email=   document.reg.email.value;
  var passWord=document.reg.passWord.value;
  var nickName=trim(document.reg.nickName.value);
  if(email.length==0&&passWord.length==0&&nickName.length==0){
     $("#tipemail").fadeIn("fast");//显示电子邮件格式不正确
          $("#tipemail").empty().append(""+tipimg+"请输入有效的邮箱");
  }
  else{
    if(!isNull(email)){//电子邮件不空
        if(isEmail(email)){//是合格电子邮件
           OnlyYoumail(email);//去验证唯一性
           
        }else{
          $("#tipemail").fadeIn("fast");//显示电子邮件格式不正确
          $("#tipemail").empty().append(""+tipimg+"电子邮箱格式不对");
          return false;
           }
    }else{
       $("#tipemail").fadeIn("fast");
       $("#tipemail").empty().append(""+tipimg+"请输入有效的邮箱地址，当密码遗失时，凭此领取");
        return false;
      }
  
  
  }
  
  
  return true;
}

//注册提示信息
function onFocusInfoHint(id){
	if(id=='regmails'){
		document.getElementById("tipemail").style.display = "";
		document.getElementById("tipemail").innerHTML = tipimg+"请填写您常用邮箱地址!";
	}else{
		//document.getElementById("tipemail").style.display = "none";
	}
	if(id=='paswd'){
		document.getElementById("psswd").style.display = "";
		document.getElementById("psswd").innerHTML = tipimg+"密码长度不能小于6位!";
	}else{
		document.getElementById("psswd").style.display = "none";
	}
	if(id=='regpass'){
		document.getElementById("tippass").style.display = "";
		document.getElementById("tippass").innerHTML = tipimg+"请再重复输入一次密码!";
	}else{
		document.getElementById("tippass").style.display = "none";
	}
	if(id=='regnick'){
		document.getElementById("tipnick").style.display = "";
		document.getElementById("tipnick").innerHTML = tipimg+"长度不超过10个英文字或5个汉字！";
	}else{
		document.getElementById("tipnick").style.display = "none";
	}
}

//失去焦点提示信息消失
function onBlurInfoHide(id){
	if(id=='paswd'){
		document.getElementById("psswd").innerHTML = "";
		document.getElementById("psswd").style.display = "none";
	}
	if(id=='regpass'){
		document.getElementById("tippass").innerHTML = "";
		document.getElementById("tippass").style.display = "none";
	}
	if(id=='regnick'){
		document.getElementById("tipnick").innerHTML = "";
		document.getElementById("tipnick").style.display = "none";
	}
}


//password失去了焦点
$("#regpass").focus(function(){
  $("#tippass").empty().append(""+tipimg+"请再输入一次上面的密码");
  $("#tippass").show();
   
}); 

function  ckNick(){
$("#dtnick").show();
   var nickName=trim(document.reg.nickName.value);
   if(nickName.length>0){
				var count = 0;
                var reg = /[^\x00-\xff]/g;
                var str = nickName;
                var result = str.match(reg)
                for (var i = 0; i < str.split("").length; i++) {
                    count = (str.split("")[i].match(reg)) ? count + 2 : count + 1;
                }
                if (count > 10) {
				      $("#tipnick").empty().append(""+tipimg+"长度不超过10个英文字或5个汉字");
					  $("#tipnick").show();
                    return false;
				}else{
					return true
				}
					return false;
	}
   else{
        $("#tipnick").empty().append(""+tipimg+"请输入昵称");
        $("#tipnick").show();
        return false;
   }
  
   return true;
} 

function ckPass() { 
         $("#tippass").empty();
	     var passWord=document.reg.passWord.value;
         var pass2=document.reg.pass2.value;
         if(!isNull(passWord)&&!isNull(pass2))
         {//非空
             if(passWord==pass2)
              {
                if(passWord.length<=20&&passWord.length>=6){
                   return true;     
                }else{
                  $("#tippass").empty().append(""+tipimg+"密码必须由6-20个字符组成");
                  $("#tippass").show();
                  return false;
                }
              }
              else
              {
               $("#tippass").empty().append(""+tipimg+"两次密码不一致");
               $("#tippass").show();
               return false;
              }
              return true;
         }else{
                $("#tippass").empty().append(""+tipimg+"请再输入一次上面的密码");
                  $("#tippass").show();
                  return false;
         }
      }
        

/**
   用途：验证EMAIL是否被占用
**/

/**
 General Ajax
**/

 var xmlHttp;
  //创建HTTP请求
 function createXMLHttpRequest() {
   if (window.ActiveXObject) {
      xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");//IE
   }
   else if (window.XMLHttpRequest) {
      xmlHttp = new XMLHttpRequest();//FF
   }
 }

 function OnlyYoumail(str) {
	   createXMLHttpRequest();
	   var url = "/users/onlymail/"+str+"/";
	   xmlHttp.onreadystatechange = callback;
	   xmlHttp.open("GET", url, true);
	   xmlHttp.send(null);
	  
}
//返回处理



function callback()
{ 
   if (xmlHttp.readyState == 4) {
       if (xmlHttp.status == 200) {
           //响应成功
           if(xmlHttp.responseText=="H"){
             //已经存在
             $("#tipemail")
             $("#tipemail").empty().append(""+tipimg+"已经存在");
             $("#tipemail").show();
            
           }else{
             //可以使用
             $("#tipemail").empty().append(""+tipimg+"可以使用");
              $("#tipemail").show();
           }
           
       }else{
           //请求失败
       }       
   }
   else
   {
        
   }
}  
