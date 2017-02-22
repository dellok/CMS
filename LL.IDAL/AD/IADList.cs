using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using LL.Model.AD;
namespace LL.IDAL.AD
{
   public  interface IADList:IBase<ADList>
    {

        DataSet GetList(int PageIndex, int PageSize, string where);
        int BatchDel(List<int> arrIDS, int fileInfoType);
        int Delete(int ID,string  fileName);

        int BatchChecked(List<int> arrIDS, int IsChecked);

        int BatchMoveToRecycle(List<int> arrIDS, int IsRecycle);

        List<ADList> GetADList(string ADPage, string ADPagePosition, bool IsCheck, bool IsExpired);
       /// <summary>
       /// 查询所有广告，
       /// </summary>
       /// <param name="isCheck"></param>
       /// <returns></returns>
        List<ADList> GetAllADList(bool isCheck);

        int  ADHit(int intID, int hitNum);

        int ADPV(int intID, int pvNum);
    }
}
