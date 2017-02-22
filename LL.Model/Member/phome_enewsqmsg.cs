using System;
namespace LL.Model.Member
{
    /// <summary>
    ///站内信
    /// </summary>
    [Serializable]
    public partial class phome_enewsqmsg:IAggregateRoot
    {
        public phome_enewsqmsg()
        { }
        #region Model
        private int _mid;
        private string _title = "";
        private string _msgtext;
        private bool _haveread = false;
        private DateTime _msgtime;
        private string _to_username = "";
        private int _from_userid = 0;
        private string _from_username = "";
        private bool _outbox;
        private bool _issys;
        /// <summary>
        /// 
        /// </summary>
        /// 
        public int ID {


            get { return mid; }
            set { mid = value; }
        }
        public int mid
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string msgtext
        {
            set { _msgtext = value; }
            get { return _msgtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool haveread
        {
            set { _haveread = value; }
            get { return _haveread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime msgtime
        {
            set { _msgtime = value; }
            get { return _msgtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string to_username
        {
            set { _to_username = value; }
            get { return _to_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int from_userid
        {
            set { _from_userid = value; }
            get { return _from_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string from_username
        {
            set { _from_username = value; }
            get { return _from_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool outbox
        {
            set { _outbox = value; }
            get { return _outbox; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool issys
        {
            set { _issys = value; }
            get { return _issys; }
        }
        #endregion Model

    }
}

