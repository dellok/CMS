using System;
namespace LL.Model.Member
{
	/// <summary>
	/// phome_enewskey:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class phome_enewskey
	{
		public phome_enewskey()
		{}
		#region Model
		private int _keyid;
		private string _keyname;
		private string _keyurl;
		/// <summary>
		/// 
		/// </summary>
		public int keyid
		{
			set{ _keyid=value;}
			get{return _keyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keyname
		{
			set{ _keyname=value;}
			get{return _keyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string keyurl
		{
			set{ _keyurl=value;}
			get{return _keyurl;}
		}
		#endregion Model

	}
}

