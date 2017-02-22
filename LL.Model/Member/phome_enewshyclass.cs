using System;
namespace LL.Model.Member
{
	/// <summary>
	/// 好友分类
	/// </summary>
	[Serializable]
	public partial class phome_enewshyclass
	{
		public phome_enewshyclass()
		{}
		#region Model
		private int _cid;
		private string _cname;
		private int _userid;
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

