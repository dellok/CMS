using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Common.EnumClass
{
    /// <summary>
    /// 发信类型
    /// </summary>
   public  enum  SendType
    {
       
       /// <summary>
       /// 直接写信
       /// </summary>
       Write,
       /// <summary>
       /// 回复
       /// </summary>
       Reply,
       /// <summary>
       /// 转发
       /// </summary>
       Transmit
    }


    /// <summary>
    /// 信的存储类型,是在收件箱还是在发件箱
    /// </summary>
   public enum LetterSaveType
   {

       /// <summary>
       /// 收件箱
       /// </summary>
       Inbox=0,
       /// <summary>
       /// 发件箱
       /// </summary>
       Outbox=1

   }


}
