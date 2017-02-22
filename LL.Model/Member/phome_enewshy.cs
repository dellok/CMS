using System;
namespace LL.Model.Member
{
	/// <summary>
	///我的好友
	/// </summary>
	[Serializable]
	public partial class phome_enewshy
	{
		public phome_enewshy()
		{}
		#region Model
		private int _fid;
		private int _userid;
		private string _fname;
		private int _cid;
		private string _fsay;
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
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fname
		{
			set{ _fname=value;}
			get{return _fname;}
		}
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
		public string fsay
		{
			set{ _fsay=value;}
			get{return _fsay;}
		}
		#endregion Model

	}
}

