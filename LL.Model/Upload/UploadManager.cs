using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Model.Upload
{
  public   class UploadManager
    {
        /// <summary>
        /// 存入数据时生成的ID
        /// </summary>
      public int FileID
      {
          get;
          set;
      }
      public string FileName
      {
          get;
          set;
      }

        /// <summary>
        /// 文件类型img flash ,doc 
        /// </summary>
        public int FileClass
        {
            get ;
            set ;
        }
        /// <summary>
        /// 文件大小:kb
        /// </summary>
        public int FileSize
        {
            get;
            set;
        }
        /// <summary>
        /// 文件信息类型
        /// </summary>
        public int FileInfoType
        {
            get;
            set;
        }

        /// <summary>
        /// 文件最在容量
        /// 默认为: 524288 btye  既512kb
        /// </summary>
        public int FileMaxSize
        {
            get;
            set;
        }
        /// <summary>
        /// 上传后的文件相对路径
        /// 不加域名前缀
        /// </summary>
        public string FileUrlPath
        {
            get;
            set;
        }
        public string FileUrlAbsolutePath
        {
            get;
            set;
        }
        /// <summary>
        /// 文件物理路径
        /// </summary>
        public string FilePhysicsPath
        {
            get;
            set;
        }
        /// <summary>
        /// 上传错误时的消息
        /// </summary>
        public string ErrMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 上传成功时的消息
        /// </summary>
        public string OkMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 上传是否成功
        /// </summary>
        public bool IsUploadSuccess
        {
            get;
            set;
        }

        private string _UploadUser;

        public string UploadUser
        {
            get { return _UploadUser; }
            set { _UploadUser = value; }
        }



        private int _NewsID;
        public int NewsID
        {
            get { return _NewsID; }
            set { _NewsID = value; }
        }




        private int _NewsClassID;
        public int NewsClassID
        {
            get { return _NewsClassID; }
            set { _NewsClassID = value; }
        }



        private string _No;


        private int _Hit;

        private int _CJID;

        private int _FPathath;

        private bool _IsRecycle;

        private int _UploadUserRole;
        public int UploadUserRole
        {
            get { return _UploadUserRole; }
            set { _UploadUserRole = value; }
        }

        private int _UserID;


        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }


        public string Title { get; set; }
    }
}
