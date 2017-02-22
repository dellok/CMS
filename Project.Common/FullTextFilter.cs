using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace Project.Common
{
   public class FullTextFilter
    {
       private const string FullTextKey = "|-|;|,|/|(|)|[|]|}|{|%|@|&|*|'|!|?|about|$|1|2|3|4|5|6|7|8|9|0|_|a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z|after|all|also|an|and|another|any|are|as|at|be|because|been|before|being|between|both|but|by|came|can|come|could|did|do|each|for|from|get|got|had|has|have|he|her|here|him|himself|his|how|if|in|into|is|it|like|make|many|me|might|more|most|much|must|my|never|now|of|on|only|or|other|our|out|over|said|same|see|should|since|some|still|such|take|than|that|the|their|them|then|there|these|they|this|those|through|to|too|under|up|very|was|way|we|well|were|what|where|which|while|who|with|would|you|your|";

       public static string Filter(string searchKey)
       {
    //       string retStr = string.Empty;

    //       s、、earchKey =Filter.ReplaceSqlChar(searchKey).Replace(" ", "，");
    //       string[] searchArr = searchKey.Split('，');

    //       string searchTemp="";

    //       for (int i = 0; i < searchArr.Length; i++)
    //       {
    //           if (!string.IsNullOrEmpty(searchArr[i]))
    //           {
    //               searchTemp += searchArr[i]+",";
    //           }
    //       }
    //       if (searchTemp.StartsWith(","))
    //       {
    //           searchTemp = searchTemp.Trim().Substring(1);
    //       }
    //       if (searchTemp.EndsWith(",")) {
    //           searchTemp = searchTemp.Substring(0, searchTemp.Trim().Length - 1);
    //       }

    //       searchArr = searchTemp.Split(',');

    //       for (int i = 0; i < searchArr.Length; i++)
    //       {
    //           if (FullTextKey.IndexOf("|" + searchArr[i] + "|") == -1)
    //           {
    //               retStr += searchArr[i] + " ";
    //           }
    //       }

    //       if (retStr.Split(' ').Length > 8)
    //       {
    //           return searchKey.Replace("，"," ");
    //       }
    
    //       return retStr;

           return "";
     }
     
    }
}
