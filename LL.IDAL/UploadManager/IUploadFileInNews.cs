using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LL.IDAL.UploadManager;

namespace CLB.IDAL.UploadManager
{
  public   interface IUploadFileInNews
    {


      int Add(UploadFileInNews model);

      int Delete(int newsID, int uploadFileID, int fileInfoType);

      int Delete(int newsID, int newClassID, string uploadFileName, int fileInfoType);

      int BatchAdd(List<int> arrNewsID,int newClassID, List<int> UploadFileID,int fileIntoType);
      int BatchAdd(List<int> arrNewsID, int newClassID, List<string> UploadFileName, int fileIntoType);


      int BatchDelete(List<int> arrNewsID, int newClassID, List<int> UploadFileID, int fileIntoType);
      int BatchDelete(List<int> arrNewsID, int newClassID, List<string> UploadFileName, int fileIntoType);

    }
}
