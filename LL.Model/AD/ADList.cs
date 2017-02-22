using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Model.AD
{
  public   class ADList:IAggregateRoot
    {
        public int  ID { get; set; }
        public int FileClass { get; set; }
        public string Title { get; set; }
        public string Page { get; set; }
        public string Position { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Seq { get; set; }
        public DateTime InDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Script { get; set; }
        public string Remark { get; set; }
        public int Hit { get; set; }
        public bool Checked { get; set; }
        public bool IsRecycle { get; set; }
        public int UploadFileID { get; set; }
        public string FileUrl { get; set; }
        public int PV { get; set; }
    }
}
