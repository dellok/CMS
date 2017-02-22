using System;
namespace LL.Model.Templete
{
	/// <summary>
	/// 实体类phome_enewstempvar 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class phome_enewstempvar
	{
		public phome_enewstempvar()
		{}
		#region Model
		private int _varid;
		private string _myvar;
		private string _varname;
		private string _varvalue;
		private int  _classid;
		private  int  _isclose;
		private int  _myorder;
		/// <summary>
		/// 
		/// </summary>
		public int varid
		{
			set{ _varid=value;}
			get{return _varid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string myvar
		{
			set{ _myvar=value;}
			get{return _myvar;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string varname
		{
			set{ _varname=value;}
			get{return _varname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string varvalue
		{
			set{ _varvalue=value;}
			get{return _varvalue;}
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
		public int  isclose
		{
			set{ _isclose=value;}
			get{return _isclose;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int myorder
		{
			set{ _myorder=value;}
			get{return _myorder;}
		}
		#endregion Model

	}
}

