using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Common;
namespace LL.Common.EnumClass
{

    

    /// <summary>
    /// 页面目录
    /// </summary>
    public enum PageDirectory
    {
        [Alias("首页")]
        Index,
        [Alias("资讯")]
         News,
        [Alias("招标公告")]
        ZhaoBiaoGongGao,
        [Alias("设备采购")]
        SheBeiCaiGou,

    
        [Alias("VIP会员")]
        Vip,
        [Alias("展会")]
        ZhanHui,
        [Alias("公司库")]
        Gsk,
        [Alias("物流装备")]
        WuLiuZhuangBei,
        [Alias("人才首页")]
        RenCai,
        [Alias("招聘")]
        ZhaoPin,
        [Alias("求职")]
        QiuZhi,
        [Alias("商用车")]
    　　　CV,
        [Alias("行业")]
        IL,
        [Alias("专题")]
        ZT,
        [Alias("广告")]
        AD
    }



   
}
