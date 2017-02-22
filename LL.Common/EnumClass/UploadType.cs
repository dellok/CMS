using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Common;
namespace LL.Common.EnumClass
{
    public enum FileClass
    {
        /// <summary>
        /// 区配文件后缀名，键文件夹
        /// </summary>
        [Alias("其它附件")]
         OtherFile = 0,
        [Alias("图片")]
        Image = 1,
        [Alias("Flash")]
        Flash = 2,
        [Alias("多媒体")]
        Media=3
    
   
    }
    public enum FileInfoType
    {
        [Alias("其它")]
        Other = 0,
        //对应上传文件夹名称
        [Alias("会员公司Banner")]
        MemberCompanyBanner = 1,
        [Alias("会员头像")]
        /// <summary>
        /// 会员头像 
        /// </summary>
        MemberHeadPic = 2,
        /// <summary>
        ///物流装备 
        ///</summary>
        [Alias("公司库")]
        Product = 3,
        /// <summary>
        /// 新闻
        /// </summary>
        [Alias("新闻")]
        News = 4,
        /// <summary>
        ///广告,按月存
        /// </summary>
        [Alias("广告")]
        AD = 5,
        /// <summary>
        /// 专题
        /// </summary>
        [Alias("专题")]
        ZuanTi = 6,
        /// <summary>
        /// 资质荣誉
        /// </summary>
        [Alias("资质荣誉")]
        Certificate = 7,
        /// <summary>
        /// 公司相册
        /// </summary>
        [Alias("公司相册")]
        Album = 8,
        [Alias("物流产品")]
        WuLiuProduct = 9,
        


    }


}
