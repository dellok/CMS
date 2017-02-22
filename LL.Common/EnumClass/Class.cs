using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Common.EnumClass
{


    /// <summary>
    //关于我们相关类别
    /// </summary>
    public enum ContactUs
    {
        关于我们 = 400,
        联系我们 = 401,
        法律声明 = 402,
        友情链接 = 403


    }


    /// <summary>
    ///有网站的会员组 
    /// </summary>
    public enum WebSiteMemberGroupID
    {
        Vip会员单位 = 2,
        理事单位 = 5,
        常务理事单位 = 6,
        副主任单位 = 9


    }
    /// <summary>
    /// 
    /// </summary>
    public enum MemberGroupID
    {


        企业普通会员 = 1,
        个人普通会员 = 7,
        游客 = 13,

        Vip会员单位 = 2,
        理事单位 = 5,
        常务理事单位 = 6,
        副主任单位 = 9

    }



    /// <summary>
    /// vip网站模板导航栏目
    /// </summary>
    public enum VipSiteItemsClassID
    {
        首页 = 97,
        网站Banner = 98,
        公司简介 = 99,
        产品展厅 = 100,
        新闻动态 = 101,
        营销网络 = 102,
        证书荣誉 = 103,
        公司相册 = 104,
        企业招聘 = 105,
        物流服务 = 106,
        联系我们 = 107,
        企业文化 = 108,
        解决方案 = 109,
        企业库资讯 = 117

    }



}
