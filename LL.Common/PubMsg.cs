using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LL.Common
{
  public  class PubMsg
  {



      #region  member  中的msg
      public const string Msg_AddSuccess = "数据提交成功!";
      public const string Msg_SubmitError = "数据提交的过程中出现错误,请重新操作或联系网站管理员!";
      public const string Msg_UpdateSuccess = "数据修改成功!";
      /// <summary>
      /// 数据丢失或不存在，请查正后操作!
      /// </summary>
      public const string Msg_DataInfo_Lost = "数据丢失或不存在，请查正后操作!";
    
      /// <summary>
      /// 数据删除成功!
      /// </summary>
      public static string Msg_Delete_Success = "数据删除成功!";
      #endregion

      #region  alert
      /// <summary>
      ///分类信息丢失，请重新操作
      /// </summary>
      public const string Msg_CategoryLost_Alert = "分类信息丢失，请重新操作!";
      #endregion


      #region  主要为member后台 数据提示性 信息


      public const string Msg_Login_Name_NeedInput = "登录名不能为空!";
      public const string Msg_Login_Password_NeedInput = "登录密码不能为空!";
      public const string Msg_Login_NameAndPwd_NoMatch = "登录名与密码不匹配，请重新输入!";
      /// <summary>
      /// 登录名已存在!
      /// </summary>
      public const string Msg_Login_Name_Exist = "登录名已存在!";
      
      /// <summary>
      /// 图片上上传信息
      /// </summary>
      public const string Msg_Img_UploadInfo = "图片上传提示信息:";


      public const string Msg_Email_NeedInput = "Email不能为空!";
      public const string Msg_Email_RuleError = "Email格式不正确!";





      /// <summary>
      /// 标题不能为空
      /// </summary>
      public const string Msg_Title_NeedInput = "标题不能为空!";

      public const string Msg_Subject_NeedInput = "信息主题不能为空!";
      /// <summary>
      /// 公司名称不
      /// </summary>
      public const string Msg_Company_NeedInput = "公司名称不能为空!";

      /// <summary>
      /// 联系地址
      /// </summary>
      public const string Msg_Address_NeedInput = "地址不能为空!";
      /// <summary>
      /// 电话不能为空
      /// </summary>
      public const string Msg_Tel_NeedInput = "联系电话不能为空!";
      /// <summary>
      /// 联第方式不能为空
      /// </summary>
      public const string Msg_Contact_NeedInput = "联系方式不能为空!";

      /// <summary>
      /// 联第人不能为空
      /// </summary>
      public const string Msg_Person_NeedInput = "联第人不能为空!";
      /// <summary>
      /// 内容不能为空
      /// </summary>
      public const string Msg_Content_NeedInput = "内容不能为空!";

      /// <summary>
      /// 验证码不能为空
      /// </summary>
      public const string Msg_CheckCode_NeedInput = "验证码不能为空!";
      /// <summary>
      /// 验证证码不正确
      /// </summary>
      public const string Msg_CheckCode_NoMatch = "请输入正确的验证码!";


      /// <summary>
      /// 起始港不能为空
      /// </summary>
      public const string Msg_Transport_InitialPort_NeedInput = "起始港不能为空!";
      /// <summary>
      /// 目地不能为空
      /// </summary>
      public const string Msg_Transport_Arrived_NeedInput = "目地港不能为空!";

      /// <summary>
      /// 起始地
      /// </summary>
      public const string Msg_Transport_InitialPosition_NeedInput = "起始地不能为空!";
      /// <summary>
      /// 目地地
      /// </summary>
      public const string Msg_Transport_ArrivedPosition_NeedInput = "目地地不能为空!";


      /// <summary>
      /// 价格不能为空
      /// </summary>
      public const string Msg_Price_NeedInput = "价格不能为空!";

      /// <summary>
      /// 行业不能为空
      /// </summary>
      public const string Msg_Industry_NeedInput = "所属行业不能为空!";

      /// <summary>
      /// 包车价不能为空
      /// </summary>
      public const string Msg_CharteredCarPrice_NeedInput = "包车价不能为空!";
      /// <summary>
      /// 公司数不能为空
      /// </summary>
      public const string Msg_Kilometer_NeedInput = "里程公里不能为空!";
      /// <summary>
      /// 报价数
      /// </summary>
      public const string Msg_OfferNum_NeedInput = "报价数不能为空!";
      /// <summary>
      /// 天数
      /// </summary>
      public const string Msg_Days_NeedInput = "天数不能为空!";
      /// <summary>
      /// 发布日期
      /// </summary>
      public const string Msg_ReleaseDate_NeedInput = "发布日期不能为空!";
      /// <summary>
      /// 截止有效期不能为空
      /// </summary>
      public const string Msg_DueDate_NeedInput="截止有效期不能为空";
      /// <summary>
      /// 结算方式不能为空
      /// </summary>
      public const string Msg_ClearingForm_NeedInput = "结算方式不能为空!";

      /// <summary>
      /// 运价类型
      /// </summary>
      public const string Msg_TransportPriceType_NeedInput = "运价类型不能为空!";

      /// <summary>
      /// 月薪不能为空!
      /// </summary>
      public const string Msg_MonthlyPay_NeedInput = "月薪不能为空!";


      /// <summary>
      /// 应聘职位不能为空!
      /// </summary>
      public const string Msg_Position_NeedInput = "应聘职位不能为空!";
      /// <summary>
      /// 简历详细内容不能为空!
      /// </summary>
      public const string Msg_ResumeText_NeedInput = "简历详细内容不能为空!";
      /// <summary>
      /// 姓名不能为空!
      /// </summary>
      public const string Msg_Name_NeedInput = "姓名不能为空!";

     
      /// <summary>
      /// 公司简介不能为空!
      /// </summary>
      public  const string  Msg_CompanyIntro_NeedInput="公司简介不能为空!";



      /// <summary>
      /// 
      /// </summary>
      public const string Msg_FriendName_NeedInput = "好友名不能为空!";
      /// <summary>
      /// 
      /// </summary>
      public const string Msg_FriendName_NoSelf = "自已不能添加自已为好友!";
     /// <summary>
     /// 
     /// </summary>
      public const string Msg_FriendName_NoExists = "不存在!";



      #endregion


      #region  上传文件

      /// <summary>
      /// 请选择要上传的文件
      /// </summary>
      public const string Msg_Upload_NeedInput = "请选择要上传的文件!";

      /// <summary>
      /// 请选择充许文件类型
      /// </summary>
     public const string Msg_Upload_Extenstion_Error = "请选择充许文件类型!";

     /// <summary>
     /// 上传的过程中出现错误,请在次上传或联系管理员!
      /// </summary>
     public static string Msg_Upload_Error = "上传的过程中出现错误,请在次上传或联系管理员!";
      #endregion

     public static string Msg_InfoNoChecked = "只有通过审核的信息才能显示!";

     public static string Msg_InfoNoExists = "你所查询信息不存在或已删除!";
  }
}
