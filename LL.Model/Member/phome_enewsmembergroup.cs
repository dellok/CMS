using System;
namespace LL.Model.Member
{
	/// <summary>
	/// phome_enewsmembergroup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class phome_enewsmembergroup
	{
		public phome_enewsmembergroup()
		{}
		#region Model
		private int _groupid;
		private string _groupname;
		private int _level;
		private int _checked;
		private int _favanum;
		private int _daydown;
		private int _msglen;
		private int _msgnum;
		private int _canreg;
		private int _formid;
		private int _regchecked;
		private int _spacestyleid;
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
		public string groupname
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int level
		{
			set{ _level=value;}
			get{return _level;}
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
		public int favanum
		{
			set{ _favanum=value;}
			get{return _favanum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int daydown
		{
			set{ _daydown=value;}
			get{return _daydown;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int msglen
		{
			set{ _msglen=value;}
			get{return _msglen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int msgnum
		{
			set{ _msgnum=value;}
			get{return _msgnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int canreg
		{
			set{ _canreg=value;}
			get{return _canreg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int formid
		{
			set{ _formid=value;}
			get{return _formid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int regchecked
		{
			set{ _regchecked=value;}
			get{return _regchecked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int spacestyleid
		{
			set{ _spacestyleid=value;}
			get{return _spacestyleid;}
		}
		#endregion Model

	}
}

