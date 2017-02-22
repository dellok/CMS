using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LL.Common.EnumClass
{
  public   class EnumUtility
    {



      public enum EnumBindControlValueType
      {
          /// <summary>
          /// 绑定控件
          /// enum 值为控件值，enum name 为控件text
          /// </summary>
        默认,
        只绑定枚举Name
      }

          /// <summary>
          /// 得到状态集合
          /// </summary>
          /// <returns></returns>
          public static Hashtable GetHashtableEnum(Type enumtype)
          {

              Hashtable ht = new Hashtable();
              foreach (int item in System.Enum.GetValues(enumtype))
              {
                  string name = System.Enum.GetName(enumtype, item);
                
                  ht.Add(name, item);
              }
              return ht;
          }

      







          /// <summary>
          /// 得到enum 名称
          /// </summary>
          /// <param name="enumtype"></param>
          /// <param name="value"></param>
          /// <returns></returns>
          public static string GetEnumName(Type enumtype, int value)
          {
              return System.Enum.GetName(enumtype, value);
          }
          /// <summary>
          /// 得到enum值
          /// </summary>
          /// <param name="enumtype"></param>
          /// <param name="name"></param>
          /// <returns></returns>
          public static int GetEnumValue(Type enumtype, string name)
          {
              return  Convert.ToInt32(System.Enum.Parse(enumtype, name));

          }


      }
    }

