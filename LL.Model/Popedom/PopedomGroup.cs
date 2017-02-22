using System;
namespace LL.Model.Popedom
{

	[Serializable]
	public partial class PopedomGroup:IAggregateRoot
	{
		public PopedomGroup()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _remark;
		private int _order=0;
		private bool _isshow= true;
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
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Order
		{
			set{ _order=value;}
			get{return _order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsShow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		#endregion Model

	}
}

