using System;
namespace LL.Model.Templete
{
    /// <summary>
    /// 实体类phome_enewslisttemp 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class phome_enewslisttemp
    {
        public phome_enewslisttemp()
        { }
        #region Model
        private int _tempid;
        private string _tempname;
        private string _temptext;
        private int _subnews;
        private int _isdefault;
        private string _listvar;
        private int _rownum;
        private int _modid;
        private string _showdate;
        private int _subtitle;
        private int _classid;
        /// <summary>
        /// 
        /// </summary>
        public int tempid
        {
            set { _tempid = value; }
            get { return _tempid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tempname
        {
            set { _tempname = value; }
            get { return _tempname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temptext
        {
            set { _temptext = value; }
            get { return _temptext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int subnews
        {
            set { _subnews = value; }
            get { return _subnews; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isdefault
        {
            set { _isdefault = value; }
            get { return _isdefault; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string listvar
        {
            set { _listvar = value; }
            get { return _listvar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int rownum
        {
            set { _rownum = value; }
            get { return _rownum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int modid
        {
            set { _modid = value; }
            get { return _modid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string showdate
        {
            set { _showdate = value; }
            get { return _showdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int subtitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int classid
        {
            set { _classid = value; }
            get { return _classid; }
        }
        #endregion Model

    }
}

