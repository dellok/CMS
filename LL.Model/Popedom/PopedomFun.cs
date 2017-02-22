using System;
namespace LL.Model.Popedom
{

	[Serializable]
	public partial class PopedomFun:IAggregateRoot
	{
		public PopedomFun()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _url;
		private int _popedomgroupid;
		private bool _showinmenu;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PopedomGroupID
		{
			set{ _popedomgroupid=value;}
			get{return _popedomgroupid;}
		}
		/// <summary>
		/// 是否在菜单中显示
		/// </summary>
		public bool showInMenu
		{
			set{ _showinmenu=value;}
			get{return _showinmenu;}
		}
		#endregion Model

	}
}

