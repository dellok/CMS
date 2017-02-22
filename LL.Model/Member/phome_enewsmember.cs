using System;
namespace LL.Model.Member
{
	/// <summary>
	/// phome_enewsmember:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class phome_enewsmember
	{
		public phome_enewsmember()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _password;
		private string _rnd;
		private string _email;
		private DateTime _registertime;
		private int _groupid=7;
		private int _userfen;
		private string  _userdate="";
		private decimal _money;
		private string _todaydate;
		private int _todaydown;
		private int _zgroupid=7;
		private int _havemsg;
		private int _checked=0;
		private string _salt;
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
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rnd
		{
			set{ _rnd=value;}
			get{return _rnd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime registertime
		{
			set{ _registertime=value;}
			get{return _registertime;}
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
		public int userfen
		{
			set{ _userfen=value;}
			get{return _userfen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string  userdate
		{
			set{ _userdate=value;}
			get{return _userdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string todaydate
		{
			set{ _todaydate=value;}
			get{return _todaydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int todaydown
		{
			set{ _todaydown=value;}
			get{return _todaydown;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int zgroupid
		{
			set{ _zgroupid=value;}
			get{return _zgroupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int havemsg
		{
			set{ _havemsg=value;}
			get{return _havemsg;}
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
		public string salt
		{
			set{ _salt=value;}
			get{return _salt;}
		}
		#endregion Model

	}
}

