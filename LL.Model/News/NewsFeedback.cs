using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Model.News
{
    public  class NewsFeedback:IAggregateRoot 
    {

     
        private int _ID;

        private int _NewsID;

        private int _NewsClassID;

        private int _UserID;

        private string _UserName;

        private string _IP;

        private DateTime  _InDate;

        private string _Content;

        private   bool  _Checked;

        private   bool  _Recommend;

        private int _ReplyParentID;

        private string _PageUrl;

        private string _Title;


        public NewsFeedback()
        {
          
        }

          public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
             
                
            }
        }

          public int NewsID
        {
            get
            {
                return this._NewsID;
            }
            set
            {
               _NewsID =value;
            
            }
        }

         public int NewsClassID
        {
            get
            {
                return this._NewsClassID;
            }
            set
            {
               _NewsClassID =value;
            
            }
        }

          public int UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
               _UserID =value;
            
            }
        }
      public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
               _UserName =value;
            
            }
        }

         public string IP
        {
            get
            {
                return this._IP;
            }
            set
            {
               _IP =value;
            
            }
        }

          public DateTime  InDate
        {
            get
            {
                return this._InDate;
            }
            set
            {
               _InDate =value;
             
            }
        }

          public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
               _Content =value;
               
            }
        }

       public   bool  Checked
        {
            get
            {
                return this._Checked;
            }
            set
            {
               _Checked =value;
             
            }
        }

        public   bool  Recommend
        {
            get
            {
                return this._Recommend;
            }
            set
            {
               _Recommend =value;
            
            }
        }
     public int ReplyParentID
        {
            get
            {
                return this._ReplyParentID;
            }
            set
            {
               _ReplyParentID =value;
           
            }
        }

         public string PageUrl
        {
            get
            {
                return this._PageUrl;
            }
            set
            {
               _PageUrl =value;
             
            }
        }

         public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
               _Title =value;
         
            }
        }

      
  
    }
}
