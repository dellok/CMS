using System;
namespace LL.Model.Templete
{
	/// <summary>
	/// phome_enewsbq:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class phome_enewsbq
	{
		public phome_enewsbq()
		{}
		#region Model
		private int _bqid;
		private string _bqname;
		private string _bqsay;
		private string _funname;
		private string _bq;
		private int _issys;
		private string _bqgs;
		private int _isclose;
		private int _classid;
		/// <summary>
		/// 
		/// </summary>
		public int bqid
		{
			set{ _bqid=value;}
			get{return _bqid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bqname
		{
			set{ _bqname=value;}
			get{return _bqname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bqsay
		{
			set{ _bqsay=value;}
			get{return _bqsay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string funname
		{
			set{ _funname=value;}
			get{return _funname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bq
		{
			set{ _bq=value;}
			get{return _bq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int issys
		{
			set{ _issys=value;}
			get{return _issys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bqgs
		{
			set{ _bqgs=value;}
			get{return _bqgs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isclose
		{
			set{ _isclose=value;}
			get{return _isclose;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int classid
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		#endregion Model

	}
}

