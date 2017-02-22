using System;
namespace LL.Model.Admin
{

	[Serializable]
	public partial class AdminUser:IAggregateRoot
    {
        public AdminUser()
        { }
        #region Model
        private int _id;
        private string _loginname;
        private string _password;
        private bool _checked;
        private string _newsclass;
        private DateTime _indate = DateTime.Now;
        private int _styleid;
        private int _filelevel;
        private string _remark;
        private int _adminroleid;
        private DateTime _lasttime = DateTime.Now;
        private string _lastip;
        private int _loginnum;
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
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NewsClass
        {
            set { _newsclass = value; }
            get { return _newsclass; }
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
        public int StyleID
        {
            set { _styleid = value; }
            get { return _styleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FileLevel
        {
            set { _filelevel = value; }
            get { return _filelevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AdminRoleID
        {
            set { _adminroleid = value; }
            get { return _adminroleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastTime
        {
            set { _lasttime = value; }
            get { return _lasttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastIP
        {
            set { _lastip = value; }
            get { return _lastip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LoginNum
        {
            set { _loginnum = value; }
            get { return _loginnum; }
        }
        #endregion Model

    }
}

