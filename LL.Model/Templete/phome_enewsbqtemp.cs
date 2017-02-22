using System;
namespace LL.Model.Templete
{
	/// <summary>
	/// phome_enewsbqtemp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class phome_enewsbqtemp
	{
		public phome_enewsbqtemp()
		{}
		#region Model
		private int _tempid;
		private string _tempname;
		private int _modid;
		private string _temptext;
		private string _showdate;
		private string _listvar;
		private int _subnews;
		private int _rownum;
		private int _classid;
		/// <summary>
		/// 
		/// </summary>
		public int tempid
		{
			set{ _tempid=value;}
			get{return _tempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tempname
		{
			set{ _tempname=value;}
			get{return _tempname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int modid
		{
			set{ _modid=value;}
			get{return _modid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string temptext
		{
			set{ _temptext=value;}
			get{return _temptext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string showdate
		{
			set{ _showdate=value;}
			get{return _showdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string listvar
		{
			set{ _listvar=value;}
			get{return _listvar;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int subnews
		{
			set{ _subnews=value;}
			get{return _subnews;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int rownum
		{
			set{ _rownum=value;}
			get{return _rownum;}
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

