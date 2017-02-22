using System;
namespace LL.Model.Admin
{
	
	[Serializable]
	public partial class AdminInAdminRole:IAggregateRoot
	{
		public AdminInAdminRole()
		{}
		#region Model
		private int _id;
		private int _adminuserid;
		private int _adminroleid;
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
		public int AdminUserID
		{
			set{ _adminuserid=value;}
			get{return _adminuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AdminRoleID
		{
			set{ _adminroleid=value;}
			get{return _adminroleid;}
		}
		#endregion Model

	}
}

