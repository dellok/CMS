using System;
namespace LL.Model.Templete
{
	/// <summary>
	/// ʵ����phome_enewsnewstemp ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class phome_enewsnewstemp
	{
		public phome_enewsnewstemp()
		{}
		#region Model
		private int _tempid;
		private string _tempname;
		private int _isdefault;
		private string _temptext;
		private string _showdate;
		private int _modid;
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
		public int isdefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
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
		public int modid
		{
			set{ _modid=value;}
			get{return _modid;}
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

