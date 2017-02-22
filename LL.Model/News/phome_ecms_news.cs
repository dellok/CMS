using System;
namespace LL.Model.News
{
	/// <summary>
	/// 新闻表
	/// </summary>
	[Serializable]
	public partial class phome_ecms_news:IAggregateRoot
    {

        #region
        public static string Field_id = "id";
        public static string Field_classid = "classid";
        public static string Field_onclick = "onclick";
        public static string Field_newspath = "newspath";
        public static string Field_keyboard = "keyboard";
        public static string Field_keyid = "keyid";
        public static string Field_userid = "userid";
        public static string Field_username = "username";
        public static string Field_ztid = "ztid";
        public static string Field_checked = "checked";
        public static string Field_istop = "istop";
        public static string Field_truetime = "truetime";
        public static string Field_ismember = "ismember";
        public static string Field_dokey = "dokey";
        public static string Field_userfen = "userfen";
        public static string Field_isgood = "isgood";
        public static string Field_titlefont = "titlefont";
        public static string Field_titleurl = "titleurl";
        public static string Field_filename = "filename";
        public static string Field_filenameqz = "filenameqz";
        public static string Field_newstempid = "newstempid";
        public static string Field_plnum = "plnum";
        public static string Field_firsttitle = "firsttitle";
        public static string Field_isqf = "isqf";
        public static string Field_totaldown = "totaldown";
        public static string Field_title = "title";
        public static string Field_newstime = "newstime";
        public static string Field_titlepic = "titlepic";
        public static string Field_closepl = "closepl";
        public static string Field_havehtml = "havehtml";
        public static string Field_lastdotime = "lastdotime";
        public static string Field_haveaddfen = "haveaddfen";
        public static string Field_infopfen = "infopfen";
        public static string Field_infopfennum = "infopfennum";
        public static string Field_votenum = "votenum";
        public static string Field_ftitle = "ftitle";
        public static string Field_smalltext = "smalltext";
        public static string Field_writer = "writer";
        public static string Field_befrom = "befrom";
        public static string Field_newstext = "newstext";
        public static string Field_diggtop = "diggtop";

        #endregion
        public phome_ecms_news()
		{}
		#region Model
		private int _id;
		private int _classid;
		private int _onclick;
		private string _newspath;
		private string _keyboard;
		private string _keyid;
		private int _userid;
		private string _username;
		private string _ztid;
		private int _checked;
		private int _istop;
		private int _truetime;
		private int _ismember;
		private int _dokey;
		private int _userfen;
		private int _isgood;
		private string _titlefont;
		private string _titleurl;
		private string _filename;
		private string _filenameqz;
		private int _fh;
		private int _groupid;
		private int _newstempid;
		private int _plnum;
		private int _firsttitle;
		private int _isqf;
		private int _totaldown;
		private string _title;
		private DateTime _newstime;
		private string _titlepic;
		private int _closepl;
		private int _havehtml;
		private int _lastdotime;
		private int _haveaddfen;
		private int _infopfen;
		private int _infopfennum;
		private int _votenum;
		private string _ftitle;
		private string _smalltext;
		private string _writer;
		private string _befrom;
		private string _newstext;
		private int _diggtop;
        /// <summary>
        /// 
        /// </summary>
        /// 

        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int classid
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int onclick
		{
			set{ _onclick=value;}
			get{return _onclick;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string newspath
		{
			set{ _newspath=value;}
			get{return _newspath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keyboard
		{
			set{ _keyboard=value;}
			get{return _keyboard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keyid
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ztid
		{
			set{ _ztid=value;}
			get{return _ztid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int @checked
		{
			set{ _checked=value;}
			get{return _checked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int istop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int truetime
		{
			set{ _truetime=value;}
			get{return _truetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ismember
		{
			set{ _ismember=value;}
			get{return _ismember;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int dokey
		{
			set{ _dokey=value;}
			get{return _dokey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userfen
		{
			set{ _userfen=value;}
			get{return _userfen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isgood
		{
			set{ _isgood=value;}
			get{return _isgood;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string titlefont
		{
			set{ _titlefont=value;}
			get{return _titlefont;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string titleurl
		{
			set{ _titleurl=value;}
			get{return _titleurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filename
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filenameqz
		{
			set{ _filenameqz=value;}
			get{return _filenameqz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int fh
		{
			set{ _fh=value;}
			get{return _fh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int groupid
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int newstempid
		{
			set{ _newstempid=value;}
			get{return _newstempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int plnum
		{
			set{ _plnum=value;}
			get{return _plnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int firsttitle
		{
			set{ _firsttitle=value;}
			get{return _firsttitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isqf
		{
			set{ _isqf=value;}
			get{return _isqf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int totaldown
		{
			set{ _totaldown=value;}
			get{return _totaldown;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime newstime
		{
			set{ _newstime=value;}
			get{return _newstime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string titlepic
		{
			set{ _titlepic=value;}
			get{return _titlepic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int closepl
		{
			set{ _closepl=value;}
			get{return _closepl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int havehtml
		{
			set{ _havehtml=value;}
			get{return _havehtml;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lastdotime
		{
			set{ _lastdotime=value;}
			get{return _lastdotime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int haveaddfen
		{
			set{ _haveaddfen=value;}
			get{return _haveaddfen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int infopfen
		{
			set{ _infopfen=value;}
			get{return _infopfen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int infopfennum
		{
			set{ _infopfennum=value;}
			get{return _infopfennum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int votenum
		{
			set{ _votenum=value;}
			get{return _votenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ftitle
		{
			set{ _ftitle=value;}
			get{return _ftitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string smalltext
		{
			set{ _smalltext=value;}
			get{return _smalltext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string writer
		{
			set{ _writer=value;}
			get{return _writer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string befrom
		{
			set{ _befrom=value;}
			get{return _befrom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string newstext
		{
			set{ _newstext=value;}
			get{return _newstext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int diggtop
		{
			set{ _diggtop=value;}
			get{return _diggtop;}
		}

        
        #endregion Model

    }
}

