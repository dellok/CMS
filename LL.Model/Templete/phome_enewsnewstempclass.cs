using System;
namespace LL.Model.Templete
{
	/// <summary>
	/// ʵ����phome_enewsnewstempclass ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class phome_enewsnewstempclass
	{
		public phome_enewsnewstempclass()
		{}
		#region Model
		private int _classid;
		private string _classname;
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
		public string classname
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		#endregion Model

	}
}

