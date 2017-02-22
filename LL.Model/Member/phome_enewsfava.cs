using System;
namespace LL.Model.Member
{

	[Serializable]
	public partial class phome_enewsfava
	{
		public phome_enewsfava()
		{}
		#region Model
		private int _favaid;
		private int _id;
		private DateTime _favatime;
		private int _userid;
		private string _username;
		private int _classid;
		private int _cid;
		/// <summary>
		/// 
		/// </summary>
		public int favaid
		{
			set{ _favaid=value;}
			get{return _favaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime favatime
		{
			set{ _favatime=value;}
			get{return _favatime;}
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
		/// <summary>
		/// 
		/// </summary>
		public int classid
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		#endregion Model

	}
}

