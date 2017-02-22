using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LL.Model.Member;
namespace LL.IDAL.Member
{
    public interface Iphome_enewsmembergroup
    {









        int Add(phome_enewsmembergroup model);

        int Update(phome_enewsmembergroup model);

        int Delete(int id);

        phome_enewsmembergroup GetModel(int id);

        /// <summary>
        /// 返回全部数据
        /// </summary>
        /// <returns></returns>
        List<phome_enewsmembergroup> GetAllList();

    }
}
