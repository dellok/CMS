using System;
namespace LL.Model.Member
{
	/// <summary>
	/// 留言分类
	/// </summary>
	[Serializable]
	public partial class phome_enewsgbookclass
	{
		public phome_enewsgbookclass()
		{}
		#region Model
		private int _bid;
		private string _bname;
		private int _checked;
		private int _groupid;
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
		public string bname
		{
			set{ _bname=value;}
			get{return _bname;}
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
		public int groupid
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		#endregion Model

	}
}

