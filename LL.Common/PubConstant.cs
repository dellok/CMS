using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Common
{
    /// <summary>
    /// 存储一些 ，网站常用的常量
    /// </summary>
    public class PubConstant
    {


        #region 用户自义模板中要用的views_key


        public const string Key_IsShowImgArrow = "isshowimg";
        public const string Key_ImghArrowPath = "imgpath";
        public const string Key_TableCSS = "tbcss";
        public const string Key_TRCss = "trcss";
        public const string Key_TDCss = "tdcss";
        public const string Key_TDPicCSS = "tdpicss";
        public const string Key_IsBClassID = "Key_IsBClassID";
        public const string Key_DataFormatStr = "fstr";
        public const string Key_IsOrderByHot = "orderByHot";
        public const string Key_IsOrderByRecommend = "isorderbyrecommend";
        public const string Key_IsShowNewsPostDate = "shownewspostdate";
        public const string Key_IsShowText = "isshowtext";
        public const string Key_SmallTextCss = "smalltextcss";
        public const string Key_SmallTextLen = "smalltextLen";
        public const string Key_PageSize = "PageSize";
        public const string Key_PageIndex = "PageIndex";
        public const string Key_Page = "Page";
        public const string Key_TitleWordNum = "titlewordnum";

        public const string Key_IsShowMore = "isShowMore";
        public const string Key_Width = "w";
        public const string Key_Height = "h";
        public const string Key_TextHeight = "th";
        public const string Key_TextAlign = "ta";
        public const string Key_DelayTimes = "DelayTimes";


        //是否显示更多
        #endregion

        #region
        public const string Key_NewsHit_ControlID = "lblNewsHit";
        #endregion



        /// <summary>
        /// 操作函数
        /// </summary>
        public const string Key_Act = "Act";

        public const string Key_CookieName_Member = "Member";
        /// <summary>
        /// 字符串常量  存储上一个url
        /// </summary>
        public const string Key_ReutrnPage = "ReturnPage";
        /// <summary>
        /// 表名称
        /// </summary>
        public const string Key_TableName = "TableName";
        /// <summary>
        /// Key:Admin
        /// </summary>
        public const string Key_Admin = "Admin";

        /// <summary>
        /// 是否自动回值,
        /// </summary>
        public const string key_AutoPostBack = "AutoPostBack";




        #region  缓存 要用 key

        /// <summary>
        /// 要清除缓存的Key值
        /// </summary>
        public const string Key_ClearCacheKey = "ClearKey";
        /// <summary>
        /// 广告列表
        /// </summary>

        public const string Key_ADList = "ADList";


        #region   admin  权限角色 要用到的key
        /// <summary>
        /// 管理员角色缓存
        /// Key:AdminRole
        /// </summary>
        public const string Key_AdminRole = "AdminRole";
        /// <summary>
        /// 管理员列表块
        /// Key: AdminList
        /// </summary>
        public const string Key_AdminList = "AdminList";
        /// <summary>
        /// 权限功能
        /// Key:PopedomFun
        /// </summary>
        public const string Key_PopedomFun = "PopedomFun";

        /// <summary>
        /// admin角色权限关联信息
        /// Key:PopedomFunInAdminRole
        /// </summary>
        public const string Key_PopedomFunInAdminRole = "PopedomFunInAdminRole";

        /// <summary>
        /// 功能权限组
        /// Key:PopedomGroup
        /// </summary>
        public const string Key_PopedomGroup = "PopedomGroup";

        #endregion

        /// <summary>
        /// 验证码session key 值
        /// </summary>
        public const string Key_CheckCode = "CheckCode";
        /// <summary>
        ///会员登录
        /// </summary>
        public const string Key_Member = "Member";


        public const string Key_MemberID = "UserID";

        public const string Key_IsVipWebSite = "IsVipWebSite";

        /// <summary>
        /// 会员公司信息
        /// </summary>
        public const string Key_MemberInfo = "MemberInfo";

        /// <summary>
        ///会员角色组
        ///key:MemberGroup
        /// </summary>
        public const string Key_MemberGroup = "MemberGroup";

        public const string Key_GroupID = "groupid";

        /// <summary>
        ///新闻分类集合Key
        ///Key:AllNewsClass
        /// </summary>
        public const string Key_NewsAllClass = "AllNewsClass";


        /// <summary>
        ///我的好友分组    Key:FriendGroup
        /// </summary>
        public const string Key_Member_FriendGroup = "FriendGroup";
        #endregion

        #region
        /// <summary>
        /// 用于不注册用户，可发布信息的用户姓名
        /// </summary>
        public const string Key_GuestName = "游客";

        public const string Key_All_Login = "AllLoginUser";
        #endregion




        #region  request
        /// <summary>
        /// key=username
        /// </summary>
        public const string Key_Member_UserName = "UserName";
        /// <summary>
        /// 数据I可标识ID
        /// </summary>
        public const string Key_ID = "ID";
        /// <summary>
        /// 分类ID
        /// </summary>
        public const string Key_ClassID = "ClassID";

        /// <summary>
        /// 父分类ID
        /// </summary>
        public const string Key_BClassID = "bclassid";

        /// <summary>
        ///站内信id  messageid
        /// </summary>
        public const string Key_MessageID = "MessageID";

        /// <summary>
        /// sendtype  发信类型
        /// </summary>
        public const string Key_SendType = "SendType";
        /// <summary>
        /// 信的存储类型，即发件箱，还是收件箱
        /// </summary>
        public const string Key_LetterSaveType = "LetterSaveType";
        #endregion
        #region sign,标记符号
        /// <summary>
        /// 分类标记分割符
        /// </summary>
        public const string Key_Sign_ClassSplitSign = "|-";
        /// <summary>
        /// 逗号 分割符
        /// </summary>
        public const char Key_Sign_CommaSign = ',';

        /// <summary>
        /// 通用分竖，|
        /// </summary>
        public const char Key_Sign_BrokenbarSign = '|';

        /// <summary>
        /// 斜线符号:/
        /// </summary>
        public const string Key_Sign_Slash = "/";
        /// <summary>
        /// 反斜线符号:\,用物理做路径
        /// </summary>
        public const string Key_Sign_Backslash = @"\";

        /// <summary>
        /// 点号:.
        /// </summary>
        public const string Key_Sign_Dot = ".";

        public const string Key_Sign_Split = "-";
        #endregion


        #region  一些操作的的类型常量

        public const string Key_Update = "Update";
        public const string Key_Add = "Add";
        public const string Key_Delete = "Delete";
        public const string Key_Cancel = "Cancel";
        public const string Key_Edit = "Edit";

        #endregion





        /// <summary>
        /// 参数，判断页面点击方式,点击，顶一下
        /// 评分数/评论数//下载数
        /// </summary>
        public const string Key_Down = "down";

        #region  与静态页有关的

        public const string Key_CreateHtml = "c";
        public const string Key_ViewPage = "ViewPage";
        #endregion





        /// <summary>
        /// 请求 参数 key, 收收藏的url
        /// </summary>
        public const string Key_FavUrl = "favUrl";

        public const string Key_Title = "title";

        public const string Key_NewsText = "newstext";


        public const string Key_Route_ListParams = "listparams";
        public const string Key_Route_ListParamValues = "listparamvalues";

        //新闻权限组
        public const string Key_NewsGroup = "newsgroup";

        public const string Key_AllNews = "allnewslist";

        public const string Key_AdminView = "adminView";

        public const string Key_AspxErrorPath = "aspxerrorpath";


        #region 与广告相关

        public const string Key_ADPage = "adpage";

        public const string Key_ADPagePosition = "ADPagePosition";
        public const string Key_ADSeq = "seq";


        #endregion

        /// <summary>
        /// 道航分割付
        /// " > "
        /// </summary>
        public const string Key_Sign_NavSeperate = "&nbsp;&gt;&nbsp;";









        public const string Key_Type = "Type";

        public const string Key_IsSearch = "IsSearch";

        public const string Key_TitleCss = "TitleCss";

        public const string Key_IsShowTextStartDot = "IsShowTextStartDot";

        public const string Key_ClassName = "classname";

        public const string Key_IsOrderByTop = "IsOrderByTop";



        public const string  DomainName = "中国医药物流网";
        public static string Domain_KeyWord = "医药物流,医药物流资讯,医药物流调研,医药物流数据统计 ";
        public static string Domain_Title = "中国医药物流网-最具权威医药物流资讯信息网";
        public static string Domain_Description = "中国物流与采购联合会医药物流分会，简称医药物流分会，英文译名为China Federation of Logistics & Purchasing Pharmaceutical logistics Sub-branch（缩写PLS），是由在国内外从事药品、保健品及医疗器械的生产、流通、物流、装备制造、信息化等企业，为实现共同意愿而自愿组成的行业性、非营利性社会团体，隶属中国物流与采购联合会，是其重要分支机构。医药物流分会在中国物流与采购联合会指导下开展工作，其主要服务范围包括：行业信息统计、标准制修订、人才培训教育、行业自律等行业基础工作，以及举办专业领域技术、装备、研讨、论坛、咨询、交流等活动。"
    + "按照中国物流与采购联合会的规定，医药物流分会将严格遵守国家法律、法规和政策；加强行业自律，反映企业呼声，维护会员合法权益；整合医药物流市场资源，协助政府推进行业工作，促进医药物流产业健康有序发展。";

        /*展会频道*/
        public const string ZhanHui_Title = "中国医药物流网-展会资讯频道";
        public const string ZhanHui_KeyWord = "医药物流展会,医药物流相关展会,医药物流合作机构";
        public const string ZhanHui_Description = "医药物流展会,医药物流相关展会,医药物流合作机构，展会发布";

    }

}