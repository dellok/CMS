using System;
namespace LL.Model.Upload
{

    [Serializable]
    public partial class UploadFile:IAggregateRoot
    {
        public UploadFile()
        { }
        #region Model
        private int _id;
        private int _fileclass;
        private int _fileinfotype;
        private string _filename;
        private int _filesize;
        private string _path;
        private string _uploaduser;
        private int _uploaduserrole;
        private DateTime _indate;
        private int _newsid;
        private int _newsclassid;
        private string _no;
        private int _hit;
        private int _cjid;
        private int _fpathath;
        private string _extension;
        private bool _isrecycle;
        private int _userid;
        private string _title;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FileClass
        {
            set { _fileclass = value; }
            get { return _fileclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FileInfoType
        {
            set { _fileinfotype = value; }
            get { return _fileinfotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UploadUser
        {
            set { _uploaduser = value; }
            get { return _uploaduser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UploadUserRole
        {
            set { _uploaduserrole = value; }
            get { return _uploaduserrole; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime InDate
        {
            set { _indate = value; }
            get { return _indate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NewsClassID
        {
            set { _newsclassid = value; }
            get { return _newsclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string No
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hit
        {
            set { _hit = value; }
            get { return _hit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CJID
        {
            set { _cjid = value; }
            get { return _cjid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FPathath
        {
            set { _fpathath = value; }
            get { return _fpathath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Extension
        {
            set { _extension = value; }
            get { return _extension; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRecycle
        {
            set { _isrecycle = value; }
            get { return _isrecycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        #endregion Model

    }
}

