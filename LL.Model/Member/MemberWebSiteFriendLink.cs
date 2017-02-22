using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Model.Member
{
    public class MemberWebSiteFriendLink
    {
        public MemberWebSiteFriendLink()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _url;
        private int _userid;
        private DateTime _indate;
        private bool _checked;
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
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
        public DateTime InDate
        {
            set { _indate = value; }
            get { return _indate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }
        #endregion Model

    }
}
