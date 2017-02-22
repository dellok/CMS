using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LL.Common.Cache;
using System.Text;
using LL.Common.EnumClass;
using System.Linq;
using System.Data.Linq;
using System.IO;
using LL.Common;
using LL.BLL.Upload;
using LL.Model.Upload;
namespace LL.BLL
{
    public class BLLUploadManager
    {
        /*
          1.文件存储格式与p
         *  栏目或类型名称/年月/日/最终文件
         * 2.文件存放路径规则:
         *   /栏目/文件类型/年月/日/
         */

        /// <summary>
        /// 根物理路径
        /// </summary>
        private string rootPhysicalPath = ConfigManager.ImgDomainRootPath;
        /*
          1.图片最大size  ,字件   1m=1024kb=  1kb=1024bit  字节 
          2. 1m=1048576 bit
         */

        private readonly long MaxImageSize = 1048576;
        //最大100m
        private readonly long MaxOtherFileSize = 104857600;

        private string errmsg = "";//上传成功的消息
        private string okmsg = "";//上传失败的消息

        /* private string[] allowedImgExtension = { };
         private string[] allowFlashExtension = { };
         private string[] allowMediaExtension = { };
         private string[] allowOtherExtension = { };
         private string[] diableExtension = { };

  */
        private string[] allowedImgExtension = ConfigManager.UploadImgExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
        private string[] allowFlashExtension = ConfigManager.UploadFlashExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
        private string[] allowMediaExtension = ConfigManager.UploadMediaExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
        private string[] allowOtherExtension = ConfigManager.UploadOtherExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
        private string[] diableExtension = ConfigManager.UploadDisabledExtension.Split(new char[] { PubConstant.Key_Sign_CommaSign });
        /// <summary>
        /// 文件最终路径
        /// </summary>
        private string physicalPath = "";
        //相对路径
        private string urlPath = "";

        private int _fileMaxSize = 524288;
        private string _fileName = "";
        private int id = 0;

        private int _fileType = 0;
        private int _fileInfoType = 0;
        private int _fileSize = 0;
        private string _fileUrlAbsolutePath = "";

        /// <summary>
        /// 是否上传成功
        /// </summary>
        private bool _isUploadSuccess = false;

        public BLLUploadManager()
        {
        }
        #region 一些属性
        /// <summary>
        /// 存入数据时生成的ID
        /// </summary>
        public int FileID
        {
            get { return id; }
            set { id = value; }
        }
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        /// <summary>
        /// 文件类型img flash ,doc 
        /// </summary>
        public int FileClass
        {
            get { return _fileType; }
            set { _fileType = value; }
        }
        /// <summary>
        /// 文件大小:kb
        /// </summary>
        public int FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }
        /// <summary>
        /// 文件信息类型
        /// </summary>
        public int FileInfoType
        {
            get { return _fileInfoType; }
            set { _fileInfoType = value; }
        }

        /// <summary>
        /// 文件最在容量
        /// 默认为: 524288 btye  既512kb
        /// </summary>
        public int FileMaxSize
        {
            get { return _fileMaxSize; }
            set { _fileMaxSize = value; }
        }
        /// <summary>
        /// 上传后的文件相对路径
        /// 不加域名前缀
        /// </summary>
        public string FileUrlPath
        {
            get { return urlPath; }
            set { urlPath = value; }
        }
        public string FileUrlAbsolutePath
        {
            get { return _fileUrlAbsolutePath; }
            set { _fileUrlAbsolutePath = value; }
        }
        /// <summary>
        /// 文件物理路径
        /// </summary>
        public string FilePhysicsPath
        {
            get { return physicalPath; }
            set { physicalPath = value; }
        }
        /// <summary>
        /// 上传错误时的消息
        /// </summary>
        public string ErrMsg
        {
            get { return errmsg; }
            set { errmsg = value; }
        }
        /// <summary>
        /// 上传成功时的消息
        /// </summary>
        public string OkMsg
        {
            get { return okmsg; }
            set { okmsg = value; }
        }
        /// <summary>
        /// 上传是否成功
        /// </summary>
        public bool IsUploadSuccess
        {
            get { return _isUploadSuccess; }
            set { _isUploadSuccess = value; }
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

        #endregion





        #region upload
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns>文件上传到服务器的相对路径</returns>
        public bool UploadFile(FileUpload uf, FileClass fClass, FileInfoType ufType)
        {
            if (uf.HasFile)
            {
                //文件类型
                bool fileOk = false;
                //文件长度
                int fileLen = uf.PostedFile.ContentLength;
                FileSize = fileLen / 1024;
                //文件名称
                string fileName = uf.PostedFile.FileName;
                //文件扩展名
                string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();

                fileExtension = fileExtension.Replace(PubConstant.Key_Sign_Dot, "");
                //得到路径物理
                //设置文件类型及文件信息类型
                SetFileTypeAndFileInfoType(ufType, fileExtension);

                string strSaveDir = SeveFileDirecotry(fileExtension, fClass, ufType);

                if (fileLen < 1 || string.IsNullOrEmpty(fileName))
                {
                    ErrMsg = "请选择要上传的文件！";
                    return IsUploadSuccess;
                }
                //是大类

                if (ufType != LL.Common.EnumClass.FileInfoType.Other)
                {

                    if (fileLen > FileMaxSize * 1024)
                    {
                        ErrMsg = string.Format("上传的文件大小超过了规定大小(<={0} m)!", FileMaxSize / 1024);
                        return IsUploadSuccess;
                    }
                }
                //确定的类型
                fileOk = CheckFileExtension(fileExtension, fClass, ufType);
                if (fileOk)
                {
                    SaveFile(uf, strSaveDir, fileExtension);
                    return IsUploadSuccess;
                }
                else
                {
                    this.ErrMsg = "文件类型错误！";
                    return IsUploadSuccess;
                }
            }
            else
            {
                ErrMsg = "请选择上传文件!";
                return IsUploadSuccess;
            }
        }

     


        #region 修改上传文件
        public bool UploadFileModify(FileUpload uf, FileClass fClass, FileInfoType ufType, UploadFile bFile)
        {
            if (uf.HasFile)
            {
                //找到原文件路径 
                string imgRootPath = LL.Common.Cache.ConfigManager.ImgDomainRootPath;
                string pathUrl = ConfigManager.ImgDomin + bFile.Path;
                string fileAbsolutePath = bFile.Path.Replace(@"/", @"\");
                string bfilePhysicsPath = imgRootPath + fileAbsolutePath;
                string bFilePath = imgRootPath + fileAbsolutePath + bFile.FileName;
                string fileVirtualPath = ConfigManager.ImgDomin + bFile.Path + bFile.FileName;



                //文件类型
                bool fileOk = false;
                //文件长度
                int fileLen = uf.PostedFile.ContentLength;
                //文件名称
                //得到上传文件信息
                string fileName = uf.PostedFile.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);


                //文件最终路径   rootURL/UploadFileType/年月日/文件作
                if (fileLen < 1 || string.IsNullOrEmpty(fileName))
                {
                    ErrMsg = "请选择要上传的文件！";
                }
                if (fileLen >= MaxImageSize)
                {
                    ErrMsg = string.Format("上传的图片大小超过了规定大小(<={0} kb)!", MaxImageSize / 1024);

                }
                //是否是确定的类型
                fileOk = CheckFileExtension(fileExtension, fClass, ufType);
                if (fileOk)
                {

                    try
                    {
                        //重名称文件
                        //新的基于时间的随机文件名

                        if (!Directory.Exists(bfilePhysicsPath))
                        {
                            Directory.CreateDirectory(bfilePhysicsPath);
                        }

                        //存储图片
                        uf.PostedFile.SaveAs(bFilePath);
                        IsUploadSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        this.ErrMsg = "上传文件失败！<br>" + ex.ToString();
                    }
                }
                else
                {
                    this.ErrMsg = "文件类型错误！";
                }
            }
            else
            {

                ErrMsg = "请选择上传文件!";
            }

            return IsUploadSuccess;
        }
        #endregion
        /// <summary>
        /// 设置文件信息类型
        /// </summary>
        /// <param name="ufType"></param>
        /// <param name="fileExtension"></param>
        private int SetFileTypeAndFileInfoType(FileInfoType ufType, string fileExtension)
        {
            fileExtension = fileExtension.Replace(PubConstant.Key_Sign_Dot, "");
            FileInfoType = (int)ufType;


            if (allowedImgExtension.Contains(fileExtension))
            {

                FileClass = (int)LL.Common.EnumClass.FileClass.Image;
            }

            else if (allowFlashExtension.Contains(fileExtension))
            {
                FileClass = (int)LL.Common.EnumClass.FileClass.Flash;
            }
            else if (allowMediaExtension.Contains(fileExtension))
            {
                FileClass = (int)LL.Common.EnumClass.FileClass.Media;
            }
            else
            {
                FileClass = (int)LL.Common.EnumClass.FileClass.OtherFile;
            }

            return FileClass;

        }
        /// <summary>
        /// 判断文件扩展名
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <param name="fClass"></param>
        /// <param name="ufType"></param>
        /// <returns></returns>
        private bool CheckFileExtension(string fileExtension, FileClass fClass, FileInfoType ufType)
        {
            bool isOk = false;
            bool isDisabled = true;

            fileExtension = fileExtension.Replace(PubConstant.Key_Sign_Dot, "");
            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.ToLower();
            }
            ///默认为图片
            string[] matchExtension = allowedImgExtension;
            string[] allExtension = allowOtherExtension;

            isDisabled = diableExtension.Contains(fileExtension);
            if (isDisabled) { return isOk; }

            switch (fClass)
            {
                case LL.Common.EnumClass.FileClass.Image:
                    matchExtension = allowedImgExtension;
                    break;
                case LL.Common.EnumClass.FileClass.OtherFile:
                    matchExtension = allowOtherExtension;
                    break;
                case LL.Common.EnumClass.FileClass.Flash:
                    matchExtension = allowFlashExtension;
                    break;
                case LL.Common.EnumClass.FileClass.Media:
                    matchExtension = allowMediaExtension;
                    break;
            }
            //不限
            if (matchExtension.Length == 0)
            { isOk = true; }
            else
            { isOk = matchExtension.Contains(fileExtension); }
            return isOk;
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        private bool SaveFile(FileUpload uf, string strSaveDir, string fileExtension)
        {
            //重名称文件
            //新的基于时间的随机文件名
            string fileName = SetFileName(fileExtension);
            //文件在img 网站下的虚拟路径
            string fileVirtualPath = strSaveDir.Replace(PubConstant.Key_Sign_Backslash, PubConstant.Key_Sign_Slash);

            strSaveDir = string.Format("{0}{1}", ConfigManager.ImgDomainRootPath, strSaveDir);
            if (!System.IO.Directory.Exists(strSaveDir))
            {
                System.IO.Directory.CreateDirectory(strSaveDir);
            }

            string filePhysicsPath = string.Format("{0}{1}{2}", strSaveDir, PubConstant.Key_Sign_Backslash, FileName);
            //存储图片
            try
            {
                uf.PostedFile.SaveAs(filePhysicsPath);

                FileUrlPath = string.Format("{0}{1}", fileVirtualPath, PubConstant.Key_Sign_Slash);
                FileName = FileName;
                FileUrlAbsolutePath = string.Format("{0}{1}{2}", ConfigManager.ImgDomin, FileUrlPath, FileName);
                IsUploadSuccess = true;

                SaveFileToDB();
            }
            catch (Exception ex)
            {
                this.ErrMsg = "上传文件失败！<br>" + ex.ToString();
                IsUploadSuccess = false;
            }
            return IsUploadSuccess;
        }



        /// <summary>
        /// 生成新的文件夹名
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        private string SetFileName(string fileExtension)
        {
            FileName = string.Format("{0}{1}{2}", this.GetHashCode(), PubConstant.Key_Sign_Dot, fileExtension);
            return FileName;
        }



        /// <summary>
        /// 得到存放文件目录,绝对路径
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <param name="fClass"></param>
        /// <param name="ufType"></param>
        /// <returns></returns>
        private string SeveFileDirecotry(string fileExtension, LL.Common.EnumClass.FileClass fClass, LL.Common.EnumClass.FileInfoType ufType)
        {
            ///根据文件后缀自动建文件夹
            //去年.号
            string d = fileExtension.Replace(PubConstant.Key_Sign_Dot, "");
            StringBuilder pFilePath = new StringBuilder();

            pFilePath.AppendFormat("{0}{1}", PubConstant.Key_Sign_Backslash, ufType);

            if (fClass == LL.Common.EnumClass.FileClass.OtherFile)
            {
                // 以扩展名作为新的文件夹
                d = d.Substring(0, 1).ToUpper() + d.Substring(1).ToLower();

                pFilePath.AppendFormat("{0}{1}", PubConstant.Key_Sign_Backslash, fileExtension);
            }
            /*
                else
                {
                    pFilePath.AppendFormat("{0}{1}", PubConstant.Key_Sign_Backslash, fClass);
                })*/


            pFilePath.AppendFormat("{0}{1}{0}{2}", PubConstant.Key_Sign_Backslash, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MMdd"));
            //加上年月/日路径
            return pFilePath.ToString();
        }
        #endregion



        #region 存入数据库
        /// <summary>
        ///存入数据
        /// </summary>
        /// <param name="FileUrlPath"></param>
        private void SaveFileToDB()
        {

            BLLUploadFile bllUFile = new BLLUploadFile();
            UploadFile newFile = new UploadFile();
            newFile.FileInfoType = FileInfoType;
            newFile.FileClass = FileClass;
            newFile.FileName = FileName;
            newFile.FileSize = FileSize;
            newFile.Path = FileUrlPath;
            newFile.UserID = UserID;
            newFile.NewsClassID = NewsClassID;
            newFile.UploadUserRole = UploadUserRole;
            newFile.UploadUser = UploadUser;
            newFile.NewsID = NewsID;
            newFile.Title = Title;
            newFile.InDate = DateTime.Now;

            try
            {

              int id=  bllUFile.Add(newFile);
                FileID = id;

            }
            catch (Exception)
            {
            }
        }
        #endregion


        #region  删除数据

        public void Delete(int id)
        {
            ////找出数据

            //  DBLinqContext db = new DBLinqContext();


            //  System.Collections.Generic.List<UpFile> arrImgs= db.UpFile.Where(m => m.ID == id).ToList();

            //if (arrImgs.Count>0)
            //{

            //    UpFile imgFile = arrImgs[0];

            //    //得到路径


            //    string phyPath = string.Format("{0}{1}{2}",ConfigManager.ImgDomainRootPath,imgFile.Path.Replace("/",@"\"),imgFile.FileName);

            //    try
            //    {
            //        File.Delete(phyPath);
            //    }
            //    catch (Exception)
            //    {


            //    }



        }



        public void Delete(string fileName)
        {
            ////找出数据

            //DBLinqContext db = new DBLinqContext();


            //System.Collections.Generic.List<UpFile> arrImgs = db.UpFile.Where(m => m.FileName == fileName).ToList();

            //if (arrImgs.Count > 0)
            //{

            //    UpFile imgFile = arrImgs[0];

            //    //得到路径


            //    string phyPath = string.Format("{0}{1}{2}", ConfigManager.ImgDomainRootPath, imgFile.Path.Replace("/", @"\"), imgFile.FileName);

            //    try
            //    {
            //        File.Delete(phyPath);
            //    }
            //    catch (Exception)
            //    {


            //    }


            //}
        }

        #endregion


    }
}


