using System;
namespace LL.Model.Temp
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public partial class TempItem:IAggregateRoot
	{
		public TempItem()
		{}
		#region Model
		private int _id;
		private string _name;
		private string  _url;
		private bool _iscreatestaticpage= true;
        private int _type;
        private string _temptext;

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

        public string ADPageName
        {
            set;
            get;
        }
		/// <summary>
		/// 
		/// </summary>
		public string  Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsCreateStaticPage
		{
			set{ _iscreatestaticpage=value;}
			get{return _iscreatestaticpage;}
		}

        public int TempType
        {
            set { _type = value; }
            get { return _type; }
        }

        public string TempText
        {
            set { _temptext = value; }
            get { return _temptext; }
        }
		#endregion Model

	}
}

