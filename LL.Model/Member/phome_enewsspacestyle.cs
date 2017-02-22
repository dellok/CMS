using System;
namespace LL.Model.Member
{
	/// <summary>
	/// 会员空间模板
	/// </summary>
	[Serializable]
	public partial class phome_enewsspacestyle
	{
		public phome_enewsspacestyle()
		{}
		#region Model
		private int _styleid;
		private string _stylename;
		private string _stylepic;
		private string _stylesay;
		private string _stylepath;
		private int _isdefault;
		private string _membergroup;
		/// <summary>
		/// 
		/// </summary>
		public int styleid
		{
			set{ _styleid=value;}
			get{return _styleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stylename
		{
			set{ _stylename=value;}
			get{return _stylename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stylepic
		{
			set{ _stylepic=value;}
			get{return _stylepic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stylesay
		{
			set{ _stylesay=value;}
			get{return _stylesay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stylepath
		{
			set{ _stylepath=value;}
			get{return _stylepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isdefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string membergroup
		{
			set{ _membergroup=value;}
			get{return _membergroup;}
		}
		#endregion Model

	}
}

