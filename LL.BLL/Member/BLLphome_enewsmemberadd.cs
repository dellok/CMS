using System;
using System.Data;
using System.Collections.Generic;
using LL.Common;
using LL.Model.Member;
using LL.DALFactory;
using LL.IDAL.Member;
namespace LL.BLL.Member
{

	public partial class BLLphome_enewsmemberadd
	{
		private readonly Iphome_enewsmemberadd dal=DataAccess.Createphome_enewsmemberadd();
		public BLLphome_enewsmemberadd()
		{}
	  public void Add(phome_enewsmemberadd model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(phome_enewsmemberadd model)
        {
           return  dal.Update(model);
        }

        public int UpdateInfo(phome_enewsmemberadd model)
        {

            return dal.UpdateInfo(model);
        
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int userid)
        {

           return  dal.Delete(userid);
        }

   
      

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int pageIndex,int pageSize, string strWhere, string filedOrder)
        {


            return dal.GetList(pageIndex, pageSize, strWhere, filedOrder);
        
      
        }

       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<phome_enewsmemberadd> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<phome_enewsmemberadd> DataTableToList(DataTable dt)
        {
            List<phome_enewsmemberadd> modelList = new List<phome_enewsmemberadd>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                phome_enewsmemberadd model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new phome_enewsmemberadd();
                    //model.userid=dt.Rows[n]["userid"].ToString();
                    model.truename = dt.Rows[n]["truename"].ToString();
                    model.oicq = dt.Rows[n]["oicq"].ToString();
                    model.msn = dt.Rows[n]["msn"].ToString();
                    model.call = dt.Rows[n]["call"].ToString();
                    model.phone = dt.Rows[n]["phone"].ToString();
                    model.address = dt.Rows[n]["address"].ToString();
                    model.zip = dt.Rows[n]["zip"].ToString();
                    if (dt.Rows[n]["spacestyleid"].ToString() != "")
                    {
                        model.spacestyleid = int.Parse(dt.Rows[n]["spacestyleid"].ToString());
                    }
                    model.homepage = dt.Rows[n]["homepage"].ToString();
                    model.saytext = dt.Rows[n]["saytext"].ToString();
                    model.company = dt.Rows[n]["company"].ToString();
                    model.fax = dt.Rows[n]["fax"].ToString();
                    model.userpic = dt.Rows[n]["userpic"].ToString();
                    model.spacename = dt.Rows[n]["spacename"].ToString();
                    model.spacegg = dt.Rows[n]["spacegg"].ToString();
                    //model.viewstats=dt.Rows[n]["viewstats"].ToString();
                    model.sex = dt.Rows[n]["sex"].ToString();
                    model.duty = dt.Rows[n]["duty"].ToString();
                    model.leixing = dt.Rows[n]["leixing"].ToString();
                    model.city = dt.Rows[n]["city"].ToString();
                    model.industry = dt.Rows[n]["industry"].ToString();
                    model.products = dt.Rows[n]["products"].ToString();
                    model.direction = dt.Rows[n]["direction"].ToString();
                    model.yzm = dt.Rows[n]["yzm"].ToString();
                    model.gslogo = dt.Rows[n]["gslogo"].ToString();
                 
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

     

        /// <summary>
        /// 增加一个新用户
        /// 增加流程:
        /// 1.增加登录信息,
        /// 2.增加到会员信息表中
        /// </summary>
        /// <param name="modelLogin"></param>
        /// <param name="modelMemberInfo"></param>
        public  int   AddNewMember(phome_enewsmember modelLogin, phome_enewsmemberadd modelMemberInfo)
        {
           return   dal.AddNewMember(modelLogin, modelMemberInfo);
        }
        /// <summary>
        ///  更改图片路径
        /// </summary>
        /// <param name="modelMemberInfo"></param>
        public int  AddMemberPic(phome_enewsmemberadd modelMemberInfo)
        {
            int intR = 0;
            if (modelMemberInfo.userid>0)
            {
                if (!string.IsNullOrEmpty(modelMemberInfo.userpic))
                {

                  intR=  dal.UpdateMemberHeadPic(modelMemberInfo.userpic,modelMemberInfo.userid);
                }
                if (!string.IsNullOrEmpty(modelMemberInfo.gslogo))
                {

                  intR=  dal.UpdateMemberHeadPic(modelMemberInfo.userpic, modelMemberInfo.userid);
                }
            }

            return intR;
           
        }



        /// <summary>
        ///得到对像
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public phome_enewsmemberadd GetModel(int userid)
        {

         return    dal.GetModel(userid);
        }


        /// <summary>
        /// 修改空间姓名
        /// </summary>
        /// <param name="strSpaceName"></param>
        /// <param name="strSpaceNotice"></param>
        public int  UpdateSpace(string strSpaceName, string strSpaceNotice,int userid)
        {
         return  dal.UpdateSpace(strSpaceName,strSpaceNotice,userid);
            
        }

        /// <summary>
        /// 更新会员登录信息，及基本信息
        /// </summary>
        /// <param name="modelLogin"></param>
        /// <param name="modelMemberInfo"></param>
        /// <returns></returns>
        public int UpdateLoginAndMemberInfo(phome_enewsmember modelLogin, phome_enewsmemberadd modelMemberInfo)
        {
            return dal.UpdateLoginAndMemberInfo(modelLogin,modelMemberInfo);
        }

        public DataSet GetMemberLoginAndCompanyInfo(int UserID)
        {
            return dal.GetMemberLoginAndCompanyInfo(UserID);
        }

        public int  UpdateCompanyLogo(int userid, string strLogoPath)
        {
            return dal.UpdateMemberCompanyLogo(strLogoPath, userid);
        }

        /// <summary>
        /// 更新公司简介
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="companyintro"></param>
        /// <returns></returns>
        public  int UpdateCompanyIntro(int userid, string companyintro)
        {
            return dal.UpdateCompanyIntro(userid,companyintro);
        }

    
    }
}

