using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LL.Common;
using Project.Common;
/// <summary>
///Data 
/// </summary>
public class Data
{
    public Data()
    {
        //
        //
        //

    }
    public static List<string> GetADPage()
    {

        string pageList = LL.Common.Cache.ConfigManager.GetConfigSettingsValue("ADPage");


        string[] aPages = pageList.Split(new char[] { PubConstant.Key_Sign_CommaSign });

        List<string> arrPage = new List<string>();

        foreach (string item in aPages)
        {

            arrPage.Add(item);
        }


        return arrPage;
    }
    public static List<string> PagePosition()
    {
        List<string> adposition = new List<string>();


        string pageList = LL.Common.Cache.ConfigManager.GetConfigSettingsValue("ADPagePosition");


        string[] aPagesPosition = pageList.Split(new char[] { PubConstant.Key_Sign_CommaSign });

        List<string> arrPage = new List<string>();

        foreach (string item in aPagesPosition)
        {

            adposition.Add(item);
        }
        return adposition;
    }
    /// <summary>
    /// Banner 最大上传数
    /// </summary>
    public const int VipWebSite_MaxCount_Banner = 1;
    /// <summary>
    /// 资质荣誉最大的上传数
    /// </summary>
    public const int VipWebSite_MaxCount_Certificate = 20;
    /// <summary>
    /// 相册最大上传数
    /// </summary>
    public const int VipWebSite_MaxCount_Album = 20;


    public const int MaxSmallTextLenght = 500;
    ///在member中的 group 角色
    public const int MemberGroup_AdminGroupID = 10;



   
}