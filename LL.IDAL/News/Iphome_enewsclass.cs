using System;
using System.Data;
using LL.Model.News;
namespace LL.IDAL.News
{

    public interface Iphome_enewsclass : IBase<phome_enewsclass>
	{

        int DeleteList(string classidlist);
	
        Model.News.phome_enewsclass GetModelByDataRow(DataRow dataRow);

        int DeleteAndSonNode(int id);
    } 
}
