using System;
namespace LL.Model.Member
{
	/// <summary>
	/// 反溃
	/// </summary>
	[Serializable]
	public partial class phome_enewsmemberfeedback
	{
		public phome_enewsmemberfeedback()
		{}
		#region Model
		private int _fid;
		private string _name;
		private string _company;
		private string _phone;
		private string _fax;
		private string _email;
		private string _address;
		private string _zip;
		private string _title;
		private string _ftext;
		private int _userid;
		private string _ip;
		private int _uid;
		private string _uname;
		private DateTime _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int fid
		{
			set{ _fid=value;}
			get{return _fid;}
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
		public string company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
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
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zip
		{
			set{ _zip=value;}
			get{return _zip;}
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
		public string ftext
		{
			set{ _ftext=value;}
			get{return _ftext;}
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
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
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
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

