using System;
namespace LL.Model.Popedom
{

	[Serializable]
	public partial class PopedomFunInAdminRole:IAggregateRoot
	{
		public PopedomFunInAdminRole()
		{}
		#region Model
		private int _id;
		private int _popedomroleid;
		private int _popedomfunid;
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
		public int PopedomRoleID
		{
			set{ _popedomroleid=value;}
			get{return _popedomroleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PopedomFunID
		{
			set{ _popedomfunid=value;}
			get{return _popedomfunid;}
		}
		#endregion Model

	}
}

