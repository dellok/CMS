using System;
namespace LL.Model.Log
{

	[Serializable]
	public partial class VisitorLog:IAggregateRoot
	{
		public VisitorLog()
		{}
		#region Model
		private int _id;
		private string _ip;
		private string _visitor;
		private DateTime? _indate;
		private string _reurl;
		private int? _infoid;
		private string _infotitle;
		private int? _infoclassid;
		private string _infourl;
		private string _infotype;
		private int? _pv;
		private int? _hit;
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
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Visitor
		{
			set{ _visitor=value;}
			get{return _visitor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InDate
		{
			set{ _indate=value;}
			get{return _indate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReUrl
		{
			set{ _reurl=value;}
			get{return _reurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InfoID
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InfoTitle
		{
			set{ _infotitle=value;}
			get{return _infotitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InfoClassID
		{
			set{ _infoclassid=value;}
			get{return _infoclassid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InfoUrl
		{
			set{ _infourl=value;}
			get{return _infourl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InfoType
		{
			set{ _infotype=value;}
			get{return _infotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PV
		{
			set{ _pv=value;}
			get{return _pv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Hit
		{
			set{ _hit=value;}
			get{return _hit;}
		}
		#endregion Model

	}
}

