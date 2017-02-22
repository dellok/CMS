using System;
namespace LL.Model.Member
{
	/// <summary>
	/// 留言
	/// </summary>
	[Serializable]
	public partial class phome_enewsgbook
	{
		public phome_enewsgbook()
		{}
		#region Model
		private int _lyid;
		private string _name;
		private string _email;
		private string _call;
		private DateTime _lytime;
		private string _lytext;
		private string _retext;
		private int _bid;
		private string _ip;
		private int _checked;
		private int _userid;
		private string _username;
		/// <summary>
		/// 
		/// </summary>
		public int lyid
		{
			set{ _lyid=value;}
			get{return _lyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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
		public string call
		{
			set{ _call=value;}
			get{return _call;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lytime
		{
			set{ _lytime=value;}
			get{return _lytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lytext
		{
			set{ _lytext=value;}
			get{return _lytext;}
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
		public int bid
		{
			set{ _bid=value;}
			get{return _bid;}
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
		public int @checked
		{
			set{ _checked=value;}
			get{return _checked;}
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
		#endregion Model

	}
}

