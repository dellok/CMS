using System;
namespace LL.Model.News
{
	/// <summary>
	/// phome_enewsclass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class phome_enewsclass:IAggregateRoot
	{
		public phome_enewsclass()
		{}
		#region Model
		private int _classid;
		private int _bclassid;
		private string _classname;
		private string _sonclass;
		private int _is_zt;
		private int _lencord;
		private int _link_num;
		private int _newstempid;
		private int _onclick;
		private int _listtempid;
		private string _featherclass;
		private int _islast;
		private string _classpath;
		private string _classtype;
		private string _newspath;
		private int _filename;
		private string _filetype;
		private int _openpl;
		private int _openadd;
		private int _newline;
		private int _newshowdate;
		private int _newstrlen;
		private int _hotline;
		private int _hotstrlen;
		private int _hotshowdate;
		private int _goodline;
		private int _goodstrlen;
		private int _goodshowdate;
		private string _classurl;
		private int _groupid;
		private int _myorder;
		private string _filename_qz;
		private int _hotplline;
		private int _hotplshowdate;
		private int _hotplstrlen;
		private int _modid;
		private int _checked;
		private int _docheckuser;
		private string _checkuser;
		private int _firstline;
		private int _firststrlen;
		private int _firstshowdate;
		private string _bname;
		private int _islist;
		private int _searchtempid;
		private int _tid;
		private string _tbname;
		private int _maxnum;
		private int _checkpl;
		private int _down_num;
		private int _online_num;
		private string _listorderf;
		private string _listorder;
		private string _reorderf;
		private string _reorder;
		private string _intro;
		private string _classimg;
		private int _jstempid;
		private int _addinfofen;
		private int _listdt;
		private int _showclass;
		private int _showdt;
		private int _checkqadd;
		private int _qaddlist;
		private int _qaddgroupid;
		private int _qaddshowkey;
		private int _adminqinfo;
		private int _doctime;
		private string _classpagekey;
		private int _dtlisttempid;
		private int _classtempid;
		private int _nreclass;
		private int _nreinfo;
		private int _nrejs;
		private int _nottobq;
		private string _ipath;
		private int _addreinfo;
		private int _haddlist;
		private int _sametitle;
		private int _definfovoteid;
		private string _wburl;
		private int _qeditchecked;
		private int _wapstyleid;
        /// <summary>
        /// 
        /// </summary>


 public int ID {

            get {
                return classid;
            }
            set {


                classid = value;
            }

        }
        public int classid
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int bclassid
		{
			set{ _bclassid=value;}
			get{return _bclassid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classname
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sonclass
		{
			set{ _sonclass=value;}
			get{return _sonclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int is_zt
		{
			set{ _is_zt=value;}
			get{return _is_zt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int lencord
		{
			set{ _lencord=value;}
			get{return _lencord;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int link_num
		{
			set{ _link_num=value;}
			get{return _link_num;}
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
		public int onclick
		{
			set{ _onclick=value;}
			get{return _onclick;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int listtempid
		{
			set{ _listtempid=value;}
			get{return _listtempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string featherclass
		{
			set{ _featherclass=value;}
			get{return _featherclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int islast
		{
			set{ _islast=value;}
			get{return _islast;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classpath
		{
			set{ _classpath=value;}
			get{return _classpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classtype
		{
			set{ _classtype=value;}
			get{return _classtype;}
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
		public int filename
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filetype
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int openpl
		{
			set{ _openpl=value;}
			get{return _openpl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int openadd
		{
			set{ _openadd=value;}
			get{return _openadd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int newline
		{
			set{ _newline=value;}
			get{return _newline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int newshowdate
		{
			set{ _newshowdate=value;}
			get{return _newshowdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int newstrlen
		{
			set{ _newstrlen=value;}
			get{return _newstrlen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hotline
		{
			set{ _hotline=value;}
			get{return _hotline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hotstrlen
		{
			set{ _hotstrlen=value;}
			get{return _hotstrlen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hotshowdate
		{
			set{ _hotshowdate=value;}
			get{return _hotshowdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goodline
		{
			set{ _goodline=value;}
			get{return _goodline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goodstrlen
		{
			set{ _goodstrlen=value;}
			get{return _goodstrlen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int goodshowdate
		{
			set{ _goodshowdate=value;}
			get{return _goodshowdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classurl
		{
			set{ _classurl=value;}
			get{return _classurl;}
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
		public int myorder
		{
			set{ _myorder=value;}
			get{return _myorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filename_qz
		{
			set{ _filename_qz=value;}
			get{return _filename_qz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hotplline
		{
			set{ _hotplline=value;}
			get{return _hotplline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hotplshowdate
		{
			set{ _hotplshowdate=value;}
			get{return _hotplshowdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int hotplstrlen
		{
			set{ _hotplstrlen=value;}
			get{return _hotplstrlen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int modid
		{
			set{ _modid=value;}
			get{return _modid;}
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
		public int docheckuser
		{
			set{ _docheckuser=value;}
			get{return _docheckuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string checkuser
		{
			set{ _checkuser=value;}
			get{return _checkuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int firstline
		{
			set{ _firstline=value;}
			get{return _firstline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int firststrlen
		{
			set{ _firststrlen=value;}
			get{return _firststrlen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int firstshowdate
		{
			set{ _firstshowdate=value;}
			get{return _firstshowdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bname
		{
			set{ _bname=value;}
			get{return _bname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int islist
		{
			set{ _islist=value;}
			get{return _islist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int searchtempid
		{
			set{ _searchtempid=value;}
			get{return _searchtempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int tid
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tbname
		{
			set{ _tbname=value;}
			get{return _tbname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int maxnum
		{
			set{ _maxnum=value;}
			get{return _maxnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int checkpl
		{
			set{ _checkpl=value;}
			get{return _checkpl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int down_num
		{
			set{ _down_num=value;}
			get{return _down_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int online_num
		{
			set{ _online_num=value;}
			get{return _online_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string listorderf
		{
			set{ _listorderf=value;}
			get{return _listorderf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string listorder
		{
			set{ _listorder=value;}
			get{return _listorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reorderf
		{
			set{ _reorderf=value;}
			get{return _reorderf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reorder
		{
			set{ _reorder=value;}
			get{return _reorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classimg
		{
			set{ _classimg=value;}
			get{return _classimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int jstempid
		{
			set{ _jstempid=value;}
			get{return _jstempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int addinfofen
		{
			set{ _addinfofen=value;}
			get{return _addinfofen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int listdt
		{
			set{ _listdt=value;}
			get{return _listdt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int showclass
		{
			set{ _showclass=value;}
			get{return _showclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int showdt
		{
			set{ _showdt=value;}
			get{return _showdt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int checkqadd
		{
			set{ _checkqadd=value;}
			get{return _checkqadd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int qaddlist
		{
			set{ _qaddlist=value;}
			get{return _qaddlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int qaddgroupid
		{
			set{ _qaddgroupid=value;}
			get{return _qaddgroupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int qaddshowkey
		{
			set{ _qaddshowkey=value;}
			get{return _qaddshowkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int adminqinfo
		{
			set{ _adminqinfo=value;}
			get{return _adminqinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int doctime
		{
			set{ _doctime=value;}
			get{return _doctime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classpagekey
		{
			set{ _classpagekey=value;}
			get{return _classpagekey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int dtlisttempid
		{
			set{ _dtlisttempid=value;}
			get{return _dtlisttempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int classtempid
		{
			set{ _classtempid=value;}
			get{return _classtempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int nreclass
		{
			set{ _nreclass=value;}
			get{return _nreclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int nreinfo
		{
			set{ _nreinfo=value;}
			get{return _nreinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int nrejs
		{
			set{ _nrejs=value;}
			get{return _nrejs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int nottobq
		{
			set{ _nottobq=value;}
			get{return _nottobq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ipath
		{
			set{ _ipath=value;}
			get{return _ipath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int addreinfo
		{
			set{ _addreinfo=value;}
			get{return _addreinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int haddlist
		{
			set{ _haddlist=value;}
			get{return _haddlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sametitle
		{
			set{ _sametitle=value;}
			get{return _sametitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int definfovoteid
		{
			set{ _definfovoteid=value;}
			get{return _definfovoteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wburl
		{
			set{ _wburl=value;}
			get{return _wburl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int qeditchecked
		{
			set{ _qeditchecked=value;}
			get{return _qeditchecked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int wapstyleid
		{
			set{ _wapstyleid=value;}
			get{return _wapstyleid;}
		}
		#endregion Model

	}
}

