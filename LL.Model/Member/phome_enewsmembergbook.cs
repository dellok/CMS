using System;
namespace LL.Model.Member
{
	/// <summary>
	/// 会员留言
	/// </summary>
	[Serializable]
	public partial class phome_enewsmembergbook
	{
		public phome_enewsmembergbook()
		{}
		#region Model
		private int _gid;
		private int _userid;
		private int _isprivate;
		private int _uid;
		private string _uname;
		private string _ip;
		private DateTime _addtime;
		private string _gbtext;
		private string _retext;
		private int _checked;
		/// <summary>
		/// 
		/// </summary>
		public int gid
		{
			set{ _gid=value;}
			get{return _gid;}
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
		public int isprivate
		{
			set{ _isprivate=value;}
			get{return _isprivate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string uname
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gbtext
		{
			set{ _gbtext=value;}
			get{return _gbtext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string retext
		{
			set{ _retext=value;}
			get{return _retext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int @checked
		{
			set{ _checked=value;}
			get{return _checked;}
		}
		#endregion Model

	}
}

