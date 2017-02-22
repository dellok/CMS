using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LL.Common.Cache;
using System.Text;
using LL.Common;
using LL.BLL.Member;
using Project.Common;
using LL.Model.Member;
using LL.Common.EnumClass;
using LL.BLL;

public partial class Member_MemberCompanyInfo : AdminPage
{
    BLLphome_enewsmemberadd bllMemberInfo = new BLLphome_enewsmemberadd();
    BLLphome_enewsmember bllLogin = new BLLphome_enewsmember();

    //是否是增加操作
    bool IsAdd = false;
    string strEnews = string.Empty;
    string strUsername = string.Empty;
    string strPassword = string.Empty;
    string strRepassword = string.Empty;
    string strEmail = string.Empty;
    string strTruename = string.Empty;
    string strSex = string.Empty;
    string strDuty = string.Empty;
    string strCall = string.Empty;
    string strFax = string.Empty;
    string strPhone = string.Empty;
    string strLeixing = string.Empty;
    string strCompany = string.Empty;
    string strCity = string.Empty;
    string strAddress = string.Empty;
    string strZip = string.Empty;
    string strIndustry = string.Empty;
    string strDirection = string.Empty;
    string strProducts = string.Empty;
    string strOicq = string.Empty;
    string strMsn = string.Empty;
    string strGslogofile = string.Empty;
    string strUserpicfile = string.Empty;
    string strHomepage = string.Empty;
    string strSaytext = string.Empty;
    string strAsk = string.Empty;

    System.Text.StringBuilder strError = new System.Text.StringBuilder();
    public int userid = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
     
         userid = base.GetReqIDValue;
   
     
        if (!Page.IsPostBack)
        {
              BindControlList();
              ShowMemberInfo();
        }

    }
    private void BindControlList()
    {

        BLLphome_enewsmembergroup bllGroup = new BLLphome_enewsmembergroup();
        List<phome_enewsmembergroup> arrGroup = bllGroup.GetAllListByCache();

        listboxMemberGroup.DataSource = arrGroup;
        listboxMemberGroup.DataTextField = "groupname";
        listboxMemberGroup.DataValueField = "groupid";
        listboxMemberGroup.DataBind();

        drplMemberGroup.DataSource = arrGroup;
        drplMemberGroup.DataTextField = "groupname";
        drplMemberGroup.DataValueField = "groupid";
        drplMemberGroup.DataBind();

        ListItem item = new ListItem("不设置", "0");
        item.Selected = true;
        drplMemberGroup.Items.Insert(0, item);




    }


    /// <summary>
    /// 显示信息
    /// </summary>
    private void ShowMemberInfo()
    {


        if (userid > 0)
        {

          
            phome_enewsmember modelLogin = bllLogin.GetModel(userid);
            phome_enewsmemberadd modelMemberInfo = bllMemberInfo.GetModel(userid);


            if (modelLogin!=null)
            {
                //会员组

                drplMemberGroup.SelectedIndex = drplMemberGroup.Items.IndexOf(drplMemberGroup.Items.FindByValue(modelLogin.zgroupid.ToString()));
                listboxMemberGroup.SelectedIndex = listboxMemberGroup.Items.IndexOf(listboxMemberGroup.Items.FindByValue(modelLogin.groupid.ToString().Trim()));

                //登录信息
                txtLoginName.Text = modelLogin.username;

                //到期天数,及日期 
                string userdate = modelLogin.userdate;
                DateTime dEndDate = new DateTime();
                int LeaveDays = 0;
                if (Format.DataConvertToInt(userdate) > 0)
                {
                    dEndDate = Format.UnixTimeStampToDateTime(userdate);
                    TimeSpan ts = dEndDate - DateTime.Now;
                    LeaveDays = ts.Days + 1;

                }

                txtUseDays.Text = LeaveDays.ToString();
                txtEnd.Text = strEmail == "0" ? "" : dEndDate.ToString();

                cboxChecked.Checked = Format.DataConvertToInt(modelLogin.@checked) > 0 ? true : false;
                drplMemberGroup.SelectedIndex = drplMemberGroup.Items.IndexOf(drplMemberGroup.Items.FindByValue(Format.DataConvertToString(modelLogin.zgroupid)));
                drplSpaceStyleID.SelectedIndex = drplSpaceStyleID.Items.IndexOf(drplSpaceStyleID.Items.FindByValue(Format.DataConvertToString(modelMemberInfo.spacestyleid)));
                txtLoginEmail.Text = modelLogin.email;
            }
            if (modelMemberInfo != null )
            {

                

                //基本信息
                txtTruename.Text = modelMemberInfo.truename;
                ucSex.SetValue = modelMemberInfo.sex;
                txtDuty.Text = modelMemberInfo.duty;
                txtCall.Text = modelMemberInfo.call;
                txtFax.Text = modelMemberInfo.fax;
                txtPhone.Text = modelMemberInfo.phone;
                radioListLeixing.SelectedIndex = BindControl.RadioSelectedIndex(radioListLeixing, modelMemberInfo.leixing);
                txtCompany.Text = modelMemberInfo.company;
                ucCity.SetValue = modelMemberInfo.city;
                txtAddress.Text = modelMemberInfo.address;
                txtZip.Text = modelMemberInfo.zip;
                txtIndustry.Text = modelMemberInfo.industry;
                radioListDirection.SelectedIndex = BindControl.RadioSelectedIndex(radioListDirection, modelMemberInfo.direction);
                txtProducts.Text = modelMemberInfo.products;
                txtOicq.Text = modelMemberInfo.oicq;
                txtMsn.Text = modelMemberInfo.msn;
                txtHomepage.Text = modelMemberInfo.homepage;
                txtSaytext.Value = modelMemberInfo.saytext;

                //显示图片
                //公司logo
                if (!string.IsNullOrEmpty(modelMemberInfo.gslogo))
                {
                    logoImg.Visible = true;
                    logoImg.ImageUrl = modelMemberInfo.gslogo;
                }
                else
                {
                    logoImg.Visible = false;
                }

                /// 头像
                if (!string.IsNullOrEmpty(modelMemberInfo.userpic))
                {
                    headPicImg.Visible = true;
                    headPicImg.ImageUrl = modelMemberInfo.userpic;
                }
                else
                {
                    headPicImg.Visible = false;
                }
            }
            else
            {
                JsAlert.ShowAlert(PubMsg.Msg_DataInfo_Lost);
            }
            btnEdit.Text = "修改【会员登录及基本信息】";
            btnAdd.Visible = false;
        }
        else
        {
            btnEdit.Visible = false;
            btnModifyDays.Visible = false;
            btnModifyMemberLogin.Visible = false;
            btnModifyMemberInfo.Visible = false;
           
      
        
        }
      
    }


    private void CheckLoginInfoInput()
    {
        if (string.IsNullOrEmpty(txtLoginName.Text))
        {
            strError.Append("登录名不能为空!\\n");
        }
        else
        {
            if (bllLogin.ExistsUserName(userid, txtLoginName.Text.Trim()))
            {

                strError.AppendFormat("已存在用户名为[{0}]的用户!请选择别的登录名!\\n", txtLoginName.Text);

            }


        }

        if (string.IsNullOrEmpty(txtLoginEmail.Text))
        {
            strError.Append("Email不能为空!\\n");
        }


        //判断登录信息是否正确
        if (!string.IsNullOrEmpty(strError.ToString()))
        {
            JsAlert.ShowAlert(strError.ToString());
            return;
        }
    }
    private void CheckMemberInfoInput()
    {

        //检查全录信息是否完整
        #region
        strTruename = txtTruename.Text.Trim();
        strSex = ucSex.GetValue;
        strDuty = txtDuty.Text.Trim();
        strCall = txtCall.Text.Trim();
        strFax = txtFax.Text.Trim();
        strPhone = txtPhone.Text.Trim();
        strLeixing = radioListLeixing.SelectedValue;
        strCompany = txtCompany.Text.Trim();

        strCity = ucCity.GetValue;
        strAddress = txtAddress.Text.Trim();
        strZip = txtZip.Text.Trim();
        strIndustry = txtIndustry.Text.Trim();
        strDirection = radioListLeixing.SelectedValue;
        strProducts = txtProducts.Text.Trim();
        strOicq = txtOicq.Text.Trim();
        strMsn = txtMsn.Text.Trim();
        strHomepage = txtHomepage.Text.Trim();
        strSaytext =txtSaytext.Value;

        #endregion

   


        if (string.IsNullOrEmpty(strTruename))
        {
            strError.Append("真实姓名不能为空!\\n");
        }
        if (string.IsNullOrEmpty(strCall))
        {
            strError.Append("联系电话不能为空!\\n");
        }
        ///企业用户需要验证的数据
        if (string.IsNullOrEmpty(strCompany))
        {
            strError.Append("请输入你的公司名称!\\n");
        }
        if (string.IsNullOrEmpty(strAddress))
        {

            strError.Append("请输入你的联系地址!\\n");
        }

        if (string.IsNullOrEmpty(strIndustry))
        {
            strError.Append("请输入你的主营行业!\\n");
        }

        if (string.IsNullOrEmpty(strProducts))
        {
            strError.Append("请输入你的主营产品!\\n");
        }



        if (!string.IsNullOrEmpty(strError.ToString().Trim()))
        {
            JsAlert.ShowAlert(strError.ToString());
            //退出显示提示信息
        }
    }
    /// <summary>
    /// 验证输入的的登录信息认证,及企业用记及个人用户
    /// </summary>
    private void Edit()
    {
        CheckLoginInfoInput();
        CheckMemberInfoInput();
  

        StringBuilder strSuccessMsg = new StringBuilder("信息更新成功!\\n");

        phome_enewsmember modelLogin = GetUpdateLoginInfo();
        phome_enewsmemberadd modelMemberInfo = GetUpdateMemberInfo(ref strSuccessMsg);

        int intR = 0;
        if (userid > 0)
        {
            if (modelLogin != null && modelMemberInfo != null)
            {
                intR = bllMemberInfo.UpdateLoginAndMemberInfo(modelLogin, modelMemberInfo);

            }
            else
            {
                JsAlert.ShowAlert("信息丢失!");
            }
        }
        else
        {

            intR = bllMemberInfo.AddNewMember(modelLogin, modelMemberInfo);

        }


        if (intR > 0)
        {
            ShowMemberInfo();
            JsAlert.ShowAlert(strSuccessMsg.ToString());
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }
    }

    #region  得到更新的信息

    private phome_enewsmember GetUpdateLoginInfo()
    {
        phome_enewsmember modelLogin = new phome_enewsmember();

        if (userid > 0 && !IsAdd)
        {
            modelLogin = bllLogin.GetModel(userid);
        }

        modelLogin.username = txtLoginName.Text.Trim();
        modelLogin.zgroupid = Format.DataConvertToInt(drplMemberGroup.SelectedValue);
        modelLogin.groupid = Format.DataConvertToInt(listboxMemberGroup.SelectedValue);
        modelLogin.@checked = cboxChecked.Checked ? 1 : 0;
        modelLogin.email = txtLoginEmail.Text.Trim();

        #region 用户使用时间有关

        MemberUnixDateTimeTrans(modelLogin);
        #endregion

        if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
        {
            modelLogin.password = Project.Common.WebSecurity.EncryptPasswordMD5(txtPassword.Text.Trim());
        }

        return modelLogin;
    }
    private phome_enewsmemberadd GetUpdateMemberInfo(ref StringBuilder strSuccessMsg)
    {

        phome_enewsmemberadd modelMemberInfo = new phome_enewsmemberadd();


        if (GetReqIDValue > 0 && !IsAdd)
        {
            modelMemberInfo = bllMemberInfo.GetModel(GetReqIDValue);
      
        }

        modelMemberInfo.truename = strTruename;
        modelMemberInfo.oicq = strOicq;
        modelMemberInfo.msn = strMsn;
        modelMemberInfo.call = strCall;
        modelMemberInfo.phone = strPhone;
        modelMemberInfo.address = strAddress;
        modelMemberInfo.zip = strZip;
        modelMemberInfo.spacestyleid = Format.DataConvertToInt(drplSpaceStyleID.SelectedValue);
        modelMemberInfo.homepage = strHomepage;
        modelMemberInfo.saytext = strSaytext;
        modelMemberInfo.company = strCompany;
        modelMemberInfo.fax = strFax;
        modelMemberInfo.userpic = strUserpicfile;
        modelMemberInfo.sex = strSex;
        modelMemberInfo.duty = strDuty;
        modelMemberInfo.leixing = strLeixing;
        modelMemberInfo.city = strCity;
        modelMemberInfo.industry = strIndustry;
        modelMemberInfo.products = strProducts;
        modelMemberInfo.direction = strDirection;
      
      
        //上传图片
        UploadImg(modelMemberInfo, ref strSuccessMsg);


        return modelMemberInfo;
    }





    #endregion

    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="modelMemberInfo"></param>
    private void UploadImg(phome_enewsmemberadd modelMemberInfo, ref StringBuilder strSuccessMsg)
    {

        //增加成功能上传图片
        string logoPath = "";
        string headPicPath = "";
        BLLUploadManager upload = new BLLUploadManager();
        //会员头像
        if (fileHeadPic.HasFile)
        {           
            bool isUpHeadPic = upload.UploadFile(fileHeadPic, FileClass.Image,FileInfoType.MemberHeadPic);
            headPicPath = upload.FileUrlAbsolutePath;

            if (!isUpHeadPic)
            {
                strSuccessMsg.AppendFormat("上传头像时出错:{0}\\n", upload.ErrMsg);
            }
            else
            {
                modelMemberInfo.userpic = headPicPath;
            }
        }
        ///公司会员可以上传logo

        if (fileLogo.HasFile)
        {
            bool isUpLogo = upload.UploadFile(fileLogo, FileClass.Image,FileInfoType.MemberCompanyBanner);
            logoPath = upload.FileUrlAbsolutePath;
            if (!isUpLogo)
            {
                strSuccessMsg.AppendFormat("上传公司logo时出错:{0}\\n", upload.ErrMsg);

            }
            else
            {
                modelMemberInfo.gslogo = logoPath;
            }
        }




    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
      
        Edit();
    }
    /// <summary>
    /// 只修改使用天数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModifyDays_Click(object sender, EventArgs e)
    {
        phome_enewsmember modelLogin = new phome_enewsmember();

        if (userid > 0)
        {
            modelLogin = bllLogin.GetModel(userid);
        }

        #region 用户使用时间有关
        MemberUnixDateTimeTrans(modelLogin);
        #endregion

        int intR = bllLogin.Update(modelLogin);


        if (intR > 0)
        {
            ShowMemberInfo();
            JsAlert.ShowAlert("修改会员使用天数成功!");
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }


    }

    private void MemberUnixDateTimeTrans(phome_enewsmember modelLogin)
    {
        int userdate = Format.DataConvertToInt(txtUseDays.Text);
        //进行数据库操作
            //开始时间，及结束时间进行更新
            DateTime EDate = DateTime.Now.AddDays(Format.DataConvertToInt(userdate));
            userdate = Format.DataConvertToInt(Format.DateTimeToUnixTimeStamp(EDate));
            modelLogin.userdate = userdate.ToString();
            //modelLogin.SDate = DateTime.Now;
            //modelLogin.EDate = EDate;
    }
    /// <summary>
    /// 修改会员登录　基本信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModifyMemberLogin_Click(object sender, EventArgs e)
    {

        phome_enewsmember login = GetUpdateLoginInfo();
      
        int intR = bllLogin.Update(login);
       
        if (intR > 0)
        {
            ShowMemberInfo();
            JsAlert.ShowAlert("修改会员登录信息成功!");
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }
    }
    protected void btnModifyMemberInfo_Click(object sender, EventArgs e)
    {
        CheckMemberInfoInput();
        StringBuilder msg = new StringBuilder();

        phome_enewsmemberadd memberinfo = GetUpdateMemberInfo(ref msg);
        int intR = bllMemberInfo.Update(memberinfo);

        if (intR > 0)
        {
            ShowMemberInfo();
            JsAlert.ShowAlert("修改会员基本信息成功!"+msg.ToString());
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Add();
    }
    private void Add()
    {
        CheckLoginInfoInput();
        CheckMemberInfoInput();

        IsAdd = true;
        StringBuilder strSuccessMsg = new StringBuilder("会员信息增加成功!\\n");

        phome_enewsmember modelLogin = GetUpdateLoginInfo();
        phome_enewsmemberadd modelMemberInfo = GetUpdateMemberInfo(ref  strSuccessMsg);

        int intR = 0;
     
            intR = bllMemberInfo.AddNewMember(modelLogin, modelMemberInfo);

        if (intR > 0)
        {
            ShowMemberInfo();
            JsAlert.ShowAlert(strSuccessMsg.ToString());
        }
        else
        {
            JsAlert.ShowAlert(PubMsg.Msg_SubmitError);
        }
    }
}