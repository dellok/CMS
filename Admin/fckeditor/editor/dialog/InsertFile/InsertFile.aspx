<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertFile.aspx.cs" Inherits="fckeditor_editor_dialog_InsertFile_InsertFile" %>

 
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="Stylesheet" href="/Css/main.css" type="text/css" />
        <script src="../../../../Scripts/jquery1.4.2.js" type="text/javascript"></script>

        <script src="../common/fck_dialog_common.js" type="text/javascript"></script>

        <style type="text/css">
         
         body,table,form,dir{width:500px;}
        </style>
    <script>
        var oEditor = window.parent.InnerDialogLoaded();
        var FCK = oEditor.FCK;
        var FCKLang = oEditor.FCKLang;
        var FCKConfig = oEditor.FCKConfig;
        var FCKDebug = oEditor.FCKDebug;


        var bPreviewInitialized;

        window.onload = function () {
            window.parent.SetOkButton(true); //"确定"按钮可以用
        }

        function Ok()//“确定"相应事件
        {

       
            if (GetE('txtUrl').value.length == 0)//源文件
            {
                alert("请选择文件!");
                return false;
            }
            var oFile;
            oFile = FCK.EditorDocument.createElement('a');
            oFile.href = GetE('txtUrl').value;

            oFile.target = '_blank';
            oFile.innerHTML = GetE('txtFileName').value; //显示文字
                oFile = FCK.InsertElementAndGetIt(oFile);
            return true;
        }

        ///引用标题图片
        function titlePic()
         {


            if (GetE('txtUrl').value.length == 0)//源文件
            {
                alert("【附件/图片 地址】 不能为空!");
                return false;
            }

            parent.document.getElementById("txtTitlePicUrl").value = GetE('txtUrl').value;
          
          
            window.close();
            parent.$.modal.close();
       

        }


    </script>


</head>
<body style="margin:0px auto;">
    <form id="form1" runat="server" >
       
       
         <table cellspacing="0" cellpadding="0" border="0" style="border:1px solid  #cccccc;" align="center" >
         <tr>
         <td colspan="2"><div class="div_nav_title2">&nbsp;&nbsp;附件/图片添加</div></td>
         </tr>
            <tr>
                <td  style="width:120px;height:30px;font-weight:bolder;text-align:right;">
                    附件/图片 地址：</td>
            
                <td >
           
                <asp:TextBox ID="txtUrl"   runat="server" Width="99%" ClientIDMode="Static"></asp:TextBox>
           
                </td>
            </tr>
            <tr>
                <td  style="width:120px;height:30px;font-weight:bolder;text-align:right;">
                    <span>显示文本：</span>
                </td>
          
                <td >
  
                      <asp:TextBox ID="txtFileName"   runat="server" Width="99%" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td></td>
                <td  style="height:30px;">
                    <input id="btnInsertText" type="button" value="插入文本中" style="font-size: 8pt;" onclick=" Ok()" runat="server" class="btn_2k3"  />&nbsp;  
                     <input id="btnTitlePic" type="button" value="标题图片引用" style="font-size: 8pt;" onclick="titlePic()" runat="server" class="btn_2k3"   />
                    <span class="style1">&nbsp;(如果是设置标题图片 则不用输入【显示文本】)</span></td>
            </tr>
          
            
              </table> 

    <div class="div_search" style="margin-top:10px;padding-bottom:10px;border:1px solid  #cccccc;" >
      <div class="div_nav_title2">&nbsp;&nbsp;上传 附件/图片</div>
        <div id="divUpload " >
            <span class="span_search_label">上传附件：</span>
            <asp:FileUpload ID="up" runat="server"  />
            &nbsp;&nbsp;<asp:Button ID="btnUpload" runat="server" Text=" 上 传 " CssClass="btn_2k3"
                 OnClick="btnUpload_Click"  />
            <br />
        </div>
      
    </div>
            
      



 

 
  
  
    </form>
</body>
</html>
