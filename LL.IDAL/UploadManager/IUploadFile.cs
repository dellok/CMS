using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.Upload;


namespace LL.IDAL.IUploadFile
{
   public  interface IUploadFile:IBase<UploadFile>
    {
       System.Data.DataSet GetList(int PageIndex, int PageSize, string where);
       /// <summary>
       /// 上传的文件放入回收站
       /// </summary>
       /// <param name="newsID"></param>
       /// <param name="fileInfoType"></param>
       /// <returns></returns>
       int SetUploadFileToRecycle(int newsID, int fileInfoType);

       int BatchDel(List<int> arrIDS);
      int  DelDataAndFile(int id);

 

      System.Data.DataSet GetVipMemberPic(int PageIndex, int PageSize, int UserID, int ClassID, int FileInfoType);
    }
}
