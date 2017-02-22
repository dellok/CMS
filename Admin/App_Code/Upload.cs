using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LL.Common.EnumClass;
using LL.Common;
using LL.Common.Cache;
using Project.Common;
using System.Web.UI.WebControls;
using LL.BLL;

/// <summary>
///Upload 
/// </summary>
public class Upload
{
     public Upload()
    {
        //
        //
        //
    }

     #region 应用于vip后台上传图片 
     public static string  VipUploadFile(FileClass fileClass,FileInfoType fileInfoType,BLLUploadManager upManager,FileUpload up)
    {

        string[] allowedImgExtension = ConfigManager.UploadImgExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
 
        string imgPath = "";
        if (up.HasFile)
        {
            //得到扩展名
            string extension = System.IO.Path.GetExtension(up.FileName).Replace(PubConstant.Key_Sign_Dot, "").ToLower().Trim();
            bool isExtension = false;

            if (fileClass == FileClass.Image)
            {
                isExtension = allowedImgExtension.Contains(extension);
            }
        
            if (isExtension)
            {

                bool isUpOk = upManager.UploadFile(up, fileClass, fileInfoType);

                if (isUpOk)
                {
                    imgPath = upManager.FileUrlAbsolutePath;
                }
                else
                {
                    JsAlert.ShowAlert(upManager.ErrMsg);
                }

            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_Upload_Extenstion_Error);

            }

        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_Upload_NeedInput);

        }
        return imgPath;
    }


     #endregion
}