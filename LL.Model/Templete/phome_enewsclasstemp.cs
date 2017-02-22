using System;
namespace LL.Model.Templete
{
	/// <summary>
	/// ·âÃæÄ£°å
	/// </summary>
	[Serializable]
	public class phome_enewsclasstemp
	{
		public phome_enewsclasstemp()
		{}
		#region Model
		private int _tempid;
		private string _tempname;
		private string _temptext;
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
		public string temptext
		{
			set{ _temptext=value;}
			get{return _temptext;}
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

