using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;
using LL.Common;
using System.Web.UI.WebControls;
using LL.Common.EnumClass;
namespace LL.Common
{
   public  class BindControl
   {


       #region 与 枚举有关




       public static void DropDownListBindEnum(DropDownList drplTempType, Type type, bool isShowAll, EnumUtility.EnumBindControlValueType enumBindControlValueType)
       {
           DropDownListBindEnum(drplTempType, string.Empty, type, isShowAll, enumBindControlValueType);
       }
       
      /// <summary>
      /// 
      /// </summary>
      /// <param name="drpl"></param>
      /// <param name="currentvalue"></param>
      /// <param name="tenum">枚举类型</param>
      /// <param name="isShowAll">是否显示默认选择全部</param>
      /// <param name="BindType"></param>
       public static void DropDownListBindEnum( DropDownList drpl, string currentvalue, Type tenum, bool isShowAll, EnumUtility.EnumBindControlValueType BindType)
       {
              Hashtable arr = EnumUtility.GetHashtableEnum(tenum);
               
                string name="";
                string value = "";
              foreach (var key in  arr.Keys)
              {

                  name=key.ToString();
                  value=arr[key].ToString();

                 ListItem item=new ListItem(name,value);

                  if (BindType==EnumUtility.EnumBindControlValueType.只绑定枚举Name)
                  {
                      item = new ListItem(name, name);
                  }
                  drpl.Items.Add(item);
              }
              //是否显示默认全部
              if (isShowAll)
              {
                  drpl.Items.Insert(0, new ListItem("---------", ""));
              }
              //当前选项
              if (!string.IsNullOrEmpty(currentvalue))
              {
                  drpl.SelectedIndex = drpl.Items.IndexOf(drpl.Items.FindByValue(currentvalue));
              }
       }



       /// <summary>
       /// 根据radion v 返回选中项的索引
       /// </summary>
       /// <param name="radionList"></param>
       /// <param name="value"></param>
       /// <returns></returns>
       public static int RadioSelectedIndex(System.Web.UI.WebControls.RadioButtonList radionList, string value)
       {
           return radionList.Items.IndexOf(radionList.Items.FindByValue(value));

       }


       /// <summary>
       /// 根据radion v 返回选中项的索引
       /// </summary>
       /// <param name="radionList"></param>
       /// <param name="value"></param>
       /// <returns></returns>
       public static int SelectSelectedIndex(System.Web.UI.HtmlControls.HtmlSelect select, string value)
       {
           return select.Items.IndexOf(select.Items.FindByValue(value));

       }

  
       #endregion





   }
   
}
